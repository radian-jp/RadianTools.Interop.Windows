using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public record HidDeviceDetail(string FriendlyName, string Manufacturer, string ProductName)
{
    public static HidDeviceDetail Empty { get; } = new HidDeviceDetail("", "", "");
}

public static class HidHelper
{
    public static HidDeviceDetail GetDeviceDetail(IntPtr hDevice)
    {
        var devicePath = GetDevicePath(hDevice);
        if (string.IsNullOrEmpty(devicePath))
            return HidDeviceDetail.Empty;

        var productName = "";
        var fh = Kernel32.CreateFile(devicePath, 0, FILE_SHARE.FILE_SHARE_READ, IntPtr.Zero, FILE_DISPOSITION.OPEN_EXISTING, 0, IntPtr.Zero);
        if (!fh.IsInvalid)
        {
            try
            {
                unsafe
                {
                    const int MAX_PRODUCT_NAME = 4092;
                    var pProductName = stackalloc char[MAX_PRODUCT_NAME / sizeof(char)];
                    if (Hid.HidD_GetProductString(fh, (IntPtr)pProductName, MAX_PRODUCT_NAME) != 0)
                        productName = new string(pProductName);
                }
            }
            finally
            {
                Kernel32.CloseHandle(fh);
            }
        }

        var friendlyName = "";
        var manufacturer = "";
        var deviceGuid = GetDeviceGuid(devicePath);
        if (deviceGuid.HasValue)
        {
            var deviceGuidVal = deviceGuid.Value;
            var deviceInstanceId = GetDeviceInstanceId(ref deviceGuidVal);
            if (!string.IsNullOrEmpty(deviceInstanceId))
            {
                const int CM_LOCATE_DEVNODE_NORMAL = 0x00000000;
                var cr = Cfgmgr32.CM_Locate_DevNode(out var devInst, deviceInstanceId, CM_LOCATE_DEVNODE_NORMAL);
                if (cr == CONFIGRET.CR_SUCCESS)
                {
                    friendlyName = GetDevNodeProperty(devInst, in DEVPKEY.NAME);
                    manufacturer = GetDevNodeProperty(devInst, in DEVPKEY.Device_Manufacturer);
                }
            }
        }

        return new HidDeviceDetail(friendlyName, manufacturer, productName);
    }

    private static string GetDevicePath(IntPtr hDevice)
    {
        int devicePathSize = 0;
        User32.GetRawInputDeviceInfo(hDevice, RIDI.DEVICENAME, IntPtr.Zero, ref devicePathSize);
        if (devicePathSize == 0)
            return "";

        unsafe
        {
            // MSのドキュメントでは、GetRawInputDeviceInfoW は文字のバイト数を返すとあるが、
            // 実装は文字数が返ってくるので deviceNameSize そのまま使用でOK
            var pDevPath = stackalloc char[devicePathSize];
            User32.GetRawInputDeviceInfo(hDevice, RIDI.DEVICENAME, (IntPtr)pDevPath, ref devicePathSize);
            var devicePath = new string(pDevPath).TrimEnd('\0');
            return devicePath;
        }
    }

    public static Guid? GetDeviceGuid(string devicePath)
    {
        int guidStart = devicePath.IndexOf('{');
        if (guidStart < 0)
            return null;

        int guidEnd = devicePath.IndexOf('}', guidStart);
        if (guidEnd < 0) 
            return null;

        string strGuid = devicePath.Substring(guidStart, guidEnd - guidStart + 1);
        if (!Guid.TryParse(strGuid, out var guid))
            return null;

        return guid;
    }

    private static string GetDeviceInstanceId(ref Guid hidGuid)
    {
        IntPtr deviceInfoSet = SetupApi.SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
        if (deviceInfoSet == IntPtr.Zero)
            return "";

        try
        {
            SP_DEVICE_INTERFACE_DATA interfaceData = new SP_DEVICE_INTERFACE_DATA 
            { 
                cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA))
            };
            SP_DEVINFO_DATA devInfoData = new SP_DEVINFO_DATA 
            { 
                cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA)) 
            };

            if (!SetupApi.SetupDiEnumDeviceInterfaces(deviceInfoSet, IntPtr.Zero, ref hidGuid, 0, ref interfaceData))
                return "";

            SetupApi.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref interfaceData, IntPtr.Zero, 0, out var requiredSize, ref devInfoData);

            SetupApi.SetupDiGetDeviceInstanceId(deviceInfoSet, ref devInfoData, IntPtr.Zero, 0, out requiredSize);

            Span<char> bufInstanceId = stackalloc char[(int)requiredSize]; 
            SetupApi.SetupDiGetDeviceInstanceId(deviceInfoSet, ref devInfoData, ref bufInstanceId[0], requiredSize, out requiredSize);

            return new string(bufInstanceId).TrimEnd('\0');
        }
        finally
        {
            SetupApi.SetupDiDestroyDeviceInfoList(deviceInfoSet);
        }
    }

    private static string GetDeviceInterfaceProperty(string deviceInterfaceName, in DEVPROPKEY devPropKey)
    {
        var cr = Cfgmgr32.CM_Get_Device_Interface_Property(deviceInterfaceName, in devPropKey, out var propertyType, IntPtr.Zero, out var propertySize, 0);
        if (cr != CONFIGRET.CR_BUFFER_SMALL)
            return "";

        Span<char> bufProp = stackalloc char[(int)propertySize / sizeof(char)];
        cr = Cfgmgr32.CM_Get_Device_Interface_Property(deviceInterfaceName, in devPropKey, out propertyType, ref bufProp[0], out propertySize, 0);
        if (cr != CONFIGRET.CR_SUCCESS)
            return "";

        string prop = new string(bufProp).TrimEnd('\0');
        return prop;
    }

    private static string GetDevNodeProperty(DEVINST devInst, in DEVPROPKEY devPropKey)
    {
        var cr = Cfgmgr32.CM_Get_DevNode_Property(devInst, in devPropKey, out var propertyType, IntPtr.Zero, out var propertySize, 0);
        if (cr != CONFIGRET.CR_BUFFER_SMALL)
            return "";

        Span<char> bufProp = stackalloc char[(int)propertySize / sizeof(char)];
        cr = Cfgmgr32.CM_Get_DevNode_Property(devInst, in devPropKey, out propertyType, ref bufProp[0], out propertySize, 0);
        if (cr != CONFIGRET.CR_SUCCESS)
            return "";

        string prop = new string(bufProp).TrimEnd('\0');
        return prop;
    }
}
using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public static class Hid
{
    [DllImport("hid.dll")]
    public static extern int HidD_GetProductString(
        IntPtr HidDeviceObject,
        IntPtr Buffer,
        int BufferLength
    );

}

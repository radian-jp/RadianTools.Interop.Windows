using RadianTools.Generators.UnmanagedStructGenerator;
using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

[StructLayout(LayoutKind.Sequential)]
public struct HRESULT
{
    private int _value;
    int Value => _value;

    public bool Succeeded => this.Value >= 0;
    public bool Failed => this.Value < 0;
    public bool IsOK => this.Value == 0;
    public bool IsNotOK => this.Value != 0;

    public HRESULT ThrowOnFailure(IntPtr errorInfo = default)
    {
        Marshal.ThrowExceptionForHR(this.Value, errorInfo);
        return this;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct BOOL : IEquatable<BOOL>
{
    int _intValue;
    public BOOL(bool value) => _intValue = value ? 1 : 0;
    public BOOL(int value) => _intValue = value > 0 ? 1 : 0;

    public bool Equals(BOOL other) => _intValue == other._intValue;

    public static implicit operator bool(BOOL value) => value._intValue > 0;
}

[StructLayout(LayoutKind.Sequential)]
public struct COLORREF
{
    public uint Value;
}

[StructLayout(LayoutKind.Sequential)]
public struct DEVPROPKEY
{
    public Guid fmtid;
    public uint pid;
}

/// <summary>
/// 定義済みデバイスプロパティキー
/// </summary>
public static class DEVPKEY
{
    public static readonly DEVPROPKEY Device_InstanceId = new DEVPROPKEY
    {
        fmtid = new Guid("78A7C492-0E3B-4EFB-B00B-DCB9D3C5E9B0"),
        pid = 256
    };

    public static readonly DEVPROPKEY NAME = new DEVPROPKEY
    {
        fmtid = new Guid("B725F130-47EF-101A-A5F1-02608C9EEBAC"),
        pid = 10
    };

    public static readonly DEVPROPKEY Device_Manufacturer = new DEVPROPKEY
    {
        fmtid = new Guid("A45C254E-DF1C-4EFD-8020-67D146A850E0"),
        pid = 13
    };
}

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int left;
    public int top;
    public int right;
    public int bottom;
}

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int x;
    public int y;
}

[StructLayout(LayoutKind.Sequential)]
public struct IMAGEINFO
{
    public HBITMAP hbmImage;
    public HBITMAP hbmMask;
    public int Unused1;
    public int Unused2;
    public RECT rcImage;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct SHFILEINFOW
{
    public HICON hIcon;
    public int iIcon;
    public uint dwAttributes;
    public CHARS_MAX_PATH szDisplayName;
    public CHARS_80 szTypeName;
}

[StructLayout(LayoutKind.Sequential)]
public struct KNOWNFOLDER_DEFINITION
{
    public KF_CATEGORY category;
    public IntPtr pszName;
    public IntPtr pszDescription;
    public Guid fidParent;
    public IntPtr pszRelativePath;
    public IntPtr pszParsingName;
    public IntPtr pszTooltip;
    public IntPtr pszLocalizedName;
    public IntPtr pszIcon;
    public IntPtr pszSecurity;
    public uint dwAttributes;
    public uint kfdFlags;
    public Guid ftidType;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SHITEMID
{
    public ushort cb;
    public byte abID;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ITEMIDLIST
{
    public SHITEMID mkid;
}

[StructLayout(LayoutKind.Sequential)]
public struct SP_DEVICE_INTERFACE_DATA
{
    public uint cbSize;
    public Guid InterfaceClassGuid;
    public uint Flags;
    public IntPtr Reserved;
}

[StructLayout(LayoutKind.Sequential)]
public struct SP_DEVINFO_DATA
{
    public uint cbSize;
    public Guid ClassGuid;
    public uint DevInst;
    public IntPtr Reserved;
}

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public struct STRRET
{
    [FieldOffset(0)] public uint uType;
    [FieldOffset(4)] public IntPtr pOleStr;
    [FieldOffset(4)] public uint uOffset;
    [FieldOffset(4)] public CHARS_MAX_PATH cStr;
}

[StructLayout(LayoutKind.Sequential)]
public struct IMAGELISTDRAWPARAMS
{
    public uint cbSize;
    public HIMAGELIST himl;
    public int i;
    public HDC hdcDst;
    public int x;
    public int y;
    public int cx;
    public int cy;
    public int xBitmap;
    public int yBitmap;
    public COLORREF rgbBk;
    public COLORREF rgbFg;
    public uint fStyle;
    public uint dwRop;
    public uint fState;
    public uint Frame;
    public COLORREF crEffect;
}

public struct ICONINFO
{
    public BOOL fIcon;
    public uint xHotspot;
    public uint yHotspot;
    public HBITMAP hbmMask;
    public HBITMAP hbmColor;
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct BITMAP
{
    public int bmType;
    public int bmWidth;
    public int bmHeight;
    public int bmWidthBytes;
    public ushort bmPlanes;
    public ushort bmBitsPixel;
    public IntPtr bmBits;
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct BITMAPINFOHEADER
{
    public uint biSize;
    public int biWidth;
    public int biHeight;
    public ushort biPlanes;
    public ushort biBitCount;
    public uint biCompression;
    public uint biSizeImage;
    public int biXPelsPerMeter;
    public int biYPelsPerMeter;
    public uint biClrUsed;
    public uint biClrImportant;
}


[StructLayout(LayoutKind.Sequential)]
public struct RAWINPUTHEADER
{
    public RIM_TYPE Type;
    public int Size;
    public IntPtr DeviceHandle;
    public IntPtr WParam;
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public record struct RAWMOUSE
{
    public short Flags;
    private short _padding;
    public short ButtonFlags;
    public short ButtonData;
    public int RawButtons;
    public int LastX;
    public int LastY;
    public int ExtraInformation;
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public record struct RAWKEYBOARD
{
    public short MakeCode;
    public short Flags;
    public short Reserved;
    public VKey VKey;
    public WindowMessage Message;
    public int ExtraInformation;
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct RAWINPUT
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DEVICEDATA
    {
        [FieldOffset(0)]
        public RAWMOUSE mouse;
        [FieldOffset(0)]
        public RAWKEYBOARD keyboard;
    }

    public RAWINPUTHEADER header;
    public DEVICEDATA data;
}

public struct RAWINPUTDEVICE
{
    public short UsagePage;
    public short Usage;
    public RIDEV Flags;
    public HWND HWndTarget;

    public RAWINPUTDEVICE(RIM_TYPE deviceType, HWND hWndTarget, bool remove)
    {
        switch (deviceType)
        {
            case RIM_TYPE.RIM_TYPEMOUSE:
                UsagePage = 1;
                Usage = 2;
                break;

            case RIM_TYPE.RIM_TYPEKEYBOARD:
                UsagePage = 1;
                Usage = 6;
                break;

            default:
                throw new ArgumentException($"RIM_TYPE {deviceType:D} is not supported.");
        }

        if (remove)
        {
            Flags = RIDEV.RIDEV_REMOVE;
            HWndTarget = HWND.Null;
        }
        else
        {
            Flags = RIDEV.RIDEV_INPUTSINK | RIDEV.RIDEV_NOLEGACY;
            HWndTarget = hWndTarget;
        }
    }
}


[StructLayout(LayoutKind.Sequential)]
public struct CREATESTRUCT
{
    public IntPtr lpCreateParams;
    public IntPtr hInstance;
    public IntPtr hMenu;
    public IntPtr hwndParent;
    public int cy;
    public int cx;
    public int y;
    public int x;
    public int style;
    public IntPtr lpszName;
    public IntPtr lpszClass;
    public int dwExStyle;
}

public delegate IntPtr DelegateWndProc(HWND hwnd, WindowMessage msg, IntPtr wParam, IntPtr lParam);

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WNDCLASSEX
{
    public uint cbSize;
    public uint style;
    public DelegateWndProc lpfnWndProc;
    public int cbClsExtra;
    public int cbWndExtra;
    public IntPtr hInstance;
    public IntPtr hIcon;
    public IntPtr hCursor;
    public IntPtr hbrBackground;
    public IntPtr lpszMenuName;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string lpszClassName;
    public IntPtr hIconSm;
}

[StructLayout(LayoutKind.Sequential)]
public struct MSG
{
    public IntPtr hwnd;
    public uint message;
    public IntPtr wParam;
    public IntPtr lParam;
    public uint time;
    public int pt_x;
    public int pt_y;
}

#region UnmanagedStructGenerator

[FixedChars(FileSystem.MAX_PATH)]
public partial struct CHARS_MAX_PATH
{
}

[FixedChars(80)]
public partial struct CHARS_80
{
}

[NativeHandle]
public partial struct DEVINST
{
}

[NativeHandle]
public partial struct HBITMAP
{
}

[NativeHandle]
public partial struct HWND
{
}

[NativeHandle]
public partial struct HANDLE
{
    public bool IsInvalid => _value == -1;
}

[NativeHandle]
public partial struct HDC
{
}

[NativeHandle]
public partial struct HIMAGELIST
{
}

[NativeHandle]
public partial struct HICON : IDisposable
{
    public void Dispose()
    {
        var value = Interlocked.Exchange(ref this._value, IntPtr.Zero);
        if (value != IntPtr.Zero)
            User32.DestroyIcon(value);
    }
}

[NativeHandle]
public partial struct HRAWINPUT
{
}

[NativeHandle(typeof(ITEMIDLIST*))]
public partial struct PIDL
{
}

#endregion
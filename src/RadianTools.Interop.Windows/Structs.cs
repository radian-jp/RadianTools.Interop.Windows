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

[NativeHandle(typeof(ITEMIDLIST*))]
public partial struct PIDL
{
}

#endregion
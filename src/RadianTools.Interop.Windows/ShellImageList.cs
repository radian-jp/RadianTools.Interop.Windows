using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public class ShellImageList
{
    public delegate object Converter(int width, int height, int stride, nint src);

    private readonly Dictionary<int, object> _cache = new();

    private IImageList ImageList { get; }
    public nint Pointer { get; }

    private Converter _converter;

    public ShellImageList(SHIL shil, Converter converter)
    {
        ImageList = GetSysImageList((uint)shil);
        _converter = converter;
    }

    public HICON GetHIcon(int iconIndex)
    {
        if (ImageList.GetIcon(iconIndex, 0, out var hIcon).IsNotOK)
            throw new Win32Exception($"IImageList.GetIcon failed.");

        return hIcon;
    }

    public object GetIcon(int iconIndex)
    {
        if (_cache.TryGetValue(iconIndex, out var image))
            return image;

        if (ImageList.GetIcon(iconIndex, 0, out var hIcon).IsNotOK)
            throw new Win32Exception($"IImageList.GetIcon failed.");

        if( !User32.GetIconInfo(hIcon, out var iconInfo) )
            throw new Win32Exception($"GetIconInfo failed.");

        var hdc = User32.GetDC(HWND.Null);
        try
        {
            BITMAPINFOHEADER bmh = new BITMAPINFOHEADER();
            bmh.biSize = (uint)Marshal.SizeOf<BITMAPINFOHEADER>();
            var result = Gdi32.GetDIBits(hdc, iconInfo.hbmColor, 0, 0, IntPtr.Zero, ref bmh, DIB_COLORS.DIB_RGB_COLORS);

            if ( bmh.biHeight>0 )
            {
                bmh.biHeight = -bmh.biHeight; // 上下反転
            }
            int width = bmh.biWidth;
            int height = -bmh.biHeight;

            var pixels = ArrayPool<byte>.Shared.Rent(width * height * 4);
            try
            {
                Gdi32.GetDIBits(hdc, iconInfo.hbmColor, 0, (uint)height, pixels, ref bmh, DIB_COLORS.DIB_RGB_COLORS);
                unsafe
                {

                    fixed(void* pImage = &pixels[0])
                    {
                        var icon = _converter(width, height, width * 4, (IntPtr)pImage);
                        _cache[iconIndex] = icon;
                        return icon;
                    }
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(pixels);
            }
        }
        finally
        {
            User32.ReleaseDC(HWND.Null, hdc);
            Gdi32.DeleteObject(iconInfo.hbmColor);
            Gdi32.DeleteObject(iconInfo.hbmMask);
        }
    }

    private static IImageList GetSysImageList(uint shil)
    {
        var iid = typeof(IImageList).GUID;
        Shell32.SHGetImageList((int)shil, in iid, out var oImageList).ThrowOnFailure();
        return (IImageList)oImageList;
    }
}
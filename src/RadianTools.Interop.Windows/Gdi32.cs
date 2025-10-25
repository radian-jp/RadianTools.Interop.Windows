using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public class Gdi32
{
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetDIBits(HDC hdc, HBITMAP hbmp, uint uStartScan, uint cScanLines, byte[] lpvBits, ref BITMAPINFOHEADER lpbi, DIB_COLORS uUsage);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetDIBits(HDC hdc, HBITMAP hbmp, uint uStartScan, uint cScanLines, IntPtr lpvBits, ref BITMAPINFOHEADER lpbi, DIB_COLORS uUsage);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetObject(HBITMAP hbm, int c, [Out]out BITMAP bm);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern BOOL DeleteObject(HBITMAP hbm);
}

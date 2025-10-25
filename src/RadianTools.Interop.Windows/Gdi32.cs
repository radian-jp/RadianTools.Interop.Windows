using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public class Gdi32
{
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetDIBits(HDC hdc, HBITMAP hbmp, uint uStartScan, uint cScanLines, byte[] lpvBits, in BITMAPINFOHEADER lpbi, DIB_COLORS uUsage);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetObject(HBITMAP hbm, int c, out BITMAP bm);
}

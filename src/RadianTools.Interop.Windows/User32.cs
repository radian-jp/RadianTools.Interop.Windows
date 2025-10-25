using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public class User32
{
    [DllImport("user32.dll", SetLastError=true)]
    public static extern BOOL DestroyIcon(IntPtr hIcon);

    [DllImport("user32.dll", SetLastError=true)]
    public static extern BOOL GetIconInfo(HICON hIcon, out ICONINFO piconinfo);

    [DllImport("user32.dll", SetLastError=true)]
    public static extern HDC GetDC(HWND hWnd);

    [DllImport("user32.dll", SetLastError=true)]
    public static extern int ReleaseDC(HWND hWnd, HDC hDC);
}

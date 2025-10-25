using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public static class Shell32
{
    [DllImport("SHELL32.dll", SetLastError=true)]
    public static extern uint ILGetSize(PIDL pidl);

    [DllImport("SHELL32.dll", SetLastError=true)]
    public static extern BOOL ILIsEqual(PIDL pidl1, PIDL pidl2);

    [DllImport("SHELL32.dll", SetLastError=true)]
    public static extern PIDL ILCombine(PIDL pidl1, PIDL pidl2);

    [DllImport("SHELL32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern PIDL ILCreateFromPath(string pszPath);

    [DllImport("SHELL32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr SHGetFileInfo(string pszPath, FILE_FLAGS_AND_ATTRIBUTES dwFileAttributes, ref SHFILEINFOW psfi, uint cbFileInfo, SHGFI_FLAGS uFlags);

    [DllImport("SHELL32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr SHGetFileInfo(PIDL pidl, FILE_FLAGS_AND_ATTRIBUTES dwFileAttributes, ref SHFILEINFOW psfi, uint cbFileInfo, SHGFI_FLAGS uFlags);

    [DllImport("SHELL32.dll", SetLastError=true)]
    public static extern HRESULT SHBindToObject(IntPtr psf, PIDL pidl, IntPtr pbc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

    [DllImport("SHELL32.dll", SetLastError=true)]
    public static extern HRESULT SHGetImageList(int iImageList, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

    [DllImport("SHELL32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetPathFromIDListEx", SetLastError=true)]
    public static extern BOOL SHGetPathFromIDListEx(PIDL pidl, out CHARS_MAX_PATH pszPath, uint cchPath, GPFIDL_FLAGS uOpts);

    [DllImport("SHELL32.dll", SetLastError=true)]
    public static extern HRESULT SHGetKnownFolderIDList(in Guid rfid, uint dwFlags, HANDLE hToken, out PIDL ppidl);
}
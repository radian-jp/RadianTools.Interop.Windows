#define COMSTRUCT_ENABLED

using RadianTools.Interop.Windows.ComStructures;
using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public static partial class Shell32
{
    [LibraryImport("shell32.dll", SetLastError = true)]
    public static partial uint ILGetSize(PIDL pidl);

    [LibraryImport("shell32.dll", SetLastError = true)]
    public static partial BOOL ILIsEqual(PIDL pidl1, PIDL pidl2);

    [LibraryImport("shell32.dll", SetLastError = true)]
    public static partial PIDL ILCombine(PIDL pidl1, PIDL pidl2);

    [LibraryImport("shell32.dll", EntryPoint = "ILCreateFromPathW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial PIDL ILCreateFromPath(string pszPath);

    [LibraryImport("shell32.dll", EntryPoint = "SHGetFileInfoW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial IntPtr SHGetFileInfo(string pszPath, FILE_FLAGS_AND_ATTRIBUTES dwFileAttributes, ref SHFILEINFOW psfi, uint cbFileInfo, SHGFI_FLAGS uFlags);

    [LibraryImport("shell32.dll", EntryPoint = "SHGetFileInfoW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial IntPtr SHGetFileInfo(PIDL pidl, FILE_FLAGS_AND_ATTRIBUTES dwFileAttributes, ref SHFILEINFOW psfi, uint cbFileInfo, SHGFI_FLAGS uFlags);

#if COMSTRUCT_ENABLED
    [LibraryImport("shell32.dll", SetLastError = true, EntryPoint = "SHBindToObject")]
    public static unsafe partial HRESULT SHBindToObject(
        nint psf,
        PIDL pidl,
        nint pbc,
        in Guid riid,
        void** ppv);

    [LibraryImport("shell32.dll", SetLastError = true, EntryPoint = "SHGetImageList")]
    public static unsafe partial HRESULT SHGetImageList(
        int iImageList,
        in Guid riid,
        IImageList** ppvObj);
#else
    [DllImport("SHELL32.dll", SetLastError = true)]
    public static extern HRESULT SHBindToObject(IntPtr psf, PIDL pidl, IntPtr pbc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

    [DllImport("SHELL32.dll", SetLastError = true)]
    public static extern HRESULT SHGetImageList(int iImageList, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);
#endif


    [LibraryImport("shell32.dll", SetLastError = true)]
    public static partial BOOL SHGetPathFromIDListEx(PIDL pidl, out CHARS_MAX_PATH pszPath, uint cchPath, GPFIDL_FLAGS uOpts);

    [LibraryImport("shell32.dll", SetLastError = true)]
    public static partial HRESULT SHGetKnownFolderIDList(in Guid rfid, uint dwFlags, HANDLE hToken, out PIDL ppidl);

    [LibraryImport("shell32.dll", SetLastError = true)]
    public static partial HRESULT SHGetNameFromIDList(
        PIDL pidl,
        SIGDN sigdnName,
        out IntPtr ppszName);
}
using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

[Guid("4DF0C730-DF9D-4AE3-9153-AA6B82E9795A"), ComImport()]
public partial class KnownFolderManager
{
}

[Guid("8BE2D872-86AA-4D47-B776-32CCA40C7018"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
public interface IKnownFolderManager
{
    void FolderIdFromCsidl(int nCsidl, out Guid pfid);
    void FolderIdToCsidl(in Guid rfid, out int pnCsidl);
    [PreserveSig()] HRESULT GetFolderIds(out IntPtr ppKFId, out uint pCount);
    void GetFolder(in Guid rfid, out IKnownFolder ppkf);
    void GetFolderByName([MarshalAs(UnmanagedType.LPWStr)] string pszCanonicalName, out IKnownFolder ppkf);
    void RegisterFolder(in Guid rfid, in KNOWNFOLDER_DEFINITION pKFD);
    void UnregisterFolder(in Guid rfid);
    void FindFolderFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath, FFFP_MODE mode, out IKnownFolder ppkf);
    [PreserveSig()] HRESULT FindFolderFromIDList(PIDL pidl, out IKnownFolder ppkf);
    void Redirect(in Guid rfid, HWND hwnd, uint flags, [MarshalAs(UnmanagedType.LPWStr)] string pszTargetPath, uint cFolders, [Optional] IntPtr pExclusion, [Optional] IntPtr ppszError);
}

public static class IKnownFolderManagerExtentions
{
    public static Guid[] GetFolderIdsSafe(this IKnownFolderManager mgr)
    {
        if (mgr.GetFolderIds(out var pGuids, out var count).IsNotOK)
            return Array.Empty<Guid>();

        using var coArray = new CoTaskMemArray<Guid>(pGuids, (int)count);
        return coArray.ToArray();
    }
}

[Guid("000214F2-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
public interface IEnumIDList
{
    [PreserveSig()] HRESULT Next(uint celt, out PIDL rgelt, [Optional] IntPtr pceltFetched);
    [PreserveSig()] HRESULT Skip(uint celt);
    [PreserveSig()] HRESULT Reset();
    [PreserveSig()] HRESULT Clone(out IEnumIDList ppenum);
}

[Guid("3AA7AF7E-9B36-420C-A8E3-F77D4674A488"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
public interface IKnownFolder
{
    void GetId(out Guid pkfid);
    void GetCategory(out KF_CATEGORY pCategory);
    void GetShellItem(uint dwFlags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
    void GetPath(uint dwFlags, out CHARS_MAX_PATH ppszPath);
    void SetPath(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszPath);
    void GetIDList(uint dwFlags, out PIDL ppidl);
    void GetFolderType(out Guid pftid);
    void GetRedirectionCapabilities(out uint pCapabilities);
    void GetFolderDefinition(out KNOWNFOLDER_DEFINITION pKFD);
}

[Guid("0000000E-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
public interface IBindCtx
{
    void RegisterObjectBound([MarshalAs(UnmanagedType.IUnknown)] object punk);
    void RevokeObjectBound([MarshalAs(UnmanagedType.IUnknown)] object punk);
    void ReleaseBoundObjects();
    void SetBindOptions(IntPtr pbindopts);
    void GetBindOptions(IntPtr pbindopts);
    void GetRunningObjectTable([MarshalAs(UnmanagedType.IUnknown)] out object pprot);
    void RegisterObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.IUnknown)] object punk);
    void GetObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
    void EnumObjectParam(out IEnumString ppenum);
    void RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey);
}

[Guid("00000101-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
public interface IEnumString
{
    [PreserveSig()] HRESULT Next(uint celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0), Out] string[] rgelt, [Optional] out uint pceltFetched);
    [PreserveSig()] HRESULT Skip(uint celt);
    void Reset();
    void Clone(out IEnumString ppenum);
}

[Guid("000214E6-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
public interface IShellFolder
{
    void ParseDisplayName(HWND hwnd, IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, [Optional] out uint pchEaten, out PIDL ppidl, ref uint pdwAttributes);
    [PreserveSig()] HRESULT EnumObjects(HWND hwnd, uint grfFlags, out IEnumIDList ppenumIDList);
    void BindToObject(PIDL pidl, IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
    void BindToStorage(PIDL pidl, IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
    [PreserveSig()] HRESULT CompareIDs(IntPtr lParam, PIDL pidl1, PIDL pidl2);
    void CreateViewObject(HWND hwndOwner, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
    void GetAttributesOf(uint cidl, in PIDL apidl, ref uint rgfInOut);
    void GetUIObjectOf(HWND hwndOwner, uint cidl, out PIDL apidl, in Guid riid, [Optional] out uint rgfReserved, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
    void GetDisplayNameOf(PIDL pidl, SHGDNF uFlags, out STRRET pName);
    void SetNameOf(HWND hwnd, PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, [Optional] out PIDL ppidlOut);
}

[ComImport]
[Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IImageList
{
    [PreserveSig] HRESULT Add(HBITMAP hbmImage, HBITMAP hbmMask, out int pi);
    [PreserveSig] HRESULT ReplaceIcon(int i, HICON hicon, out int pi);
    [PreserveSig] HRESULT SetOverlayImage(int iImage, int iOverlay);
    [PreserveSig] HRESULT Replace(int i, HBITMAP hbmImage, HBITMAP hbmMask);
    [PreserveSig] HRESULT AddMasked(HBITMAP hbmImage, COLORREF crMask, out int pi);
    [PreserveSig] HRESULT Draw(ref IMAGELISTDRAWPARAMS pimldp);
    [PreserveSig] HRESULT Remove(int i);
    [PreserveSig] HRESULT GetIcon(int i, uint flags, out HICON picon);
    [PreserveSig] HRESULT GetImageInfo(int i, out IMAGEINFO pImageInfo);
    [PreserveSig] HRESULT Copy(int iDst, [MarshalAs(UnmanagedType.IUnknown)] object punkSrc, int iSrc, uint uFlags);
    [PreserveSig] HRESULT Merge(int i1, [MarshalAs(UnmanagedType.IUnknown)] object punk2, int i2, int dx, int dy, ref Guid riid, out nint ppv);
    [PreserveSig] HRESULT Clone(ref Guid riid, out nint ppv);
    [PreserveSig] HRESULT GetImageRect(int i, out RECT prc);
    [PreserveSig] HRESULT GetIconSize(out int cx, out int cy);
    [PreserveSig] HRESULT SetIconSize(int cx, int cy);
    [PreserveSig] HRESULT GetImageCount(out int pi);
    [PreserveSig] HRESULT SetImageCount(uint uNewCount);
    [PreserveSig] HRESULT SetBkColor(COLORREF clrBk, out COLORREF pclr);
    [PreserveSig] HRESULT GetBkColor(out COLORREF pclr);
    [PreserveSig] HRESULT BeginDrag(int iTrack, int dxHotspot, int dyHotspot);
    [PreserveSig] HRESULT EndDrag();
    [PreserveSig] HRESULT DragEnter(HWND hwndLock, int x, int y);
    [PreserveSig] HRESULT DragLeave(HWND hwndLock);
    [PreserveSig] HRESULT DragMove(int x, int y);
    [PreserveSig] HRESULT SetDragCursorImage([MarshalAs(UnmanagedType.IUnknown)] object punk, int iDrag, int dxHotspot, int dyHotspot);
    [PreserveSig] HRESULT DragShowNolock(BOOL fShow);
    [PreserveSig] HRESULT GetDragImage(out POINT ppt, out POINT pptHotspot, ref Guid riid, out nint ppv);
    [PreserveSig] HRESULT GetItemFlags(int i, out uint dwFlags);
    [PreserveSig] HRESULT GetOverlayImage(int iOverlay, out int piIndex);
}

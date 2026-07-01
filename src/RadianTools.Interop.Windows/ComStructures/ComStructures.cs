namespace RadianTools.Interop.Windows.ComStructures;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class CLSID
{
    public static Guid CLSID_KnownFolderManager = new("4DF0C730-DF9D-4AE3-9153-AA6B82E9795A");
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IKnownFolderManager : IComObj<IKnownFolderManager>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new("8BE2D872-86AA-4D47-B776-32CCA40C7018");

    // IUnknown
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])
            (ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])
            (ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])
            (ThisPtr);

    // IKnownFolderManager
    public void FolderIdFromCsidl(
        int nCsidl,
        Guid* pfid)
        => ((delegate* unmanaged[Stdcall]
            <void*, int, Guid*, void>)_pVTable[3])
            (ThisPtr, nCsidl, pfid);

    public void FolderIdToCsidl(
        Guid* rfid,
        int* pnCsidl)
        => ((delegate* unmanaged[Stdcall]
            <void*, Guid*, int*, void>)_pVTable[4])
            (ThisPtr, rfid, pnCsidl);

    public HRESULT GetFolderIds(
        void** ppKFId,
        uint* pCount)
        => ((delegate* unmanaged[Stdcall]
            <void*, void**, uint*, HRESULT>)_pVTable[5])
            (ThisPtr, ppKFId, pCount);

    public void GetFolder(
        Guid* rfid,
        IKnownFolder** ppkf)
        => ((delegate* unmanaged[Stdcall]
            <void*, Guid*, IKnownFolder**, void>)_pVTable[6])
            (ThisPtr, rfid, ppkf);

    public void GetFolderByName(
        char* pszCanonicalName,
        IKnownFolder** ppkf)
        => ((delegate* unmanaged[Stdcall]
            <void*, char*, IKnownFolder**, void>)_pVTable[7])
            (ThisPtr, pszCanonicalName, ppkf);

    public void RegisterFolder(
        Guid* rfid,
        KNOWNFOLDER_DEFINITION* pKFD)
        => ((delegate* unmanaged[Stdcall]
            <void*, Guid*, KNOWNFOLDER_DEFINITION*, void>)_pVTable[8])
            (ThisPtr, rfid, pKFD);

    public void UnregisterFolder(
        Guid* rfid)
        => ((delegate* unmanaged[Stdcall]
            <void*, Guid*, void>)_pVTable[9])
            (ThisPtr, rfid);

    public void FindFolderFromPath(
        char* pszPath,
        FFFP_MODE mode,
        IKnownFolder** ppkf)
        => ((delegate* unmanaged[Stdcall]
            <void*, char*, FFFP_MODE, IKnownFolder**, void>)_pVTable[10])
            (ThisPtr, pszPath, mode, ppkf);

    public HRESULT FindFolderFromIDList(
        PIDL pidl,
        IKnownFolder** ppkf)
        => ((delegate* unmanaged[Stdcall]
            <void*, PIDL, IKnownFolder**, HRESULT>)_pVTable[11])
            (ThisPtr, pidl, ppkf);

    public void Redirect(
        Guid* rfid,
        HWND hwnd,
        uint flags,
        char* pszTargetPath,
        uint cFolders,
        void* pExclusion,
        void* ppszError)
        => ((delegate* unmanaged[Stdcall]
            <void*, Guid*, HWND, uint, char*, uint, void*, void*, void>)_pVTable[12])
            (ThisPtr, rfid, hwnd, flags, pszTargetPath, cFolders, pExclusion, ppszError);
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public unsafe struct IUnknown : IComObj<IUnknown>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new Guid("00000000-0000-0000-C000-000000000046");

    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])(ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])(ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])(ThisPtr);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IEnumString : IComObj<IEnumString>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new("00000101-0000-0000-C000-000000000046");

    // IUnknown
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])
            (ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])
            (ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])
            (ThisPtr);

    // IEnumString
    public HRESULT Next(
        uint celt,
        char** rgelt,
        uint* pceltFetched)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, char**, uint*, HRESULT>)_pVTable[3])
            (ThisPtr, celt, rgelt, pceltFetched);

    public HRESULT Skip(uint celt)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, HRESULT>)_pVTable[4])
            (ThisPtr, celt);

    public void Reset()
        => ((delegate* unmanaged[Stdcall]
            <void*, void>)_pVTable[5])
            (ThisPtr);

    public HRESULT Clone(IEnumString** ppenum)
        => ((delegate* unmanaged[Stdcall]
            <void*, IEnumString**, HRESULT>)_pVTable[6])
            (ThisPtr, ppenum);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IBindCtx : IComObj<IBindCtx>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new("0000000E-0000-0000-C000-000000000046");

    // IUnknown
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])
            (ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])
            (ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])
            (ThisPtr);

    // IBindCtx
    public void RegisterObjectBound(void* punk)
        => ((delegate* unmanaged[Stdcall]<void*, void*, void>)_pVTable[3])
            (ThisPtr, punk);

    public void RevokeObjectBound(void* punk)
        => ((delegate* unmanaged[Stdcall]<void*, void*, void>)_pVTable[4])
            (ThisPtr, punk);

    public void ReleaseBoundObjects()
        => ((delegate* unmanaged[Stdcall]<void*, void>)_pVTable[5])
            (ThisPtr);

    public void SetBindOptions(void* pbindopts)
        => ((delegate* unmanaged[Stdcall]<void*, void*, void>)_pVTable[6])
            (ThisPtr, pbindopts);

    public void GetBindOptions(void* pbindopts)
        => ((delegate* unmanaged[Stdcall]<void*, void*, void>)_pVTable[7])
            (ThisPtr, pbindopts);

    public void GetRunningObjectTable(void** pprot)
        => ((delegate* unmanaged[Stdcall]<void*, void**, void>)_pVTable[8])
            (ThisPtr, pprot);

    public void RegisterObjectParam(char* pszKey, void* punk)
        => ((delegate* unmanaged[Stdcall]<void*, char*, void*, void>)_pVTable[9])
            (ThisPtr, pszKey, punk);

    public void GetObjectParam(char* pszKey, void** ppunk)
        => ((delegate* unmanaged[Stdcall]<void*, char*, void**, void>)_pVTable[10])
            (ThisPtr, pszKey, ppunk);

    public HRESULT EnumObjectParam(IEnumString** ppenum)
        => ((delegate* unmanaged[Stdcall]<void*, IEnumString**, HRESULT>)_pVTable[11])
            (ThisPtr, ppenum);

    public void RevokeObjectParam(char* pszKey)
        => ((delegate* unmanaged[Stdcall]<void*, char*, void>)_pVTable[12])
            (ThisPtr, pszKey);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IEnumIDList : IComObj<IEnumIDList>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new("000214F2-0000-0000-C000-000000000046");

    // IUnknown
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])
            (ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])
            (ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])
            (ThisPtr);

    // IEnumIDList
    public HRESULT Next(
        uint celt,
        PIDL* rgelt,
        uint* pceltFetched)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, PIDL*, uint*, HRESULT>)_pVTable[3])
            (ThisPtr, celt, rgelt, pceltFetched);

    public HRESULT Skip(uint celt)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, HRESULT>)_pVTable[4])
            (ThisPtr, celt);

    public HRESULT Reset()
        => ((delegate* unmanaged[Stdcall]
            <void*, HRESULT>)_pVTable[5])
            (ThisPtr);

    public HRESULT Clone(IEnumIDList** ppenum)
        => ((delegate* unmanaged[Stdcall]
            <void*, IEnumIDList**, HRESULT>)_pVTable[6])
            (ThisPtr, ppenum);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IKnownFolder : IComObj<IKnownFolder>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new("3AA7AF7E-9B36-420C-A8E3-F77D4674A488");

    // IUnknown
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])
            (ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])
            (ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])
            (ThisPtr);

    // IKnownFolder
    public void GetId(Guid* pkfid)
        => ((delegate* unmanaged[Stdcall]
            <void*, Guid*, void>)_pVTable[3])
            (ThisPtr, pkfid);

    public void GetCategory(KF_CATEGORY* pCategory)
        => ((delegate* unmanaged[Stdcall]
            <void*, KF_CATEGORY*, void>)_pVTable[4])
            (ThisPtr, pCategory);

    public void GetShellItem(
        uint dwFlags,
        Guid* riid,
        void** ppv)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, Guid*, void**, void>)_pVTable[5])
            (ThisPtr, dwFlags, riid, ppv);

    public void GetPath(
        uint dwFlags,
        CHARS_MAX_PATH* ppszPath)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, CHARS_MAX_PATH*, void>)_pVTable[6])
            (ThisPtr, dwFlags, ppszPath);

    public void SetPath(
        uint dwFlags,
        char* pszPath)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, char*, void>)_pVTable[7])
            (ThisPtr, dwFlags, pszPath);

    public void GetIDList(
        uint dwFlags,
        PIDL* ppidl)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, PIDL*, void>)_pVTable[8])
            (ThisPtr, dwFlags, ppidl);

    public void GetFolderType(Guid* pftid)
        => ((delegate* unmanaged[Stdcall]
            <void*, Guid*, void>)_pVTable[9])
            (ThisPtr, pftid);

    public void GetRedirectionCapabilities(uint* pCapabilities)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint*, void>)_pVTable[10])
            (ThisPtr, pCapabilities);

    public void GetFolderDefinition(
        KNOWNFOLDER_DEFINITION* pKFD)
        => ((delegate* unmanaged[Stdcall]
            <void*, KNOWNFOLDER_DEFINITION*, void>)_pVTable[11])
            (ThisPtr, pKFD);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IShellFolder : IComObj<IShellFolder>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new("000214E6-0000-0000-C000-000000000046");

    // IUnknown
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])
            (ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])
            (ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])
            (ThisPtr);

    // IShellFolder
    public void ParseDisplayName(
        HWND hwnd,
        IBindCtx* pbc,
        char* pszDisplayName,
        uint* pchEaten,
        PIDL* ppidl,
        uint* pdwAttributes)
        => ((delegate* unmanaged[Stdcall]
            <void*, HWND, IBindCtx*, char*, uint*, PIDL*, uint*, void>)_pVTable[3])
            (ThisPtr, hwnd, pbc, pszDisplayName, pchEaten, ppidl, pdwAttributes);

    public HRESULT EnumObjects(
        HWND hwnd,
        _SHCONTF grfFlags,
        IEnumIDList** ppenumIDList)
        => ((delegate* unmanaged[Stdcall]
            <void*, HWND, _SHCONTF, IEnumIDList**, HRESULT>)_pVTable[4])
            (ThisPtr, hwnd, grfFlags, ppenumIDList);

    public void BindToObject(
        PIDL pidl,
        IBindCtx* pbc,
        Guid* riid,
        void** ppv)
        => ((delegate* unmanaged[Stdcall]
            <void*, PIDL, IBindCtx*, Guid*, void**, void>)_pVTable[5])
            (ThisPtr, pidl, pbc, riid, ppv);

    public void BindToStorage(
        PIDL pidl,
        IBindCtx* pbc,
        Guid* riid,
        void** ppv)
        => ((delegate* unmanaged[Stdcall]
            <void*, PIDL, IBindCtx*, Guid*, void**, void>)_pVTable[6])
            (ThisPtr, pidl, pbc, riid, ppv);

    public HRESULT CompareIDs(
        nint lParam,
        PIDL pidl1,
        PIDL pidl2)
        => ((delegate* unmanaged[Stdcall]
            <void*, nint, PIDL, PIDL, HRESULT>)_pVTable[7])
            (ThisPtr, lParam, pidl1, pidl2);

    public void CreateViewObject(
        HWND hwndOwner,
        Guid* riid,
        void** ppv)
        => ((delegate* unmanaged[Stdcall]
            <void*, HWND, Guid*, void**, void>)_pVTable[8])
            (ThisPtr, hwndOwner, riid, ppv);

    public void GetAttributesOf(
        uint cidl,
        PIDL* apidl,
        uint* rgfInOut)
        => ((delegate* unmanaged[Stdcall]
            <void*, uint, PIDL*, uint*, void>)_pVTable[9])
            (ThisPtr, cidl, apidl, rgfInOut);

    public void GetUIObjectOf(
        HWND hwndOwner,
        uint cidl,
        PIDL* apidl,
        Guid* riid,
        uint* rgfReserved,
        void** ppv)
        => ((delegate* unmanaged[Stdcall]
            <void*, HWND, uint, PIDL*, Guid*, uint*, void**, void>)_pVTable[10])
            (ThisPtr, hwndOwner, cidl, apidl, riid, rgfReserved, ppv);

    public void GetDisplayNameOf(
        PIDL pidl,
        SHGDNF uFlags,
        STRRET* pName)
        => ((delegate* unmanaged[Stdcall]
            <void*, PIDL, SHGDNF, STRRET*, void>)_pVTable[11])
            (ThisPtr, pidl, uFlags, pName);

    public void SetNameOf(
        HWND hwnd,
        PIDL pidl,
        char* pszName,
        SHGDNF uFlags,
        PIDL* ppidlOut)
        => ((delegate* unmanaged[Stdcall]
            <void*, HWND, PIDL, char*, SHGDNF, PIDL*, void>)_pVTable[12])
            (ThisPtr, hwnd, pidl, pszName, uFlags, ppidlOut);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IImageList : IComObj<IImageList>
{
    private readonly void** _pVTable;

    private readonly void* ThisPtr
        => Unsafe.AsPointer(ref Unsafe.AsRef(in this));

    public static Guid IID => new("46EB5926-582E-4017-9FDF-E8998DAA0950");

    // IUnknown
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[0])
            (ThisPtr, riid, ppvObject);

    public uint AddRef()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[1])
            (ThisPtr);

    public uint Release()
        => ((delegate* unmanaged[Stdcall]<void*, uint>)_pVTable[2])
            (ThisPtr);

    // IImageList
    public HRESULT Add(HBITMAP hbmImage, HBITMAP hbmMask, int* pi)
        => ((delegate* unmanaged[Stdcall]<void*, HBITMAP, HBITMAP, int*, HRESULT>)_pVTable[3])
            (ThisPtr, hbmImage, hbmMask, pi);

    public HRESULT ReplaceIcon(int i, HICON hicon, int* pi)
        => ((delegate* unmanaged[Stdcall]<void*, int, HICON, int*, HRESULT>)_pVTable[4])
            (ThisPtr, i, hicon, pi);

    public HRESULT SetOverlayImage(int iImage, int iOverlay)
        => ((delegate* unmanaged[Stdcall]<void*, int, int, HRESULT>)_pVTable[5])
            (ThisPtr, iImage, iOverlay);

    public HRESULT Replace(int i, HBITMAP hbmImage, HBITMAP hbmMask)
        => ((delegate* unmanaged[Stdcall]<void*, int, HBITMAP, HBITMAP, HRESULT>)_pVTable[6])
            (ThisPtr, i, hbmImage, hbmMask);

    public HRESULT AddMasked(HBITMAP hbmImage, COLORREF crMask, int* pi)
        => ((delegate* unmanaged[Stdcall]<void*, HBITMAP, COLORREF, int*, HRESULT>)_pVTable[7])
            (ThisPtr, hbmImage, crMask, pi);

    public HRESULT Draw(IMAGELISTDRAWPARAMS* pimldp)
        => ((delegate* unmanaged[Stdcall]<void*, IMAGELISTDRAWPARAMS*, HRESULT>)_pVTable[8])
            (ThisPtr, pimldp);

    public HRESULT Remove(int i)
        => ((delegate* unmanaged[Stdcall]<void*, int, HRESULT>)_pVTable[9])
            (ThisPtr, i);

    public HRESULT GetIcon(int i, uint flags, HICON* picon)
        => ((delegate* unmanaged[Stdcall]<void*, int, uint, HICON*, HRESULT>)_pVTable[10])
            (ThisPtr, i, flags, picon);

    public HRESULT GetImageInfo(int i, IMAGEINFO* pImageInfo)
        => ((delegate* unmanaged[Stdcall]<void*, int, IMAGEINFO*, HRESULT>)_pVTable[11])
            (ThisPtr, i, pImageInfo);

    public HRESULT Copy(int iDst, void* punkSrc, int iSrc, uint uFlags)
        => ((delegate* unmanaged[Stdcall]<void*, int, void*, int, uint, HRESULT>)_pVTable[12])
            (ThisPtr, iDst, punkSrc, iSrc, uFlags);

    public HRESULT Merge(
        int i1,
        void* punk2,
        int i2,
        int dx,
        int dy,
        Guid* riid,
        void** ppv)
        => ((delegate* unmanaged[Stdcall]
            <void*, int, void*, int, int, int, Guid*, void**, HRESULT>)_pVTable[13])
            (ThisPtr, i1, punk2, i2, dx, dy, riid, ppv);

    public HRESULT Clone(Guid* riid, void** ppv)
        => ((delegate* unmanaged[Stdcall]<void*, Guid*, void**, HRESULT>)_pVTable[14])
            (ThisPtr, riid, ppv);

    public HRESULT GetImageRect(int i, RECT* prc)
        => ((delegate* unmanaged[Stdcall]<void*, int, RECT*, HRESULT>)_pVTable[15])
            (ThisPtr, i, prc);

    public HRESULT GetIconSize(int* cx, int* cy)
        => ((delegate* unmanaged[Stdcall]<void*, int*, int*, HRESULT>)_pVTable[16])
            (ThisPtr, cx, cy);

    public HRESULT SetIconSize(int cx, int cy)
        => ((delegate* unmanaged[Stdcall]<void*, int, int, HRESULT>)_pVTable[17])
            (ThisPtr, cx, cy);

    public HRESULT GetImageCount(int* pi)
        => ((delegate* unmanaged[Stdcall]<void*, int*, HRESULT>)_pVTable[18])
            (ThisPtr, pi);

    public HRESULT SetImageCount(uint uNewCount)
        => ((delegate* unmanaged[Stdcall]<void*, uint, HRESULT>)_pVTable[19])
            (ThisPtr, uNewCount);

    public HRESULT SetBkColor(COLORREF clrBk, COLORREF* pclr)
        => ((delegate* unmanaged[Stdcall]<void*, COLORREF, COLORREF*, HRESULT>)_pVTable[20])
            (ThisPtr, clrBk, pclr);

    public HRESULT GetBkColor(COLORREF* pclr)
        => ((delegate* unmanaged[Stdcall]<void*, COLORREF*, HRESULT>)_pVTable[21])
            (ThisPtr, pclr);

    public HRESULT BeginDrag(int iTrack, int dxHotspot, int dyHotspot)
        => ((delegate* unmanaged[Stdcall]<void*, int, int, int, HRESULT>)_pVTable[22])
            (ThisPtr, iTrack, dxHotspot, dyHotspot);

    public HRESULT EndDrag()
        => ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_pVTable[23])
            (ThisPtr);

    public HRESULT DragEnter(HWND hwndLock, int x, int y)
        => ((delegate* unmanaged[Stdcall]<void*, HWND, int, int, HRESULT>)_pVTable[24])
            (ThisPtr, hwndLock, x, y);

    public HRESULT DragLeave(HWND hwndLock)
        => ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_pVTable[25])
            (ThisPtr, hwndLock);

    public HRESULT DragMove(int x, int y)
        => ((delegate* unmanaged[Stdcall]<void*, int, int, HRESULT>)_pVTable[26])
            (ThisPtr, x, y);

    public HRESULT SetDragCursorImage(void* punk, int iDrag, int dxHotspot, int dyHotspot)
        => ((delegate* unmanaged[Stdcall]<void*, void*, int, int, int, HRESULT>)_pVTable[27])
            (ThisPtr, punk, iDrag, dxHotspot, dyHotspot);

    public HRESULT DragShowNolock(BOOL fShow)
        => ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_pVTable[28])
            (ThisPtr, fShow);

    public HRESULT GetDragImage(
        POINT* ppt,
        POINT* pptHotspot,
        Guid* riid,
        void** ppv)
        => ((delegate* unmanaged[Stdcall]
            <void*, POINT*, POINT*, Guid*, void**, HRESULT>)_pVTable[29])
            (ThisPtr, ppt, pptHotspot, riid, ppv);

    public HRESULT GetItemFlags(int i, uint* dwFlags)
        => ((delegate* unmanaged[Stdcall]<void*, int, uint*, HRESULT>)_pVTable[30])
            (ThisPtr, i, dwFlags);

    public HRESULT GetOverlayImage(int iOverlay, int* piIndex)
        => ((delegate* unmanaged[Stdcall]<void*, int, int*, HRESULT>)_pVTable[31])
            (ThisPtr, iOverlay, piIndex);
}
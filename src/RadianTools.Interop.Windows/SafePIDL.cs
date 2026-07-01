using RadianTools.Interop.Windows.ComStructures;
using RadianTools.Interop.Windows.Utility;
using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

public class SafePIDL : IDisposable, IEquatable<SafePIDL>
{
    private IntPtr _Value;
    private bool _mustNotFree;
    private Guid? _KnownFolderId;
    private int? _cachedHashCode;
    private static readonly STAThreadPool _staPool = new STAThreadPool(threadCount: 2);

    public string FilePath { get; }
    public string DisplayName { get; }
    public bool IsFolder { get; }
    public bool IsFileSystem { get; }
    public bool HasSubFolder { get; }
    public int IconIndex { get; }

    public Guid KnownFolderId
    {
        get
        {
            if (_KnownFolderId.HasValue)
                return _KnownFolderId.Value;

            _KnownFolderId = Guid.Empty;
            if (IsNull)
            {
                return _KnownFolderId.Value;
            }

            unsafe
            {
                using var pFolderManager = ComFactory.Create<IKnownFolderManager>(in CLSID.CLSID_KnownFolderManager);
                ComPtr<IKnownFolder> pKnownFolder = new ();
                if (pFolderManager.Value->FindFolderFromIDList(_Value, pKnownFolder.Address).IsNotOK)
                    return _KnownFolderId.Value;

                using(pKnownFolder)
                {
                    Guid folderId;
                    pKnownFolder.Value->GetId(&folderId);
                    _KnownFolderId = folderId;
                    return _KnownFolderId.Value;
                }
            }
        }
    }

    public bool IsKnownFolder
        => KnownFolderId != Guid.Empty;

    private SafePIDL(PIDL pidl, bool mustNotFree)
    {
        _Value = pidl;
        _mustNotFree = mustNotFree;
        FilePath = GetFilePath();
        IsFileSystem = !string.IsNullOrEmpty(FilePath);
        DisplayName = string.Empty;

        if (IsNull)
        {
            return;
        }

        var fileInfo = GetFileInfo(
            SFGAO_FLAGS.SFGAO_FOLDER | SFGAO_FLAGS.SFGAO_HASSUBFOLDER,
            SHGFI_FLAGS.SHGFI_DISPLAYNAME |
            SHGFI_FLAGS.SHGFI_SMALLICON |
            SHGFI_FLAGS.SHGFI_SYSICONINDEX |
            SHGFI_FLAGS.SHGFI_ATTR_SPECIFIED |
            SHGFI_FLAGS.SHGFI_ATTRIBUTES |
            SHGFI_FLAGS.SHGFI_PIDL
            );
        if (!fileInfo.HasValue)
        {
            return;
        }

        DisplayName = fileInfo.Value.szDisplayName.ToString();
        IconIndex = fileInfo.Value.iIcon;
        IsFolder = (fileInfo.Value.dwAttributes & (uint)SFGAO_FLAGS.SFGAO_FOLDER) != 0;
        HasSubFolder = (fileInfo.Value.dwAttributes & (uint)SFGAO_FLAGS.SFGAO_HASSUBFOLDER) != 0;
    }

    public static SafePIDL Create(PIDL pidl)
        => new SafePIDL(pidl, mustNotFree: false);

    public static SafePIDL FromStatic(PIDL pidl)
        => new SafePIDL(pidl, mustNotFree: true);

    protected virtual void Dispose(bool disposing)
    {
        var p = Interlocked.Exchange(ref _Value, IntPtr.Zero);

        if (!_mustNotFree && p != IntPtr.Zero)
            Marshal.FreeCoTaskMem(p);
    }

    ~SafePIDL()
        => Dispose(disposing: false);

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public PIDL Value => (PIDL)_Value;

    public static implicit operator PIDL(SafePIDL p)
        => p.Value;

    public static SafePIDL Null { get; } = FromStatic(PIDL.Null);

    public bool IsNull
        => _Value == IntPtr.Zero;

    public SHFILEINFOW? GetFileInfo(SFGAO_FLAGS attrFlags, SHGFI_FLAGS getFlags)
    {
        var fileInfo = new SHFILEINFOW();
        fileInfo.dwAttributes = (uint)attrFlags;
        var result = Shell32.SHGetFileInfo(Value, 0, ref fileInfo, (uint)Marshal.SizeOf(fileInfo), getFlags);
        return result == 0 ? null : fileInfo;
    }

    public IEnumerable<SafePIDL> EnumFolders(CancellationToken? token = null)
        => InternalEnumChildsAsync(_SHCONTF.SHCONTF_FOLDERS, token);

    public IEnumerable<SafePIDL> EnumFiles(CancellationToken? token = null)
        => InternalEnumChildsAsync(_SHCONTF.SHCONTF_NONFOLDERS, token);

    public IEnumerable<SafePIDL> EnumAllChilds(CancellationToken? token = null)
        => InternalEnumChildsAsync(_SHCONTF.SHCONTF_FOLDERS | _SHCONTF.SHCONTF_NONFOLDERS, token);

    public Task<IEnumerable<SafePIDL>> EnumFoldersAsync(CancellationToken token)
        => RunSTA(ct => EnumFolders(ct), token);

    public Task<IEnumerable<SafePIDL>> EnumFilesAsync(CancellationToken token)
        => RunSTA(ct => EnumFiles(ct), token);

    public Task<IEnumerable<SafePIDL>> EnumAllChildsAsync(CancellationToken token)
        => RunSTA(ct => EnumAllChilds(ct), token);

    private IEnumerable<SafePIDL> InternalEnumChildsAsync(_SHCONTF flags, CancellationToken? token)
    {
        using var shellFolder = CreateShellFolder();
        if (shellFolder == ComPtr<IShellFolder>.Null)
            yield break;

        using var enumIDList = EnumShellObjects(shellFolder, flags);
        if (enumIDList == ComPtr<IEnumIDList>.Null)
            yield break;

        while (token?.IsCancellationRequested != true && NextIDList(enumIDList, this, out var childPidl))
        {
            yield return childPidl;
        }
    }

    public static SafePIDL FromFilePath(string filePath)
    {
        return Create(Shell32.ILCreateFromPath(filePath));
    }

    public bool Equals(SafePIDL? other)
    {
        if (other is null || IsNull || other.IsNull)
            return false;

        return Shell32.ILIsEqual(Value, other.Value);
    }

    public override int GetHashCode()
    {
        if (_cachedHashCode.HasValue)
            return _cachedHashCode.Value;

        if (IsNull)
        {
            _cachedHashCode = 0;
            return 0;
        }

        unsafe
        {
            var size = Shell32.ILGetSize(Value);
            if (size <= 0)
            {
                _cachedHashCode = 0;
                return 0;
            }

            byte* ptr = (byte*)_Value;
            int hash = 17;
            for (int i = 0; i < size; i++)
            {
                hash = hash * 31 ^ ptr[i];
            }

            _cachedHashCode = hash;
            return hash;
        }
    }

    private static ComPtr<IEnumIDList> EnumShellObjects(ComPtr<IShellFolder> pShellFolder, _SHCONTF flags)
    {
        unsafe
        {
            ComPtr<IEnumIDList> pEnumIDList = new ();
            if (pShellFolder.Value->EnumObjects(HWND.Null, flags, pEnumIDList.Address).IsNotOK)
                return ComPtr<IEnumIDList>.Null;

            return pEnumIDList;
        }
    }

    private static bool NextIDList(ComPtr<IEnumIDList> pEnumIDList, SafePIDL parent, out SafePIDL pidl)
    {
        unsafe
        {
            PIDL childPidl;
            if (pEnumIDList.Value->Next(1, &childPidl, null).IsNotOK)
            {
                pidl = Null;
                return false;
            }

            pidl = Combine(parent, childPidl);
            Marshal.FreeCoTaskMem((IntPtr)childPidl);
            return true;
        }
    }

    private string GetFilePath()
    {
        if (Shell32.SHGetPathFromIDListEx(
            Value,
            out var path,
            FileSystem.MAX_PATH,
            GPFIDL_FLAGS.GPFIDL_DEFAULT))
        {
            return path.ToString();
        }

        // ファイルシステムでない場合（ZIP内など）
        if (Shell32.SHGetNameFromIDList(
            Value,
            SIGDN.DESKTOPABSOLUTEPARSING,
            out var psz).IsOK)
        {
            try
            {
                return Marshal.PtrToStringUni((IntPtr)psz) ?? "";
            }
            finally
            {
                Marshal.FreeCoTaskMem((IntPtr)psz);
            }
        }

        return "";
    }

    private ComPtr<IShellFolder> CreateShellFolder()
    {
        var iid = IShellFolder.IID;
        unsafe
        {
            ComPtr<IShellFolder> shell = new();
            if (Shell32.SHBindToObject(IntPtr.Zero, Value, IntPtr.Zero, in iid, (void**)shell.Address).IsNotOK)
                return ComPtr<IShellFolder>.Null;

            return shell;
        }
    }

    private static SafePIDL Combine(PIDL pidl1, PIDL pidl2)
        => Create(Shell32.ILCombine(pidl1, pidl2));

    public static Task<T> RunSTA<T>(Func<CancellationToken, T> func, CancellationToken token)
        => _staPool.RunAsync(func, token);
}
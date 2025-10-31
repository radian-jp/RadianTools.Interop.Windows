namespace RadianTools.Interop.Windows;

public enum CONFIGRET : uint
{
    CR_SUCCESS = 0x00000000,
    CR_DEFAULT = 0x00000001,
    CR_OUT_OF_MEMORY = 0x00000002,
    CR_INVALID_POINTER = 0x00000003,
    CR_INVALID_FLAG = 0x00000004,
    CR_INVALID_DEVNODE = 0x00000005,
    CR_INVALID_DEVINST = CR_INVALID_DEVNODE,
    CR_INVALID_RES_DES = 0x00000006,
    CR_INVALID_LOG_CONF = 0x00000007,
    CR_INVALID_ARBITRATOR = 0x00000008,
    CR_INVALID_NODELIST = 0x00000009,
    CR_DEVNODE_HAS_REQS = 0x0000000A,
    CR_INVALID_RESOURCEID = 0x0000000B,
    CR_DLVXD_NOT_FOUND = 0x0000000C,
    CR_NO_SUCH_DEVNODE = 0x0000000D,
    CR_NO_MORE_LOG_CONF = 0x0000000E,
    CR_NO_MORE_RES_DES = 0x0000000F,
    CR_ALREADY_SUCH_DEVNODE = 0x00000010,
    CR_INVALID_RANGE = 0x00000011,
    CR_INVALID_RANGE_LIST = 0x00000012,
    CR_INVALID_DUPLICATE = 0x00000013,
    CR_NO_SUCH_LOGICAL_DEV = 0x00000014,
    CR_CREATE_BLOCKED = 0x00000015,
    CR_NOT_SYSTEM_VM = 0x00000016,
    CR_REMOVE_VETOED = 0x00000017,
    CR_APM_VETOED = 0x00000018,
    CR_INVALID_LOAD_TYPE = 0x00000019,
    CR_BUFFER_SMALL = 0x0000001A,
    CR_NO_ARBITRATOR = 0x0000001B,
    CR_NO_REGISTRY_HANDLE = 0x0000001C,
    CR_REGISTRY_ERROR = 0x0000001D,
    CR_INVALID_DEVICE_ID = 0x0000001E,
    CR_INVALID_DATA = 0x0000001F,
    CR_INVALID_API = 0x00000020,
    CR_DEVLOADER_NOT_READY = 0x00000021,
    CR_NEED_RESTART = 0x00000022,
    CR_NO_MORE_HW_PROFILES = 0x00000023,
    CR_DEVICE_NOT_FOUND = 0x00000024,
    CR_NO_SUCH_HW_PROFILE = 0x00000025,
    CR_INVALID_HW_PROFILE = 0x00000026,
    CR_NULL_VPD = 0x00000027,
    CR_VPD_NOT_FOUND = 0x00000028,
    CR_INVALID_VPD = 0x00000029,
    CR_BUFFER_TOO_SMALL = 0x0000002A,
    CR_NO_MORE_DEVNODES = 0x0000002B,
    CR_NO_MORE_RESOURCES = 0x0000002C,
    CR_NOT_DISABLEABLE = 0x0000002D,
    CR_FREE_RESOURCES = 0x0000002E,
    CR_QUERY_VETOED = 0x0000002F,
    CR_CANT_SHARE_IRQ = 0x00000030,
    CR_NO_DEPENDENT = 0x00000031,
    CR_SAME_RESOURCES = 0x00000032,
    CR_NO_SUCH_REGISTRY_KEY = 0x00000033,
    CR_INVALID_MACHINENAME = 0x00000034,
    CR_REMOTE_COMM_FAILURE = 0x00000035,
    CR_MACHINE_UNAVAILABLE = 0x00000036,
    CR_NO_CM_SERVICES = 0x00000037,
    CR_ACCESS_DENIED = 0x00000038,
    CR_CALL_NOT_IMPLEMENTED = 0x00000039,
    CR_INVALID_PROPERTY = 0x0000003A,
    CR_DEVICE_INTERFACE_ACTIVE = 0x0000003B,
    CR_NO_SUCH_DEVICE_INTERFACE = 0x0000003C,
    CR_INVALID_REFERENCE_STRING = 0x0000003D,
    CR_INVALID_CONFLICT_LIST = 0x0000003E,
    CR_INVALID_INDEX = 0x0000003F,
    CR_INVALID_STRUCTURE_SIZE = 0x00000040
}

public enum FILE_ACCESS : uint
{
    GENERIC_ALL = 0x10000000,
    GENERIC_EXECUTE = 0x20000000,
    GENERIC_WRITE = 0x40000000,
    GENERIC_READ = 0x80000000,
}

/// <summary>
/// ファイル属性
/// </summary>
[Flags]
public enum FILE_ATTRIBUTE : uint
{
    /// <summary>
    /// 読み取り専用のファイル。書き込みや削除はできません。ディレクトリには使用できません。
    /// </summary>
    FILE_ATTRIBUTE_READONLY = 0x00000001,

    /// <summary>
    /// 非表示のファイルまたはディレクトリ。通常の一覧には表示されません。
    /// </summary>
    FILE_ATTRIBUTE_HIDDEN = 0x00000002,

    /// <summary>
    /// オペレーティングシステムが使用するファイルまたはディレクトリ。
    /// </summary>
    FILE_ATTRIBUTE_SYSTEM = 0x00000004,

    /// <summary>
    /// ディレクトリを識別するハンドル。
    /// </summary>
    FILE_ATTRIBUTE_DIRECTORY = 0x00000010,

    /// <summary>
    /// アーカイブ対象のファイルまたはディレクトリ。バックアップや削除のマークに使用されます。
    /// </summary>
    FILE_ATTRIBUTE_ARCHIVE = 0x00000020,

    /// <summary>
    /// システムで予約された値。
    /// </summary>
    FILE_ATTRIBUTE_DEVICE = 0x00000040,

    /// <summary>
    /// 他の属性が設定されていないファイル。単独で使用する場合のみ有効です。
    /// </summary>
    FILE_ATTRIBUTE_NORMAL = 0x00000080,

    /// <summary>
    /// 一時ストレージ用のファイル。キャッシュメモリを優先して使用されます。
    /// </summary>
    FILE_ATTRIBUTE_TEMPORARY = 0x00000100,

    /// <summary>
    /// スパースファイルであるファイル。
    /// </summary>
    FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,

    /// <summary>
    /// 再解析ポイントが関連付けられているファイルまたはディレクトリ、またはシンボリックリンク。
    /// </summary>
    FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,

    /// <summary>
    /// 圧縮されたファイルまたはディレクトリ。
    /// </summary>
    FILE_ATTRIBUTE_COMPRESSED = 0x00000800,

    /// <summary>
    /// データがオフラインストレージに移動されたファイル。
    /// </summary>
    FILE_ATTRIBUTE_OFFLINE = 0x00001000,

    /// <summary>
    /// コンテンツインデックスサービスによってインデックスされないファイルまたはディレクトリ。
    /// </summary>
    FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,

    /// <summary>
    /// 暗号化されたファイルまたはディレクトリ。
    /// </summary>
    FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,

    /// <summary>
    /// 整合性ストリーム付きのファイルまたはディレクトリ（ReFSボリュームのみ）。
    /// </summary>
    FILE_ATTRIBUTE_INTEGRITY_STREAM = 0x00008000,

    /// <summary>
    /// システムで予約された値。
    /// </summary>
    FILE_ATTRIBUTE_VIRTUAL = 0x00010000,

    /// <summary>
    /// スクラバーによって読み取られないユーザーデータストリーム。
    /// </summary>
    FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x00020000,

    /// <summary>
    /// 拡張属性を持つファイルまたはディレクトリ。内部使用専用。
    /// </summary>
    FILE_ATTRIBUTE_EA = 0x00040000,

    /// <summary>
    /// ファイルまたはディレクトリをローカルに保持する必要があることを示す属性。
    /// </summary>
    FILE_ATTRIBUTE_PINNED = 0x00080000,

    /// <summary>
    /// アクティブにアクセスする場合を除き、ローカルに保持されないことを示す属性。
    /// </summary>
    FILE_ATTRIBUTE_UNPINNED = 0x00100000,

    /// <summary>
    /// ファイルまたはディレクトリが仮想であり、開くとリモートストアからフェッチされる可能性があることを示す属性。
    /// </summary>
    FILE_ATTRIBUTE_RECALL_ON_OPEN = 0x00040000,

    /// <summary>
    /// ファイルまたはディレクトリが完全にローカルに存在しないことを示す属性。データアクセス時にリモートストアからフェッチされる可能性があります。
    /// </summary>
    FILE_ATTRIBUTE_RECALL_ON_DATA_ACCESS = 0x00400000
}

[Flags]
public enum FILE_SHARE
{
    NOT_SET = 0,
    FILE_SHARE_READ = 0x00000001,
    FILE_SHARE_WRITE = 0x00000002,
    FILE_SHARE_DELETE = 0x00000004,
}

public enum FILE_DISPOSITION
{
    CREATE_NEW = 1,
    CREATE_ALWAYS = 2,
    OPEN_EXISTING = 3,
    OPEN_ALWAYS = 4,
    TRUNCATE_EXISTING = 5,
}

public enum DIB_COLORS
{
    DIB_RGB_COLORS = 0,
    DIB_PAL_COLORS = 1,
}

[Flags]
public enum DIGCF
{
    DIGCF_DEFAULT = 0x01,
    DIGCF_PRESENT = 0x02,
    DIGCF_ALLCLASSES = 0x04,
    DIGCF_PROFILE = 0x08,
    DIGCF_DEVICEINTERFACE = 0x10,
}

public enum KF_CATEGORY
{
    KF_CATEGORY_VIRTUAL = 1,
    KF_CATEGORY_FIXED = 2,
    KF_CATEGORY_COMMON = 3,
    KF_CATEGORY_PERUSER = 4,
}

public enum FFFP_MODE
{
    FFFP_EXACTMATCH = 0,
    FFFP_NEARESTPARENTMATCH = 1,
}

/// <summary>
/// GetWindowLongPtr / SetWindowLongPtr 用のインデックス定数（GWLP_）
/// </summary>
public enum GWLP : int
{
    /// <summary>
    /// ウィンドウプロシージャのアドレス（SetWindowLongPtr によって置き換え可能）
    /// </summary>
    GWLP_WNDPROC = -4,

    /// <summary>
    /// アプリケーションインスタンスのハンドル
    /// </summary>
    GWLP_HINSTANCE = -6,

    /// <summary>
    /// 親ウィンドウのハンドル（子ウィンドウやポップアップの親）
    /// </summary>
    GWLP_HWNDPARENT = -8,

    /// <summary>
    /// メニュー識別子またはメニューハンドル
    /// </summary>
    GWLP_ID = -12,

    /// <summary>
    /// ウィンドウスタイル（WS_ 系のフラグ）
    /// </summary>
    GWLP_STYLE = -16,

    /// <summary>
    /// 拡張ウィンドウスタイル（WS_EX_ 系のフラグ）
    /// </summary>
    GWLP_EXSTYLE = -20,

    /// <summary>
    /// アプリケーション定義のユーザーデータ
    /// </summary>
    GWLP_USERDATA = -21
}

public enum GPFIDL_FLAGS : uint
{
    GPFIDL_DEFAULT = 0U,
    GPFIDL_ALTNAME = 1U,
    GPFIDL_UNCPRINTER = 2U,
}

public enum SHIL : uint
{
    LARGE = 0,
    SMALL,
    EXTRALARGE,
    SYSSMALL,
    JUMBO,
}

public enum SPDRP
{
    SPDRP_FRIENDLYNAME = 0x0000000C,
}

public enum STRRET_TYPE
{
    STRRET_WSTR = 0,
    STRRET_OFFSET = 1,
    STRRET_CSTR = 2,
}

[Flags]
public enum SHGDNF : uint
{
    SHGDN_NORMAL = 0U,
    SHGDN_INFOLDER = 1U,
    SHGDN_FOREDITING = 4096U,
    SHGDN_FORADDRESSBAR = 16384U,
    SHGDN_FORPARSING = 32768U,
}

[Flags]
public enum _SHCONTF
{
    SHCONTF_CHECKING_FOR_CHILDREN = 16,
    SHCONTF_FOLDERS = 32,
    SHCONTF_NONFOLDERS = 64,
    SHCONTF_INCLUDEHIDDEN = 128,
    SHCONTF_INIT_ON_FIRST_NEXT = 256,
    SHCONTF_NETPRINTERSRCH = 512,
    SHCONTF_SHAREABLE = 1024,
    SHCONTF_STORAGE = 2048,
    SHCONTF_NAVIGATION_ENUM = 4096,
    SHCONTF_FASTITEMS = 8192,
    SHCONTF_FLATLIST = 16384,
    SHCONTF_ENABLE_ASYNC = 32768,
    SHCONTF_INCLUDESUPERHIDDEN = 65536,
}

[Flags]
public enum SFGAO_FLAGS : uint
{
    SFGAO_CANCOPY = 0x00000001,
    SFGAO_CANMOVE = 0x00000002,
    SFGAO_CANLINK = 0x00000004,
    SFGAO_STORAGE = 0x00000008,
    SFGAO_CANRENAME = 0x00000010,
    SFGAO_CANDELETE = 0x00000020,
    SFGAO_HASPROPSHEET = 0x00000040,
    SFGAO_DROPTARGET = 0x00000100,
    SFGAO_CAPABILITYMASK = 0x00000177,
    SFGAO_PLACEHOLDER = 0x00000800,
    SFGAO_SYSTEM = 0x00001000,
    SFGAO_ENCRYPTED = 0x00002000,
    SFGAO_ISSLOW = 0x00004000,
    SFGAO_GHOSTED = 0x00008000,
    SFGAO_LINK = 0x00010000,
    SFGAO_SHARE = 0x00020000,
    SFGAO_READONLY = 0x00040000,
    SFGAO_HIDDEN = 0x00080000,
    SFGAO_DISPLAYATTRMASK = 0x000FC000,
    SFGAO_FILESYSANCESTOR = 0x10000000,
    SFGAO_FOLDER = 0x20000000,
    SFGAO_FILESYSTEM = 0x40000000,
    SFGAO_HASSUBFOLDER = 0x80000000,
    SFGAO_CONTENTSMASK = 0x80000000,
    SFGAO_VALIDATE = 0x01000000,
    SFGAO_REMOVABLE = 0x02000000,
    SFGAO_COMPRESSED = 0x04000000,
    SFGAO_BROWSABLE = 0x08000000,
    SFGAO_NONENUMERATED = 0x00100000,
    SFGAO_NEWCONTENT = 0x00200000,
    SFGAO_CANMONIKER = 0x00400000,
    SFGAO_HASSTORAGE = 0x00400000,
    SFGAO_STREAM = 0x00400000,
    SFGAO_STORAGEANCESTOR = 0x00800000,
    SFGAO_STORAGECAPMASK = 0x70C50008,
    SFGAO_PKEYSFGAOMASK = 0x81044000,
}

[Flags]
public enum FILE_FLAGS_AND_ATTRIBUTES : uint
{
    FILE_ATTRIBUTE_READONLY = 0x00000001,
    FILE_ATTRIBUTE_HIDDEN = 0x00000002,
    FILE_ATTRIBUTE_SYSTEM = 0x00000004,
    FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
    FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
    FILE_ATTRIBUTE_DEVICE = 0x00000040,
    FILE_ATTRIBUTE_NORMAL = 0x00000080,
    FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
    FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
    FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
    FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
    FILE_ATTRIBUTE_OFFLINE = 0x00001000,
    FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
    FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,
    FILE_ATTRIBUTE_INTEGRITY_STREAM = 0x00008000,
    FILE_ATTRIBUTE_VIRTUAL = 0x00010000,
    FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x00020000,
    FILE_ATTRIBUTE_EA = 0x00040000,
    FILE_ATTRIBUTE_PINNED = 0x00080000,
    FILE_ATTRIBUTE_UNPINNED = 0x00100000,
    FILE_ATTRIBUTE_RECALL_ON_OPEN = 0x00040000,
    FILE_ATTRIBUTE_RECALL_ON_DATA_ACCESS = 0x00400000,
    FILE_FLAG_WRITE_THROUGH = 0x80000000,
    FILE_FLAG_OVERLAPPED = 0x40000000,
    FILE_FLAG_NO_BUFFERING = 0x20000000,
    FILE_FLAG_RANDOM_ACCESS = 0x10000000,
    FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,
    FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,
    FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,
    FILE_FLAG_POSIX_SEMANTICS = 0x01000000,
    FILE_FLAG_SESSION_AWARE = 0x00800000,
    FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,
    FILE_FLAG_OPEN_NO_RECALL = 0x00100000,
    FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
    PIPE_ACCESS_DUPLEX = 0x00000003,
    PIPE_ACCESS_INBOUND = 0x00000001,
    PIPE_ACCESS_OUTBOUND = 0x00000002,
    SECURITY_ANONYMOUS = 0x00000000,
    SECURITY_IDENTIFICATION = 0x00010000,
    SECURITY_IMPERSONATION = 0x00020000,
    SECURITY_DELEGATION = 0x00030000,
    SECURITY_CONTEXT_TRACKING = 0x00040000,
    SECURITY_EFFECTIVE_ONLY = 0x00080000,
    SECURITY_SQOS_PRESENT = 0x00100000,
    SECURITY_VALID_SQOS_FLAGS = 0x001F0000,
}

[Flags]
public enum SHGFI_FLAGS : uint
{
    SHGFI_ADDOVERLAYS = 0x00000020,
    SHGFI_ATTR_SPECIFIED = 0x00020000,
    SHGFI_ATTRIBUTES = 0x00000800,
    SHGFI_DISPLAYNAME = 0x00000200,
    SHGFI_EXETYPE = 0x00002000,
    SHGFI_ICON = 0x00000100,
    SHGFI_ICONLOCATION = 0x00001000,
    SHGFI_LARGEICON = 0x00000000,
    SHGFI_LINKOVERLAY = 0x00008000,
    SHGFI_OPENICON = 0x00000002,
    SHGFI_OVERLAYINDEX = 0x00000040,
    SHGFI_PIDL = 0x00000008,
    SHGFI_SELECTED = 0x00010000,
    SHGFI_SHELLICONSIZE = 0x00000004,
    SHGFI_SMALLICON = 0x00000001,
    SHGFI_SYSICONINDEX = 0x00004000,
    SHGFI_TYPENAME = 0x00000400,
    SHGFI_USEFILEATTRIBUTES = 0x00000010,
}

[Flags]
public enum RIDEV : int
{
    /// <summary>
    /// 受信を停止する
    /// </summary>
    RIDEV_REMOVE = 0x00000001,

    /// <summary>
    /// レガシメッセージを生成しない
    /// </summary>
    RIDEV_NOLEGACY = 0x00000030,

    /// <summary>
    /// 非フォアグラウンドでも入力を受け取る
    /// </summary>
    RIDEV_INPUTSINK = 0x00000100,
}

public enum RIDI : int
{
    PREPARSEDDATA = 0x20000005,
    DEVICENAME = 0x20000007,
    RIDI_DEVICEINFO = 0x2000000b,
}

public enum RIM_TYPE : int
{
    RIM_TYPEMOUSE = 0,
    RIM_TYPEKEYBOARD = 1,
    RIM_TYPEHID = 2,
}

/// <summary>
/// 仮想キーコードの定義
/// </summary>
public enum VKey : short
{
    VK_LBUTTON = 0x01,
    VK_RBUTTON = 0x02,
    VK_CANCEL = 0x03,
    VK_MBUTTON = 0x04,
    VK_XBUTTON1 = 0x05,
    VK_XBUTTON2 = 0x06,
    VK_BACK = 0x08,
    VK_TAB = 0x09,
    VK_CLEAR = 0x0C,
    VK_RETURN = 0x0D,
    VK_SHIFT = 0x10,
    VK_CONTROL = 0x11,
    VK_MENU = 0x12,
    VK_PAUSE = 0x13,
    VK_CAPITAL = 0x14,
    VK_KANA = 0x15,
    VK_HANGUL = 0x15,
    VK_IME_ON = 0x16,
    VK_JUNJA = 0x17,
    VK_FINAL = 0x18,
    VK_HANJA = 0x19,
    VK_KANJI = 0x19,
    VK_IME_OFF = 0x1A,
    VK_ESCAPE = 0x1B,
    VK_CONVERT = 0x1C,
    VK_NONCONVERT = 0x1D,
    VK_ACCEPT = 0x1E,
    VK_MODECHANGE = 0x1F,
    VK_SPACE = 0x20,
    VK_PRIOR = 0x21,
    VK_NEXT = 0x22,
    VK_END = 0x23,
    VK_HOME = 0x24,
    VK_LEFT = 0x25,
    VK_UP = 0x26,
    VK_RIGHT = 0x27,
    VK_DOWN = 0x28,
    VK_SELECT = 0x29,
    VK_PRINT = 0x2A,
    VK_EXECUTE = 0x2B,
    VK_SNAPSHOT = 0x2C,
    VK_INSERT = 0x2D,
    VK_DELETE = 0x2E,
    VK_HELP = 0x2F,
    VK_0 = 0x30,
    VK_1 = 0x31,
    VK_2 = 0x32,
    VK_3 = 0x33,
    VK_4 = 0x34,
    VK_5 = 0x35,
    VK_6 = 0x36,
    VK_7 = 0x37,
    VK_8 = 0x38,
    VK_9 = 0x39,
    VK_A = 0x41,
    VK_B = 0x42,
    VK_C = 0x43,
    VK_D = 0x44,
    VK_E = 0x45,
    VK_F = 0x46,
    VK_G = 0x47,
    VK_H = 0x48,
    VK_I = 0x49,
    VK_J = 0x4A,
    VK_K = 0x4B,
    VK_L = 0x4C,
    VK_M = 0x4D,
    VK_N = 0x4E,
    VK_O = 0x4F,
    VK_P = 0x50,
    VK_Q = 0x51,
    VK_R = 0x52,
    VK_S = 0x53,
    VK_T = 0x54,
    VK_U = 0x55,
    VK_V = 0x56,
    VK_W = 0x57,
    VK_X = 0x58,
    VK_Y = 0x59,
    VK_Z = 0x5A,
    VK_LWIN = 0x5B,
    VK_RWIN = 0x5C,
    VK_APPS = 0x5D,
    VK_SLEEP = 0x5F,
    VK_NUMPAD0 = 0x60,
    VK_NUMPAD1 = 0x61,
    VK_NUMPAD2 = 0x62,
    VK_NUMPAD3 = 0x63,
    VK_NUMPAD4 = 0x64,
    VK_NUMPAD5 = 0x65,
    VK_NUMPAD6 = 0x66,
    VK_NUMPAD7 = 0x67,
    VK_NUMPAD8 = 0x68,
    VK_NUMPAD9 = 0x69,
    VK_MULTIPLY = 0x6A,
    VK_ADD = 0x6B,
    VK_SEPARATOR = 0x6C,
    VK_SUBTRACT = 0x6D,
    VK_DECIMAL = 0x6E,
    VK_DIVIDE = 0x6F,
    VK_F1 = 0x70,
    VK_F2 = 0x71,
    VK_F3 = 0x72,
    VK_F4 = 0x73,
    VK_F5 = 0x74,
    VK_F6 = 0x75,
    VK_F7 = 0x76,
    VK_F8 = 0x77,
    VK_F9 = 0x78,
    VK_F10 = 0x79,
    VK_F11 = 0x7A,
    VK_F12 = 0x7B,
    VK_F13 = 0x7C,
    VK_F14 = 0x7D,
    VK_F15 = 0x7E,
    VK_F16 = 0x7F,
    VK_F17 = 0x80,
    VK_F18 = 0x81,
    VK_F19 = 0x82,
    VK_F20 = 0x83,
    VK_F21 = 0x84,
    VK_F22 = 0x85,
    VK_F23 = 0x86,
    VK_F24 = 0x87,
    VK_NUMLOCK = 0x90,
    VK_SCROLL = 0x91,
    VK_LSHIFT = 0xA0,
    VK_RSHIFT = 0xA1,
    VK_LCONTROL = 0xA2,
    VK_RCONTROL = 0xA3,
    VK_LMENU = 0xA4,
    VK_RMENU = 0xA5,
    VK_BROWSER_BACK = 0xA6,
    VK_BROWSER_FORWARD = 0xA7,
    VK_BROWSER_REFRESH = 0xA8,
    VK_BROWSER_STOP = 0xA9,
    VK_BROWSER_SEARCH = 0xAA,
    VK_BROWSER_FAVORITES = 0xAB,
    VK_BROWSER_HOME = 0xAC,
    VK_VOLUME_MUTE = 0xAD,
    VK_VOLUME_DOWN = 0xAE,
    VK_VOLUME_UP = 0xAF,
    VK_MEDIA_NEXT_TRACK = 0xB0,
    VK_MEDIA_PREV_TRACK = 0xB1,
    VK_MEDIA_STOP = 0xB2,
    VK_MEDIA_PLAY_PAUSE = 0xB3,
    VK_LAUNCH_MAIL = 0xB4,
    VK_LAUNCH_MEDIA_SELECT = 0xB5,
    VK_LAUNCH_APP1 = 0xB6,
    VK_LAUNCH_APP2 = 0xB7,
    VK_OEM_1 = 0xBA,
    VK_OEM_PLUS = 0xBB,
    VK_OEM_COMMA = 0xBC,
    VK_OEM_MINUS = 0xBD,
    VK_OEM_PERIOD = 0xBE,
    VK_OEM_2 = 0xBF,
    VK_OEM_3 = 0xC0,
    VK_GAMEPAD_A = 0xC3,
    VK_GAMEPAD_B = 0xC4,
    VK_GAMEPAD_X = 0xC5,
    VK_GAMEPAD_Y = 0xC6,
    VK_GAMEPAD_RIGHT_SHOULDER = 0xC7,
    VK_GAMEPAD_LEFT_SHOULDER = 0xC8,
    VK_GAMEPAD_LEFT_TRIGGER = 0xC9,
    VK_GAMEPAD_RIGHT_TRIGGER = 0xCA,
    VK_GAMEPAD_DPAD_UP = 0xCB,
    VK_GAMEPAD_DPAD_DOWN = 0xCC,
    VK_GAMEPAD_DPAD_LEFT = 0xCD,
    VK_GAMEPAD_DPAD_RIGHT = 0xCE,
    VK_GAMEPAD_MENU = 0xCF,
    VK_GAMEPAD_VIEW = 0xD0,
    VK_GAMEPAD_LEFT_THUMBSTICK_BUTTON = 0xD1,
    VK_GAMEPAD_RIGHT_THUMBSTICK_BUTTON = 0xD2,
    VK_GAMEPAD_LEFT_THUMBSTICK_UP = 0xD3,
    VK_GAMEPAD_LEFT_THUMBSTICK_DOWN = 0xD4,
    VK_GAMEPAD_LEFT_THUMBSTICK_RIGHT = 0xD5,
    VK_GAMEPAD_LEFT_THUMBSTICK_LEFT = 0xD6,
    VK_GAMEPAD_RIGHT_THUMBSTICK_UP = 0xD7,
    VK_GAMEPAD_RIGHT_THUMBSTICK_DOWN = 0xD8,
    VK_GAMEPAD_RIGHT_THUMBSTICK_RIGHT = 0xD9,
    VK_GAMEPAD_RIGHT_THUMBSTICK_LEFT = 0xDA,
    VK_OEM_4 = 0xDB,
    VK_OEM_5 = 0xDC,
    VK_OEM_6 = 0xDD,
    VK_OEM_7 = 0xDE,
    VK_OEM_8 = 0xDF,
    VK_OEM_102 = 0xE2,
    VK_PROCESSKEY = 0xE5,
    VK_PACKET = 0xE7,
    VK_ATTN = 0xF6,
    VK_CRSEL = 0xF7,
    VK_EXSEL = 0xF8,
    VK_EREOF = 0xF9,
    VK_PLAY = 0xFA,
    VK_ZOOM = 0xFB,
    VK_NONAME = 0xFC,
    VK_PA1 = 0xFD,
    VK_OEM_CLEAR = 0xFE,
}

/// <summary>
/// ウィンドウメッセージ定数
/// </summary>
public enum WindowMessage : uint
{
    WM_NULL = 0x0000,
    WM_CREATE = 0x0001,
    WM_DESTROY = 0x0002,
    WM_MOVE = 0x0003,
    WM_SIZE = 0x0005,
    WM_ACTIVATE = 0x0006,
    WM_SETFOCUS = 0x0007,
    WM_KILLFOCUS = 0x0008,
    WM_ENABLE = 0x000A,
    WM_SETREDRAW = 0x000B,
    WM_SETTEXT = 0x000C,
    WM_GETTEXT = 0x000D,
    WM_GETTEXTLENGTH = 0x000E,
    WM_PAINT = 0x000F,
    WM_CLOSE = 0x0010,
    WM_QUIT = 0x0012,
    WM_ERASEBKGND = 0x0014,
    WM_SHOWWINDOW = 0x0018,
    WM_SETTINGCHANGE = 0x001A,
    WM_ACTIVATEAPP = 0x001C,
    WM_NCPAINT = 0x0085,
    WM_NCACTIVATE = 0x0086,
    WM_DEVICECHANGE = 0x0219,

    // キーボード
    WM_KEYDOWN = 0x0100,
    WM_KEYUP = 0x0101,
    WM_CHAR = 0x0102,
    WM_SYSKEYDOWN = 0x0104,
    WM_SYSKEYUP = 0x0105,
    WM_SYSCHAR = 0x0106,

    // マウス
    WM_MOUSEMOVE = 0x0200,
    WM_LBUTTONDOWN = 0x0201,
    WM_LBUTTONUP = 0x0202,
    WM_RBUTTONDOWN = 0x0204,
    WM_RBUTTONUP = 0x0205,
    WM_MBUTTONDOWN = 0x0207,
    WM_MBUTTONUP = 0x0208,
    WM_MOUSEWHEEL = 0x020A,
    WM_XBUTTONDOWN = 0x020B,
    WM_XBUTTONUP = 0x020C,
    WM_MOUSEHWHEEL = 0x020E,

    // Raw Input
    WM_INPUT = 0x00FF,
}

public static class FileSystem
{
    public const int MAX_PATH = 260;
}

public static class FOLDERID
{
    public static readonly Guid Computer = new Guid(0x0AC0837C, 0xBBF8, 0x452A, 0x85, 0x0D, 0x79, 0xD0, 0x8E, 0x66, 0x7C, 0xA7);
    public static readonly Guid Desktop = new Guid(0xB4BFCC3A, 0xDB2C, 0x424C, 0xB0, 0x29, 0x7F, 0xE9, 0x9A, 0x87, 0xC6, 0x41);
    public static readonly Guid NetworkFolder = new Guid(0xD20BEEC4, 0x5CA8, 0x4905, 0xAE, 0x3B, 0xBF, 0x25, 0x1E, 0xA0, 0x9B, 0x53);
    public static readonly Guid UsersLibraries = new Guid(0xA302545D, 0xDEFF, 0x464B, 0xAB, 0xE8, 0x61, 0xC8, 0x64, 0x8D, 0x93, 0x9B);
    public static readonly Guid UsersFiles = new Guid(0xF3CE0F7C, 0x4901, 0x4ACC, 0x86, 0x48, 0xD5, 0xD4, 0x4B, 0x04, 0xEF, 0x8F);
}

public class KnownFolderPIDL
{
    public static readonly Lazy<SafePIDL> Desktop = new(() => GetKnownFolderPIDL(FOLDERID.Desktop));
    public static readonly Lazy<SafePIDL> NetworkFolder = new(() => GetKnownFolderPIDL(FOLDERID.NetworkFolder));
    public static readonly Lazy<SafePIDL> UsersLibraries = new(() => GetKnownFolderPIDL(FOLDERID.UsersLibraries));
    public static readonly Lazy<SafePIDL> UsersFiles = new(GetKnownFolderPIDL(FOLDERID.UsersFiles));

    public static SafePIDL GetKnownFolderPIDL(in Guid rfid)
    {
        var hr = Shell32.SHGetKnownFolderIDList(in rfid, 0, HANDLE.Null, out var pidl);
        return hr.IsOK ? new SafePIDL(pidl, false) : SafePIDL.Null;
    }
}

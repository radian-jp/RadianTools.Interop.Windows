using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RadianTools.Interop.Windows;

/// <summary>
/// 不可視ウィンドウクラス(専用スレッド動作)
/// 派生クラスで WndProc をオーバーライドすることで、メッセージ処理を拡張可能。
/// </summary>
public class HiddenWindow : IDisposable
{
    private Thread? _thread;
    private HWND _hwnd;
    private uint _threadId;
    private const int DisposeWaitMsec = 5000;

    private static Lazy<string> _windowClassName = new Lazy<string>(() => "HiddenWindowClass_" + Guid.NewGuid().ToString("N"));
    private static ushort? _atomWindow;
    private static IntPtr _hInstance = Kernel32.GetModuleHandle(IntPtr.Zero);
    private static DelegateWndProc _wndProcDelegate = StaticWndProc;

    public HWND Handle => _hwnd;
    public Exception? LastException { get; private set; }

    public void Run()
    {
        var gch = GCHandle.Alloc(this);
        using var eventInitialized = new CountdownEvent(1);

        _thread = new Thread(() => {
            try
            {
                try
                {
                    _threadId = Kernel32.GetCurrentThreadId();

                    // ウィンドウクラスは一度だけ登録し、
                    // アプリケーションの終了と同時に OS により自動解放される。
                    // UnregisterClass は不要かつリスクがあるため、呼び出していない。
                    RegisterWindowClass();

                    // ウィンドウ作成（不可視）
                    _hwnd = User32.CreateWindowEx(
                        0,
                        _windowClassName.Value,
                        string.Empty,
                        0,
                        0, 0, 0, 0,
                        IntPtr.Zero,
                        IntPtr.Zero,
                        _hInstance,
                        GCHandle.ToIntPtr(gch));

                    if (_hwnd.Value == IntPtr.Zero)
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                finally
                {
                    //ウィンドウ作成完了(または失敗)
                    eventInitialized.Signal();
                }

                // メッセージループ
                MSG msg;
                while (true)
                {
                    int ret = User32.GetMessage(out msg, IntPtr.Zero, 0, 0);
                    if (ret > 0)
                    {
                        // 通常メッセージ
                        User32.TranslateMessage(ref msg);
                        User32.DispatchMessage(ref msg);
                    }
                    else if (ret == 0)
                    {
                        // WM_QUIT → 正常終了
                        break;
                    }
                    else // ret == -1
                    {
                        // エラー発生
                        int err = Marshal.GetLastWin32Error();
                        Debug.WriteLine($"GetMessage failed. Error={err}");
                        break;
                    }
                }

                // 終了処理
                User32.DestroyWindow(_hwnd);
            }
            catch (Exception ex)
            {
                LastException = ex;
            }
            finally
            {
                gch.Free();
            }
        });
        _thread.IsBackground = true;
        _thread.SetApartmentState(ApartmentState.STA);
        _thread.Start();

        // HWND ができるまで待つ
        eventInitialized.Wait();
    }

    private static void RegisterWindowClass()
    {
        if (_atomWindow.HasValue)
            return;

        // ウィンドウクラス登録
        WNDCLASSEX wc = new WNDCLASSEX();
        wc.cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX));
        wc.lpfnWndProc = _wndProcDelegate;
        wc.hInstance = _hInstance;
        wc.lpszClassName = _windowClassName.Value;
        ushort atom = User32.RegisterClassEx(ref wc);
        if (atom == 0)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        _atomWindow = atom;
    }

    private static IntPtr StaticWndProc(HWND hwnd, WindowMessage msg, IntPtr wParam, IntPtr lParam)
    {
        switch (msg)
        {
            case WindowMessage.WM_CREATE:
                unsafe
                {
                    var createStruct = (CREATESTRUCT*)lParam;
                    var gcHandle = GCHandle.FromIntPtr(createStruct->lpCreateParams);
                    var instance = (HiddenWindow)gcHandle.Target!;
                    User32.SetWindowLongPtr(hwnd, GWLP.GWLP_USERDATA, createStruct->lpCreateParams);
                    return instance.WndProc(hwnd, msg, wParam, lParam);
                }

            default:
                {
                    var userData = User32.GetWindowLongPtr(hwnd, GWLP.GWLP_USERDATA);
                    if (userData == IntPtr.Zero)
                        return User32.DefWindowProc(hwnd, msg, wParam, lParam);

                    var gcHandle = GCHandle.FromIntPtr(userData);
                    var instance = (HiddenWindow)gcHandle.Target!;
                    return instance.WndProc(hwnd, msg, wParam, lParam);
                }
        }
    }

    protected virtual IntPtr WndProc(HWND hwnd, WindowMessage msg, IntPtr wParam, IntPtr lParam)
    {
        switch (msg)
        {
            case WindowMessage.WM_DESTROY:
                User32.PostQuitMessage(0);
                break;
        }

        return User32.DefWindowProc(hwnd, msg, wParam, lParam);
    }

    public void Dispose()
    {
        var thread = Interlocked.Exchange(ref _thread, null);
        if (thread != null && thread.IsAlive)
        {
            User32.PostThreadMessage(_threadId, (uint)WindowMessage.WM_QUIT, IntPtr.Zero, IntPtr.Zero);
            if (!thread.Join(DisposeWaitMsec))
            {
                Debug.WriteLine($"After Dispose, the thread did not stop within {DisposeWaitMsec} msec.");
            }
        }
    }
}

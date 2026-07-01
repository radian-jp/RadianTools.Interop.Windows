namespace RadianTools.Interop.Windows.ComStructures;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

internal static class ComFactory
{
    [DllImport("ole32.dll")]
    private static extern unsafe HRESULT CoCreateInstance(
            in Guid rclsid,
            IntPtr pUnkOuter,
            uint dwClsContext,
            in Guid riid,
            out IntPtr ppv
    );

    const int CLSCTX_INPROC_SERVER = 1;

    public static unsafe ComPtr<T> Create<T>(in Guid clsid) where T : unmanaged, IComObj<T>
    {
        var iid = T.IID;
        var hr = CoCreateInstance(in clsid, IntPtr.Zero, CLSCTX_INPROC_SERVER, in iid, out var pv);
        hr.ThrowIfFailed();
        return new ComPtr<T>((T*)pv);
    }

    public static unsafe bool TryCreate<T>(in Guid clsid, out ComPtr<T> ptr, out HRESULT hr) where T : unmanaged, IComObj<T>
    {
        var iid = T.IID;
        hr = CoCreateInstance(in clsid, IntPtr.Zero, CLSCTX_INPROC_SERVER, in iid, out var pv);
        if (hr.Failed)
        {
            ptr = ComPtr<T>.Null;
            return false;
        }

        unsafe
        {
            ptr = new ComPtr<T>((T*)pv);
            return true;
        }
    }
}

public unsafe interface IComObj<T> where T : unmanaged
{
    static abstract Guid IID { get; }
    HRESULT QueryInterface(Guid* riid, void** ppvObject);
    uint AddRef();
    uint Release();
}

public struct ComPtr<T> : IEquatable<ComPtr<T>>, IDisposable where T : unmanaged, IComObj<T>
{
    public static ComPtr<T> Null { get; }

    static ComPtr()
    {
        unsafe {
            Null = new ComPtr<T>(null);
        }
    }

    private IntPtr _value;

    public unsafe T* Value => (T*)_value;
    public unsafe T** Address => (T**)Unsafe.AsPointer(ref _value);

    internal unsafe ComPtr(T* ptr)
        => _value = (IntPtr)ptr;

    public void Dispose()
    {
        var ptr = Interlocked.Exchange(ref _value, IntPtr.Zero);
        if( ptr!=IntPtr.Zero )
        {
            unsafe
            {
                ((T*)ptr)->Release();
            }
        }
    }

    public bool Equals(ComPtr<T> other)
        => _value == other._value;

    public static bool operator ==(ComPtr<T> val1, ComPtr<T> val2)
        => val1.Equals(val2);

    public static bool operator !=(ComPtr<T> val1, ComPtr<T> val2)
        => !val1.Equals(val2);

    public override bool Equals(object? obj)
    {
        return obj is ComPtr<T> && Equals((ComPtr<T>)obj);
    }

    public override int GetHashCode()
        => _value.GetHashCode();

    public ComPtr<TTo> As<TTo>() where TTo : unmanaged, IComObj<TTo>
    {
        unsafe
        {
            void* ppv = null;
            Guid iid = TTo.IID;
            HRESULT hr = Value->QueryInterface(&iid, &ppv);
            if (!hr.Succeeded)
                return ComPtr<TTo>.Null;

            return new ComPtr<TTo>((TTo*)ppv);
        }
    }
}

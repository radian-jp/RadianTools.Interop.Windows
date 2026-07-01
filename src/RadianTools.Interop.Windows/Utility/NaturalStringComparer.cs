namespace RadianTools.Interop.Windows.Utility;

using RadianTools.Interop.Windows;
using System.Collections.Generic;

public class NaturalStringComparer : IComparer<string>
{
    public static NaturalStringComparer Shared { get; } = new();

    public int Compare(string? x, string? y)
    {
        return ShlwApi.StrCmpLogicalW(x ?? "", y ?? "");
    }
}
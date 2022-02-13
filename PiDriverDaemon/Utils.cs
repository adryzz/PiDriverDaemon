using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PiDriverDaemon;

public static class Utils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoot() => geteuid() == 0;
    
    [DllImport ("libc")]
    private static extern int geteuid();
}
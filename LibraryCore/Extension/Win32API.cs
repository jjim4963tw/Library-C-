using System.Runtime.InteropServices;

namespace LibraryCore.Extension
{
    class Win32API
    {
        // 偵測網路狀態。
        [DllImport("wininet")]
        public static extern bool InternetGetConnectedState(ref uint lpdwFlags, uint dwReserved);
    }
}

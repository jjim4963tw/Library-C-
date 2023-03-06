using LibraryCore.Extension;

namespace LibraryCore.Utility
{
    class NetworkUtility
    {
        public static bool CheckNetworkStatusFunction()
        {
            uint flags = 0x0;
            var isNetworkAvailable = Win32API.InternetGetConnectedState(ref flags, 0);

            return isNetworkAvailable;
        }
    }
}

using LibraryCore.Utility;
using LibraryCore.Manager;
using System;
using System.Threading;
using WebStorageDrive.Utility;

namespace LibraryCore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length <= 0 || args[0].ToLower() == "/h")
            {
                RunHelperFunction();
            }
            else if (args[0].ToLower() == "/netstate")
            {
                CheckNetworkStatus();
            }
            else if (args[0].ToLower() == "/time")
            {
                string type = "0";
                if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
                {
                    type = args[1];
                }

                GetNowSystemTime(type);
            }
            else if (args[0].ToLower() == "/v")
            {
                GetSystemInfo();
            }

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }


        #region Private Function
        //
        // 摘要:
        //     /h：顯示幫助區塊，包括可使用指令。
        private static void RunHelperFunction()
        {
            Console.WriteLine("使用方式：LibraryCore [/h] [/v]");
            Console.WriteLine();
            Console.WriteLine("/h-          查詢指令");
            Console.WriteLine("/v-          查詢系統資訊");
            Console.WriteLine("/netstate-   檢測網路狀態");
            Console.WriteLine("/time-       查詢目前時間 (搭配參數：0 為當地時間；1 為UTC 時間，預設為0)");
        }
        //
        // 摘要:
        //     /netstate：偵測目前是否有網路。
        private static void CheckNetworkStatus()
        {
            while (true)
            {
                Console.WriteLine("Network Status：" + NetworkUtility.CheckNetworkStatusFunction());
                Thread.Sleep(1000);
            }
        }
        //
        // 摘要:
        //     /time [0/1]：取得當前時間，0 為當地時間；1 為 UTC 時間。
        private static void GetNowSystemTime(string type)
        {
            Console.WriteLine(DateUtility.FormatADDataTimeFunction(DateTime.Now, string.IsNullOrEmpty(type) || type == "0").ToString());
        }
        //
        // 摘要:
        //     /v：取得系統資訊。
        private static void GetSystemInfo()
        {
            Console.WriteLine("App Name：" + ConfigUtility.Instance.GetExeutingName);
            Console.WriteLine("Windows OS Version：" + ConfigUtility.Instance.GetWindowsVersionName);
            Console.WriteLine("Manufacturer：" + ConfigUtility.Instance.SystemManufacturer);
            Console.WriteLine("Device Name：" + ConfigUtility.Instance.GetMachineName);
            Console.WriteLine("Device Model：" + ConfigUtility.Instance.SystemModel);
        }
        #endregion    
    }
}

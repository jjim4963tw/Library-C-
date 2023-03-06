using LibraryCore.Utility;
using System;

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
            else if (args[0].ToLower() == "/v") 
            {
                GetSystemInfo();
            }

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }


        private static void GetSystemInfo()
        {
            Console.WriteLine("App Name：" + ConfigUtility.Instance.GetExeutingName);
            Console.WriteLine("Windows OS Version：" + ConfigUtility.Instance.GetWindowsVersionName);
            Console.WriteLine("Manufacturer：" + ConfigUtility.Instance.SystemManufacturer);
            Console.WriteLine("Device Name：" + ConfigUtility.Instance.GetMachineName);
            Console.WriteLine("Device Model：" + ConfigUtility.Instance.SystemModel);
        }

        private static void RunHelperFunction()
        {
            Console.WriteLine("使用方式：LibraryCore [/h] [/v]");
            Console.WriteLine();
            Console.WriteLine("/h-      查詢指令");
            Console.WriteLine("/v-      查詢系統資訊");
        }
    }
}

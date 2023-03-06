using Microsoft.Win32;
using System;
using System.Configuration;
using System.Management;
using System.Reflection;
using System.Text;
using WebStorageDrive.Utility;

namespace LibraryCore.Utility
{
    class ConfigUtility
    {
        public string SystemManufacturer = "";
        public string SystemModel = "";

        private static readonly Lazy<ConfigUtility> lazy = new Lazy<ConfigUtility>(() => new ConfigUtility());
        public static ConfigUtility Instance { get { return lazy.Value; } }

        private ConfigUtility()
        {
            this.GetSystemInfo();
        }
        //
        // 摘要:
        //     讀取目前執行的應用程式名稱。
        //
        // 傳回:
        //     回傳字串型態，執行的應用程式名稱。
        public string GetExeutingName
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
        //
        // 摘要:
        //     取得 Windows 系統版本。
        //
        // 傳回:
        //     回傳字串型態，Windows OS Version。
        public string GetWindowsVersionName
        {
            get
            {
                string nowSystemWinVersionName = "";

                if (string.IsNullOrEmpty(nowSystemWinVersionName))
                {
                    try
                    {
                        object versionObject = RegistryKeyUtility.GetRegistryValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
                        if (versionObject != null && !string.IsNullOrEmpty(versionObject.ToString()))
                        {
                            nowSystemWinVersionName = versionObject.ToString();
                        }
                        else
                        {
                            nowSystemWinVersionName = Environment.OSVersion.Version.Major.ToString();
                        }
                    }
                    catch { }
                }

                return nowSystemWinVersionName;
            }
        }
        //
        // 摘要:
        //     取得裝置名稱。
        //
        // 傳回:
        //     回傳字串型態，裝置名稱。
        public string GetMachineName
        {
            get
            {
                string machineName = "";
                string inMachineName = Environment.MachineName;
                //try
                //{
                //    if (inMachineName.Length > 20)
                //    {
                //        inMachineName = inMachineName.Substring(0, 20);
                //    }

                //    machineName = Convert.ToBase64String(Encoding.UTF8.GetBytes(inMachineName));
                //}
                //catch// (Exception ex)
                //{
                //}

                return inMachineName;
            }
        }
        //
        // 摘要:
        //     取得系統硬體資訊。
        //
        // 傳回:
        //     回傳字串型態，系統硬體資訊。
        private void GetSystemInfo()
        {
            try
            {
                SelectQuery query = new SelectQuery(@"Select * from Win32_ComputerSystem");

                //initialize the searcher with the query it is supposed to execute
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    //execute the query
                    foreach (ManagementObject process in searcher.Get())
                    {
                        //print system info
                        process.Get();
                        SystemManufacturer = (string)process["Manufacturer"];
                        SystemModel = (string)process["Model"];
                    }
                }
            }
            catch { }
        }
    }
}

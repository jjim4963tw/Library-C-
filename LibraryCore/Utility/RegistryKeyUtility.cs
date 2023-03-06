using LibraryCore.Utility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace WebStorageDrive.Utility
{
    class RegistryKeyUtility
    {
        private static readonly string TAG = nameof(RegistryKeyUtility);

        // 設定開機自動啟動的 Registry Key Path
        public static readonly string s_AutoRunPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        // 安裝路徑
        public static readonly string s_InstallationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + ConfigUtility.Instance.GetExeutingName;


        #region Select (讀取)
        //
        // 摘要:
        //     讀取 Registry Key 中的值。
        //
        // 參數:
        //   rootKey:
        //     Registry Key 的根路徑 (CurrentUser、LocalMachine、ClassesRoot...)。
        //
        //   machinePath:
        //     欲讀取的 Registry 路徑。
        //
        //   subKey:
        //     該項目的 Key 值。
        //
        // 傳回:
        //     回傳泛型型態，Registry Key 的 Value。
        public static object GetRegistryValue(RegistryKey rootKey, string machinePath, string subKey)
        {
            object resultValue = null;
            RegistryKey registryKey = null;
            try
            {
                registryKey = rootKey.OpenSubKey(machinePath, false);
                if (registryKey != null)
                {
                    resultValue = registryKey.GetValue(subKey);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Get Registry Key Value Error : " + err.Message);
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }

            return resultValue;
        }
        //
        // 摘要:
        //     讀取 Registry Key 底下所有子 Key 與 子 Value。
        //
        // 參數:
        //   rootKey:
        //     Registry Key 的根路徑 (CurrentUser、LocalMachine、ClassesRoot...)。
        //
        //   machinePath:
        //     欲讀取的 Registry 路徑。
        //
        // 傳回:
        //     回傳 Dictionary 型態，Registry Key 的所有子 Key - Value。
        public static Dictionary<string, object> GetAllSubKeyAndValue(RegistryKey rootKey, string machinePath)
        {
            Dictionary<string, object> dataList = new Dictionary<string, object>();

            RegistryKey registryKey = null;
            try
            {
                registryKey = rootKey.OpenSubKey(machinePath, false);
                if (registryKey == null)
                {
                    return dataList;
                }

                foreach (var subkey in registryKey.GetValueNames())
                {
                    if (registryKey.GetValue(subkey) != null)
                    {
                        dataList.Add(subkey, registryKey.GetValue(subkey));
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Get All Sub Key and Value Error : " + err.Message);
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }

            return dataList;
        }
        #endregion


        #region Insert (新增)
        //
        // 摘要:
        //     設定 Registry Key 中的值。
        //
        // 參數:
        //   rootKey:
        //     Registry Key 的根路徑 (CurrentUser、LocalMachine、ClassesRoot...)。
        //
        //   machinePath:
        //     欲讀取的 Registry 路徑。
        //
        //   subKey:
        //     該項目的 Key 值。
        //
        //   subValue:
        //     該項目的 Value 值。
        //
        public static void SetRegistryValue(RegistryKey rootKey, string machinePath, string subKey, object subValue)
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = rootKey.OpenSubKey(machinePath, true);
                if (registryKey == null)
                {
                    registryKey = rootKey.CreateSubKey(machinePath);
                }

                registryKey.SetValue(subKey, subValue);
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Set Registry Key Value Error : " + err.Message);
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }
        //
        // 摘要:
        //     批次新增 Registry Key 中的值。
        //
        // 參數:
        //   rootKey:
        //     Registry Key 的根路徑 (CurrentUser、LocalMachine、ClassesRoot...)。
        //
        //   machinePath:
        //     欲讀取的 Registry 路徑。
        //
        //   valueList:
        //     批次存入的 Key - Value 列表。
        //
        public static void SetRegistryValues(RegistryKey rootKey, string machinePath, Dictionary<string, object> valueList)
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = rootKey.OpenSubKey(machinePath, true);
                if (registryKey == null)
                {
                    registryKey = rootKey.CreateSubKey(machinePath);
                }

                foreach (KeyValuePair<string, object> entry in valueList)
                {
                    registryKey.SetValue(entry.Key, entry.Value);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Set Registry Key Value Error : " + err.Message);
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }
        //
        // 摘要:
        //     更新應用程式自動更新是否開啟。
        //
        // 參數:
        //   appName:
        //     Application Name。
        //
        //   executablePath:
        //     欲執行的應用程式路徑。
        //
        //   isOpen:
        //     是否開啟開機自動開啟程式。
        //
        public static void SetAutoRunValue(string appName, string executablePath, bool isOpen)
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = Registry.CurrentUser.OpenSubKey(s_AutoRunPath, true);
                if (registryKey != null)
                {
                    if (isOpen)
                    {
                        registryKey.SetValue(appName, executablePath);
                    }
                    else
                    {
                        registryKey.DeleteValue(appName);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Set AutoRun Value Error : " + err.Message);
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }
        #endregion


        #region Delete (刪除)
        //
        // 摘要:
        //     移除 Registry Key 中的參數。
        //
        // 參數:
        //   rootKey:
        //     Registry Key 的根路徑 (CurrentUser、LocalMachine、ClassesRoot...)。
        //
        //   machinePath:
        //     欲讀取的 Registry 路徑。
        //
        //   subKey:
        //     該項目的 Key 值。
        //
        // 傳回:
        //     回傳 Bool 型態，是否刪除成功。
        public static bool DeleteRegistryKey(RegistryKey rootKey, string machinePath, string subKey)
        {
            bool isSuccess = false;

            RegistryKey registryKey = null;
            try
            {
                registryKey = rootKey.OpenSubKey(machinePath, true);
                if (registryKey == null)
                {
                    return true;
                }

                registryKey.DeleteValue(subKey, false);
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Remove Registry Value Error : " + err.Message);
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }

            return isSuccess;
        }
        //
        // 摘要:
        //     移除 Registry Key 中所有的參數。
        //
        // 參數:
        //   rootKey:
        //     Registry Key 的根路徑 (CurrentUser、LocalMachine、ClassesRoot...)。
        //
        //   machinePath:
        //     欲讀取的 Registry 路徑。
        //
        // 傳回:
        //     回傳 Bool 型態，是否刪除成功。
        public static bool DeleteAllRegistryKeys(RegistryKey rootKey, string machinePath)
        {
            bool isSuccess = false;

            RegistryKey registryKey = null;
            try
            {
                registryKey = rootKey.OpenSubKey(machinePath, true);
                if (registryKey == null)
                {
                    return true;
                }

                foreach (var subkey in registryKey.GetValueNames())
                {
                    registryKey.DeleteValue(subkey, false);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Remove All Registry Value Error : " + err.Message);
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }

            return isSuccess;
        }
        #endregion
    }
}

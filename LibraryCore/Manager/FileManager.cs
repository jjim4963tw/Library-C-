using System;
using System.IO;
using System.Web;

namespace LibraryCore.Manager
{
    class FileManager
    {
        public static string TAG = nameof(FileManager);

        #region Dir Path
        //
        // 摘要:
        //     取得 C:\Users\userName\AppData\Roaming 的路徑。
        //
        // 傳回:
        //     string 型態，對應路徑。
        public static string GetAppDataRomingPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        #endregion


        #region File Info
        //
        // 摘要:
        //     取得檔案的 MIME Type。
        //
        // 參數:
        //   fileName:
        //     檔案名稱或路徑
        //
        // 傳回:
        //     回傳 string 型態，檔案類型。
        public static string GetFileMIMEType(string fileName)
        {
            string mimeType = "";

            try
            {
                mimeType = MimeMapping.GetMimeMapping(fileName);
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Get MIME Type Error : " + err.Message);
            }

            return mimeType;
        }
        //
        // 摘要:
        //     取得檔案的副檔名。
        //
        // 參數:
        //   fileName:
        //     檔案名稱或路徑
        //
        // 傳回:
        //     回傳 string 型態，檔案副檔名。
        public static string GetFileExtension(string fileName)
        {
            string extension = "";

            try
            {
                extension = Path.GetExtension(fileName);
            }
            catch (Exception err)
            {
                Console.WriteLine("[" + TAG + "] Get File Extension Error : " + err.Message);
            }

            return extension;
        }
        #endregion


        #region File Operation

        #endregion


    }
}

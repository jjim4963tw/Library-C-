using System;
using System.Collections.Generic;
using System.Web;

namespace LibraryCore.Extension
{
    static class CoreExtension
    {
        //
        // 摘要:
        //     將 List 中的資料亂數排序
        private static Random s_random = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = s_random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        //
        // 摘要:
        //     解析 Scheme 後的參數
        //
        // 傳回:
        //     Dictionary 型態，為 key 對 value 的參數對。
        public static Dictionary<string, string> QueryParser(this string query)
        {
            Dictionary<string, string> queryPairs = new Dictionary<string, string>();

            string[] pairs = query.Split('&');
            foreach (string pair in pairs)
            {
                int idx = pair.IndexOf("=");
                queryPairs.Add(HttpUtility.UrlDecode(pair.Substring(0, idx)), HttpUtility.UrlDecode(pair.Substring(idx + 1)));
            }

            return queryPairs;
        }
    }
}

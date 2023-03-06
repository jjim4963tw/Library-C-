using System;
using System.Globalization;

namespace WebStorageDrive.Utility
{
    class DateUtility
    {
        public static readonly DateTime s_ZeroDateTime = new DateTime(0001, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static readonly DateTime s_WindowsNTDateTime = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static readonly DateTime s_UTCStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        //
        // 摘要:
        //     判斷 DateTime 是否為初始值。
        //
        // 參數:
        //   dateTimes:
        //     欲轉換的時間格式。
        //
        // 傳回:
        //     long 型態，為 UTC 的 MillionSecond。
        public static bool IsEmptyDateTime(DateTime dateTimes)
        {
            if (dateTimes == s_ZeroDateTime || dateTimes == s_WindowsNTDateTime)
            {
                return true;
            }

            return false;
        }
        //
        // 摘要:
        //     將 DateTime 格式轉換為西元格式。
        //
        // 參數:
        //   dateString:
        //     Format 的日期字串 。
        //
        //   isUTCTime:
        //     來源是否為 UTC 格式。
        //
        // 傳回:
        //     DateTime 型態，為西元格式時間型態。
        public static DateTime FormatADDataTimeFunction(DateTime dateTime, bool isUTCTime = true)
        {
            DateTime resultDateTime = isUTCTime
                ? Convert.ToDateTime(dateTime.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture))
                : Convert.ToDateTime(dateTime.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            return resultDateTime;
        }
        //
        // 摘要:
        //     將系統時間 (DateTime) 轉換為 MillionSecond。
        //
        // 參數:
        //   dateTimes:
        //     欲轉換的時間格式。
        // 
        //   isUTCTime:
        //     來源是否為 UTC 格式。
        //
        // 傳回:
        //     long 型態，為 UTC 的 MillionSecond。
        public static long ConvertToMillionSecond(DateTime dateTimes, bool isUTCTime = true)
        {
            double millionSecond;
            if (isUTCTime)
            {
                // UTC Time
                millionSecond = dateTimes.Subtract(s_UTCStartTime).TotalMilliseconds;
            }
            else
            {
                // Local Time
                millionSecond = dateTimes.ToUniversalTime().Subtract(s_UTCStartTime).TotalMilliseconds;
            }

            return Convert.ToInt64(millionSecond);
        }
        //
        // 摘要:
        //     將 MillionSecond 轉換為系統時間 (DateTime) 。
        //
        // 參數:
        //   millionSecond:
        //     為 MillionSecond。
        // 
        //   isUTCTime:
        //     是否轉換為 UTC 格式。
        //
        // 傳回:
        //     DateTime 型態，為 UTC / Local 時間型態。
        public static DateTime ConvertMillionSecondToDateTime(long millionSecond, bool convertToLocalTime = false)
        {
            DateTime dateTime = new DateTime(s_UTCStartTime.Ticks);
            dateTime = dateTime.AddMilliseconds(millionSecond);

            if (!convertToLocalTime)
            {
                // UTC Time
                return dateTime;
            }
            else
            {
                // Local Time
                return dateTime.ToLocalTime();
            }
        }
        //
        // 摘要:
        //     將 Data String 轉換為系統時間 (DateTime) 。
        //
        // 參數:
        //   dateString:
        //     Format 的日期字串 。
        //
        //   dateFormat:
        //     日期的格式。
        // 
        //   isUTCTime:
        //     來源是否為 UTC 格式。
        //
        // 傳回:
        //     DateTime 型態，為 UTC 時間型態。
        public static DateTime ConvertStringToDateTime(string dateString, string dateFormat, bool isUTCTime = false)
        {
            DateTime dateTime = isUTCTime
                ? DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture)
                : DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture).ToUniversalTime();
            return dateTime;
        }
    }
}

namespace AviBlog.Core.Helpers
{
    using System;

    public static class DateTimeHelper
    {
         public static string DateToStringInMinutes(this DateTime dateTime)
         {
             return dateTime.ToString("yyyyMMddHHmm");
         }
    }
}
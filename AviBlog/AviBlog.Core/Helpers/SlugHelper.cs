using System.Text.RegularExpressions;

namespace AviBlog.Core.Helpers
{
    public static class SlugHelper
    {

        public static string ToSlug(this string text,int maxLength = 75)
        {
            var str = text.ToLower();
            // invalid chars, make into spaces
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces/hyphens into one space       
            str = Regex.Replace(str, @"[\s-]+", " ").Trim();
            // cut and trim it
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
            // hyphens
            str = Regex.Replace(str, @"\s", "-");
            return str;
        }
         
    }
}
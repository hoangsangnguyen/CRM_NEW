using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Services.Helper
{
    public static class StringExtensions
    {
        public static string[] SplitIds(this string value)
        {
            return value.IsNullOrEmpty() ? new string[] { }
                : value.Split(SharedValues.Delimiter);
        }
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static int[] SplitIntIds(this string value)
        {
            var ids = value.SplitIds();
            return ids.Select(x => Convert.ToInt32(x)).ToArray();
        }
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static string ToIds(this IEnumerable<string> source)
        {
            if (source == null || !source.Any()) return "";
            return string.Join(SharedValues.DelimiterString, source);
        }
        public static string ToIds(this IEnumerable<int> source)
        {
            if (source == null || !source.Any()) return "";
            return string.Join(SharedValues.DelimiterString, source);
        }
	    public static string ConvertToUnSign(this string s)
	    {
		    var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
		    var temp = s.Normalize(NormalizationForm.FormD);
		    return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
	    }
	    public static string CreateSlug(this string source)
	    {
		    var regex = new Regex(@"([^a-z0-9\-]?)");
		    var slug = "";

		    if (string.IsNullOrEmpty(source)) return slug;
		    slug = source.Trim().ToLower();
		    slug = slug.Replace(' ', '-');
		    slug = slug.Replace("---", "-");
		    slug = slug.Replace("--", "-");
		    slug = regex.Replace(slug, "");

		    if (slug.Length * 2 < source.Length)
			    return "";

		    if (slug.Length > 100)
			    slug = slug.Substring(0, 100);
		    return slug;
	    }
		public static string TruncWholeWord(this string sourceString, int maxLenght, bool addDots = true)
	    {
		    if (IsNullOrEmpty(sourceString) || sourceString.Length < maxLenght)
			    return sourceString;
		    var nextSpace = sourceString.LastIndexOf(" ", maxLenght, StringComparison.Ordinal);
		    var dots = (addDots) ? "..." : "";

		    return $"{sourceString.Substring(0, (nextSpace > 0) ? nextSpace : maxLenght).Trim()}{dots}";
	    }
	}
}

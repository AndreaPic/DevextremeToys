using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.Strings
{
    public static partial class StringExtensions
    {
        public static string ReplaceLast(this string sourceString, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (!string.IsNullOrWhiteSpace(oldValue))
            {
                int lastIndex = sourceString.LastIndexOf(oldValue, comparisonType);
                if (lastIndex != -1)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(sourceString.Substring(0, lastIndex));
                    stringBuilder.Append(newValue);
                    stringBuilder.Append(sourceString.Substring(lastIndex + (oldValue != null ? oldValue.Length : 0)));
                    return stringBuilder.ToString();
                }
            }
            return sourceString;
        }
        public static string ReplaceLast(this string sourceString, string oldValue, string newValue)
        {
            return sourceString.ReplaceLast(oldValue, newValue, StringComparison.Ordinal);
        }
        public static string ReplaceLast(this string sourceString, string oldValue, string newValue, bool ignoreCase)//, CultureInfo? culture)
        {
            return sourceString.ReplaceLast(oldValue, newValue, ignoreCase? StringComparison.OrdinalIgnoreCase:StringComparison.Ordinal);
        }

        public static string ReplaceFirst(this string sourceString, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (!string.IsNullOrWhiteSpace(oldValue))
            {
                int index = sourceString.IndexOf(oldValue, comparisonType);
                if (index != -1)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(sourceString.Substring(0, index));
                    stringBuilder.Append(newValue);
                    stringBuilder.Append(sourceString.Substring(index + (oldValue != null ? oldValue.Length : 0)));
                    return stringBuilder.ToString();
                }
            }
            return sourceString;
        }
        public static string ReplaceFirst(this string sourceString, string oldValue, string newValue)
        {
            return sourceString.ReplaceFirst(oldValue, newValue, StringComparison.Ordinal);
        }
        public static string ReplaceFirst(this string sourceString, string oldValue, string newValue, bool ignoreCase)//, CultureInfo? culture)
        {
            return sourceString.ReplaceFirst(oldValue, newValue, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }


    }
}

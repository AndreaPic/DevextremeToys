using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.Strings
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Return reverse value of a string
        /// </summary>
        /// <param name="sourceString">String to reverse</param>
        /// <returns>Reversed string</returns>
        public static string ReverseString(this string sourceString)
        {
            string ret = null;
            if (!string.IsNullOrWhiteSpace(sourceString))
            {
                var ic = sourceString.Reverse();
                StringBuilder sb = new StringBuilder(ic.Count());
                foreach (var c in ic)
                {
                    sb.Append(c);
                }
                ret = sb.ToString();
            }
            return ret;
        }
    }
}

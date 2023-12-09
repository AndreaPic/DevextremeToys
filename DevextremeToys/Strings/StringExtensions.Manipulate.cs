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
        public static string? ReverseString(this string sourceString)
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

        /// <summary>
        /// Pad a string with specified character to reach a specified string length
        /// </summary>
        /// <param name="sourceString">String to pad</param>
        /// <param name="padChar">Char to use for padding</param>
        /// <param name="outputStringLen">Requested output string length</param>
        /// <returns>String padded with specified char with the requested length</returns>
        /// <remarks>
        /// Please, for your self, don't fill with blanks ;)
        /// </remarks>
        public static string? PadRight(this string sourceString, char padChar, int outputStringLen)
        {
            return Pad(sourceString, padChar, outputStringLen, false);
        }
        /// <summary>
        /// Pad a string with specified character to reach a specified string length
        /// </summary>
        /// <param name="sourceString">String to pad</param>
        /// <param name="padChar">Char to use for padding</param>
        /// <param name="outputStringLen">Requested output string length</param>
        /// <returns>String padded with specified char with the requested length</returns>
        /// <remarks>
        /// Please, for your self, don't fill with blanks ;)
        /// </remarks>
        public static string? PadLeft(this string sourceString, char padChar, int outputStringLen)
        {
            return Pad(sourceString,padChar,outputStringLen,true);
        }
        
        /// <summary>
        /// Pad a string with specified character to reach a specified string length
        /// </summary>
        /// <param name="sourceString">String to pad</param>
        /// <param name="padChar">Char to use for padding</param>
        /// <param name="outputStringLen">Requested output string length</param>
        /// <param name="isLeft">If true the string is padded to the left, if false to the right</param>
        /// <returns>String padded with specified char with the requested length</returns>
        private static string? Pad(string sourceString, char padChar, int outputStringLen,bool isLeft)
        {
            string ret = null;
            if (!string.IsNullOrWhiteSpace(sourceString) && (sourceString.Length < outputStringLen))
            {
                int padQuantity = outputStringLen - sourceString.Length;
                string padding = new string(padChar, padQuantity);
                StringBuilder sb = new StringBuilder();
                if (isLeft)
                {
                    sb.Append(padding);
                    sb.Append(sourceString);
                }
                else
                {
                    sb.Append(sourceString);
                    sb.Append(padding);
                }

                ret = sb.ToString();
            }
            return ret;
        }

    }
}

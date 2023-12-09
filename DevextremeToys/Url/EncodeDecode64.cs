using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.Url
{
    /// <summary>
    /// Utility to Encode and Decode valid URL to and from base 64 string
    /// </summary>
    public static class EncodeDecode64StringExtension
    {
        /// <summary>
        /// Create valid url base 64 encoded from string
        /// </summary>
        /// <param name="source">string to encode</param>
        /// <returns>encoded url friendly string</returns>
        public static string EncodeURL64(this string source)
        {
            var bytes = Encoding.UTF8.GetBytes(source);
            return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        /// <summary>
        /// Decode url base 64 encoded string
        /// </summary>
        /// <param name="encoded">encoded base 64 string to decode</param>
        /// <returns>Decoded string</returns>
        public static string DecodeURL64(this string encoded)
        {
            encoded = encoded.Replace('-', '+').Replace('_', '/');
            var d = encoded.Length % 4;
            if (d != 0)
            {
                encoded = encoded.TrimEnd('=');
                encoded += d % 2 > 0 ? "=" : "==";
            }
            byte[] bytes = Convert.FromBase64String(encoded);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DevExtremeToys.Strings
{
    public static partial class StringExtensions
    {
        private static void ValidateEncryptDecryptArguments(string sourceString, string key, string iv)
        {
            if (sourceString == null || sourceString.Length <= 0)
                throw new ArgumentException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentException("iv");
            int keyLen = Encoding.UTF8.GetByteCount(key)*8;
            if ( (keyLen != 128) && (keyLen != 192) && (keyLen != 256) )
            {
                throw new ArgumentException("key string must be 16,24,32 length");
            }
            int ivLen = Encoding.UTF8.GetByteCount(iv)*8;
            if (ivLen != 128) 
            {
                throw new ArgumentException("iv string must be 16 length");
            }
        }

        /// <summary>
        /// Encrypt current string value
        /// </summary>
        /// <param name="plainString">String to encrypt</param>
        /// <param name="keyString">The secret key to use for the AES algorithm. The key length must be 16, 24 or 32.</param>
        /// <param name="ivString">The initialization vector to use for the AES algorithm, must be 16 length.</param>
        /// <returns>Encrypted string</returns>
        public static string AesEncrypt(this string plainString, [NotNull] string keyString, [NotNull] string ivString)
        {
            string ret;

            ValidateEncryptDecryptArguments(plainString, keyString, ivString);
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = Encoding.UTF8.GetBytes(ivString);

            using (Aes aesAlg = Aes.Create())
            {
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(key, iv);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {                        
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainString);
                        }
                        var encrypted = msEncrypt.ToArray();
                        ret = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Decrypt encrypted string
        /// </summary>
        /// <param name="cipherText">Encrypted string</param>
        /// <param name="keyString">The secret key to use for the AES algorithm. The key length must be 16, 24 or 32.</param>
        /// <param name="ivString">The initialization vector to use for the AES algorithm, must be 16 length.</param>
        /// <returns>Decrypted string</returns>
        public static string AesDecrypt(this string cipherText, [NotNull] string keyString, [NotNull] string ivString)
        {
            ValidateEncryptDecryptArguments(cipherText, keyString, ivString);
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = Encoding.UTF8.GetBytes(ivString);

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(key, iv);

                byte[] bytes = Convert.FromBase64String(cipherText);

                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}

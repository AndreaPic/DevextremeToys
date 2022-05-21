using DevExtremeToys.Serialization;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.Compression
{
    /// <summary>
    /// Extension class for zip and unzip objects
    /// </summary>
    public static class ZipExtensions
    {
        /// <summary>
        /// Zip any serializable object
        /// </summary>
        /// <param name="obj">extended object</param>
        /// <returns>byte array of gzipped object</returns>
        public static byte[] Zip(this object obj)
        {
            byte[] bytes = obj.ToUTF8ByteArray();

            using (MemoryStream msi = new MemoryStream(bytes))
            {
                using (MemoryStream mso = new MemoryStream())
                {
                    using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    {
                        msi.CopyTo(gs);
                    }

                    return mso.ToArray();
                }
            }
        }

        /// <summary>
        /// UnZip a byte array of a zipped object and deserialize the object
        /// </summary>
        /// <param name="bytes">byte array of zipped object</param>
        /// <typeparam name="T">Deserialized Type</typeparam>
        /// <returns>Uncompressed and deserialized object</returns>
        public static T Unzip<T>(this byte[] bytes)
        {
            using (MemoryStream msi = new MemoryStream(bytes))
            {
                using (MemoryStream mso = new MemoryStream())
                {
                    using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                    {
                        gs.CopyTo(mso);
                    }

                    return mso.ToArray().ObjectFromUF8ByteArray<T>();
                }
            }
        }
    }
}

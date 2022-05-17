using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace DevExtremeToys.Serialization
{
    /// <summary>
    /// Extension to serialize and deserialize any serializable objects
    /// </summary>
    public static class SerializerExtensions
    {
        /// <summary>
        /// Get JsonSerializerSettings from JsonConvert.DefaultSettings 
        /// and if it is null create a new instance of JsonSerializerSettings
        /// </summary>
        /// <returns>JsonSerializerSettings</returns>
        private static JsonSerializerSettings GetJSonSerializationSettings()
        {
            JsonSerializerSettings jsonsettings = null;
            if (JsonConvert.DefaultSettings == null)
            {
                jsonsettings = new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                    NullValueHandling = NullValueHandling.Ignore
                };
            }
            else
            {
                jsonsettings = JsonConvert.DefaultSettings();
            }

            return jsonsettings;
        }

        /// <summary>
        /// Serialize object to JSon then to a byte array
        /// </summary>
        /// <typeparam name="T">Type to serialize</typeparam>
        /// <param name="objectToSerialize">Instance to serialize</param>
        /// <returns>byte array result from object serialization</returns>
        /// <remarks>Serialization use JsonConvert.DefaultSettings and UTF8 to convert object in bytearray</remarks>
        public static byte[] ToUTF8ByteArray<T>(this T objectToSerialize)
        {
            JsonSerializerSettings jsonsettings = GetJSonSerializationSettings();
            return ToUTF8ByteArray(objectToSerialize, jsonsettings);
        }

        /// <summary>
        /// Serialize object to JSon then to a byte array
        /// </summary>
        /// <typeparam name="T">Type to serialize</typeparam>
        /// <param name="objectToWrite">Instance to serialize</param>
        /// <param name="jsonsettings">Settins used for serialization</param>
        /// <returns>byte array result from object serialization</returns>
        /// <remarks>Serialization use JsonConvert.DefaultSettings and UTF8 to convert object in bytearray</remarks>
        public static byte[] ToUTF8ByteArray<T>(this T objectToWrite, JsonSerializerSettings jsonsettings)
        {
            var json = JsonConvert.SerializeObject(objectToWrite, jsonsettings);
            return Encoding.UTF8.GetBytes(json);
        }

        /// <summary>
        /// Deserialize a byte array of utf8 string of serialized object
        /// </summary>
        /// <typeparam name="T">Typo to deserialize</typeparam>
        /// <param name="arr">byte array of serialed object</param>
        /// <returns>Deserialized object</returns>
        /// <remarks>bytearray need to be created with UTF8 and JsonConvert.DefaultSettings</remarks>
        public static T FromUF8ByteArray<T>(this byte[] arr)
        {
            JsonSerializerSettings jsonsettings = GetJSonSerializationSettings();
            return arr.FromUF8ByteArray<T>(jsonsettings);
        }

        /// <summary>
        /// Deserialize a byte array of utf8 string of serialized object
        /// </summary>
        /// <typeparam name="T">Typo to deserialize</typeparam>
        /// <param name="arr">byte array of serialed object</param>
        /// <returns>Deserialized object</returns>
        /// <remarks>bytearray need to be created with UTF8 and JsonConvert.DefaultSettings</remarks>
        public static T FromUF8ByteArray<T>(this byte[] arr, JsonSerializerSettings jsonsettings)
        {
            var json = Encoding.UTF8.GetString(arr);
            T ret = JsonConvert.DeserializeObject<T>(json, jsonsettings);
            return ret;
        }

        /// <summary>
        /// Deserialize a byte array of serialized object
        /// </summary>
        /// <param name="arr">byte array of serialed object</param>
        /// <returns>Deserialized object</returns>
        public static object ObjectFromUF8ByteArray(this byte[] arr)
        {
            object obj = arr.FromUF8ByteArray<object>();
            return obj;
        }

        /// <summary>
        /// Deserialize a byte array of serialized object
        /// </summary>
        /// <param name="arr">byte array of serialed object</param>
        /// <returns>Deserialized object</returns>
        public static object ObjectFromUF8ByteArray(this byte[] arr, JsonSerializerSettings jsonsettings)
        {
            object obj = arr.FromUF8ByteArray<object>(jsonsettings);
            return obj;
        }
    }
}

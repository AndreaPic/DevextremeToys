using Newtonsoft.Json;
using System;

namespace DevExtremeToys.JSon
{
    /// <summary>
    /// Extensions for json serialization
    /// </summary>
    public static class JSonExtensions
    {
        /// <summary>
        /// Create a JSon string for the object
        /// </summary>
        /// <param name="source">objecto to serialize in json</param>
        /// <returns>json rapresentation of the object</returns>
        public static string ToJSon(this object source)
        {
            var json = JsonConvert.SerializeObject(source);
            return json;
        }

        /// <summary>
        /// Create a JSon string for the object
        /// </summary>
        /// <param name="source">objecto to serialize in json</param>
        /// <param name="settings">setting for json serialization</param>
        /// <returns>json rapresentation of the object</returns>
        public static string ToJSon(this object source, JsonSerializerSettings settings)
        {
            var json = JsonConvert.SerializeObject(source, settings);
            return json;
        }

        /// <summary>
        /// Deserialize object form json
        /// </summary>
        /// <typeparam name="TObject">Object type</typeparam>
        /// <param name="json">JSon for the object</param>
        /// <returns>Deserialized Object</returns>
        public static TObject ToObject<TObject>(this string json)
        {
            TObject ret = JsonConvert.DeserializeObject<TObject>(json);
            return ret;
        }

        /// <summary>
        /// Deserialize object form json
        /// </summary>
        /// <param name="json">JSon for the object</param>
        /// <param name="outputType">Object type</param>
        /// <returns>Deserialized Object</returns>
        public static object? ToObject(this string json, Type outputType)
        {
            object? ret = JsonConvert.DeserializeObject(json, outputType);
            return ret;
        }

        /// <summary>
        /// Deserialize object form json
        /// </summary>
        /// <typeparam name="TObject">Object type</typeparam>
        /// <param name="json">JSon for the object</param>
        /// <param name="settings">Settings used in deserialization</param>
        /// <returns>Deserialized Object</returns>
        public static TObject ToObject<TObject>(this string json, JsonSerializerSettings settings)
        {
            TObject ret = JsonConvert.DeserializeObject<TObject>(json, settings);
            return ret;
        }

        /// <summary>
        /// Deserialize object form json
        /// </summary>
        /// <param name="json">JSon for the object</param>
        /// <param name="outputType">Object type</param>
        /// <param name="settings"></param>
        /// <param name="settings">Settings used in deserialization</param>
        /// <returns>Deserialized Object</returns>
        public static object? ToObject(this string json, Type outputType, JsonSerializerSettings settings)
        {
            object? ret = JsonConvert.DeserializeObject(json, outputType, settings);
            return ret;
        }

    }
}
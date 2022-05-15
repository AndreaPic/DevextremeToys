using Newtonsoft.Json;

namespace DevExtremeToys.JSon
{
    public static class ObjectExtensions
    {
        public static string ToJSon(this object source)
        {
            var json = JsonConvert.SerializeObject(source);
            return json;
        }
        public static string ToJSon(this object source, JsonSerializerSettings settings)
        {
            var json = JsonConvert.SerializeObject(source, settings);
            return json;
        }
    }
}
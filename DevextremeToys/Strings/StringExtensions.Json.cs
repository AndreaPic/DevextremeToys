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
        public static TObject? JsonToObject<TObject>(this string json)
        {
            TObject? ret = JsonConvert.DeserializeObject<TObject>(json);
            return ret;
        }

        public static object? JsonToObject(this string json, Type outputType)
        {
            object? ret = JsonConvert.DeserializeObject(json, outputType);
            return ret;
        }

        public static TObject? JsonToObject<TObject>(this string json, JsonSerializerSettings settings)
        {
            TObject? ret = JsonConvert.DeserializeObject<TObject>(json, settings);
            return ret;
        }

        public static object? JsonToObject(this string json, Type outputType, JsonSerializerSettings settings)
        {
            object? ret = JsonConvert.DeserializeObject(json, outputType, settings);
            return ret;
        }


    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace Angular.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void Configure(HttpConfiguration config)
        {
            //var formatter = config.Formatters.FirstOrDefault(f => f.SupportedMediaTypes.Any(v => v.MediaType.Equals("application/xml", StringComparison.CurrentCultureIgnoreCase)));
            //if (formatter != null)
            //{
            //    config.Formatters.Remove(formatter);
            //}
            //JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

            //serializerSettings.Converters.Add(new IsoDateTimeConverter());

            //config.Formatters.Add(new JsonNetFormatter(serializerSettings));

            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new CustomDateTimeConverter());
        }
    }

    //public class CustomDateTimeConverter : DateTimeConverterBase//IsoDateTimeConverter
    //{

    //    /// <summary>
    //    /// DateTime format
    //    /// </summary>
    //    private const string Format = "MM/dd/yyyy hh:mm:ss.fff";

    //    /// <summary>
    //    /// Writes value to JSON
    //    /// </summary>
    //    /// <param name="writer">JSON writer</param>
    //    /// <param name="value">Value to be written</param>
    //    /// <param name="serializer">JSON serializer</param>
    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        writer.WriteValue(((DateTime)value).ToString(Format));
    //    }

    //    /// <summary>
    //    /// Reads value from JSON
    //    /// </summary>
    //    /// <param name="reader">JSON reader</param>
    //    /// <param name="objectType">Target type</param>
    //    /// <param name="existingValue">Existing value</param>
    //    /// <param name="serializer">JSON serialized</param>
    //    /// <returns>Deserialized DateTime</returns>
    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.Value == null)
    //        {
    //            return null;
    //        }

    //        var s = reader.Value.ToString();
    //        DateTime result;
    //        if (DateTime.TryParseExact(s, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
    //        {
    //            return result;
    //        }

    //        return DateTime.Now;
    //    }
    //}
    //public class JsonNetFormatter : MediaTypeFormatter
    //{
    //    public JsonNetFormatter()
    //    {
    //        SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
    //    }

    //    public override bool CanWriteType(Type type)
    //    {
    //        // don't serialize JsonValue structure use default for that
    //        if (type == typeof(JValue) || type == typeof(JObject) || type == typeof(JArray))
    //            return false;

    //        return true;
    //    }

    //    public override bool CanReadType(Type type)
    //    {
    //        return true;
    //    }

    //    public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type,
    //                                                        Stream stream,
    //                                                        HttpContent content,
    //                                                        IFormatterLogger formatterLogger)
    //    {
    //        var task = Task<object>.Factory.StartNew(() =>
    //        {
    //            var settings = new JsonSerializerSettings()
    //            {
    //                NullValueHandling = NullValueHandling.Ignore,
    //            };

    //            var sr = new StreamReader(stream);
    //            var jreader = new JsonTextReader(sr);

    //            var ser = new JsonSerializer();
    //            ser.Converters.Add(new IsoDateTimeConverter());

    //            object val = ser.Deserialize(jreader, type);
    //            return val;
    //        });

    //        return task;
    //    }

    //    public override Task WriteToStreamAsync(Type type, object value,
    //                                            Stream stream,
    //                                            HttpContent content,
    //                                            TransportContext transportContext)
    //    {
    //        var task = Task.Factory.StartNew(() =>
    //        {
    //            var settings = new JsonSerializerSettings()
    //            {
    //                NullValueHandling = NullValueHandling.Ignore,
    //            };

    //            string json = JsonConvert.SerializeObject(value, Formatting.Indented,
    //                                                      new JsonConverter[1] { new IsoDateTimeConverter() });

    //            byte[] buf = System.Text.Encoding.Default.GetBytes(json);
    //            stream.Write(buf, 0, buf.Length);
    //            stream.Flush();
    //        });

    //        return task;
    //    }
    //}
}

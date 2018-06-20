using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AzureApplicationInsightsKit.Models
{
    public partial class Metric
    {
        [JsonProperty("value")]
        public Value Value { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }

        [JsonProperty("requests/duration")]
        public RequestsDuration RequestsDuration { get; set; }
    }

    public partial class RequestsDuration
    {
        [JsonProperty("avg")]
        public double Avg { get; set; }
    }

    public partial class Metric
    {
        public static Metric FromJson(string json) => JsonConvert.DeserializeObject<Metric>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Metric self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            },
        };
    }
}

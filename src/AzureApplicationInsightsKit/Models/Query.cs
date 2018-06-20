using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AzureApplicationInsightsKit.Models
{
    public partial class Query
    {
        [JsonProperty("tables")]
        public List<Table> Tables { get; set; }
    }

    public partial class Table
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }

        [JsonProperty("rows")]
        public List<List<long>> Rows { get; set; }
    }

    public partial class Column
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
    }

    public enum TypeEnum { Datetime, Dynamic, Int, Real, String, Long };

    public partial class Query
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public static Query FromJson(string json) => JsonConvert.DeserializeObject<Query>(json, Settings);
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "datetime":
                    return TypeEnum.Datetime;
                case "dynamic":
                    return TypeEnum.Dynamic;
                case "int":
                    return TypeEnum.Int;
                case "real":
                    return TypeEnum.Real;
                case "string":
                    return TypeEnum.String;
                case "long":
                    return TypeEnum.Long;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Datetime:
                    serializer.Serialize(writer, "datetime");
                    return;
                case TypeEnum.Dynamic:
                    serializer.Serialize(writer, "dynamic");
                    return;
                case TypeEnum.Int:
                    serializer.Serialize(writer, "int");
                    return;
                case TypeEnum.Real:
                    serializer.Serialize(writer, "real");
                    return;
                case TypeEnum.String:
                    serializer.Serialize(writer, "string");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}

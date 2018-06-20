using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AzureApplicationInsightsKit.Models
{
    public partial class Event
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("@ai.messages")]
        public List<AiMessage> AiMessages { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }

    public partial class AiMessage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("dependency")]
        public Dependency Dependency { get; set; }

        [JsonProperty("customDimensions")]
        public CustomDimensions CustomDimensions { get; set; }

        [JsonProperty("customMeasurements")]
        public object CustomMeasurements { get; set; }

        [JsonProperty("operation")]
        public Operation Operation { get; set; }

        [JsonProperty("session")]
        public Session Session { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("cloud")]
        public Cloud Cloud { get; set; }

        [JsonProperty("ai")]
        public Ai Ai { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }
    }

    public partial class Ai
    {
        [JsonProperty("iKey")]
        public string IKey { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("sdkVersion")]
        public string SdkVersion { get; set; }
    }

    public partial class Application
    {
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public partial class Client
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("browser")]
        public string Browser { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateOrProvince")]
        public string StateOrProvince { get; set; }

        [JsonProperty("countryOrRegion")]
        public string CountryOrRegion { get; set; }
    }

    public partial class Cloud
    {
        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("roleInstance")]
        public string RoleInstance { get; set; }
    }

    public partial class CustomDimensions
    {
        [JsonProperty("AspNetCoreEnvironment")]
        public string AspNetCoreEnvironment { get; set; }

        [JsonProperty("Container")]
        public string Container { get; set; }

        [JsonProperty("Blob", NullValueHandling = NullValueHandling.Ignore)]
        public string Blob { get; set; }
    }

    public partial class Dependency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("performanceBucket")]
        public string PerformanceBucket { get; set; }

        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Operation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("syntheticSource")]
        public string SyntheticSource { get; set; }
    }

    public partial class Session
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("authenticatedId")]
        public string AuthenticatedId { get; set; }
    }

    public partial class Event
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

        public static Event FromJson(string json) => JsonConvert.DeserializeObject<Event>(json, Settings);
    }
}

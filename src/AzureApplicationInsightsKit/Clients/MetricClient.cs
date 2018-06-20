using System.Threading.Tasks;
using AzureApplicationInsightsKit.Builders;
using AzureApplicationInsightsKit.Models;

namespace AzureApplicationInsightsKit.Clients
{
    /// <summary>
    /// Client for gather Metrics from App Insights API
    /// </summary>
    public class MetricClient : IMetricClient
    {
        private string metric;
        private string timespan;

        private readonly BaseUrlBuilder baseUrlBuilder;
        private readonly string appId;
        private readonly string apiKey;

        public MetricClient(string appId, string apiKey)
        {
            this.appId = appId;
            this.apiKey = apiKey;
            baseUrlBuilder = new BaseUrlBuilder();
        }

        /// <summary>
        /// With the requests duration metric.
        /// </summary>
        /// <returns></returns>
        public MetricClient WithRequestsDurationMetric()
        {
            metric = $"requests/duration";
            return this;
        }

        /// <summary>
        /// Withes the last one day time span.
        /// </summary>
        /// <returns></returns>
        public MetricClient WithTimeSpan(TimeSpan timeSpan)
        {
            this.timespan = Utils.GetTimeSpan(timeSpan);

            return this;
        }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetJson()
        {
            string query = $"metrics/{metric}?timespan={timespan}";

            string url = baseUrlBuilder.With(appId, apiKey, query).Build();

            return await TelemetryClient.GetTelemetry(url, apiKey);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<Metric> Get()
        {
            string json = await GetJson();

            Utils.ValidatateResponseString(json);

            return Metric.FromJson(json);
        }
    }
}
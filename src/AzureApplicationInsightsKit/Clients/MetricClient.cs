using System.Threading.Tasks;
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

        private readonly string appId;
        private readonly string apiKey;

        private const string RequestDuration = "requests/duration";

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        private string Query => $"metrics/{metric}?timespan={timespan}";

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricClient"/> class.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="apiKey">The API key.</param>
        public MetricClient(string appId, string apiKey)
        {
            this.appId = appId;
            this.apiKey = apiKey;
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
        /// Gets the request duration metric.
        /// </summary>
        /// <returns></returns>
        public async Task<Metric> GetRequestDurationMetric()
        {
            this.metric = RequestDuration;

            return await new TelemetryClient().GetMetric(Query, appId, apiKey);
        }
    }
}
using System.Threading.Tasks;
using AzureApplicationInsightsKit.Builders;
using AzureApplicationInsightsKit.Models;
using TimeSpan = AzureApplicationInsightsKit.Models.TimeSpan;

namespace AzureApplicationInsightsKit.Clients
{
    /// <summary>
    /// Client for gather data by Query from Azure App Insights API
    /// </summary>
    public class QueryClient : IQueryClient
    {
        private string timespan;
        private string query;

        private readonly string appId;
        private readonly string apiKey;

        private readonly BaseUrlBuilder baseUrlBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryClient"/> class.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="apiKey">The API key.</param>
        public QueryClient(string appId, string apiKey)
        {
            this.appId = appId;
            this.apiKey = apiKey;
            baseUrlBuilder = new BaseUrlBuilder();
        }

        /// <summary>
        /// With the timespan.
        /// </summary>
        /// <returns>Metrics Builder</returns>
        public QueryClient WithTimespan(TimeSpan timeSpan)
        {
            this.timespan = $"timespan={Utils.GetTimeSpan(timeSpan)}";
            return this;
        }

        /// <summary>
        /// With the query.
        /// </summary>
        /// <param name="newQuery">The new street.</param>
        /// <returns>Metrics Builder</returns>
        public QueryClient WithQuery(string newQuery)
        {
            this.query = newQuery;
            return this;
        }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetJson()
        {
            string queryUrl = $"query?{timespan}&query={query}";

            string url = baseUrlBuilder.With(appId, apiKey, queryUrl).Build();

            return await TelemetryClient.GetTelemetry(url, apiKey);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<Query> Get()
        {
            string json = await GetJson();

            Utils.ValidatateResponseString(json);

            return Query.FromJson(json);
        }
    }
}
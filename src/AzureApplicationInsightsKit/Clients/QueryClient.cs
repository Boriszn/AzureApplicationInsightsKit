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
        private string appInsightsQuery;

        private readonly string appId;
        private readonly string apiKey;

        private readonly BaseUrlBuilder baseUrlBuilder;

        /// <summary>
        /// Gets the URL with query.
        /// </summary>
        /// <value>
        /// The URL with query.
        /// </value>
        private string UrlWithQuery => $"query?{timespan}&query={appInsightsQuery}";

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
        /// Gets the by query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<Query> GetByQuery(string query)
        {
            this.appInsightsQuery = query;

            return await new TelemetryClient().GetByQuery(UrlWithQuery, appId, apiKey);
        }
    }
}
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AzureApplicationInsightsKit.Builders;
using AzureApplicationInsightsKit.Models;

namespace AzureApplicationInsightsKit.Clients
{
    /// <summary>
    /// Http clinent which make calls to Aplication insights API
    /// </summary>
    internal class TelemetryClient
    {
        private const string ApiKeyHeader = "x-api-key";
        private const string JsonMediaType = "application/json";
        private readonly BaseUrlBuilder baseUrlBuilder;

        public TelemetryClient()
        {
            baseUrlBuilder = new BaseUrlBuilder();
        }

        /// <summary>
        /// Gets the telemetry.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <param name="apikey">The apikey.</param>
        /// <returns></returns>
        private static async Task<string> GetTelemetry(string requestUrl, string apikey)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));
                httpClient.DefaultRequestHeaders.Add(ApiKeyHeader, apikey);

                var response = await httpClient.GetAsync(requestUrl);

                return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : response.ReasonPhrase;
            }
        }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="appId">The application identifier.</param>
        /// <param name="apiKey">The API key.</param>
        /// <returns></returns>
        public async Task<string> GetJson(string query, string appId, string apiKey)
        {
            string url = baseUrlBuilder.With(appId, apiKey, query).Build();

            return await GetTelemetry(url, apiKey);
        }

        /// <summary>
        /// Gets the metric.
        /// TODO: create generic method to code duplication
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="appId">The application identifier.</param>
        /// <param name="apiKey">The API key.</param>
        /// <returns></returns>
        public async Task<Metric> GetMetric(string query, string appId, string apiKey)
        {
            string json = await new TelemetryClient().GetJson(query, appId, apiKey);

            Utils.ValidatateResponseString(json);

            return Metric.FromJson(json);
        }

        /// <summary>
        /// Gets the by query.
        /// TODO: create generic method to code duplication
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="appId">The application identifier.</param>
        /// <param name="apiKey">The API key.</param>
        /// <returns></returns>
        public async Task<Query> GetByQuery(string query, string appId, string apiKey)
        {
            string json = await new TelemetryClient().GetJson(query, appId, apiKey);

            Utils.ValidatateResponseString(json);

            return Query.FromJson(json);
        }

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="appId">The application identifier.</param>
        /// <param name="apiKey">The API key.</param>
        /// <returns></returns>
        public async Task<Event> GetEvent(string query, string appId, string apiKey)
        {
            string json = await new TelemetryClient().GetJson(query, appId, apiKey);

            Utils.ValidatateResponseString(json);

            return Event.FromJson(json);
        }
    }
}
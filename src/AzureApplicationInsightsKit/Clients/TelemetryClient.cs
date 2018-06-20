using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureApplicationInsightsKit.Clients
{
    /// <summary>
    /// Http clinent which make calls to Aplication insights API
    /// </summary>
    internal class TelemetryClient
    {
        private const string ApiKeyHeader = "x-api-key";
        private const string JsonMediaType = "application/json";

        /// <summary>
        /// Gets the telemetry.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <param name="apikey">The apikey.</param>
        /// <returns></returns>
        public static async Task<string> GetTelemetry(string requestUrl, string apikey)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));
                httpClient.DefaultRequestHeaders.Add(ApiKeyHeader, apikey);

                var response = await httpClient.GetAsync(requestUrl);

                return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : response.ReasonPhrase;
            }
        }
    }
}
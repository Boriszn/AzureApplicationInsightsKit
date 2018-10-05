namespace AzureApplicationInsightsKit.Builders
{
    /// <summary>
    /// Builds the base URL to Application Insights API
    /// </summary>
    internal class BaseUrlBuilder
    {
        private string baseUrl;

        /// <summary>
        /// Builds the URL.
        /// </summary>
        /// <param name="appid">The appid.</param>
        /// <param name="apikey">The apikey.</param>
        /// <param name="queryType">Type of the query.</param>
        /// <param name="queryPath">The query path.</param>
        /// <param name="parameterString">The parameter string.</param>
        /// <returns></returns>
        public string BuildUrl(string appid, string apikey, string queryType, string queryPath, string parameterString)
        {
            return $"https://{Constants.BaseApplicationinsightsUrl}/{appid}/{queryType}{queryPath}?{parameterString}";
        }

        /// <summary>
        /// Withes the specified appid.
        /// </summary>
        /// <param name="appid">The appid.</param>
        /// <param name="apikey">The apikey.</param>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public BaseUrlBuilder With(string appid, string apikey, string query)
        {
            baseUrl = $"https://{Constants.BaseApplicationinsightsUrl}/{appid}/{query}";
            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return baseUrl;
        }
    }
}
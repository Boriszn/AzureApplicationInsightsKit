using System.Text;
using System.Threading.Tasks;
using AzureApplicationInsightsKit.Builders;
using AzureApplicationInsightsKit.Models;
using TimeSpan = AzureApplicationInsightsKit.Models.TimeSpan;

namespace AzureApplicationInsightsKit.Clients
{
    /// <summary>
    /// Client for gather Events 
    /// </summary>
    public class EventsClient : IEventsClient
    {
        private string eventUrl;
        private string timespan;
        private string top;

        private readonly string appId;
        private readonly string apiKey;
        

        private const string EventEntityKey = "events";

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsClient"/> class.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="apiKey">The API key.</param>
        public EventsClient(string appId, string apiKey)
        {
            this.appId = appId;
            this.apiKey = apiKey;

            WithTimeSpan(TimeSpan.Last1Day);
        }

        /// <summary>
        /// With the requests duration eventUrl.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithAll()
        {
            eventUrl = $"{EventEntityKey}/$all";
            return this;
        }

        /// <summary>
        /// With the requests duration eventUrl.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithTraces()
        {
            eventUrl = $"{EventEntityKey}/traces";
            return this;
        }

        /// <summary>
        /// With the last one day time span.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithTimeSpan(TimeSpan timeSpan)
        {
            this.timespan = $"timespan={Utils.GetTimeSpan(timeSpan)}";
            return this;
        }

        /// <summary>
        /// Withes the top.
        /// </summary>
        /// <param name="selectTop">The Top numbers off selected items.</param>
        /// <returns></returns>
        public EventsClient WithTop(int selectTop)
        {
            this.top = $"$top={selectTop}";
            return this;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<Event> GetEvents()
        {
            var queryBuilder = new StringBuilder();

            queryBuilder.Append($"{eventUrl}?{timespan}");
            
            AppendQueryParameters(queryBuilder);

            return await new TelemetryClient().GetEvent(queryBuilder.ToString(), appId, apiKey);
        }

        /// <summary>
        /// Appends the query parameters.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        private void AppendQueryParameters(StringBuilder queryBuilder)
        {
            // append '$top' numebert to select
            if (!string.IsNullOrEmpty(top))
            {
                queryBuilder.Append($"&{top}");
            }
        }
    }
}
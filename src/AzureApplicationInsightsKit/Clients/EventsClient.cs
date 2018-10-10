using System.Text;
using System.Threading.Tasks;
using AzureApplicationInsightsKit.Models;
using TimeSpan = AzureApplicationInsightsKit.Models.TimeSpan;

namespace AzureApplicationInsightsKit.Clients
{
    /// <summary>
    /// Client for gather Events from 
    /// https://dev.applicationinsights.io/documentation/Using-the-API/Events
    /// </summary>
    public class EventsClient : IEventsClient
    {
        private string eventUrl;
        private string timespan;
        private string top;

        private readonly string appId;
        private readonly string apiKey;
        private string count;
        private string skip;
        private string filter;
        private string select;
        private string search;

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
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/$all";
            return this;
        }

        /// <summary>
        /// With the requests duration eventUrl.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithTraces()
        {
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/traces";
            return this;
        }

        /// <summary>
        /// Withes the requests.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithRequests()
        {
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/requests";
            return this;
        }

        /// <summary>
        /// With the page views.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithPageViews()
        {
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/pageViews";
            return this;
        }

        /// <summary>
        /// With the exceptions.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithExceptions()
        {
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/exceptions";
            return this;
        }

        /// <summary>
        /// With the dependencies.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithDependencies()
        {
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/dependencies";
            return this;
        }

        /// <summary>
        /// With the custom events.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithCustomEvents()
        {
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/customEvents";
            return this;
        }

        /// <summary>
        /// With the availability results.
        /// </summary>
        /// <returns></returns>
        public EventsClient WithAvailabilityResults()
        {
            eventUrl = string.Empty;
            eventUrl = $"{EventEntityKey}/availabilityResults";
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
        /// With the top.
        /// </summary>
        /// <param name="selectTop">The Top numbers off selected items.</param>
        /// <returns></returns>
        public EventsClient WithTop(int selectTop)
        {
            this.top = $"$top={selectTop}";
            return this;
        }

        /// <summary>
        /// With Count
        /// </summary>
        /// <param name="selectCount"></param>
        /// <returns></returns>
        public EventsClient WithCount(int selectCount)
        {
            this.count = string.Empty;
            this.count = $"$count={selectCount}";
            return this;
        }

        /// <summary>
        /// With Skip
        /// </summary>
        /// <param name="selectSkip"></param>
        /// <returns></returns>
        public EventsClient WithSkip(int selectSkip)
        {
            this.skip = string.Empty;
            this.skip = $"$skip={selectSkip}";
            return this;
        }

        /// <summary>
        /// With Filter 
        /// </summary>
        /// <param name="selectFilter"></param>
        /// <returns></returns>
        public EventsClient WithFilter(string selectFilter)
        {
            this.filter = string.Empty;
            this.filter = $"$filter={selectFilter}";
            return this;
        }

        /// <summary>
        /// With Select
        /// </summary>
        /// <param name="inSelect">The select</param>
        /// <returns></returns>
        public EventsClient WithSelect(string inSelect)
        {
            this.select = string.Empty;
            this.select = $"$select={inSelect}";
            return this;
        }

        /// <summary>
        /// With Search
        /// </summary>
        /// <param name="selectSearch">The select search</param>
        /// <returns></returns>
        public EventsClient WithSearch(string selectSearch)
        {
            this.search = string.Empty;
            this.search = $"$search={selectSearch}";
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
            // append '$top' number to select
            if (!string.IsNullOrEmpty(top))
            {
                queryBuilder.Append($"&{top}");
            }

            if (!string.IsNullOrEmpty(count))
            {
                queryBuilder.Append($"&{count}");
            }

            if (!string.IsNullOrEmpty(filter))
            {
                queryBuilder.Append($"&{filter}");
            }

            if (!string.IsNullOrEmpty(skip))
            {
                queryBuilder.Append($"&{skip}");
            }

            if (!string.IsNullOrEmpty(select))
            {
                queryBuilder.Append($"&{select}");
            }

            if (!string.IsNullOrEmpty(search))
            {
                queryBuilder.Append($"&{search}");
            }
        }
    }
}
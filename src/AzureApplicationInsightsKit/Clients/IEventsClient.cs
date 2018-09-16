using System.Threading.Tasks;
using AzureApplicationInsightsKit.Models;
using TimeSpan = AzureApplicationInsightsKit.Models.TimeSpan;

namespace AzureApplicationInsightsKit.Clients
{
    public interface IEventsClient
    {
        /// <summary>
        /// With the requests duration eventUrl.
        /// </summary>
        /// <returns></returns>
        EventsClient WithAll();

        /// <summary>
        /// With the requests duration eventUrl.
        /// </summary>
        /// <returns></returns>
        EventsClient WithTraces();

        /// <summary>
        /// With the last one day time span.
        /// </summary>
        /// <returns></returns>
        EventsClient WithTimeSpan(TimeSpan timeSpan);

        /// <summary>
        /// Withes the top.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns></returns>
        EventsClient WithTop(int top);

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<Event> GetEvents();
    }
}

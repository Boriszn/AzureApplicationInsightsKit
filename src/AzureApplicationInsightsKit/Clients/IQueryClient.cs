using System.Threading.Tasks;
using AzureApplicationInsightsKit.Models;

namespace AzureApplicationInsightsKit.Clients
{
    public interface IQueryClient
    {
        /// <summary>
        /// With the timespan.
        /// </summary>
        /// <returns>Metrics Builder</returns>
        QueryClient WithTimespan(TimeSpan timeSpan);

        /// <summary>
        /// With the query.
        /// </summary>
        /// <param name="newQuery">The new street.</param>
        /// <returns>Metrics Builder</returns>
        QueryClient WithQuery(string newQuery);

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns></returns>
        Task<string> GetJson();

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<Query> Get();
    }
}

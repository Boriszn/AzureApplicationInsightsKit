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
        /// Gets the by query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        Task<Query> GetByQuery(string query);
    }
}

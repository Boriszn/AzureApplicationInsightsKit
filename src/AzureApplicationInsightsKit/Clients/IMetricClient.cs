using System.Threading.Tasks;
using AzureApplicationInsightsKit.Models;
using TimeSpan = AzureApplicationInsightsKit.Models.TimeSpan;

namespace AzureApplicationInsightsKit.Clients
{
    /// <summary>
    /// Metric client interface
    /// </summary>
    public interface IMetricClient
    {
        /// <summary>
        /// With the requests duration metric.
        /// </summary>
        /// <returns></returns>
        MetricClient WithRequestsDurationMetric();

        /// <summary>
        /// Withes the last one day time span.
        /// </summary>
        /// <returns></returns>
        MetricClient WithTimeSpan(TimeSpan timeSpan);

        /// <summary>
        /// Gets the request duration metric.
        /// </summary>
        /// <returns></returns>
        Task<Metric> GetRequestDurationMetric();
    }
}

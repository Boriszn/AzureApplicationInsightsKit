using System;
using AzureApplicationInsightsKit.Exceptions;
using TimeSpan = AzureApplicationInsightsKit.Models.TimeSpan;

namespace AzureApplicationInsightsKit.Clients
{
    internal static class Utils
    {
        /// <summary>
        /// Gets the time span.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">timeSpan - null</exception>
        public static string GetTimeSpan(TimeSpan timeSpan)
        {
            string resultTimeSpan;

            switch (timeSpan)
            {
                case TimeSpan.Last1Day:
                    resultTimeSpan = Constants.Last1Day;
                    break;
                case TimeSpan.Last12Hours:
                    resultTimeSpan = Constants.Last12Hours;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(timeSpan), timeSpan, null);
            }

            return resultTimeSpan;
        }

        /// <summary>
        /// Validatates the response string.
        /// </summary>
        /// <param name="repsonse">The repsonse.</param>
        /// <exception cref="ClientErrorException"></exception>
        public static void ValidatateResponseString(string repsonse)
        {
            string resultResponse = repsonse.ToLower();

            switch (resultResponse)
            {
                case var _ when resultResponse.Contains("bad request"):
                    throw new ClientErrorException(resultResponse);
            }
        }
    }
}

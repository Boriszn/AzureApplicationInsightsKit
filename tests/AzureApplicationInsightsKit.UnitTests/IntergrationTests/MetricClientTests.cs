using AzureApplicationInsightsKit.Clients;
using AzureApplicationInsightsKit.Models;
using FluentAssertions;
using Xunit;

namespace AzureApplicationInsightsKit.UnitTests.IntergrationTests
{
    public class MetricClientTests
    {
        [Fact]
        public async void GetRequestDurationMetric_WithLastOneDayTimeSpan_RetrunEvent()
        {
            // Arrange / Act
            var metricData = await new MetricClient(Constants.AppId, Constants.ApiKey)
                            .WithTimeSpan(TimeSpan.Last1Day)
                            .GetRequestDurationMetric();

            // Assert
            metricData.Should().NotBeNull();
            metricData.Value.RequestsDuration.Avg.Should().NotBe(0);
        }
    }
}

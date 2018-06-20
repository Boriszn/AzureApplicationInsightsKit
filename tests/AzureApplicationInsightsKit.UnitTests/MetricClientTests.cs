using Xunit;
using AzureApplicationInsightsKit.Clients;
using AzureApplicationInsightsKit.Models;
using FluentAssertions;

namespace AzureApplicationInsightsKit.UnitTests
{
    public class MetricClientTests
    {
        [Fact]
        public async void GetDurationMetric_WithLastOneDayTimeSpan_RetrunEvent()
        {
            // Arrange 
            const string AppId = "";
            const string ApiKey = "";

            // Act
            var metricData = await new MetricClient(AppId, ApiKey)
                            .WithTimeSpan(TimeSpan.Last1Day)
                            .WithRequestsDurationMetric()
                            .Get();

            // Assert
            metricData.Should().NotBeNull();
        }
    }
}

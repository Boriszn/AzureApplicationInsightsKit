using AzureApplicationInsightsKit.Clients;
using AzureApplicationInsightsKit.Models;
using FluentAssertions;
using Xunit;

namespace AzureApplicationInsightsKit.UnitTests.IntergrationTests
{
    public class QueryClientTests
    {
        [Fact]
        public async void GetByQuery_WithLastOneDayTimeSpan_RetrunEvent()
        {
            // Arrange 
            string query = "requests\r\n| where timestamp >= ago(24h)\r\n| count";

            // Act
            Query queryData = await new QueryClient(Constants.AppId, Constants.ApiKey)
                                .WithTimespan(TimeSpan.Last1Day)
                                .GetByQuery(query);

            // Assert
            queryData.Should().NotBeNull();
        }
    }
}

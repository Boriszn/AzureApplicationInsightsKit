using Xunit;
using AzureApplicationInsightsKit.Clients;
using AzureApplicationInsightsKit.Models;
using FluentAssertions;

namespace AzureApplicationInsightsKit.UnitTests
{
    public class QueryClientTests
    {
        [Fact]
        public async void GetByQuery_WithLastOneDayTimeSpan_RetrunEvent()
        {
            // Arrange 
            const string AppId = "";
            const string ApiKey = "";

            string query = "requests\r\n| where timestamp >= ago(24h)\r\n| count";

            // Act
            Query queryData = await new QueryClient(AppId, ApiKey)
                                .WithTimespan(TimeSpan.Last1Day)
                                .WithQuery(query)
                                .Get();

            // Assert
            queryData.Should().NotBeNull();
        }
    }
}

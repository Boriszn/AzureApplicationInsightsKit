using Xunit;
using AzureApplicationInsightsKit.Clients;
using AzureApplicationInsightsKit.Models;
using FluentAssertions;

namespace AzureApplicationInsightsKit.UnitTests
{
    public class EventClientTests
    {
        [Fact]
        public async void GetAllEvents_WithTopFive_RetrunEvent()
        {
            // Arrange 
            const string AppId = "";
            const string ApiKey = "";

            // Act
            Event eventsData = await new EventsClient(AppId, ApiKey)
                    .WithAll()
                    .WithTop(5)
                    .Get();

            // Assert
            eventsData.Should().NotBeNull();
        }
    }
}

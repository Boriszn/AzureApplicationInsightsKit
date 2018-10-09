using AzureApplicationInsightsKit.Clients;
using AzureApplicationInsightsKit.Models;
using FluentAssertions;
using Xunit;

namespace AzureApplicationInsightsKit.UnitTests.IntergrationTests
{
    public class EventClientTests
    {
        [Fact]
        public async void GetAllEvents_WithTopFive_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                    .WithAll()
                    .WithTop(5)
                    .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }

        [Fact]
        public async void GetAllEventsRequestTracking_WithTopFive_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                .WithRequests()
                .WithTop(5)
                .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }
    }
}

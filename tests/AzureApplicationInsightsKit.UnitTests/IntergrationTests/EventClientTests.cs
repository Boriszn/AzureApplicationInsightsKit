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
        public async void GetAllEvents_WithTopFiveSkipOne_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                .WithAll()
                .WithTop(5)
                .WithSkip(1)
                .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }

        [Fact]
        public async void GetEventsRequestTracking_WithTopFive_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                .WithRequests()
                .WithTop(5)
                .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }

        [Fact]
        public async void GetPageViews_WithTop15_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                .WithPageViews()
                .WithTop(5)
                .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }

        [Fact]
        public async void GetExceptions_WithTop15_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                .WithExceptions()
                .WithTop(15)
                .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }

        [Fact]
        public async void GetDependencies_WithTop15_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                .WithDependencies()
                .WithTop(15)
                .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }

        [Fact]
        public async void GetTraces_WithTop15_RetrunEvent()
        {
            // Arrange and Act
            Event eventsData = await new EventsClient(Constants.AppId, Constants.ApiKey)
                .WithTraces()
                .WithTop(15)
                .GetEvents();

            // Assert
            eventsData.Should().NotBeNull();
        }
    }
}

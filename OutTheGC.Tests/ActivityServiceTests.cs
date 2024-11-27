using Moq;
using OutTheGC.Models;
using OutTheGC.Services;
using OutTheGC.Interfaces;

namespace OutTheGC.Tests;

public class ActivityServiceTests
{
    private readonly ActivityService _activityService;

    private readonly Mock<IActivityRepository> _mockActivityRepository;

    public ActivityServiceTests()
    {
        _mockActivityRepository = new Mock<IActivityRepository>();
        _activityService = new ActivityService(_mockActivityRepository.Object);
    }

    [Fact]
    public async Task GetActvityDetails_Success()
    {
        Guid activityId = new Guid("382e4b03-3e9b-4297-8ff4-096e787ef612");

        Activity expectedActivity = new Activity
        {
            Id = activityId,
            TripId = new Guid("d2a207f0-2695-400b-9a52-b5995d6d5e3d"),
            Title = "Kayaking",
            Location = "Aruba",
            Date = new DateTime(2024, 3, 22),
            Duration = 1,
            Cost = 50,
            CategoryId = new Guid("085469d5-54e8-48d2-8b1d-215c88ba7505"),
            UserId = new Guid("3d6883ed-7d5a-49f6-999f-a9f7b15105cd\n"),
            CreatedAt = DateTime.Now
        };

        _mockActivityRepository.Setup(repo => repo.GetSingleActivityAsync(activityId)).ReturnsAsync(expectedActivity);

        var actualActivity = await _activityService.GetSingleActivityAsync(activityId);

        Assert.Equal(expectedActivity, actualActivity);

    }

    [Fact]
    public async Task CreateActvity_Success()
    {
        Activity expectedActivity = new Activity
        {
            Id = new Guid("1b615afc-7477-488f-86c6-d7d72c8c8176"),
            TripId = new Guid("60618250-918c-465f-92d3-e9146fa39b51"),
            Title = "Museum Tour",
            Location = "New York",
            Date = new DateTime(2025, 2, 11, 2, 20, 47),
            Duration = 4,
            Cost = 185,
            CategoryId = new Guid("57cfa649-2c21-4874-a7cc-6d0c6cd04b12"),
            UserId = new Guid("4b779cab-37cf-4357-b6e5-ae3882b01602"),
            CreatedAt = DateTime.Now
        };

        _mockActivityRepository.Setup(repo => repo.CreateActivityAsync(expectedActivity)).ReturnsAsync(expectedActivity);

        var actualCreatedActivity = await _activityService.CreateActivityAsync(expectedActivity);

        Assert.Equal(expectedActivity, actualCreatedActivity);
    }

    [Fact]
    public async Task UpdateActvity_Success()
    {
        Guid activityId = new Guid("1b615afc-7477-488f-86c6-d7d72c8c8176");

        Activity expectedUpdatedActivity = new Activity
        {
            Id = activityId,
            Location = "New York City"
        };

        Activity updatedActivity = new Activity
        {
            Id = activityId,
            Location = "New York City"
        };

        _mockActivityRepository.Setup(repo => repo.UpdateActivityAsync(activityId, expectedUpdatedActivity)).ReturnsAsync(updatedActivity);

        var actualUpdatedActivity = await _activityService.UpdateActivityAsync(activityId, expectedUpdatedActivity);

        Assert.Equal(updatedActivity, actualUpdatedActivity);
    }

    [Fact]
    public async Task DeleteActvity_Success()
    {
        Guid activityId = new Guid("1b615afc-7477-488f-86c6-d7d72c8c8176");

        Activity expectedActivityToDelete = new Activity
        {
            Id = activityId,
            TripId = new Guid("60618250-918c-465f-92d3-e9146fa39b51"),
            Title = "Museum Tour",
            Location = "New York",
            Date = new DateTime(2025, 2, 11, 2, 20, 47),
            Duration = 4,
            Cost = 185,
            CategoryId = new Guid("57cfa649-2c21-4874-a7cc-6d0c6cd04b12"),
            UserId = new Guid("4b779cab-37cf-4357-b6e5-ae3882b01602"),
            CreatedAt = DateTime.Now
        };

        _mockActivityRepository.Setup(repo => repo.DeleteActivityAsync(activityId)).ReturnsAsync(expectedActivityToDelete);

        var actualDeletedActivity = await _activityService.DeleteActivityAsync(activityId);

        Assert.Equal(expectedActivityToDelete, actualDeletedActivity);
    }

    [Fact]
    public async Task SearchActvity_Success()
    {
        string searchString = "Hiking";

        Guid tripId = new Guid("60618250-918c-465f-92d3-e9146fa39b51");

        var expectedSearchResult = new List<Activity>
        {
            new Activity
            {
                Id = new Guid("b8285e18-9d92-4a9c-86a0-c7a3834b9d19"),
                TripId = tripId,
                Title = "Hiking",
                Location = "Denver",
                Date = new DateTime(2025, 2, 11, 2, 20, 47),
                Duration = 4,
                Cost = 185,
                CategoryId = new Guid("57cfa649-2c21-4874-a7cc-6d0c6cd04b12"),
                UserId = new Guid("ab56f7c1-2591-4a1f-8751-bf8bda466ac0")
            }
        };

        _mockActivityRepository.Setup(repo => repo.SearchActivityAsync(tripId, searchString)).ReturnsAsync(expectedSearchResult);

        var actualSearchResults = await _activityService.SearchActivityAsync(tripId, searchString);

        Assert.Equal(expectedSearchResult, actualSearchResults);
    }

}
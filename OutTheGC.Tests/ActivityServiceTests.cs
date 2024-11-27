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

    }

    [Fact]
    public async Task CreateActvity_Success()
    {

    }

    [Fact]
    public async Task UpdateActvity_Success()
    {

    }

    [Fact]
    public async Task DeleteActvity_Success()
    {

    }
}


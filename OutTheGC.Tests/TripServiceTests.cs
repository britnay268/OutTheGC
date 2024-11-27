using Moq;
using OutTheGC.Services;
using OutTheGC.Interfaces;
namespace OutTheGC.Tests;

public class TripServiceTests
{
    private readonly TripService _tripService;

    private readonly Mock<ITripRepository> _mockTripRepository;

    public TripServiceTests()
    {
        _mockTripRepository = new Mock<ITripRepository>();
        _tripService = new TripService(_mockTripRepository.Object);
    }

    [Fact]
    public async Task GetTripDetails_Success()
    {

    }

    [Fact]
    public async Task CreateTrip_Success()
    {

    }

    [Fact]
    public async Task UpdateTrip_Success()
    {

    }

    [Fact]
    public async Task DeleteTrip_Success()
    {

    }
}

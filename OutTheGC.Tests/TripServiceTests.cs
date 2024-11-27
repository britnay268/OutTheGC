using Moq;
using OutTheGC.Services;
using OutTheGC.Interfaces;
using OutTheGC.Models;
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
    public async Task GetListOfTrips_Success()
    {
        Guid userId = new Guid("f99a3c9e-39a7-4655-9d84-61ab3cb913f7");

        var expectedTripList = new List<Trip>
        {
            new Trip
            {
                Id = new Guid("e8a96b9c-411c-4002-9146-6c036846579e"),
                Title = "Eyptian Excursion",
                Destination = "Eygpt",
                StartDate = new DateTime(2023, 4, 15),
                EndDate = new DateTime(2023, 4, 25),
                Status = "Planning",
                Budget = 5000,
                UserId = userId,
                CreatedAt = new DateTime(2022, 4, 12)
            },
            new Trip
            {
                Id = new Guid("f47ac10b-58cc-4372-b6af-453d14a9e1fe"),
                Title = "Japanese Adventure",
                Destination = "Japan",
                StartDate = new DateTime(2024, 10, 20),
                EndDate = new DateTime(2024, 11, 5),
                Status = "Planning",
                Budget = 8000,
                UserId = userId,
                CreatedAt = new DateTime(2023, 10, 15)
            }
        };

        _mockTripRepository.Setup(repo => repo.GetTripsAsync(userId)).ReturnsAsync(expectedTripList);

        var actualTripList = await _tripService.GetTripsAsync(userId);

        Assert.Equal(expectedTripList, actualTripList);
    }

    [Fact]
    public async Task GetTripDetails_Success()
    {
        Guid tripId = new Guid("e8a96b9c-411c-4002-9146-6c036846579e");

        Trip expectedTrip = new Trip
        {
            Id = tripId,
            Title = "Eyptian Excursion",
            Destination = "Eygpt",
            StartDate = new DateTime(2023, 4, 15),
            EndDate = new DateTime(2023, 4, 25),
            Status = "Planning",
            Budget = 5000,
            UserId = new Guid("f99a3c9e-39a7-4655-9d84-61ab3cb913f7"),
            CreatedAt = new DateTime(2022, 4, 12)
        };

        _mockTripRepository.Setup(repo => repo.GetTripsByIdAsync(tripId)).ReturnsAsync(expectedTrip);

        var actualTrip = await _tripService.GetTripsByIdAsync(tripId);

        Assert.Equal(expectedTrip, actualTrip);
    }

    [Fact]
    public async Task CreateTrip_Success()
    {
        Trip expectedTrip = new Trip
        {
            Id = new Guid("a1b2c3d4-5678-90ab-cdef-1234567890ab"),
            Title = "Australian Outback Exploration",
            Destination = "Australia",
            StartDate = new DateTime(2025, 5, 1),
            EndDate = new DateTime(2025, 6, 15),
            Status = "Planning",
            Budget = 12000,
            UserId = new Guid("f99a3c9e-39a7-4655-9d84-61ab3cb913f7"),
            CreatedAt = new DateTime(2024, 11, 10)
        };

        _mockTripRepository.Setup(repo => repo.CreateTripAsync(expectedTrip)).ReturnsAsync(expectedTrip);

        var actualTrip = await _tripService.CreateTripAsync(expectedTrip);

        Assert.Equal(expectedTrip, actualTrip);
    }

    [Fact]
    public async Task UpdateTrip_Success()
    {
        Guid tripId = new Guid("a1b2c3d4-5678-90ab-cdef-1234567890ab");

        Guid ownerId = new Guid("f99a3c9e-39a7-4655-9d84-61ab3cb913f7");

        Trip expectedUpdatedTrip = new Trip
        {
            Status = "Completed",
            UserId = ownerId
        };

        _mockTripRepository.Setup(repo => repo.UpdateTripAsync(tripId, expectedUpdatedTrip, ownerId)).ReturnsAsync(expectedUpdatedTrip);

        var actualUpdatedTrip = await _tripService.UpdateTripAsync(tripId, expectedUpdatedTrip, ownerId);

        Assert.Equal(expectedUpdatedTrip, actualUpdatedTrip);
    }

    [Fact]
    public async Task DeleteTrip_Success()
    {
        Guid tripId = new Guid("a1b2c3d4-5678-90ab-cdef-1234567890ab");

        Trip expectedDeletedTrip = new Trip
        {
            Id = tripId,
            Title = "Australian Outback Exploration",
            Destination = "Australia",
            StartDate = new DateTime(2025, 5, 1),
            EndDate = new DateTime(2025, 6, 15),
            Status = "Planning",
            Budget = 12000,
            UserId = new Guid("f99a3c9e-39a7-4655-9d84-61ab3cb913f7"),
            CreatedAt = new DateTime(2024, 11, 10)
        };

        _mockTripRepository.Setup(repo => repo.DeleteTripAsync(tripId)).ReturnsAsync(expectedDeletedTrip);

        var actualDeletedTrip = await _tripService.DeleteTripAsync(tripId);

        Assert.Equal(expectedDeletedTrip, actualDeletedTrip);

    }
}

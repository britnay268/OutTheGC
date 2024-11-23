using System;
using OutTheGC.Interfaces;
using OutTheGC.Data;
using OutTheGC.Models;

namespace OutTheGC.Services;

public class TripService : ITripService
{
	private readonly ITripRepository _tripRepository;

	public TripService(ITripRepository tripRepository)
	{
		_tripRepository = tripRepository;
	}

    public async Task<List<Trip>> GetTripsAsync(Guid userId)
    {
        return await _tripRepository.GetTripsAsync(userId);
    }

    public async Task<Trip> GetTripsByIdAsync(Guid tripId)
    {
        return await _tripRepository.GetTripsByIdAsync(tripId);
    }

    public async Task<Trip> CreateTripAsync(Trip newTrip)
    {
        return await _tripRepository.CreateTripAsync(newTrip);
    }

    public async Task<Trip> UpdateTripAsync(Guid tripId, Trip updatedTrip, Guid ownerId)
    {
        return await _tripRepository.UpdateTripAsync(tripId, updatedTrip, ownerId);
    }

    public async Task<Trip> DeleteTripAsync(Guid tripId)
    {
        return await _tripRepository.DeleteTripAsync(tripId);
    }

    public async Task<UserTrip> DeleteUserFromTripAsync(Guid tripId, Guid userId)
    {
        return await _tripRepository.DeleteUserFromTripAsync(tripId, userId);
    }
}


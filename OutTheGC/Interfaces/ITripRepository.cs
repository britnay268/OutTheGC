using System;
using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ITripRepository
{
	Task<List<Trip>> GetTripsAsync(Guid userId);

	Task<Trip> GetTripsByIdAsync(Guid tripId);

	Task<Trip> CreateTripAsync(Trip newTrip);

	Task<Trip> UpdateTripAsync(Guid tripId, Trip updatedTrip);

	Task<Trip> DeleteTripAsync(Guid tripId);

	Task<Trip> DeleteUserFromTripAsync(Guid tripId, Guid userId);
}


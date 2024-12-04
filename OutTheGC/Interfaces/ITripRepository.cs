﻿using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ITripRepository
{
	Task<List<Trip>> GetTripsAsync(Guid userId);

	Task<Trip> GetTripsByIdAsync(Guid tripId);

	Task<Trip> CreateTripAsync(Trip newTrip);

	Task<Trip> UpdateTripAsync(Guid tripId, Trip updatedTrip, Guid ownerId);

	Task<Trip> DeleteTripAsync(Guid tripId, Guid ownerId);

	Task<UserTrip> DeleteUserFromTripAsync(Guid tripId, Guid userId, Guid ownerId);

	Task<UserTrip> AddUserToTripAsync(Guid tripId, Guid userId, Guid ownerId);

    Task<List<Activity>> GetArchivedAndDeletedActivities(Guid tripId);
}


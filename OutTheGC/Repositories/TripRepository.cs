using System;
using OutTheGC.Interfaces;
using OutTheGC.Data;
using OutTheGC.Models;

namespace OutTheGC.Repositories;

public class TripRepository : ITripRepository
{
	private readonly OutTheGCDbContext dbContext;

	public TripRepository(OutTheGCDbContext context)
	{
		dbContext = context;
	}

    public async Task<List<Trip>> GetTripsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Trip> GetTripsByIdAsync(Guid tripId)
    {
        throw new NotImplementedException();
    }

    public async Task<Trip> CreateTripAsync(Trip newTrip)
    {
        throw new NotImplementedException();
    }

    public async  Task<Trip> UpdateTripAsync(Guid tripId, Trip updatedTrip)
    {
        throw new NotImplementedException();
    }

    public async Task<Trip> DeleteTripAsync(Guid tripId)
    {
        throw new NotImplementedException();
    }

    public async Task<Trip> DeleteUserFromTripAsync(Guid tripId, Guid userId)
    {
        throw new NotImplementedException();
    }
}


using Microsoft.EntityFrameworkCore;
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
        var userExists = await dbContext.Users.AnyAsync(u => u.Id == userId);

        if (!userExists)
        {
            return null;
        }

        return await dbContext.Trips
            .Where(t => t.UserId == userId)
            .Include(t => t.Owner)
            .Include(t => t.Participants)
            .ToListAsync();
    }

    public async Task<Trip?> GetTripsByIdAsync(Guid tripId)
    {
        return await dbContext.Trips
            .Include(t => t.Activities)
            .Include(t => t.Participants)
            .Include(t => t.Owner)
            .SingleOrDefaultAsync(t => t.Id == tripId);
    }

    public async Task<Trip> CreateTripAsync(Trip newTrip)
    {
        var userExists = dbContext.Users.Any(u => u.Id == newTrip.UserId);

        if (!userExists)
        {
            return null;
        }

        Trip? TriptoAdd = new Trip
        {
            Title = newTrip.Title,
            Notes = newTrip.Notes,
            Destination = newTrip.Destination,
            StartDate = newTrip.StartDate,
            EndDate = newTrip.EndDate,
            Status = "Planning",
            Budget = newTrip.Budget,
            ImageUrl = newTrip.ImageUrl,
            UserId = newTrip.UserId,
            CreatedAt = DateTime.Now
        };

        dbContext.Trips.Add(TriptoAdd);
        await dbContext.SaveChangesAsync();
        return TriptoAdd;
    }

    public async Task<Trip> UpdateTripAsync(Guid tripId, Trip updatedTrip, Guid ownerId)
    {
        var triptoUpdate = await dbContext.Trips.SingleOrDefaultAsync(t => t.Id == tripId);

        if (triptoUpdate == null)
        {
            return null;
        }

        if (triptoUpdate.UserId != ownerId)
        {
            throw new Exception("You are not the owner of this Trip!");
        }

        triptoUpdate.Title = updatedTrip.Title ?? triptoUpdate.Title;
        triptoUpdate.Notes = updatedTrip.Notes ?? triptoUpdate.Notes;
        triptoUpdate.Destination = updatedTrip.Destination ?? triptoUpdate.Destination;
        triptoUpdate.Status = updatedTrip.Status ?? triptoUpdate.Status;
        triptoUpdate.Budget = updatedTrip.Budget != 0 ? updatedTrip.Budget : triptoUpdate.Budget;
        triptoUpdate.ImageUrl = updatedTrip.ImageUrl ?? triptoUpdate.ImageUrl;
        triptoUpdate.UpdatedAt = DateTime.Now;

        await dbContext.SaveChangesAsync();
        return updatedTrip;

    }

    public async Task<Trip> DeleteTripAsync(Guid tripId)
    {
        var tripToDelete = await dbContext.Trips.SingleOrDefaultAsync(t => t.Id == tripId);

        if (tripToDelete == null) 
        {
            return null;
        }

        dbContext.Trips.Remove(tripToDelete);
        await dbContext.SaveChangesAsync();
        return tripToDelete;

    }

    public async Task<UserTrip> DeleteUserFromTripAsync(Guid tripId, Guid userId)
    {
        var userOnTrip = await dbContext.UserTrips.SingleOrDefaultAsync(ut => ut.TripId == tripId && ut.UserId == userId);

        if (userOnTrip == null)
        {
            return null;
        }

        var tripExists = await dbContext.Trips.AnyAsync(t => t.Id == tripId);

        if (!tripExists)
        {
            return new UserTrip { TripId = Guid.Empty };
        }

        var userExists = await dbContext.Users.AnyAsync(t => t.Id == userId);

        if (!userExists)
        {
            return new UserTrip { UserId = Guid.Empty };
        }

        dbContext.UserTrips.Remove(userOnTrip);
        await dbContext.SaveChangesAsync();

        return userOnTrip;
    }
}


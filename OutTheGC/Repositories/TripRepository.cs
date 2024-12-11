using Microsoft.EntityFrameworkCore;
using OutTheGC.Interfaces;
using OutTheGC.Data;
using OutTheGC.Models;
using OutTheGC.DTOs;
using MimeKit;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Macs;
using MailKit.Security;

namespace OutTheGC.Repositories;

public class TripRepository : ITripRepository
{
	private readonly OutTheGCDbContext dbContext;
    private readonly IConfiguration _config;

    public TripRepository(OutTheGCDbContext context, IConfiguration config)
	{
		dbContext = context;
        _config = config;
	}

    public async Task<List<Trip>> GetTripsAsync(Guid userId)
    {
        var userExists = await dbContext.Users.AnyAsync(u => u.Id == userId);

        if (!userExists)
        {
            return null;
        }

        return await dbContext.Trips
            .Where(t => t.UserId == userId || t.Participants.Any(p => p.Id == userId))
            .Include(t => t.Owner)
            .Include(t => t.Participants)
            .ToListAsync();
    }

    public async Task<Trip?> GetTripsByIdAsync(Guid tripId)
    {
        return await dbContext.Trips
            .Include(t => t.Activities.Where(a => !a.isArchived && !a.isDeleted))
            .ThenInclude(t => t.Votes)
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
            throw new UnauthorizedAccessException("You are not the owner of this Trip!");
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

    public async Task<Trip> DeleteTripAsync(Guid tripId, Guid ownerId)
    {
        var tripToDelete = await dbContext.Trips.SingleOrDefaultAsync(t => t.Id == tripId);

        if (tripToDelete == null) 
        {
            return null;
        }

        if (tripToDelete.UserId != ownerId)
        {
            throw new UnauthorizedAccessException("You are not the owner of this Trip!");
        }

        dbContext.Trips.Remove(tripToDelete);
        await dbContext.SaveChangesAsync();
        return tripToDelete;

    }

    public async Task<UserTrip> DeleteUserFromTripAsync(Guid tripId, Guid userId, Guid ownerId)
    {
        var userOnTrip = await dbContext.UserTrips.SingleOrDefaultAsync(ut => ut.TripId == tripId && ut.UserId == userId);

        if (userOnTrip == null)
        {
            return null;
        }

        var trip = await dbContext.Trips.SingleOrDefaultAsync(t => t.Id == tripId);


        if (trip.UserId != ownerId)
        {
            throw new UnauthorizedAccessException("You are not the owner of this Trip!");
        }

        dbContext.UserTrips.Remove(userOnTrip);
        await dbContext.SaveChangesAsync();

        return userOnTrip;
    }

    public async Task<UserTrip> AddUserToTripAsync(Guid tripId, Guid userId, Guid ownerId)
    {
        var userExists = dbContext.Users.Any(u => u.Id == userId);

        if (!userExists)
        {
            throw new Exception("The user to be added does not exist!");
        }

        var trip = await dbContext.Trips.SingleOrDefaultAsync(t => t.Id == tripId);

        if (trip.UserId != ownerId)
        {
            throw new UnauthorizedAccessException("You are not the owner of this Trip!");
        }

        UserTrip newTripUser = new UserTrip
        {
            UserId = userId,
            TripId = tripId,
            CreatedAt = DateTime.Now
        };

        dbContext.UserTrips.Add(newTripUser);
        await dbContext.SaveChangesAsync();
        return newTripUser;
    }

    public async Task<List<Activity>> GetArchivedAndDeletedActivities(Guid tripId)
    {
        var actvities = await dbContext.Activities
            .Where(a => a.TripId == tripId && (a.isArchived || a.isDeleted))
            .Include(a => a.Votes)
            .Include(a => a.Category)
            .Include(a => a.User)
            .ToListAsync();

        if (!actvities.Any())
        {
            return null;
        }

        return actvities;
    }

    public async Task<IResult> ShareTripViaEmailAsync(EmailDTO sendEmail)
    {
        var userSharingTrip = await dbContext.Users
                    .Where(u => u.Id == sendEmail.UserId)
                    .Select(u => u.FullName)
                    .SingleOrDefaultAsync();

        if (userSharingTrip == null)
        {
            return null;
        }

        var gmailEmail = _config["GmailEmail"];
        var gmailPassword = _config["GmailPassword"];

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Britnay's Out The GC App", gmailEmail));
        message.To.Add(new MailboxAddress("", sendEmail.Recipient));
        message.Subject = $"Out The GC Trip Invitation";
        message.Body = new TextPart("plain")
        {
            Text = $"{userSharingTrip} is inviting to you to be apart of their trip"
        };


        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate(gmailEmail, gmailPassword);
            client.Send(message);
            client.Disconnect(true);
        }

        return Results.Ok();
    }

}


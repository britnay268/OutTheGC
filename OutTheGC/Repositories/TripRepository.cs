using Microsoft.EntityFrameworkCore;
using OutTheGC.Interfaces;
using OutTheGC.Data;
using OutTheGC.Models;
using OutTheGC.DTOs;
using MimeKit;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Macs;
using MailKit.Security;
using static System.Net.WebRequestMethods;

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
                    .Where(u => u.Id == sendEmail.SenderId)
                    .Select(u => u.FullName)
                    .SingleOrDefaultAsync();


        var tripToBeShared = await dbContext.Trips.Where(t => t.Id == sendEmail.TripId && t.UserId == sendEmail.SenderId).Select(t => t.Title).SingleOrDefaultAsync();


        //if (tripToBeShared == null)
        //{
        //    throw new Exception("User is not an owner of the trip");
        //}
        if (tripToBeShared == null)
        {
            return Results.NotFound(new
            {
                error = "The specified trip was not found, or the sender is not authorized."
            });
        }

        var gmailEmail = _config["GmailEmail"];
        var gmailPassword = _config["GmailPassword"];

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Britnay's Out The GC App", gmailEmail));
        message.To.Add(new MailboxAddress("", sendEmail.RecipientEmail));
        message.Subject = $"Out The GC Trip Invitation";
        var builder = new BodyBuilder
        {
            HtmlBody =
            @$"{userSharingTrip} is inviting to you to be apart of <b>Trip:</b> <a href='https://www.google.com/'>{tripToBeShared}</a>. <br><br>The link above currently goes to google as the FE in under construction!"
        };
        message.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate(gmailEmail, gmailPassword);
            client.Send(message);
            client.Disconnect(true);
        }

        var findRecipient = await dbContext.Users.Where(u => u.Email == sendEmail.RecipientEmail).Select(u => u.Id).SingleOrDefaultAsync();

        TripInvitation invitationCreation = new TripInvitation
        {
            SenderId = sendEmail.SenderId,
            TripId = sendEmail.TripId,
            RecipientEmail = sendEmail.RecipientEmail,
            SentDate = DateTime.Now,
            ExpirationDate = DateTime.Now.AddDays(14),
            RecipientId = findRecipient == null ? null : findRecipient,
            Status = InvitationStatus.pending
        };

        dbContext.TripInvitations.Add(invitationCreation);
        await dbContext.SaveChangesAsync();

        return Results.Ok(new { message = "Email has been sent!" });
    }

    public async Task<List<TripInvitation>> GetListofUserInvitaionsAsync(Guid userId, string? status = null)
    {
        InvitationStatus? parsedStatus = null;

        if (!string.IsNullOrWhiteSpace(status))
        {
            if (!Enum.TryParse<InvitationStatus>(status, true, out var result))
            {
                throw new ArgumentException($"Invalid status: {status}. Valid values are: {string.Join(", ", Enum.GetNames(typeof(InvitationStatus)))}");
            }

            parsedStatus = result;
        }

        var invitations = dbContext.TripInvitations.Where(ti => ti.RecipientId == userId);

        if (!string.IsNullOrWhiteSpace(status))
        {
            invitations = invitations.Where(i => i.Status == parsedStatus);
        }

        return await invitations.ToListAsync();
    }

    public async Task<TripInvitation> RespondToInvitationAsync(Guid invitationId, InvitationStatus status)
    {
        throw new NotImplementedException();
    }

    public async Task<TripInvitation> DeleteInvitationAsync(Guid invitationId, Guid userId)
    {
        throw new NotImplementedException();
    }

}


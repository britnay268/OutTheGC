using OutTheGC.Models;
using OutTheGC.DTOs;

namespace OutTheGC.Interfaces;

public interface ITripService
{
    Task<List<Trip>> GetTripsAsync(Guid userId);

    Task<Trip> GetTripsByIdAsync(Guid tripId);

    Task<Trip> CreateTripAsync(Trip newTrip);

    Task<Trip> UpdateTripAsync(Guid tripId, Trip updatedTrip, Guid ownerId);

    Task<Trip> DeleteTripAsync(Guid tripId, Guid ownerId);

    Task<UserTrip> DeleteUserFromTripAsync(Guid tripId, Guid userId, Guid ownerId);

    Task<UserTrip> AddUserToTripAsync(Guid tripId, Guid userId, Guid ownerId);

    Task<List<Activity>> GetArchivedAndDeletedActivities(Guid tripId);

    Task<IResult> ShareTripViaEmailAsync(EmailDTO sendEmail);

    Task<List<TripInvitation>> GetListofUserInvitaionsAsync(Guid userId, string? status = null);

    Task<TripInvitation> RespondToInvitationAsync(Guid invitationId, string status);

    Task<TripInvitation> DeleteInvitationAsync(Guid invitationId, Guid userId);
}


﻿using System;
using OutTheGC.Interfaces;
using OutTheGC.Data;
using OutTheGC.Models;
using OutTheGC.Repositories;
using OutTheGC.DTOs;

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

    public async Task<Trip> DeleteTripAsync(Guid tripId, Guid ownerId)
    {
        return await _tripRepository.DeleteTripAsync(tripId, ownerId);
    }

    public async Task<UserTrip> DeleteUserFromTripAsync(Guid tripId, Guid userId, Guid ownerId)
    {
        return await _tripRepository.DeleteUserFromTripAsync(tripId, userId, ownerId);
    }

    public async Task<UserTrip> AddUserToTripAsync(Guid tripId, Guid userId, Guid ownerId)
    {
        return await _tripRepository.AddUserToTripAsync(tripId, userId, ownerId);
    }

    public async Task<List<Activity>> GetArchivedAndDeletedActivities(Guid tripId)
    {
        return await _tripRepository.GetArchivedAndDeletedActivities(tripId);
    }

    public async Task<IResult> ShareTripViaEmailAsync(EmailDTO sendEmail)
    {
        return await _tripRepository.ShareTripViaEmailAsync(sendEmail);
    }

    public async Task<List<TripInvitation>> GetListofUserInvitaionsAsync(Guid userId, string? status = null)
    {
        return await _tripRepository.GetListofUserInvitaionsAsync(userId, status);
    }

    public async Task<TripInvitation> RespondToInvitationAsync(Guid invitationId, string response)
    {
        return await _tripRepository.RespondToInvitationAsync(invitationId, response);
    }

    public async Task<TripInvitation> DeleteInvitationAsync(Guid invitationId, Guid userId)
    {
        return await _tripRepository.DeleteInvitationAsync(invitationId, userId);
    }
}


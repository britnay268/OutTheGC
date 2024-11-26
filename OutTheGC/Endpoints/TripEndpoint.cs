using OutTheGC.Models;
using OutTheGC.Interfaces;

namespace OutTheGC.Endpoints;

public static class TripEndpoint
{
	public static void MapTripEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(Trip));

        group.MapGet("/trips", async (ITripService tripService, Guid userId) =>
        {
            var usersTrips = await tripService.GetTripsAsync(userId);

            if (usersTrips == null)
            {
                return Results.NotFound(new { error = "There is no trip for the specified user." });

            }

            return Results.Ok(usersTrips.Select(t => new
            {
                t.Id,
                t.Title,
                t.Notes,
                t.Destination,
                t.StartDate,
                t.EndDate,
                t.Status,
                t.Budget,
                t.ImageUrl,
                t.UserId,
                Owner = new
                {
                    t.Owner.FullName,
                    t.Owner.Email,
                    t.Owner.ImageUrl,
                    t.Owner.Uid
                },
                t.CreatedAt,
                t.UpdatedAt,
                Participants = t.Participants.Select(p => new
                {
                    p.Id,
                    p.FullName,
                    p.Email,
                    p.ImageUrl,
                    p.Uid
                })
            }));
        })
        .WithOpenApi()
        .Produces<List<Trip>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/trip/{tripId}", async (ITripService tripService, Guid tripId) =>
        {
            var trip = await tripService.GetTripsByIdAsync(tripId);

            if (trip == null)
            {
                return Results.NotFound(new
                {
                    error = "The tripId entered is not valid"
                });
            }

            return Results.Ok(new
            {
                trip.Id,
                trip.Title,
                trip.Notes,
                trip.Destination,
                trip.StartDate,
                trip.EndDate,
                trip.Status,
                trip.Budget,
                trip.ImageUrl,
                trip.UserId,
                Owner = new
                {
                    trip.Owner.FullName,
                    trip.Owner.Email,
                    trip.Owner.ImageUrl,
                    trip.Owner.Uid
                },
                trip.CreatedAt,
                trip.UpdatedAt,
                Participants = trip.Participants.Select(p => new
                {
                    p.Id,
                    p.FullName,
                    p.Email,
                    p.ImageUrl,
                    p.Uid
                }),
                Activities = trip.Activities.Select(a => new
                {
                    a.Id,
                    a.Title,
                    a.Notes,
                    a.Location,
                    a.Date,
                    a.Duration,
                    a.Cost,
                    a.CategoryId,
                    a.Category,
                    a.WebsiteUrl,
                    User = new
                    {
                        a.User.Id,
                        a.User.FullName,
                        a.User.ImageUrl
                    },
                })
            });
        })
        .WithOpenApi()
        .Produces<Trip>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/trip", async (ITripService tripService, Trip newTrip) =>
        {
            var addTrip = await tripService.CreateTripAsync(newTrip);

            if (addTrip == null)
            {
                return Results.NotFound(new
                {
                    error = "The userId does not exist."
                });
            }

            return Results.Created($"/podcast/{addTrip.Id}", addTrip);
        })
        .WithOpenApi()
        .Produces<Trip>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/trip/{tripId}", async (ITripService tripService, Guid tripId, Trip updatedTrip, Guid ownerId) =>
        {
            var triptoUpdate = await tripService.UpdateTripAsync(tripId, updatedTrip, ownerId);

            if (triptoUpdate == null)
            {
                return Results.BadRequest(new
                {
                    error = "The trip you wish to update does not exist"
                });
            }

            return Results.Ok(new { message = "Trip information has been updated." });
        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/trip/{tripId}", async (ITripService tripService, Guid tripId) =>
        {
            var tripToDelete = await tripService.DeleteTripAsync(tripId);

            if (tripToDelete == null)
            {
                return Results.NotFound(new
                {
                    error = "The tripId does not exist."
                });
            }

            return Results.Ok(new { message = "Trip and all it has activities and comments have been deleted!" });

        })
        .WithOpenApi()
        .Produces<Trip>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/trip/{tripId}/user/{userId}", async (ITripService tripService, Guid tripId, Guid userId) =>
        {
            var userToDelete = await tripService.DeleteUserFromTripAsync(tripId, userId);

            

            if (userToDelete == null)
            {
                return Results.NotFound(new
                {
                    error = "There is no trip with this user."
                });
            }

            return Results.Ok(new { message = "User has been deleted from trip!" });

        })
        .WithOpenApi()
        .Produces<Trip>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);
    }
}


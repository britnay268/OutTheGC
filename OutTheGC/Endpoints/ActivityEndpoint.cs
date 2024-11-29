using OutTheGC.Models;
using OutTheGC.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OutTheGC.Endpoints;

public static class ActivityEndpoint
{
	public static void MapActivityEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(Activity));

        group.MapGet("/activity/{activityId}", async (IActivityService activityService, Guid activityId) =>
        {
            var singleActivity = await activityService.GetSingleActivityAsync(activityId);

            if (singleActivity == null)
            {
                return Results.NotFound(new
                {
                    error = "The activity does not exist."
                });
            }

            return Results.Ok(new
            {
                singleActivity.Id,
                singleActivity.Title,
                singleActivity.Notes,
                singleActivity.Location,
                singleActivity.Date,
                singleActivity.Duration,
                singleActivity.Cost,
                singleActivity.Category,
                singleActivity.WebsiteUrl,
                User = new
                {
                    singleActivity.User.FullName
                },
                singleActivity.CreatedAt,
                singleActivity.UpdatedAt,
                Comments = singleActivity.Comments.Select(sa => new
                {
                    User = new
                    {
                        sa.User.FullName
                    },
                    sa.Content,
                    sa.CreatedAt,
                    sa.UpdatedAt
                })
            });
        })
        .WithOpenApi()
        .Produces<List<Trip>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/activity", async (IActivityService activityService, Activity newActivity) =>
        {
            var activityToAdd = await activityService.CreateActivityAsync(newActivity);

            return Results.Created($"/activity/{activityToAdd.Id}", activityToAdd);
        })
        .WithOpenApi()
        .Produces<Trip>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/activity/{activityId}", async (IActivityService activityService, Guid activityId, Activity updatedActivity) =>
        {
            var activityToUpdate = await activityService.UpdateActivityAsync(activityId, updatedActivity);

            if (activityToUpdate == null)
            {
                return Results.NotFound(new
                {
                    error = "The activity does not exist."
                });
            }

            return Results.Ok(new { message = "Activity information has been updated." });
        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/activity/{activityId}", async (IActivityService activityService, Guid activityId, Guid userId) =>
        {
            var activityToDelete = await activityService.DeleteActivityAsync(activityId, userId);

            if (activityToDelete == null)
            {
                return Results.NotFound(new
                {
                    error = "The activity does not exist."
                });
            }

            return Results.Ok(new { nessage = "Activity has been deleted." });
        })
        .WithOpenApi()
        .Produces<Trip>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/activity/{tripId}/search", async (IActivityService activityService, Guid tripId, string searchInput) =>
        {
            List<Activity> searchResults = await activityService.SearchActivityAsync(tripId, searchInput);

            if (!searchResults.Any())
            {
                return Results.NotFound(new
                {
                    error = $"No search results found!"
                });
            }

            return Results.Ok(searchResults.Select(sr => new
            {
                sr.Id,
                sr.Title,
                sr.Notes,
                sr.Location,
                sr.Date,
                sr.Duration,
                sr.Cost,
                sr.CategoryId,
                sr.Category,
                sr.WebsiteUrl,
                User = new
                {
                    sr.User.Id,
                    sr.User.FullName,
                    sr.User.ImageUrl
                },
            }));
        })
        .WithOpenApi()
        .Produces<List<Trip>>(StatusCodes.Status200OK);
    }
}


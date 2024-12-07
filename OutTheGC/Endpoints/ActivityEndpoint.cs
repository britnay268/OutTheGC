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
                    sa.Id,
                    User = new
                    {
                        sa.User.FullName
                    },
                    sa.Content,
                    sa.CreatedAt,
                    sa.UpdatedAt
                }),
                VoteCount = singleActivity.Votes.Count()
            });
        })
        .WithOpenApi()
        .Produces<Activity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/activity", async (IActivityService activityService, Activity newActivity) =>
        {
            var activityToAdd = await activityService.CreateActivityAsync(newActivity);

            return Results.Created($"/activity/{activityToAdd.Id}", activityToAdd);
        })
        .WithOpenApi()
        .Produces<Activity>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/activity/{activityId}", async (IActivityService activityService, Guid activityId, Activity updatedActivity, Guid userId) =>
        {
            var activityToUpdate = await activityService.UpdateActivityAsync(activityId, updatedActivity, userId);

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
        .Produces<Activity>(StatusCodes.Status200OK)
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

            return Results.Ok(new { nessage = "Activity has been permanently deleted." });
        })
        .WithOpenApi()
        .Produces<Activity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/activity/{tripId}/search", async (IActivityService activityService, Guid tripId, string searchInput) =>
        {
            List<Activity> searchResults = await activityService.SearchActivityAsync(tripId, searchInput);

            if (!searchResults.Any())
            {
                return Results.NotFound(new
                {
                    message = "No search results found!"
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
                VoteCount = sr.Votes.Count()
            }));
        })
        .WithOpenApi()
        .Produces<List<Activity>>(StatusCodes.Status200OK);

        group.MapPut("/activity/{activityId}/vote/{userId}", async (IActivityService activityService, Guid userId, Guid activityId) =>
        {
            var results = await activityService.VoteOnActivity(userId, activityId);

            return results;
        })
        .WithOpenApi()
        .Produces<Activity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/activity/filter", async (IActivityService activityService, Guid tripId) =>
        {
            var results = await activityService.FilterActivitiesByHighestVotes(tripId);

            return Results.Ok(results.Select(r => new
            {
                r.Id,
                r.TripId,
                r.Title,
                r.Notes,
                r.Location,
                r.Date,
                r.Duration,
                r.Cost,
                r.CategoryId,
                r.Category,
                r.WebsiteUrl,
                User = new
                {
                    r.User.Id,
                    r.User.FullName,
                    r.User.ImageUrl
                },
                VoteCount = r.Votes.Count()
            }));

            //return results;
        })
        .WithOpenApi()
        .Produces<List<Activity>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPatch("/activity/{activityId}/archive", async (IActivityService activityService, Guid activityId, bool isArchived) =>
        {
            var results = await activityService.ArchiveActivity(activityId, isArchived);

            if (results == null)
            {
                return Results.NotFound("Actvity does not exist");
            }

            return Results.Ok(results.isArchived ? "Activity is archived" : "Activity is unarchived");
        })
        .WithOpenApi()
        .Produces<Activity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPatch("/activity/{activityId}/delete", async (IActivityService activityService, Guid activityId, bool isDeleted) =>
        {
            var results = await activityService.MarkActivityAsDeleted(activityId, isDeleted);

            if (results == null)
            {
                return Results.NotFound("Actvity does not exist");
            }

            return Results.Ok(results.isArchived ? "Activity is deleted" : "Activity is recovered");
        })
        .WithOpenApi()
        .Produces<Activity>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/category/{categoryId}/activities", async (IActivityService activityService, Guid categoryId, Guid tripId) =>
        {
            var activitiesByCategory = await activityService.GetActivitiesByCategoriesAsync(categoryId, tripId);

            if (!activitiesByCategory.Any())
            {
                return Results.NotFound(new
                {
                    message = "There are no activities in this category."
                });
            }

            return Results.Ok(activitiesByCategory.Select(ac => new
            {
                ac.Id,
                ac.Title,
                ac.Notes,
                ac.Location,
                ac.Date,
                ac.Duration,
                ac.Cost,
                ac.Category,
                ac.WebsiteUrl,
                User = new
                {
                    ac.User.FullName
                },
                ac.CreatedAt,
                ac.UpdatedAt,
                VoteCount = ac.Votes.Count()
            }));
        })
        .WithOpenApi()
        .Produces<List<Activity>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}


using OutTheGC.Interfaces;
using OutTheGC.Models;
using OutTheGC.Data;
using Microsoft.EntityFrameworkCore;

namespace OutTheGC.Repositories;

public class ActivityRepository : IActivityRepository
{
	private readonly OutTheGCDbContext dbContext;

	public ActivityRepository(OutTheGCDbContext context)
	{
		dbContext = context;
	}

    public async Task<Activity?> GetSingleActivityAsync(Guid activityId)
    {
        return await dbContext.Activities
                    .Include(a => a.Category)
                    .Include(a => a.User)
                    .Include(a => a.Comments)
                    .Include(a => a.Votes)
                    .SingleOrDefaultAsync(a => a.Id == activityId);
    }

    public async Task<Activity> CreateActivityAsync(Activity newActivity)
    {
        var tripExists = await dbContext.Trips.AnyAsync(t => t.Id == newActivity.TripId);

        var categoryExists = await dbContext.Categories.AnyAsync(c => c.Id == newActivity.CategoryId);

        var userExists = await dbContext.Users.AnyAsync(c => c.Id == newActivity.UserId);

        if (!tripExists || !categoryExists || !userExists)
        {
            // Build a meaningful error message
            var errors = new List<string>();
            if (!tripExists) errors.Add("Invalid TripId.");
            if (!categoryExists) errors.Add("Invalid CategoryId.");
            if (!userExists) errors.Add("Invalid UserId.");

            throw new InvalidOperationException($"Activity creation failed: {string.Join(" ", errors)}");
        }

        Activity activityToAdd = new Activity
        {
            TripId = newActivity.TripId,
            Title = newActivity.Title,
            Notes = newActivity.Notes,
            Location = newActivity.Location,
            Date = newActivity.Date,
            Duration = newActivity.Duration,
            Cost = newActivity.Cost,
            CategoryId = newActivity.CategoryId,
            WebsiteUrl = newActivity.WebsiteUrl,
            UserId = newActivity.UserId,
            CreatedAt = DateTime.Now
        };

        dbContext.Activities.Add(activityToAdd);
        await dbContext.SaveChangesAsync();
        return activityToAdd;
    }

    public async Task<Activity> UpdateActivityAsync(Guid activityId, Activity updatedActivity, Guid userId)
    {
        var activityToUpdate = await dbContext.Activities.SingleOrDefaultAsync(a => a.Id == activityId);

        if (activityToUpdate == null)
        {
            return null;
        }

        if (activityToUpdate.UserId != userId)
        {
            throw new Exception("403 Forbidden: User is not authorized to update this activity");
        }

        activityToUpdate.Title = updatedActivity.Title ?? activityToUpdate.Title;
        activityToUpdate.Notes = updatedActivity.Notes ?? activityToUpdate.Notes;
        activityToUpdate.Location = updatedActivity.Location ?? activityToUpdate.Location;
        activityToUpdate.Date = updatedActivity.Date;
        activityToUpdate.Duration = updatedActivity.Duration != 0 ? updatedActivity.Duration : activityToUpdate.Duration;
        activityToUpdate.Cost = updatedActivity.Cost != 0 ? updatedActivity.Cost : activityToUpdate.Cost;
        activityToUpdate.CategoryId = updatedActivity.CategoryId != Guid.Empty ? updatedActivity.CategoryId : activityToUpdate.CategoryId;
        activityToUpdate.WebsiteUrl = updatedActivity.WebsiteUrl ?? activityToUpdate.WebsiteUrl;
        activityToUpdate.UpdatedAt = DateTime.Now;

        await dbContext.SaveChangesAsync();

        return updatedActivity;
    }

    public async Task<Activity> DeleteActivityAsync(Guid activityId, Guid userId)
    {
        var activityToDelete = await dbContext.Activities.SingleOrDefaultAsync(a => a.Id == activityId);

        if (activityToDelete == null)
        {
            return null;
        }

        var tripOwnerId = await dbContext.Trips.Where(t => t.Id == activityToDelete.TripId).Select(t => t.UserId).SingleOrDefaultAsync();

        // If the user satisfy one of the conditions then it deletes the activity. If it does not satisfy any of the consitions, it throws the exception                             \
        if (activityToDelete.UserId != userId && tripOwnerId != userId)
        {
            throw new Exception("403 Forbidden: User is not authorized to delete this activity");
        }

        dbContext.Activities.Remove(activityToDelete);
        await dbContext.SaveChangesAsync();
        return activityToDelete;
    }

    public async Task<List<Activity>> SearchActivityAsync(Guid tripId, string searchInput)
    {
        if (string.IsNullOrEmpty(searchInput))
        {
            return null;
        }

        var seachActivity = await dbContext.Activities
            .Where(a => a.TripId == tripId)
            .Where(a => a.Title.ToLower().Contains(searchInput.ToLower()) || a.Notes.ToLower().Contains(searchInput.ToLower()) || a.Category.Name.ToLower().Contains(searchInput.ToLower()))
            .Include(a => a.Category)
            .Include(a => a.User)
            .Include(a => a.Comments)
            .ToListAsync();

        return seachActivity;
    }

    public async Task<IResult> VoteOnActivity(Guid userId, Guid activityId)
    {
       var activitytoVoteOn = await dbContext.Activities
                                    .Include(a => a.Trip)
                                    .ThenInclude(t => t.Participants)
                                    .SingleOrDefaultAsync(a => a.Id == activityId);

        if (activitytoVoteOn == null)
        {
            return Results.NotFound("Activity does not exist");
        }

        // If the user is on the trip or is an owner of the trip with the activity, they should be the only one able to vote on an activity
        var userOnTrip = activitytoVoteOn.Trip.Participants.Any(p => p.Id == userId) || activitytoVoteOn.Trip.UserId == userId;

        if (!userOnTrip)
        {
            return Results.NotFound("User is not apart of this trip with this activity");
        }

        var votedActivity = await dbContext.UsersVotes.SingleOrDefaultAsync(uv => uv.UserId == userId && uv.ActivityId == activityId);

        if (votedActivity == null)
        {
            dbContext.UsersVotes.Add(new UserVote
            {
                UserId = userId,
                ActivityId = activityId
            });
        }
        else
        {
            dbContext.UsersVotes.Remove(votedActivity);
        }

        await dbContext.SaveChangesAsync();
        return Results.Ok(votedActivity == null ? "Vote added" : "Vote removed");
    }

    public async Task<List<Activity>> FilterActivitiesByHighestVotes(Guid tripId)
    {
        var activitiesToFilter = await dbContext.Activities
            .Where(a => a.TripId == tripId)
            .Include(a => a.Category)
            .Include(a => a.User)
            .Include(a => a.Votes)
            .OrderByDescending(a => a.Votes.Count())
            .ToListAsync();

        return activitiesToFilter;
    }

    public async Task<Activity> ArchiveActivity(Guid activityId, bool isArchived)
    {
        var singleActivity = await dbContext.Activities.SingleOrDefaultAsync(a => a.Id == activityId);

        if (singleActivity == null)
        {
            return null;
        }

        singleActivity.isArchived = isArchived;

        await dbContext.SaveChangesAsync();
        return singleActivity;
    }

    public async Task<Activity> MarkActivityAsDeleted(Guid activityId, bool isDeleted)
    {
        var singleActivity = await dbContext.Activities.SingleOrDefaultAsync(a => a.Id == activityId);

        if (singleActivity == null)
        {
            return null;
        }

        singleActivity.isDeleted = isDeleted;

        await dbContext.SaveChangesAsync();
        return singleActivity;
    }
}


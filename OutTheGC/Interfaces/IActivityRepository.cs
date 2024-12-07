using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface IActivityRepository
{
	Task<Activity> GetSingleActivityAsync(Guid activityId);

	Task<Activity> CreateActivityAsync(Activity newActivity);

	Task<Activity> UpdateActivityAsync(Guid activityId, Activity updatedActivity, Guid userId);

	Task<Activity> DeleteActivityAsync(Guid activityId, Guid userId);

	Task<List<Activity>> SearchActivityAsync(Guid tripId, string searchInput);

    Task<IResult> VoteOnActivity(Guid userId, Guid activityId);

	Task<List<Activity>> FilterActivitiesByHighestVotes(Guid tripId);

	Task<Activity> ArchiveActivity(Guid activityId, bool isArchived);

	Task<Activity> MarkActivityAsDeleted(Guid activityId, bool isDeleted);

    Task<List<Activity>> GetActivitiesByCategoriesAsync(Guid categoryId, Guid tripId);
}

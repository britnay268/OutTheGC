using OutTheGC.Interfaces;
using OutTheGC.Models;
using OutTheGC.Data;
using OutTheGC.Services;

namespace OutTheGC.Services;

public class ActivityService : IActivityService
{
	private readonly IActivityRepository _activityRepository;

	public ActivityService(IActivityRepository activityRepository)
	{
		_activityRepository = activityRepository;
	}

    public async Task<Activity> GetSingleActivityAsync(Guid activityId)
    {
        return await _activityRepository.GetSingleActivityAsync(activityId);
    }

    public async Task<Activity> CreateActivityAsync(Activity newActivity)
    {
        return await _activityRepository.CreateActivityAsync(newActivity);
    }

    public async Task<Activity> UpdateActivityAsync(Guid activityId, Activity updatedActivity, Guid userId)
    {
        return await _activityRepository.UpdateActivityAsync(activityId, updatedActivity, userId);
    }

    public async Task<Activity> DeleteActivityAsync(Guid activityId, Guid userId)
    {
        return await _activityRepository.DeleteActivityAsync(activityId, userId);
    }

    public async Task<List<Activity>> SearchActivityAsync(Guid tripId, string searchInput)
    {
        return await _activityRepository.SearchActivityAsync(tripId, searchInput);
    }

    public async Task<IResult> VoteOnActivity(Guid userId, Guid activityId)
    {
        return await _activityRepository.VoteOnActivity(userId, activityId);
    }

    public async Task<List<Activity>> FilterActivitiesByHighestVotes(Guid tripId)
    {
        return await _activityRepository.FilterActivitiesByHighestVotes(tripId);
    }
}


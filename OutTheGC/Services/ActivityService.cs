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

    public async Task<List<Activity>> GetActivitiesAsync(Guid tripId)
    {
        return await _activityRepository.GetActivitiesAsync(tripId);
    }

    public async Task<Activity> GetSingleActivityAsync(Guid activityId)
    {
        return await _activityRepository.GetSingleActivityAsync(activityId);
    }

    public async Task<Activity> CreateActivityAsync(Activity newActivity)
    {
        return await _activityRepository.CreateActivityAsync(newActivity);
    }

    public async Task<Activity> UpdateActivityAsync(Guid activityId, Activity updatedActivity)
    {
        return await _activityRepository.UpdateActivityAsync(activityId, updatedActivity);
    }

    public async Task<Activity> DeleteActivityAsync(Guid activityId)
    {
        return await _activityRepository.DeleteActivityAsync(activityId);
    }

    public async Task<List<Activity>> SearchActivityAsync(Guid tripId, string searchInput)
    {
        return await _activityRepository.SearchActivityAsync(tripId, searchInput);
    }
}


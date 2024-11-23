using OutTheGC.Interfaces;
using OutTheGC.Models;
using OutTheGC.Data;

namespace OutTheGC.Repositories;

public class ActivityRepository : IActivityRepository
{
	private readonly OutTheGCDbContext dbContext;

	public ActivityRepository(OutTheGCDbContext context)
	{
		dbContext = context;
	}

    public async Task<List<Activity>> GetActivitiesAsync(Guid tripId)
    {
        throw new NotImplementedException();
    }

    public async Task<Activity> GetSingleActivityAsync(Guid activityId)
    {
        throw new NotImplementedException();
    }

    public async Task<Activity> CreateActivityAsync(Activity newActivity)
    {
        throw new NotImplementedException();
    }

    public async Task<Activity> UpdateActivityAsync(Guid activityId, Activity updatedActivity)
    {
        throw new NotImplementedException();
    }

    public async Task<Activity> DeleteActivityAsync(Guid activityId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Activity>> SearchActivityAsync(Guid tripId, string searchInput)
    {
        throw new NotImplementedException();
    }
}


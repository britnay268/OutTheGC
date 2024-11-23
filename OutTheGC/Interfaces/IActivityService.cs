﻿using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface IActivityService
{
    Task<List<Activity>> GetActivitiesAsync(Guid tripId);

    Task<Activity> GetSingleActivityAsync(Guid activityId);

    Task<Activity> CreateActivityAsync(Activity newActivity);

    Task<Activity> UpdateActivityAsync(Guid activityId, Activity updatedActivity);

    Task<Activity> DeleteActivityAsync(Guid activityId);

    Task<List<Activity>> SearchActivityAsync(Guid tripId, string searchInput);
}

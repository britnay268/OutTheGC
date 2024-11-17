using System;
using OutTheGC.Models;
namespace OutTheGC.Data;

public class UserTripData
{
	public static List<UserTrip> UserTrips = new()
	{
		new()
		{
			Id = new Guid("d7b5750c-b545-48ed-adb0-453896881619"),
			UserId = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
			TripId = new Guid("6f927882-1196-4d72-917d-972c6de3f1b4")
        },
        new()
        {
            Id = new Guid("bbecb304-34bf-42ad-a495-755eccf85e42"),
            UserId = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
            TripId = new Guid("6f927882-1196-4d72-917d-972c6de3f1b4")
        },
        new()
        {
            Id = new Guid("c8dfcc2c-e2a3-4ac1-ad8e-fc428bdbcf63"),
            UserId = new Guid("0eaed767-eecd-4d19-a853-9da895e78057"),
            TripId = new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2")
        },
        new()
        {
            Id = new Guid("bbecb304-34bf-42ad-a495-755eccf85e42"),
            UserId = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
            TripId = new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70")
        }
    };

}


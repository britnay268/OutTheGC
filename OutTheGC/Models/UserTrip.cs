using System;
namespace OutTheGC.Models;

public class UserTrip
{
	public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TripId { get; set; }
    public DateTime CreatedAt { get; set; }
}


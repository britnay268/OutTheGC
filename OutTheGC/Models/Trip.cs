using System;
namespace OutTheGC.Models;

public class Trip
{
	public Guid Id { get; set; }
	public string Title { get; set; }
    public string? Notes { get; set; }
    public string Destination { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public decimal Budget { get; set; }
    public string? ImageUrl { get; set; }
    public Guid UserId { get; set; }
    public User Owner { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<Activity> Activities { get; set; }
    public List<User> Participants { get; set; }
}

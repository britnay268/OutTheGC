using System;
namespace OutTheGC.Models;

public class Activity
{
	public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public Trip Trip { get; set; }
    public string Title { get; set; }
    public string Notes { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public decimal Duration { get; set; }
    public decimal Cost { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string WebsiteUrl { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    List<Comment> Comments { get; set; }
}


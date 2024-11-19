using System;
namespace OutTheGC.Models;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string? Bio { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime DateJoined { get; set; }
    public string Uid { get; set; }
    public List<Activity> Activities { get; set; }
    public List <Comment> Comments { get; set; }
    public List <Trip> Trips { get; set; }
}


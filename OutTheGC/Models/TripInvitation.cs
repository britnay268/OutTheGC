using System;
namespace OutTheGC.Models;

public class TripInvitation
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid TripId { get; set; }
    public Guid? RecipientId { get; set; }
    public string RecipientEmail { get; set; }
    public DateTime SentDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public Trip Trip { get; set; }
}


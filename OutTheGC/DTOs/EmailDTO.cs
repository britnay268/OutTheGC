using System;
using OutTheGC.Models;
namespace OutTheGC.DTOs;

public class EmailDTO
{
	public string RecipientEmail { get; set; }
	public Guid SenderId { get; set; }
	public Guid TripId { get; set; }
}


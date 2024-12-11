using System;
using OutTheGC.Models;
namespace OutTheGC.DTOs;

public class EmailDTO
{
	public string Recipient { get; set; }
	public Guid UserId { get; set; }
}


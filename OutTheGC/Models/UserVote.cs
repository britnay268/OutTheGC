using System;
namespace OutTheGC.Models
{
	public class UserVote
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid ActivityId { get; set; }
	}
}


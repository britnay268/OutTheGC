using System;
using OutTheGC.Models;
namespace OutTheGC.Data;

public class UserVoteData
{
	public static List<UserVote> UsersVotes = new()
	{
		new()
		{
            Id = Guid.NewGuid(),
			UserId = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
			ActivityId = new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb")

        },
		new()
		{
            Id = Guid.NewGuid(),
			UserId = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
			ActivityId = new Guid("175a8012-6200-4180-915b-f3e4d604923d")
        },
		new()
		{
            Id = Guid.NewGuid(),
			UserId = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
			ActivityId = new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71")

        }
	};
}


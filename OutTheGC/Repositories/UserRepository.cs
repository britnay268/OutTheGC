using System;
using OutTheGC.Models;
using Microsoft.EntityFrameworkCore;
using OutTheGC.Interfaces;
using OutTheGC.Data;

namespace OutTheGC.Repositories;

public class UserRepository : IUserRepository
{
	private readonly OutTheGCDbContext dbContext;

	public UserRepository(OutTheGCDbContext context)
	{
		dbContext = context;
	}

	public async Task<User> GetSingleUserAsync(Guid userId)
	{
		var singleUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

		return singleUser;
	}

    public async Task<IResult> CheckUserExistenceAsync(string uid)
	{
		var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Uid == uid);

		if (user == null)
		{
			return Results.Ok(false);
		}

		return Results.Ok(true);
    }

    public async Task<User> CreateUserAsync(User newUser)
	{
		User addUser = new User
		{
			FullName = newUser.FullName,
			Email = newUser.Email,
			Bio = newUser.Bio,
			ImageUrl = newUser.ImageUrl,
			DateJoined = DateTime.Now,
			Uid = newUser.Uid
		};

		dbContext.Users.Add(addUser);
		dbContext.SaveChangesAsync();
		return addUser;
    }

    public async Task<User> UpdateUserAsync(Guid id, User existingUser)
	{
		var userToUpdate = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (userToUpdate == null)
        {
            return null;
        }

        userToUpdate.Email = existingUser.Email ?? userToUpdate.Email;
		userToUpdate.Bio = existingUser.Bio ?? userToUpdate.Bio;
		userToUpdate.ImageUrl = existingUser.ImageUrl ?? userToUpdate.ImageUrl;

		dbContext.SaveChangesAsync();
		return userToUpdate;
    }

    public async Task<User> DeleteUserAsync(Guid id)
	{
		var userToDelete = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

		if (userToDelete == null)
		{
			return null;
		}

		dbContext.Users.Remove(userToDelete);
		dbContext.SaveChangesAsync();

		return userToDelete;
    }
}


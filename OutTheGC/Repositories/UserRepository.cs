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
		throw new NotImplementedException();
	}

    public async Task<User> CheckUserExistenceAsync(string uid)
	{
        throw new NotImplementedException();
    }

    public async Task<User> CreateUserAsync(User newUser)
	{
        throw new NotImplementedException();
    }

    public async Task<User> UpdateUserAsync(Guid id, User existingUser)
	{
        throw new NotImplementedException();
    }

    public async Task<User> DeleteUserAsync(Guid id)
	{
        throw new NotImplementedException();
    }
}


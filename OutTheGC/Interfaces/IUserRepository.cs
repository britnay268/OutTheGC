using System;
using OutTheGC.Models;
namespace OutTheGC.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetSingleUserAsync(Guid id);

		Task<User> CheckUserExistenceAsync(string uid);

		Task<User> CreateUserAsync(User newUser);

		Task<User> UpdateUserAsync(Guid id, User existingUser);

		Task<User> DeleteUserAsync(Guid id);
	}
}


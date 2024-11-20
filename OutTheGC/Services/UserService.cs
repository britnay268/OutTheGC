using System;
using OutTheGC.Interfaces;
using OutTheGC.Models;

namespace OutTheGC.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

    public async Task<User> GetSingleUserAsync(Guid id)
    {
        return await _userRepository.GetSingleUserAsync(id);
    }

    public async Task<User> CheckUserExistenceAsync(string uid)
    {
        return await _userRepository.CheckUserExistenceAsync(uid);
    }

    public async Task<User> CreateUserAsync(User newUser)
    {
        return await _userRepository.CreateUserAsync(newUser);
    }

    public async Task<User> UpdateUserAsync(Guid id, User existingUser)
    {
        return await _userRepository.UpdateUserAsync(id, existingUser);
    }

    public async Task<User> DeleteUserAsync(Guid id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
}


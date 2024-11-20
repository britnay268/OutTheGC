﻿using System;
using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface IUserService
{
	Task<User> GetSingleUserAsync(Guid userId);

    Task<User> CheckUserExistenceAsync(string uid);

    Task<User> CreateUserAsync(User newUser);

    Task<User> UpdateUserAsync(Guid id, User existingUser);

    Task<User> DeleteUserAsync(Guid id);
}

﻿using OutTheGC.Models;
using OutTheGC.Interfaces;

namespace OutTheGC.Endpoints;

public static class UserEndpoint
{
	public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(User));

        group.MapGet("/user/{userId}", async (IUserService userService, Guid userId) =>
        {
            User user = await userService.GetSingleUserAsync(userId);

            if (user == null)
            {
                return Results.NotFound(new
                {
                    statusCode = 404,
                    message = "User not found",
                    errorCode = "USER_NOT_FOUND",
                    details = $"No user exists with the ID {userId}"
                });
            }

            return Results.Ok(new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.Bio,
                user.ImageUrl,
                user.DateJoined,
                user.Uid
            });
        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/user/exists", async (IUserService userService, string uid) =>
        {
            return await userService.CheckUserExistenceAsync(uid);
        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/user", async (IUserService userService, User newUser) =>
        {
            if (string.IsNullOrEmpty(newUser.FullName) || string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.Uid))
            {
                return Results.BadRequest(new { error = "FullName, Email, and Uid are required." });
            }

            var createdUser = await userService.CreateUserAsync(newUser);

            if (createdUser == null)
            {
                return Results.BadRequest();
            }

            return Results.Created($"/user/{createdUser.Id}", createdUser);
        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        group.MapPut("/user/{userId}", async (IUserService userService, Guid userId, User existingUser) =>
        {
            var userToUpdate = await userService.UpdateUserAsync(userId, existingUser);

            if (userToUpdate == null)
            {
                return Results.NotFound(new {error = "User by that id does not exist."});
            }

            return Results.Ok(new {message = "User information has been updated."});
        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/user/{userId}", async (IUserService userService, Guid userId) =>
        {
            var userToDelete = await userService.DeleteUserAsync(userId);

            if (userToDelete == null)
            {
                return Results.NotFound(new { error = "User by that id does not exist." });
            }

            return Results.Ok(new { message = "User has been deleted!" });
        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }

}


using System;
using OutTheGC.Models;
using OutTheGC.Interfaces;
using OutTheGC.Models;

namespace OutTheGC.Endpoints;

public static class UserEndpoint
{
	public static void MapUserRndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(User));

        group.MapGet("/user/{userId}", async (IUserService userService, Guid userId) =>
        {

        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/user/{userId}/exists", async (IUserService userService, Guid useId) =>
        {

        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/user", async (IUserService userService, User newUser) =>
        {

        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        group.MapPut("/user/{userId}", async (IUserService userService, Guid id, User existingUser) =>
        {

        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/user/{userId}", async (IUserService userService, Guid id) =>
        {

        })
        .WithOpenApi()
        .Produces<User>(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }

}


using OutTheGC.Models;
using OutTheGC.Interfaces;

namespace OutTheGC.Endpoints;

public static class CommentEndpoint
{
	public static void MapCommentEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(Comment));

        group.MapGet("/comment/{commentId}", async (ICommentService commentService, Guid commentId) =>
        {
            var singleComment = await commentService.GetSingleCommentAsync(commentId);

            if (singleComment == null)
            {
                return Results.NotFound(new
                {
                    error = "The commentId entered is not valid"
                });
            }

            return Results.Ok(new
            {
                singleComment.Id,
                singleComment.UserId,
                User = new
                {
                    singleComment.User.Id,
                    singleComment.User.FullName
                },
                singleComment.ActivityId,
                singleComment.Content,
                singleComment.CreatedAt,
                singleComment.UpdatedAt
            });
        })
        .WithOpenApi()
        .Produces<Comment>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/comment", async (ICommentService commentService, Comment newComment) =>
        {
            var commentToAdd = await commentService.CreateCommentAsync(newComment);

            return Results.Created($"/activity/{commentToAdd.Id}", commentToAdd);
        })
        .WithOpenApi()
        .Produces<Comment>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/comment/{commentId}", async (ICommentService commentService, Guid commentId, Comment updatedComment, Guid userId) =>
        {
            var commentToUpdate = await commentService.UpdateCommentAsync(commentId, updatedComment, userId);

            if (commentToUpdate == null)
            {
                return Results.NotFound(new
                {
                    error = "The comment does not exist."
                });
            }

            return Results.Ok(new { message = "Comment information has been updated." });
        })
        .WithOpenApi()
        .Produces<Comment>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/comment/{commentId}", async (ICommentService commentService, Guid commentId, Guid userId) =>
        {
            var commentToDelete = await commentService.DeleteCommentAsync(commentId, userId);

            if (commentToDelete == null)
            {
                return Results.NotFound(new
                {
                    error = "The comment does not exist."
                });
            }

            return Results.Ok(new { message = "Comment has been deleted." });
        })
        .WithOpenApi()
        .Produces<Comment>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);
    }
}


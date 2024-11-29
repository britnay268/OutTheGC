using OutTheGC.Data;
using OutTheGC.Interfaces;
using OutTheGC.Models;
using Microsoft.EntityFrameworkCore;

namespace OutTheGC.Repositories;

public class CommentRepository : ICommentRepository
{
	private readonly OutTheGCDbContext dbContext;

	public CommentRepository(OutTheGCDbContext context)
	{
		dbContext = context;
	}

    public async Task<Comment> GetSingleCommentAsync(Guid commentId)
    {
        return await dbContext.Comments.Include(c => c.User).SingleOrDefaultAsync(c => c.Id == commentId);
    }

    public async Task<Comment> CreateCommentAsync(Comment newComment)
    {
        var activityExists = await dbContext.Activities.AnyAsync(a => a.Id == newComment.ActivityId);

        var userExists = await dbContext.Users.AnyAsync(c => c.Id == newComment.UserId);

        if (!activityExists || !userExists)
        {
            var errors = new List<string>();
            if (!activityExists) errors.Add("Invalid ActivityId.");
            if (!userExists) errors.Add("Invalid UserId.");

            throw new InvalidOperationException($"Comment failed to be created: {string.Join(" ", errors)}");
        }

        Comment commentToAdd = new Comment
        {
            UserId = newComment.UserId,
            ActivityId = newComment.ActivityId,
            Content = newComment.Content,
            CreatedAt = DateTime.Now
        };

        dbContext.Comments.Add(commentToAdd);
        await dbContext.SaveChangesAsync();

        return commentToAdd;
    }

    public async Task<Comment> UpdateCommentAsync(Guid commentId, Comment updatedComment, Guid userId)
    {
        var commentToUpdate = await dbContext.Comments.SingleOrDefaultAsync(c => c.Id == commentId);

        if (commentToUpdate == null)
        {
            return null;
        }

        if (commentToUpdate.UserId != userId)
        {
            throw new Exception("403 Forbidden: User is not authorized to delete this activity");
        }

        commentToUpdate.Content = updatedComment.Content ?? commentToUpdate.Content;
        commentToUpdate.UpdatedAt = DateTime.Now;

        await dbContext.SaveChangesAsync();

        return commentToUpdate;
    }

    public async Task<Comment> DeleteCommentAsync(Guid commentId, Guid userId)
    {
        var commentToDelete = await dbContext.Comments.SingleOrDefaultAsync(c => c.Id == commentId);

        if (commentToDelete == null)
        {
            return null;
        }

        if (commentToDelete.UserId != userId)
        {
            throw new Exception("403 Forbidden: User is not authorized to delete this activity");
        }
        dbContext.Comments.Remove(commentToDelete);
        await dbContext.SaveChangesAsync();

        return commentToDelete;
    }
}


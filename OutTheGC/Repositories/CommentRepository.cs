using OutTheGC.Data;
using OutTheGC.Interfaces;
using OutTheGC.Models;

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
        throw new NotImplementedException();
    }

    public async Task<Comment> CreateCommentAsync(Comment newComment)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment> UpdateCommentAsync(Guid commentId, Comment updatedComment)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment> DeleteCommentAsync(Guid commentId)
    {
        throw new NotImplementedException();
    }
}


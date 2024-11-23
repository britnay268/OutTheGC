using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ICommentRepository
{
	Task<List<Comment>> GetCommentsAsync(Guid activityId);

	Task<Comment> GetSingleCommentAsync(Guid commentId);

	Task<Comment> CreateCommentAsync(Comment newComment);

	Task<Comment> UpdateCommentAsync(Guid commentId, Comment updatedComment);

	Task<Comment> DeleteCommentAsync(Guid commentId);
}


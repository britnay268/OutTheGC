using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ICommentRepository
{
	Task<Comment> GetSingleCommentAsync(Guid commentId);

	Task<Comment> CreateCommentAsync(Comment newComment);

	Task<Comment> UpdateCommentAsync(Guid commentId, Comment updatedComment, Guid userId);

	Task<Comment> DeleteCommentAsync(Guid commentId, Guid userId);
}


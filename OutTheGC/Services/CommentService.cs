using OutTheGC.Data;
using OutTheGC.Interfaces;
using OutTheGC.Models;

namespace OutTheGC.Services;

public class CommentService : ICommentService
{
	private readonly ICommentRepository _commentRepository;

	public CommentService(ICommentRepository commentRepository)
	{
		_commentRepository = commentRepository;
	}

    public async Task<Comment> GetSingleCommentAsync(Guid commentId)
    {
        return await _commentRepository.GetSingleCommentAsync(commentId);
    }

    public async Task<Comment> CreateCommentAsync(Comment newComment)
    {
        return await _commentRepository.CreateCommentAsync(newComment);
    }

    public async Task<Comment> UpdateCommentAsync(Guid commentId, Comment updatedComment)
    {
        return await _commentRepository.UpdateCommentAsync(commentId, updatedComment);
    }

    public async Task<Comment> DeleteCommentAsync(Guid commentId)
    {
        return await _commentRepository.DeleteCommentAsync(commentId);
    }
}


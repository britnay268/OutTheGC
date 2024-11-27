using Moq;
using OutTheGC.Services;
using OutTheGC.Interfaces;
using OutTheGC.Models;

namespace OutTheGC.Tests;

public class CommentServiceTests
{
    private readonly CommentService _commentService;

    private readonly Mock<ICommentRepository> _mockCommentRepository;

    public CommentServiceTests()
    {
        _mockCommentRepository = new Mock<ICommentRepository>();
        _commentService = new CommentService(_mockCommentRepository.Object);
    }

    [Fact]
    public async Task GetCommentDetails_Success()
    {
        Guid commentId = new Guid("fedcba98-7654-3210-fedc-ba9876543210");

        Comment expectedComment = new Comment
        {
            Id = commentId,
            UserId = new Guid("d2a207f0-2695-400b-9a52-b5995d6d5e3d"),
            ActivityId = new Guid("382e4b03-3e9b-4297-8ff4-096e787ef612"),
            Content = "I think we should rethink kayaking.",
            CreatedAt = DateTime.Now
        };
        _mockCommentRepository.Setup(repo => repo.GetSingleCommentAsync(commentId)).ReturnsAsync(expectedComment);

        var actualComment = await _commentService.GetSingleCommentAsync(commentId);

        Assert.Equal(expectedComment, actualComment);
    }

    [Fact]
    public async Task CreateComment_Success()
    {
        Comment expectedNewComment = new Comment
        {
            Id = new Guid("3c99229a-2fee-4123-912a-7669d075e4da"),
            UserId = new Guid("d2a207f0-2695-400b-9a52-b5995d6d5e3d"),
            ActivityId = new Guid("1b615afc-7477-488f-86c6-d7d72c8c8176"),
            Content = "The museums in New York are so cool! I am excited!!",
            CreatedAt = DateTime.Now
        };

        _mockCommentRepository.Setup(repo => repo.CreateCommentAsync(expectedNewComment)).ReturnsAsync(expectedNewComment);

        var actualNewComment = await _commentService.CreateCommentAsync(expectedNewComment);

        Assert.Equal(expectedNewComment, actualNewComment);
    }

    [Fact]
    public async Task UpdateComment_Success()
    {
        Guid commentId = new Guid("3c99229a-2fee-4123-912a-7669d075e4da");

        Comment expectedUpdatedComment = new Comment
        {
            Id = commentId,
            UserId = new Guid("d2a207f0-2695-400b-9a52-b5995d6d5e3d"),
            ActivityId = new Guid("1b615afc-7477-488f-86c6-d7d72c8c8176"),
            Content = "The museums in New York are so cool! I am so excited for this activity!!"
        };

        _mockCommentRepository.Setup(repo => repo.UpdateCommentAsync(commentId, expectedUpdatedComment)).ReturnsAsync(expectedUpdatedComment);

        var actualUpdatedComment = await _commentService.UpdateCommentAsync(commentId, expectedUpdatedComment);

        Assert.Equal(expectedUpdatedComment, actualUpdatedComment);
    }

    [Fact]
    public async Task DeleteComment_Success()
    {
        Guid commentId = new Guid("3c99229a-2fee-4123-912a-7669d075e4da");

        Comment expectedDeletedComment = new Comment
        {
            Id = commentId,
            UserId = new Guid("d2a207f0-2695-400b-9a52-b5995d6d5e3d"),
            ActivityId = new Guid("1b615afc-7477-488f-86c6-d7d72c8c8176"),
            Content = "The museums in New York are so cool! I am so excited for this activity!!"
        };

        _mockCommentRepository.Setup(repo => repo.DeleteCommentAsync(commentId)).ReturnsAsync(expectedDeletedComment);

        var actualDeletedComment = await _commentService.DeleteCommentAsync(commentId);

        Assert.Equal(expectedDeletedComment, actualDeletedComment);
    }
}


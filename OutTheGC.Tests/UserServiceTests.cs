using Moq;
using OutTheGC.Models;
using OutTheGC.Services;
using OutTheGC.Interfaces;
using Microsoft.AspNetCore.Http;

namespace OutTheGC.Tests;

public class UserServiceTests
{
    private readonly UserService _userService;

    private readonly Mock<IUserRepository> _mockUserRepository;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task GetUserDetails_Success()
    {
        Guid userId = new Guid("d2a207f0-2695-400b-9a52-b5995d6d5e3d");

        User expectedUser = new User
        {
            Id = userId,
            FullName =  "Jane Doe",
            Email =  "JaneDoe007@gmail.com",
            Bio = "This is Jane Does account",
            ImageUrl = "https://www.shutterstock.com/image-vector/pictogram-head-question-mark-john-260nw-171638717.jpg",
            DateJoined = DateTime.Now,
            Uid = "kVU8OMt1PNbdVMRJIYoWToozrTE3"
        };

        _mockUserRepository.Setup(repo => repo.GetSingleUserAsync(userId)).ReturnsAsync(expectedUser);

        User actualUser = await _userService.GetSingleUserAsync(userId);

        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public async Task CreateUser_Success()
    {
        User newUser = new User
        {
            FullName = "Sally Suie",
            Email = "SallySuie007@gmail.com",
            Bio = "This is Sally Suie coming at you!",
            ImageUrl = "https://www.shutterstock.com/image-vector/pictogram-head-question-mark-john-260nw-171638717.jpg",
            Uid = "kVU8OMt1PNbdVMRJIYoWToozr6He"
        };

        _mockUserRepository.Setup(repo => repo.CreateUserAsync(newUser)).ReturnsAsync(newUser);

        var actualUserCreated = await _userService.CreateUserAsync(newUser);

        Assert.Equal(newUser, actualUserCreated);
    }

    [Fact]
    public async Task UpdateUser_Success()
    {
        Guid userId = new Guid("9f8c12e3-75bd-4a8d-95f2-27eab3f7b40c");

        User userToUpdate = new User
        {
            Id = userId,
            Bio = "This is Sally's accounttt!!"
        };

        _mockUserRepository.Setup(repo => repo.UpdateUserAsync(userId, userToUpdate)).ReturnsAsync(userToUpdate);

        var actualUserToUpdate = await _userService.UpdateUserAsync(userId, userToUpdate);

        Assert.Equal(userToUpdate, actualUserToUpdate);
    }

    [Fact]
    public async Task DeleteUser_Success()
    {
        Guid userId = new Guid("6f10b1bc-ec0e-4a54-a6a0-50aa288285b8");

        User userToDelete = new User
        {
            Id = userId,
            FullName = "Sally Suie",
            Email = "SallySuie007@gmail.com",
            Bio = "This is Sally Suie coming at you!",
            ImageUrl = "https://www.shutterstock.com/image-vector/pictogram-head-question-mark-john-260nw-171638717.jpg",
            Uid = "kVU8OMt1PNbdVMRJIYoWToozr6He"
        };

        _mockUserRepository.Setup(repo => repo.DeleteUserAsync(userId)).ReturnsAsync(userToDelete);

        User actualDeletedUser = await _userService.DeleteUserAsync(userId);

        Assert.Equal(userToDelete, actualDeletedUser);
    }

    [Fact]
    public async Task UserExists_Success()
    {
        string userExistsUid = "hdahljloodjwoa";

        _mockUserRepository.Setup(repo => repo.CheckUserExistenceAsync(userExistsUid)).ReturnsAsync(Results.Ok(true));

        var result = await _userService.CheckUserExistenceAsync(userExistsUid);

        // This check that the result is of type HttpResults.Ok<bool>
        var actualResponse = Assert.IsType<Microsoft.AspNetCore.Http.HttpResults.Ok<bool>>(result);

        Assert.Equal(true, actualResponse.Value);
    }
}

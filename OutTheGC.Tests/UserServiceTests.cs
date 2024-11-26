using Moq;
using OutTheGC.Services;
using OutTheGC.Interfaces;

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

    }

    [Fact]
    public async Task CreateUser_Success()
    {

    }

    [Fact]
    public async Task UpdateUser_Success()
    {

    }

    [Fact]
    public async Task DeleteUser_Success()
    {

    }

    [Fact]
    public async Task UserExists_Success()
    {

    }
    
    [Fact]
    public async Task GetUserDetails_UserNotFound()
    {

    }

    [Fact]
    public async Task CreateUser_MissingFeilds()
    {

    }

    [Fact]
    public async Task UpdateUser_InvalidActivityId()
    {

    }

    [Fact]
    public async Task DeleteUser_InvalidActivityId()
    {

    }

    [Fact]
    public async Task UserExists_NotFound()
    {

    }

}

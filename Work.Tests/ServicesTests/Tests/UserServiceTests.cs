using Moq;
using Newtonsoft.Json;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.Tests.ServicesTests.TestsData;

namespace Work.Tests.ServicesTests.Tests;

public class UserServiceTests
{
    [Fact]
    public void GetAllUsersAsyncReturnHotelsList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Users.GetAllAsync()).Returns(GetTestUsersAsync());

        //Act
        var users = unitOfWorkMock.Object.Users.GetAllAsync().Result;

        //Assert
        Assert.NotNull(users);
        Assert.IsType<List<User>>(users);
    }

    [Theory]
    [ClassData(typeof(LoginUserTestsData))]
    public async Task LoginAsync(User user, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Users.UpdateAsync(user)).Returns(LoginTestAsync(user));

        //Act
        var actual = unitOfWorkMock.Object.Users.UpdateAsync(user);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(LogoutUserTestsData))]
    public async Task LogoutAsync(User user, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Users.UpdateAsync(user)).Returns(LogoutTestAsync(user));

        //Act
        var actual = unitOfWorkMock.Object.Users.UpdateAsync(user);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(EditUserTestsData))]
    public async Task EditUserAsync(User user, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Users.UpdateAsync(user)).Returns(EditTestHotel(user));

        //Act
        var actual = unitOfWorkMock.Object.Users.UpdateAsync(user);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddUserTestsData))]
    public async Task AddUserAsync(User user, User expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Users.CreateAsync(user)).Returns(AddTestUserAsync(user));

        //Act
        var actual = await unitOfWorkMock.Object.Users.CreateAsync(user);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteUserTestsData))]
    public async Task DeleteHotelAsync(User user, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Users.DeleteAsync(user)).Returns(DeleteTestUser(user));

        //Act
        var actual = unitOfWorkMock.Object.Users.DeleteAsync(user);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetUserByIdTestsData))]
    public async Task GetUserByIdAsyncReturnHotel(int id, User expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Users.GetByIdAsync(id)).Returns(GetTestUserByIdAsync(id));

        //Act
        var user = await unitOfWorkMock.Object.Users.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(user);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task LoginTestAsync(User user)
    {
        return Task.CompletedTask;
    }

    private Task LogoutTestAsync(User user)
    {
        return Task.CompletedTask;
    }

    private Task EditTestHotel(User user)
    {
        return Task.CompletedTask;
    }

    private async Task<User> AddTestUserAsync(User user)
    {
        return user;
    }

    private Task DeleteTestUser(User user)
    {
        return Task.CompletedTask;
    }

    private async Task<User> GetTestUserByIdAsync(int id)
    {
        if (id == 0) return null;

        return new User
        {
            Id = 3,
            Email = "user@mail.com",
            IsLogged = false,
            Role = "User"
        };
    }

    private async Task<List<User>> GetTestUsersAsync()
    {
        var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "administrator@mail.com",
                    IsLogged = true,
                    Role = "Administrator"
                },
                new User
                {
                    Id = 2,
                    Email = "manager@mail.com",
                    IsLogged = false,
                    Role = "Manager"
                },
                new User
                {
                    Id = 3,
                    Email = "user@mail.com",
                    IsLogged = false,
                    Role = "User"
                }
            };

        return users;
    }
}
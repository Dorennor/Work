using Moq;
using Newtonsoft.Json;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.Tests.ServicesTests.TestsData;

namespace Work.Tests.ServicesTests.Tests;

public class OrderServiceTests
{
    [Fact]
    public void GetAllOrdersAsyncReturnHotelsList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Orders.GetAllAsync()).Returns(GetTestOrdersAsync());

        //Act
        var order = unitOfWorkMock.Object.Orders.GetAllAsync().Result;

        //Assert
        Assert.NotNull(order);
        Assert.IsType<List<Order>>(order);
    }

    [Theory]
    [ClassData(typeof(EditOrderTestsData))]
    public async Task EditOrderAsync(Order order, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Orders.UpdateAsync(order)).Returns(EditTestOrder(order));

        //Act
        var actual = unitOfWorkMock.Object.Orders.UpdateAsync(order);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddOrderTestsData))]
    public async Task AddOrderAsync(Order order, Order expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Orders.CreateAsync(order)).Returns(AddTestOrderAsync(order));

        //Act
        var actual = await unitOfWorkMock.Object.Orders.CreateAsync(order);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteOrderTestsData))]
    public async Task DeleteOrderAsync(Order order, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Orders.DeleteAsync(order)).Returns(DeleteTestOrder(order));

        //Act
        var actual = unitOfWorkMock.Object.Orders.DeleteAsync(order);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetOrderByIdTestsData))]
    public async Task GetOrderByIdAsyncReturnHotel(int id, Order expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Orders.GetByIdAsync(id)).Returns(GetTestOrderByIdAsync(id));

        //Act
        var order = await unitOfWorkMock.Object.Orders.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(order);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task EditTestOrder(Order order)
    {
        return Task.CompletedTask;
    }

    private async Task<Order> AddTestOrderAsync(Order order)
    {
        return order;
    }

    private Task DeleteTestOrder(Order order)
    {
        return Task.CompletedTask;
    }

    private async Task<Order> GetTestOrderByIdAsync(int id)
    {
        if (id == 0) return null;

        return new Order
        {
            Id = 1,
            FinalPrice = 500,
            HotelTicketId = 1,
            TransportTicketId = 1,
            TourId = 1,
            UserId = 3
        };
    }

    private async Task<List<Order>> GetTestOrdersAsync()
    {
        var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    FinalPrice = 500,
                    HotelTicketId = 1,
                    TransportTicketId = 1,
                    TourId = 1,
                    UserId = 3
                },
                new Order
                {
                    Id = 2,
                    FinalPrice = 400,
                    HotelTicketId = 2,
                    TransportTicketId = 2,
                    TourId = 2,
                    UserId = 3
                }
            };

        return orders;
    }
}
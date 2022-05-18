using Moq;
using Newtonsoft.Json;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.Tests.ServicesTests.TestsData;

namespace Work.Tests.ServicesTests.Tests;

public class HotelTicketServiceTests
{
    [Fact]
    public void GetAllHotelTicketsAsyncReturnHotelsList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.HotelTickets.GetAllAsync()).Returns(GetTestHotelTicketsAsync());

        //Act
        var hotelTickets = unitOfWorkMock.Object.HotelTickets.GetAllAsync().Result;

        //Assert
        Assert.NotNull(hotelTickets);
        Assert.IsType<List<HotelTicket>>(hotelTickets);
    }

    [Theory]
    [ClassData(typeof(EditHotelTicketTestsData))]
    public async Task EditHotelTicketAsync(HotelTicket hotelTicket, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.HotelTickets.UpdateAsync(hotelTicket)).Returns(EditTestHotelTicket(hotelTicket));

        //Act
        var actual = unitOfWorkMock.Object.HotelTickets.UpdateAsync(hotelTicket);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddHotelTicketTestsData))]
    public async Task AddHotelTicketAsync(HotelTicket hotelTicket, HotelTicket expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.HotelTickets.CreateAsync(hotelTicket)).Returns(AddTestHotelTicketAsync(hotelTicket));

        //Act
        var actual = await unitOfWorkMock.Object.HotelTickets.CreateAsync(hotelTicket);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteHotelTicketTestsData))]
    public async Task DeleteHotelTicketAsync(HotelTicket hotelTicket, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.HotelTickets.DeleteAsync(hotelTicket)).Returns(DeleteTestHotelTicket(hotelTicket));

        //Act
        var actual = unitOfWorkMock.Object.HotelTickets.DeleteAsync(hotelTicket);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetHotelTicketByIdTestsData))]
    public async Task GetHotelTicketByIdAsyncReturnHotel(int id, HotelTicket expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.HotelTickets.GetByIdAsync(id)).Returns(GetTestHotelTicketByIdAsync(id));

        //Act
        var hotelTicket = await unitOfWorkMock.Object.HotelTickets.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(hotelTicket);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task EditTestHotelTicket(HotelTicket hotelTicket)
    {
        return Task.CompletedTask;
    }

    private async Task<HotelTicket> AddTestHotelTicketAsync(HotelTicket hotelTicket)
    {
        return hotelTicket;
    }

    private Task DeleteTestHotelTicket(HotelTicket hotelTicket)
    {
        return Task.CompletedTask;
    }

    private async Task<HotelTicket> GetTestHotelTicketByIdAsync(int id)
    {
        if (id == 0) return null;

        return new HotelTicket
        {
            Id = 3,
            HotelId = 1,
            NumberOfDays = 5,
            SummaryPrice = 100
        };
    }

    private async Task<List<HotelTicket>> GetTestHotelTicketsAsync()
    {
        var hotelTickets = new List<HotelTicket>
            {
                new HotelTicket
                {
                    Id = 3,
                    HotelId = 1,
                    NumberOfDays = 5,
                    SummaryPrice = 100
                },
                new HotelTicket
                {
                    Id = 2,
                    HotelId = 3,
                    NumberOfDays = 50,
                    SummaryPrice = 1020
                },
                new HotelTicket
                {
                    Id = 10,
                    HotelId = 5,
                    NumberOfDays = 15,
                    SummaryPrice = 2100
                }
            };

        return hotelTickets;
    }
}
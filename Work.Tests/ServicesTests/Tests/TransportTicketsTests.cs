using Moq;
using Newtonsoft.Json;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.Tests.ServicesTests.TestsData;

namespace Work.Tests.ServicesTests.Tests;

public class TransportTicketsTests
{
    [Fact]
    public void GetAllTransportTicketsAsyncReturnHotelsList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.TransportTickets.GetAllAsync()).Returns(GetTestTransportTicketsAsync());

        //Act
        var transportTickets = unitOfWorkMock.Object.TransportTickets.GetAllAsync().Result;

        //Assert
        Assert.NotNull(transportTickets);
        Assert.IsType<List<TransportTicket>>(transportTickets);
    }

    [Theory]
    [ClassData(typeof(EditTransportTicketTestsData))]
    public async Task EditTransportTicketAsync(TransportTicket transportTicket, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.TransportTickets.UpdateAsync(transportTicket)).Returns(EditTestTransportTicket(transportTicket));

        //Act
        var actual = unitOfWorkMock.Object.TransportTickets.UpdateAsync(transportTicket);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddTransportTicketTestsData))]
    public async Task AddTransportTicketAsync(TransportTicket transportTicket, TransportTicket expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.TransportTickets.CreateAsync(transportTicket)).Returns(AddTestTransportTicketAsync(transportTicket));

        //Act
        var actual = await unitOfWorkMock.Object.TransportTickets.CreateAsync(transportTicket);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteTransportTicketTestsData))]
    public async Task DeleteTransportTicketAsync(TransportTicket transportTicket, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.TransportTickets.DeleteAsync(transportTicket)).Returns(DeleteTestTransportTicket(transportTicket));

        //Act
        var actual = unitOfWorkMock.Object.TransportTickets.DeleteAsync(transportTicket);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetTransportTicketByIdTestsData))]
    public async Task GetTransportTicketByIdAsyncReturnHotel(int id, TransportTicket expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.TransportTickets.GetByIdAsync(id)).Returns(GetTestTransportTicketByIdAsync(id));

        //Act
        var hotel = await unitOfWorkMock.Object.TransportTickets.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(hotel);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task EditTestTransportTicket(TransportTicket transportTicket)
    {
        return Task.CompletedTask;
    }

    private async Task<TransportTicket> AddTestTransportTicketAsync(TransportTicket transportTicket)
    {
        return transportTicket;
    }

    private Task DeleteTestTransportTicket(TransportTicket transportTicket)
    {
        return Task.CompletedTask;
    }

    private async Task<TransportTicket> GetTestTransportTicketByIdAsync(int id)
    {
        if (id == 0) return null;

        return new TransportTicket
        {
            Id = 3,
            NumberOfUsing = 3,
            TransportId = 2,
            TransportPrice = 30
        };
    }

    private async Task<List<TransportTicket>> GetTestTransportTicketsAsync()
    {
        var transportTickets = new List<TransportTicket>
            {
                new TransportTicket
                {
                    Id = 3,
                    NumberOfUsing = 3,
                    TransportId = 2,
                    TransportPrice = 30
                },
                new TransportTicket
                {
                    Id = 5,
                    NumberOfUsing = 7,
                    TransportId = 8,
                    TransportPrice = 40
                }
            };

        return transportTickets;
    }
}
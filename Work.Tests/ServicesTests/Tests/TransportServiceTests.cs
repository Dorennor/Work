using Moq;
using Newtonsoft.Json;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.Tests.ServicesTests.TestsData;

namespace Work.Tests.ServicesTests.Tests;

public class TransportServiceTests
{
    [Fact]
    public void GetAllTransportsAsyncReturnTransportsList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Transports.GetAllAsync()).Returns(GetTestTransportsAsync());

        //Act
        var transports = unitOfWorkMock.Object.Transports.GetAllAsync().Result;

        //Assert
        Assert.NotNull(transports);
        Assert.IsType<List<Transport>>(transports);
    }

    [Theory]
    [ClassData(typeof(EditTransportTestsData))]
    public async Task EditTransportAsync(Transport transport, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Transports.UpdateAsync(transport)).Returns(EditTestTransport(transport));

        //Act
        var actual = unitOfWorkMock.Object.Transports.UpdateAsync(transport);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddTransportTestsData))]
    public async Task AddTransportAsync(Transport transport, Transport expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Transports.CreateAsync(transport)).Returns(AddTestTransportAsync(transport));

        //Act
        var actual = await unitOfWorkMock.Object.Transports.CreateAsync(transport);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteTransportTestsData))]
    public async Task DeleteTransportAsync(Transport transport, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Transports.DeleteAsync(transport)).Returns(DeleteTestTransport(transport));

        //Act
        var actual = unitOfWorkMock.Object.Transports.DeleteAsync(transport);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetTransportByIdTestsData))]
    public async Task GetTransportByIdAsyncReturnTransport(int id, Transport expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Transports.GetByIdAsync(id)).Returns(GetTestTransportByIdAsync(id));

        //Act
        var transport = await unitOfWorkMock.Object.Transports.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(transport);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task EditTestTransport(Transport transport)
    {
        return Task.CompletedTask;
    }

    private async Task<Transport> AddTestTransportAsync(Transport transport)
    {
        return transport;
    }

    private Task DeleteTestTransport(Transport transport)
    {
        return Task.CompletedTask;
    }

    private async Task<Transport> GetTestTransportByIdAsync(int id)
    {
        if (id == 0) return null;

        return new Transport
        {
            Id = 1,
            Name = "Liner",
            TransportPrice = 82.60
        };
    }

    private async Task<List<Transport>> GetTestTransportsAsync()
    {
        var transports = new List<Transport>
            {
                new Transport
                {
                    Id = 1,
                    Name = "Liner",
                    TransportPrice = 82.60
                },
                new Transport
                {
                    Id = 2,
                    Name = "Bus",
                    TransportPrice = 10.20
                },
                new Transport
                {
                    Id = 3,
                    Name = "Airplane",
                    TransportPrice = 52.30
                }
            };

        return transports;
    }
}
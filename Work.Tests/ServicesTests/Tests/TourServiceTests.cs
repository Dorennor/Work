using Moq;
using Newtonsoft.Json;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.Tests.ServicesTests.TestsData;

namespace Work.Tests.ServicesTests.Tests;

public class TourServiceTests
{
    [Fact]
    public void GetAllHotelsAsyncReturnToursList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tours.GetAllAsync()).Returns(GetTestToursAsync());

        //Act
        var tours = unitOfWorkMock.Object.Tours.GetAllAsync().Result;

        //Assert
        Assert.NotNull(tours);
        Assert.IsType<List<Tour>>(tours);
    }

    [Theory]
    [ClassData(typeof(EditTourTestsData))]
    public async Task EditTourAsync(Tour tour, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tours.UpdateAsync(tour)).Returns(EditTestTour(tour));

        //Act
        var actual = unitOfWorkMock.Object.Tours.UpdateAsync(tour);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddTourTestsData))]
    public async Task AddTourAsync(Tour tour, Tour expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tours.CreateAsync(tour)).Returns(AddTestTourAsync(tour));

        //Act
        var actual = await unitOfWorkMock.Object.Tours.CreateAsync(tour);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteTourTestsData))]
    public async Task DeleteTourAsync(Tour tour, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tours.DeleteAsync(tour)).Returns(DeleteTestTour(tour));

        //Act
        var actual = unitOfWorkMock.Object.Tours.DeleteAsync(tour);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetTourByIdTestsData))]
    public async Task GetTourByIdAsyncReturnHotel(int id, Tour expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tours.GetByIdAsync(id)).Returns(GetTestTourByIdAsync(id));

        //Act
        var tour = await unitOfWorkMock.Object.Tours.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(tour);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task EditTestTour(Tour tour)
    {
        return Task.CompletedTask;
    }

    private async Task<Tour> AddTestTourAsync(Tour tour)
    {
        return tour;
    }

    private Task DeleteTestTour(Tour tour)
    {
        return Task.CompletedTask;
    }

    private async Task<Tour> GetTestTourByIdAsync(int id)
    {
        if (id == 0) return null;

        return new Tour
        {
            Id = 1,
            TourMovementType = "Walking",
            TourName = "Fenway Park",
            TourDateTime = new DateTime(2022, 5, 30),
            TourDurationInDays = 1,
            TourRegion = "USA",
            TourType = "Individual Tour",
            TourPrice = 100
        };
    }

    private async Task<List<Tour>> GetTestToursAsync()
    {
        var tours = new List<Tour>
            {
                new Tour
                {
                    Id = 1,
                    TourMovementType = "Walking",
                    TourName = "Fenway Park",
                    TourDateTime = new DateTime(2022, 5, 30),
                    TourDurationInDays = 1,
                    TourRegion = "USA",
                    TourType = "Individual Tour",
                    TourPrice = 100
                },
                new Tour
                {
                    Id = 2,
                    TourMovementType = "Climbing",
                    TourName = "Colorado Hiking: Rocky Mountain National Park",
                    TourDateTime = new DateTime(2022, 11, 20),
                    TourDurationInDays = 6,
                    TourRegion = "USA",
                    TourType = "Mountain Skiing Tour",
                    TourPrice = 200
                }
            };

        return tours;
    }
}
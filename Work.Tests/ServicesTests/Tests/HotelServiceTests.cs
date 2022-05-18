using Moq;
using Newtonsoft.Json;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.Tests.ServicesTests.TestsData;

namespace Work.Tests.ServicesTests.Tests
{
    public class HotelServiceTests
    {
        [Fact]
        public void GetAllHotelsAsyncReturnHotelsList()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Hotels.GetAllAsync()).Returns(GetTestHotelsAsync());

            //Act
            var hotels = unitOfWorkMock.Object.Hotels.GetAllAsync().Result;

            //Assert
            Assert.NotNull(hotels);
            Assert.IsType<List<Hotel>>(hotels);
        }

        [Theory]
        [ClassData(typeof(EditHotelTestsData))]
        public async Task EditHotelAsync(Hotel hotel, Task expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Hotels.UpdateAsync(hotel)).Returns(EditTestHotel(hotel));

            //Act
            var actual = unitOfWorkMock.Object.Hotels.UpdateAsync(hotel);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(AddHotelTestsData))]
        public async Task AddHotelAsync(Hotel hotel, Hotel expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Hotels.CreateAsync(hotel)).Returns(AddTestHotelAsync(hotel));

            //Act
            var actual = await unitOfWorkMock.Object.Hotels.CreateAsync(hotel);
            var actualJson = JsonConvert.SerializeObject(actual);
            var expectedJson = JsonConvert.SerializeObject(expected);

            //Assert
            Assert.Equal(expectedJson, actualJson);
        }

        [Theory]
        [ClassData(typeof(DeleteHotelTestsData))]
        public async Task DeleteHotelAsync(Hotel hotel, Task expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Hotels.DeleteAsync(hotel)).Returns(DeleteTestHotel(hotel));

            //Act
            var actual = unitOfWorkMock.Object.Hotels.DeleteAsync(hotel);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetHotelByIdTestsData))]
        public async Task GetHotelByIdAsyncReturnHotel(int id, Hotel expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Hotels.GetByIdAsync(id)).Returns(GetTestHotelByIdAsync(id));

            //Act
            var hotel = await unitOfWorkMock.Object.Hotels.GetByIdAsync(id);
            var actualJson = JsonConvert.SerializeObject(hotel);
            var expectedJson = JsonConvert.SerializeObject(expected);

            //Assert
            Assert.Equal(expectedJson, actualJson);
        }

        private Task EditTestHotel(Hotel hotel)
        {
            return Task.CompletedTask;
        }

        private async Task<Hotel> AddTestHotelAsync(Hotel hotel)
        {
            return hotel;
        }

        private Task DeleteTestHotel(Hotel hotel)
        {
            return Task.CompletedTask;
        }

        private async Task<Hotel> GetTestHotelByIdAsync(int id)
        {
            if (id == 0) return null;

            return new Hotel
            {
                Id = 3,
                HotelName = "Montage Kapalua Bay",
                HotelStars = 5,
                HotelPrice = 90
            };
        }

        private async Task<List<Hotel>> GetTestHotelsAsync()
        {
            var hotels = new List<Hotel>
            {
                new Hotel
                {
                    Id = 1,
                    HotelName = "Belagio",
                    HotelStars = 3,
                    HotelPrice = 45
                },
                new Hotel
                {
                    Id = 2,
                    HotelName = "The Peninsula Chicago",
                    HotelStars = 4,
                    HotelPrice = 70
                },
                new Hotel
                {
                    Id = 3,
                    HotelName = "Montage Kapalua Bay",
                    HotelStars = 5,
                    HotelPrice = 90
                }
            };

            return hotels;
        }
    }
}
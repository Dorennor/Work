using Microsoft.EntityFrameworkCore;
using Work.DAL.Entities;

namespace Work.DAL.Data;

public static class SeedData
{
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        User admin = new User
        {
            Id = 1,
            Email = "administrator@mail.com",
            IsLogged = true,
            Role = "Administrator"
        };
        User manager = new User
        {
            Id = 2,
            Email = "manager@mail.com",
            IsLogged = false,
            Role = "Manager"
        };
        User user = new User
        {
            Id = 3,
            Email = "user@mail.com",
            IsLogged = false,
            Role = "User"
        };

        admin.GeneratePasswordHash("administrator");
        manager.GeneratePasswordHash("manager");
        user.GeneratePasswordHash("user");

        modelBuilder.Entity<User>().HasData(admin, manager, user);
    }

    public static void SeedTransport(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transport>().HasData(
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
        );
    }

    public static void SeedTours(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>().HasData(
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
        );
    }

    public static void SeedHotels(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasData(
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
        );
    }
}
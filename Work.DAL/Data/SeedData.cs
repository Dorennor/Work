using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Work.DAL.Entities;

namespace Work.DAL.Data;

public static class SeedData
{
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        IdentityUser<int> admin = new IdentityUser<int>
        {
            Id = 1,
            Email = "administrator@mail.com",
            NormalizedEmail = "ADMINISTRATOR@MAIL.COM",
            UserName = "Administrator",
            NormalizedUserName = "ADMINISTRATOR",
            EmailConfirmed = true
        };
        IdentityUser<int> manager = new IdentityUser<int>
        {
            Id = 2,
            Email = "manager@mail.com",
            NormalizedEmail = "MANAGER@MAIL.COM",
            UserName = "Manager",
            NormalizedUserName = "MANAGER",
            EmailConfirmed = true
        };
        IdentityUser<int> user = new IdentityUser<int>
        {
            Id = 3,
            Email = "user@mail.com",
            NormalizedEmail = "USER@MAIL.COM",
            UserName = "User",
            NormalizedUserName = "USER",
            EmailConfirmed = true
        };

        PasswordHasher<IdentityUser<int>> passwordHasher = new PasswordHasher<IdentityUser<int>>();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "administrator");
        manager.PasswordHash = passwordHasher.HashPassword(manager, "manager");
        user.PasswordHash = passwordHasher.HashPassword(user, "user");

        modelBuilder.Entity<IdentityUser<int>>().HasData(admin, manager, user);
    }

    public static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new IdentityRole<int>
            {
                Id = 3,
                Name = "User",
                NormalizedName = "USER"
            });
    }

    public static void SeedUserRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            },
            new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 2
            },
            new IdentityUserRole<int>
            {
                RoleId = 3,
                UserId = 3
            });
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
                TourName = "Colorado Hiking: Rocky Mountain National Park",
                TourDateTime = new DateTime(2022, 11, 20),
                TourDurationInDays = 6,
                TourRegion = "USA",
                TourType = "Mountain Skiing Tour"
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
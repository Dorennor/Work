using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Work.DAL.Entities;

namespace Work.DAL.Data;

public class TourDbContext : IdentityDbContext<User>
{
    public DbSet<Tour> Tours { get; set; }

    //public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<HotelTicket> HotelTickets { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<TransportTicket> TransportTickets { get; set; }
    public DbSet<Transport> Transports { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer(@"Server=VLADIMIRPC;Database=TourDb;Trusted_Connection=True;");
    //    }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Transport>().HasData(
            new Transport
            {
                Id = 1,
                Name = "Liner",
                Price = 50
            }
        );
        //SeedRoles(modelBuilder);
        //SeedUsers(modelBuilder);
        //SeedUserRoles(modelBuilder);
    }

    //private void SeedRoles(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<IdentityRole>().HasData(
    //        new IdentityRole<int>
    //        {
    //            Id = 1,
    //            Name = "Administrator",
    //            NormalizedName = "ADMINISTRATOR"
    //        },
    //        new IdentityRole<int>
    //        {
    //            Id = 2,
    //            Name = "User",
    //            NormalizedName = "USER"
    //        },
    //        new IdentityRole<int>
    //        {
    //            Id = 3,
    //            Name = "Manager",
    //            NormalizedName = "MANAGER"
    //        });
    //}

    //private void SeedUsers(ModelBuilder modelBuilder)
    //{
    //    User admin = new User()
    //    {
    //        Id = 1,
    //        Email = "admin@mail.com",
    //        NormalizedEmail = "ADMIN@MAIL.COM",
    //        UserName = "Administrator",
    //        NormalizedUserName = "ADMINISTRATOR",
    //        EmailConfirmed = true
    //    };

    //    PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
    //    admin.PasswordHash = passwordHasher.HashPassword(admin, "administrator");

    //    modelBuilder.Entity<User>().HasData(admin);
    //}

    //private void SeedUserRoles(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
    //        new IdentityUserRole<int>
    //        {
    //            RoleId = 2,
    //            UserId = 1
    //        });
    //}

    public TourDbContext()
    {
        Database.Migrate();
    }

    public TourDbContext(DbContextOptions<TourDbContext> options) : base(options)
    {
        Database.Migrate();
    }
}
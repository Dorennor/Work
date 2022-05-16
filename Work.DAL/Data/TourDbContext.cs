using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Work.DAL.Entities;

namespace Work.DAL.Data;

public class TourDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Tour> Tours { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<HotelTicket> HotelTickets { get; set; }

    public DbSet<Hotel> Hotels { get; set; }

    public DbSet<TransportTicket> TransportTickets { get; set; }

    public DbSet<Transport> Transports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedData.SeedUsers(modelBuilder);
        SeedData.SeedTours(modelBuilder);
        SeedData.SeedTransport(modelBuilder);
        SeedData.SeedHotels(modelBuilder);
    }

    public TourDbContext()
    {
        Database.Migrate();
    }

    public TourDbContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}
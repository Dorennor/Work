using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
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
            var connectionString = config.GetConnectionString("LocalDbConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File(AppContext.BaseDirectory + $"/logs/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}_log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
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
        try
        {
            Database.Migrate();
        }
        catch
        {
            Log.Information("Migration, try #1");
            try
            {
                Database.Migrate();
            }
            catch
            {
                Log.Information("Migration, try #2");
                try
                {
                    Database.Migrate();
                }
                catch
                {
                    Log.Information("Migration, try #3");
                    Log.Information("Migration failed.");
                }
            }
        }
    }

    public TourDbContext(DbContextOptions options) : base(options)
    {
        try
        {
            Database.Migrate();
        }
        catch
        {
            Log.Information("Migration, try #1");
            try
            {
                Database.Migrate();
            }
            catch
            {
                Log.Information("Migration, try #2");
                try
                {
                    Database.Migrate();
                }
                catch
                {
                    Log.Information("Migration, try #3");
                    Log.Information("Migration failed.");
                }
            }
        }
    }
}
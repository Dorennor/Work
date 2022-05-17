using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Work.WebClient.Interfaces;
using Work.WebClient.Services;

namespace Work.WebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Views/Home/Index", "");
            });

            builder.Services.AddTransient<IUserManagerService, UserManagerService>();
            builder.Services.AddScoped<ITransportService, TransportService>();
            builder.Services.AddScoped<ITourService, TourService>();
            builder.Services.AddTransient<ITransportService, TransportService>();
            builder.Services.AddTransient<IHotelService, HotelService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<ITransportTicketService, TransportTicketService>();
            builder.Services.AddTransient<IHotelTicketService, HotelTicketService>();

            var app = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(AppContext.BaseDirectory + $"/logs/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}_log.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

#if DEBUG
            app.UseDeveloperExceptionPage();
            app.UseHsts();
#endif

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapRazorPages();
            app.Run();
        }
    }
}
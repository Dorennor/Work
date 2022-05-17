using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Work.BLL.Interfaces;
using Work.BLL.Services;

namespace Work.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<ITransportService, TransportService>();
            builder.Services.AddScoped<ITourService, TourService>();
            builder.Services.AddScoped<IUserService, UserService>();
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
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
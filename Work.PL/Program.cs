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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File("logs/log.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<ITransportService, TransportService>();
            builder.Services.AddScoped<ITourService, TourService>();

            var app = builder.Build();
#if DEBUG
            app.UseDeveloperExceptionPage();
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
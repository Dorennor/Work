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
            builder.Services.AddTransient<IUserManager, UserManager>();

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
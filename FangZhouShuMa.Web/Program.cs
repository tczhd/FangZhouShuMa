using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using FangZhouShuMa.Infrastructure.Data;
using FangZhouShuMa.Infrastructure.Identity;

namespace FangZhouShuMa.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var fangZhouShuMaContext = services.GetRequiredService<FangZhouShuMaContext>();
                    FangZhouShuMaContextSeed.SeedAsync(fangZhouShuMaContext, loggerFactory)
            .Wait();

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    ApplicationDbContextSeed.SeedAsync(userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

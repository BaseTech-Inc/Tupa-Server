using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

using Application.Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence;

namespace WebAPI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    context.Database.SetCommandTimeout(0);

                    if (context.Database.IsSqlServer() || context.Database.IsRelational())
                    {
                        await context.Database.MigrateAsync();
                    }

                   var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var placesService = services.GetRequiredService<IPlacesService>();
                    var meshesService = services.GetRequiredService<IMeshesService>();

                    await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);
                    await ApplicationDbContextSeed.SeedDefaultPontosRiscoAsync(context, logger);
                    await ApplicationDbContextSeed.SeedDefaultPlacesAsync(context, placesService, meshesService, logger);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

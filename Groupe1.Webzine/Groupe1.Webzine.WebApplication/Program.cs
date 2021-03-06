using Groupe1.Webzine.EntitiesContext;
using Groupe1.Webzine.EntitiesContext.Seeder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Groupe1.Webzine.WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            if (Config.RepositoryOptions == "db")
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = new WebzineDbContext(services.GetRequiredService<DbContextOptions<WebzineDbContext>>());

                    var config = services.GetRequiredService<IConfiguration>();
                    Config.SeederOption = config.GetSection("Config").GetSection("SeederOption").Value;

                    if (Config.SeederOption == "locale")
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        SeedDataLocal.Initialize(services);
                    }
                    else if (Config.SeederOption == "spotify")
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        SeedDataSpotify.Initialize(services);
                    }

                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

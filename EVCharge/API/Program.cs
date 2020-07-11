using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Core
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            //Using statement used so that the code inside it gets dispossed of as soon as it gets run
            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                //Used to create instances of a logger class
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try 
                {
                    var context = services.GetRequiredService<StoreContext>();
                    //Used to apply any pending migrations for the context to the DB. Will create the DB if it doesn't exist already.
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during the migration!!!");
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

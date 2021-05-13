using App.Application.EntitiesCommandsQueries.System.SeedDB;
using App.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {

                var services = scope.ServiceProvider;
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                try
                {
                    var appDbContext = services.GetRequiredService<AppDbContext>();
                    appDbContext.Database.Migrate();

                    logger.LogInformation("App Starting");


                    // Seed DB

                    var mediator = services.GetRequiredService<IMediator>();

                    await mediator.Send(new SeedDBCommand {FolderKey="AppDB" }, CancellationToken.None);
                }
                catch (Exception ex)
                {

                    
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");

                }

            }


            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureAppConfiguration((builderContext, config) =>
                     {

                         var configurationBuilder = new ConfigurationBuilder();

                         configurationBuilder.AddEnvironmentVariables();

                         config.AddConfiguration(configurationBuilder.Build());
                     })
                    .ConfigureLogging((hostingContext, builder) =>
                     {
                         builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                         
                     })
                     .UseSerilog((builderContext, config) =>
                     {
                         var loggerSettings = builderContext.Configuration.GetSection("LoggerSetting");

                         config
                             .Enrich.FromLogContext()
                             .WriteTo.Console()
                             .WriteTo.File(
                                 @loggerSettings["Path"],
                                 fileSizeLimitBytes: 1_000_000,
                                 rollOnFileSizeLimit: true,
                                 shared: true,
                                 flushToDiskInterval: TimeSpan.FromSeconds(1)
                             );
                     });

                });
    }
}

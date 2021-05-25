using App.API.Extensions;
using App.Application.EntitiesCommandsQueries.System.SeedDB;
using App.Application.Infrastructure;
using App.Application.Interfaces.FileOperations;
using App.Application.Interfaces.Notifications;
using App.Application.Interfaces.Utilities;
using App.Infrastructure.FileOperations;
using App.Infrastructure.Notifications;
using App.Infrastructure.Utilities;
using App.Persistence;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace App.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string dbConnectionString = Configuration.GetConnectionString("AppDB");

            // DB Contexts
            services.AddDbContext<AppDbContext>(options =>
              options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.API", Version = "v1" });
            });

            services.AddTransient<IMachineDateTime, MachineDateTime>();
            services.AddTransient<IMachineLogger, MachineLogger>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IFileUtils, FileUtils>();

            //Add Mediator
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            services.AddMediatR(typeof(SeedDBCommand).GetTypeInfo().Assembly);


            //CORS
            services.ConfigureCors(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

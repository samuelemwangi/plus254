using App.API.Extensions;
using App.API.Helpers;
using App.Application.EntitiesCommandsQueries.Countries.Commands.CreateCountry;
using App.Application.EntitiesCommandsQueries.System.SeedDB;
using App.Application.Infrastructure;
using App.Application.Interfaces.Messaging;
using App.Application.Interfaces.Utilities;
using App.Infrastructure.Messaging;
using App.Infrastructure.Utilities;
using App.Persistence;
using Confluent.Kafka;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            // Read environment Values 
            string dbServer = Configuration.GetValue<string>("DB_SERVER");
            string dbUser = Configuration.GetValue<string>("DB_USER");
            string dbPassword = Configuration.GetValue<string>("DB_PASSWORD");

            string secretKey = Configuration.GetValue<string>("SECRET_KEY");

            string messagingBrokers = Configuration.GetValue<string>("MESSAGING_BROKERS");


            // Connection string from appsettings
            string connectionString = Configuration.GetConnectionString("AppDB");

            string dbConnectionString = connectionString.Replace("DB_SERVER", dbServer)
                                                        .Replace("DB_USER", dbUser)
                                                        .Replace("DB_PASSWORD", dbPassword);


            // DB Contexts
            // if env variables not set use connection string as it is 
            services.AddDbContext<AppDbContext>(options =>
              options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(String.IsNullOrEmpty(dbServer) ? connectionString : dbConnectionString)));

            // Register the ConfigurationBuilder instance of AuthSettings
            var authSettings = Configuration.GetSection(nameof(AuthSettings));
            services.Configure<AuthSettings>(authSettings);


            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey + "" == "" ? authSettings[nameof(AuthSettings.SecretKey)] : secretKey));

            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection("JwtIssuerOptions");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions["Issuer"],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions["Audience"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions["Issuer"];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;

                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("X-Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });


            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCountryCommandValidator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.API", Version = "v1" });
            });


            //Kafka
            var messagingConfigs = Configuration.GetSection("Messaging");

            var producerConfig = new ProducerConfig(new ClientConfig
            {
                BootstrapServers = String.IsNullOrEmpty(messagingBrokers) ? messagingConfigs["BootstrapServers"] : messagingBrokers
            });


            services.AddSingleton(producerConfig);
            services.AddSingleton(typeof(IMessageProducer<,>), typeof(MessageProducer<,>));

            services.AddTransient<IMachineDateTime, MachineDateTime>();
            services.AddTransient<IMachineLogger, MachineLogger>();
            

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

using App.API.Extensions;
using App.API.Helpers;
using App.Application.EntitiesCommandsQueries.System.SeedDB;
using App.Application.EntitiesCommandsQueries.Users.Commands.LoginUser;
using App.Application.Infrastructure;
using App.Application.Interfaces.Auth;
using App.Application.Interfaces.Notifications;
using App.Application.Interfaces.Utilities;
using App.Infrastructure.Auth;
using App.Infrastructure.Helpers;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Notifications;
using App.Infrastructure.Utilities;
using App.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;

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


            string connectionString = Configuration.GetConnectionString("AppDB");

            string dbServer = Configuration.GetValue<string>("DB_SERVER");
            string dbUser = Configuration.GetValue<string>("DB_USER");
            string dbPassword = Configuration.GetValue<string>("DB_PASSWORD");
            string secretKey = Configuration.GetValue<string>("SECRET_KEY");

            string dbConnectionString = connectionString.Replace("DB_SERVER", dbServer)
                                                        .Replace("DB_USER", dbUser)
                                                        .Replace("DB_PASSWORD", dbPassword);


            // DB Contexts
            services.AddDbContext<AppDbContext>(options =>
              options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

            // Register the ConfigurationBuilder instance of AuthSettings
            var authSettings = Configuration.GetSection(nameof(AuthSettings));
            services.Configure<AuthSettings>(authSettings);

            //var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings[nameof(AuthSettings.SecretKey)]));            

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey + "" == "" ? authSettings[nameof(AuthSettings.SecretKey)] : secretKey));

            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.ValidFor = TimeSpan.FromMinutes(Double.Parse(jwtAppSettingOptions[nameof(JwtIssuerOptions.ValidFor)]));
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

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
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;


                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });


            // api user claim policy
            services.AddAuthorization(options =>
            {
                //options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, "AppUser"));
            });

            // add identity
            var identityBuilder = services.AddIdentityCore<IdentityUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequiredLength = 8;
            });



            identityBuilder.AddRoles<IdentityRole>();

            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole), identityBuilder.Services);
            identityBuilder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginUserCommandValidator>());

            services.AddTransient<IJwtFactory, JwtFactory>();
            services.AddTransient<IJwtTokenHandler, JwtTokenHandler>();
            services.AddTransient<IJwtTokenValidator, JwtTokenValidator>();
            services.AddTransient<ITokenFactory, TokenFactory>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.API", Version = "v1" });
            });

            services.AddTransient<IMachineDateTime, MachineDateTime>();
            services.AddTransient<IMachineLogger, MachineLogger>();
            services.AddTransient<INotificationService, NotificationService>();

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

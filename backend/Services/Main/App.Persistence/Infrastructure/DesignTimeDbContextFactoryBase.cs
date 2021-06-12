using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// DesignTimeDbContextFactoryBase
/// </summary>

namespace App.Persistence.Infrastructure
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "AppDB";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
        public TContext CreateDbContext(string[] args)
        {
            string basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}App.API", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        private TContext Create(string basePath, string environmentName)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();


            string connectionString = configuration.GetConnectionString(ConnectionStringName);

            string dbServer = configuration["DB_SERVER"];
            string dbUser = configuration["DB_USER"];
            string dbPassword = configuration["DB_PASSWORD"];

            string dbConnectionString = connectionString.Replace("DB_SERVER", dbServer)
                                                        .Replace("DB_USER", dbUser)
                                                        .Replace("DB_PASSWORD", dbPassword);

            // check if env vaiables are set if not use connection string
            return Create(String.IsNullOrEmpty(dbServer) ? connectionString : dbConnectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");


            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}

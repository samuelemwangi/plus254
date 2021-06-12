using App.Domain.Entities.Countries;
using App.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence
{
    public class AppDbContext : DbContext
    {
        readonly string _entityKeyPrefix = "";


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<CountryRegion> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryRegionConfiguration());

         

            // Entities
            modelBuilder.Entity<Country>().ToTable(_entityKeyPrefix + "country");
            modelBuilder.Entity<CountryRegion>().ToTable(_entityKeyPrefix + "country_region");



        }
    }
}

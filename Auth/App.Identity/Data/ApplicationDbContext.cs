using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using App.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace App.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            string Schema = "Identity.";
            
            builder.Entity<ApplicationUser>().ToTable(Schema + "Users");
            builder.Entity<IdentityRole>().ToTable(Schema+"Role");
            builder.Entity<IdentityUserRole<string>>().ToTable(Schema + "UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable(Schema + "UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable(Schema + "UserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable(Schema + "RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable(Schema + "UserToken");



        }
    }
}

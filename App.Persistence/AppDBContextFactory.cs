﻿using App.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace App.Persistence
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        public override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}

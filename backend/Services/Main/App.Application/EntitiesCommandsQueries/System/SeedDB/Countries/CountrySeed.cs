using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Countries;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.System.SeedDB.Countries
{
    public class CountrySeed
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMachineLogger _machineLogger;
        private readonly IMachineDateTime _machineDateTime;
        public readonly Country country = new() { Name = "Kenya", Description = "plus254 " };

        public CountrySeed()
        {

        }
        public CountrySeed(AppDbContext appDbContext, IMachineLogger machineLogger, IMachineDateTime machineDateTime)
        {
            _appDbContext = appDbContext;
            _machineLogger = machineLogger;
            _machineDateTime = machineDateTime;
        }

        public async Task SeedDataAsync()
        {
            try
            {
                country.CreatedDate = _machineDateTime.Now;
                country.LastEditedDate = _machineDateTime.Now;
                country.LastEditedBy = "System Seed";
                country.CreatedBy = "System Seed";

                var messageStatusExists = await _appDbContext.Country
                    .Where(e => e.Name == country.Name)
                    .AnyAsync();

                if (messageStatusExists) throw new Exception("Country already exists");

                _appDbContext.Country.Add(country);

                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

                _machineLogger.LogDetails(LogLevel.Error, e.Message);
            }

        }



    }
}

using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Messages;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.System.SeedDB.Messages
{
    public class MessageStatusSeed
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMachineLogger _machineLogger;        
        public readonly MessageStatus successMesageStatus = new() { StatusLabel = "Active" };

        public MessageStatusSeed()
        {

        }
        public MessageStatusSeed(AppDbContext appDbContext, IMachineLogger machineLogger)
        {
            _appDbContext = appDbContext;
            _machineLogger = machineLogger;
        }

        public async Task SeedDataAsync()
        {
            try
            {
                successMesageStatus.CreatedDate = DateTime.UtcNow; 

                var messageStatusExists = await _appDbContext.MessageStatuses
                    .Where(e => e.StatusLabel == successMesageStatus.StatusLabel)
                    .AnyAsync();

                if (messageStatusExists) throw new Exception("Status already exists");

                _appDbContext.MessageStatuses.Add(successMesageStatus);

                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

                _machineLogger.LogDetails(LogLevel.Error, e.Message);
            }

        }



    }
}

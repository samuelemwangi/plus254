using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Notifications;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.System.SeedDB.Notifications
{
    public class NotificationStatusSeed
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMachineLogger _machineLogger;
        private readonly IMachineDateTime _machineDateTime;
        public readonly NotificationStatus notificationStatus = new() { StatusName = "New", StatusDescription = "New Status" };

        public NotificationStatusSeed()
        {

        }
        public NotificationStatusSeed(AppDbContext appDbContext, IMachineLogger machineLogger, IMachineDateTime machineDateTime)
        {
            _appDbContext = appDbContext;
            _machineLogger = machineLogger;
            _machineDateTime = machineDateTime;
        }

        public async Task SeedDataAsync()
        {
            try
            {
                notificationStatus.CreatedDate = _machineDateTime.Now;
                notificationStatus.LastEditedDate = _machineDateTime.Now;
                notificationStatus.LastEditedBy = "System Seed";
                notificationStatus.CreatedBy = "System Seed";

                var messageStatusExists = await _appDbContext.NotificationStatus
                    .Where(e => e.StatusName == notificationStatus.StatusName)
                    .AnyAsync();

                if (messageStatusExists) throw new Exception("Status already exists");

                _appDbContext.NotificationStatus.Add(notificationStatus);

                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

                _machineLogger.LogDetails(LogLevel.Error, e.Message);
            }

        }


    }
}

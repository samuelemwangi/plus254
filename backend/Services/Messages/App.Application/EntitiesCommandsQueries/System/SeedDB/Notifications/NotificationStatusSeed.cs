using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Notifications;
using App.Domain.Enums;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.System.SeedDB.Notifications
{
    public class NotificationStatusSeed
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMachineLogger _machineLogger;
        private readonly IMachineDateTime _machineDateTime;
        private readonly IConfigurationSection _configurationSection;

        public readonly List<NotificationStatus> notificationStatuses = new();

        public NotificationStatusSeed()
        {

        }
        public NotificationStatusSeed(
            AppDbContext appDbContext,
            IMachineLogger machineLogger,
            IMachineDateTime machineDateTime,
            IConfiguration configuration
            )
        {
            _appDbContext = appDbContext;
            _machineLogger = machineLogger;
            _machineDateTime = machineDateTime;
            _configurationSection = configuration.GetSection("AppDetails");
        }

        public async Task SeedDataAsync()
        {
            try
            {
                foreach (var item in NotificationMessageStatus.GetValues(typeof(NotificationMessageStatus)))
                {
                    notificationStatuses.Add(new NotificationStatus
                    {
                        StatusName = item + "",
                        CreatedDate = _machineDateTime.Now,
                        LastEditedDate = _machineDateTime.Now,
                        LastEditedBy = _configurationSection["Name"],
                        CreatedBy = _configurationSection["Name"]

                    });
                }

                var messageStatusExists = await _appDbContext.NotificationStatus
                    .Where(e => e.StatusName == notificationStatuses[0].StatusName)
                    .AnyAsync();

                if (messageStatusExists) throw new Exception("Status already exists");

                _appDbContext.NotificationStatus.AddRange(notificationStatuses);

                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

                _machineLogger.LogDetails(LogLevel.Error, e.Message);
            }

        }


    }
}

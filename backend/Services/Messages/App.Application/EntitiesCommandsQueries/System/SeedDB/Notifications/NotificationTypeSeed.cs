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
    public class NotificationTypeSeed
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMachineLogger _machineLogger;
        private readonly IMachineDateTime _machineDateTime;
        private readonly IConfigurationSection _configurationSection;

        public readonly List<NotificationType> notificationTypes = new();

        public NotificationTypeSeed()
        {

        }
        public NotificationTypeSeed(
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
                foreach (var item in NotificationMessageType.GetValues(typeof(NotificationMessageType)))
                {
                    notificationTypes.Add(new NotificationType
                    {
                        TypeName = item + "",
                        CreatedDate = _machineDateTime.Now,
                        LastEditedDate = _machineDateTime.Now,
                        LastEditedBy = _configurationSection["Name"],
                        CreatedBy = _configurationSection["Name"]

                    });
                }

                var messageStatusExists = await _appDbContext.NotificationType
                    .Where(e => e.TypeName == notificationTypes[0].TypeName)
                    .AnyAsync();

                if (messageStatusExists) throw new Exception("Type already exists");

                _appDbContext.NotificationType.AddRange(notificationTypes);

                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

                _machineLogger.LogDetails(LogLevel.Error, e.Message);
            }

        }


    }
}

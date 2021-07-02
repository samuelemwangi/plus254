using App.Application.Interfaces.Utilities;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.System.SeedDB
{
    public class AppDbSeeder
    {

        private readonly AppDbContext _appDbContext;
        private readonly IConfigurationSection _configurationSection;
        private readonly IMachineLogger _machineLogger;


        public AppDbSeeder(AppDbContext appDbContext, IConfigurationSection configurationSection, IMachineLogger machineLogger)
        {
            _appDbContext = appDbContext;
            _configurationSection = configurationSection;            
            _machineLogger = machineLogger;
        }

        public async Task SeedAllAsync(string folderKey, CancellationToken cancellationToken)
        {


            string rootFolderPath = _configurationSection["FilesPath"].Replace('\\', Path.DirectorySeparatorChar);


            string entityFolderPath = string.Format("{0}{1}{2}", rootFolderPath, Path.DirectorySeparatorChar, folderKey);

            await SeedDBTablesAsync();
            await SeedDBUsingSQLScriptsAsync(string.Format("{0}{1}{2}", entityFolderPath, Path.DirectorySeparatorChar, "Functions"), cancellationToken);
            await SeedDBUsingSQLScriptsAsync(string.Format("{0}{1}{2}", entityFolderPath, Path.DirectorySeparatorChar, "Views"), cancellationToken);



        }

        public async Task SeedDBTablesAsync()
        {
            // Seed table 
        }

        private async Task SeedDBUsingSQLScriptsAsync(string targetDirectory, CancellationToken cancellationToken)
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(targetDirectory);

                foreach (string fileName in fileEntries)
                {
                    await _appDbContext.Database.ExecuteSqlRawAsync(
                        File.ReadAllText(fileName).Replace(_configurationSection["EntityPrefixFrom"], _configurationSection["EntityPrefixTo"]),
                        cancellationToken
                        );
                }

            }
            catch (Exception e)
            {
                
                _machineLogger.LogDetails(LogLevel.Error, e.Message);

            }

        }

    }


}


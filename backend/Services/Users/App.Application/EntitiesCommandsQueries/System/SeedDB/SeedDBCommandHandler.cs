﻿using App.Application.Interfaces.Utilities;
using App.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Use this when seeding Command
/// </summary>



namespace App.Application.EntitiesCommandsQueries.System.SeedDB
{
    public class SeedDBCommand : IRequest
    {
        public string FolderKey { get; set; }
    }

    public class SeedDBCommandHandler : IRequestHandler<SeedDBCommand>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IMachineLogger _machineLogger;

        public SeedDBCommandHandler(AppDbContext appDbContext, IConfiguration configuration, IMachineLogger machineLogger)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _machineLogger = machineLogger;

        }
        public async Task<Unit> Handle(SeedDBCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IConfigurationSection sqlSection = _configuration.GetSection("SQL");

                if (sqlSection == null) throw new Exception("No SQL Section provided in appsettings.json. Kindly provide one");

                AppDbSeeder appDbSeeder = new(_appDbContext, _configuration.GetSection("SQL"), _machineLogger);
                await appDbSeeder.SeedAllAsync(request.FolderKey, cancellationToken);
            }
            catch (Exception e)
            {
                _machineLogger.LogDetails(LogLevel.Error, e.Message);

            }
            return Unit.Value;
        }
    }
}

using App.Application.Interfaces.Utilities;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.Utilities
{
    public class MachineLogger : IMachineLogger
    {
        private readonly ILogger<MachineLogger> _logger;
        public MachineLogger(ILogger<MachineLogger> logger)
        {
            _logger = logger;
        }
        public void LogDetails(LogLevel logLevel, string logDetails)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    _logger.LogTrace(logDetails);
                    break;
                case LogLevel.Debug:
                    _logger.LogDebug(logDetails);
                    break;
                case LogLevel.Information:
                    _logger.LogInformation(logDetails);
                    break;
                case LogLevel.Warning:
                    _logger.LogWarning(logDetails);
                    break;
                case LogLevel.Error:
                    _logger.LogError(logDetails);
                    break;
                case LogLevel.Critical:
                    _logger.LogCritical(logDetails);
                    break;
                case LogLevel.None:
                    _logger.LogInformation(logDetails);
                    break;
                default:
                    break;
            }

        }
    }
}

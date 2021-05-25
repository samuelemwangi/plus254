using Microsoft.Extensions.Logging;

/// <summary>
/// Manage logging - where ILogger can not be used via DI
/// </summary>

namespace App.Application.Interfaces.Utilities
{
    public interface IMachineLogger
    {
        void LogDetails(LogLevel logLevel, string logDetails);
    }
}

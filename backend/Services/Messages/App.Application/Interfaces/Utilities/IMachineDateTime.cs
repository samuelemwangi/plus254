using System;

/// <summary>
/// Manage Date & Time Interface
/// Ensures uniformity in format and timezone
/// </summary>

namespace App.Application.Interfaces.Utilities
{
    public interface IMachineDateTime
    {
        DateTime? DefaultNull { get; }
        DateTime Now { get; }
        string GetTimeStamp();
        string ResolveDate(DateTime? dateTime);
    }
}

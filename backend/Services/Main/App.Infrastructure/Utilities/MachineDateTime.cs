using App.Application.Interfaces.Utilities;
using System;

/// <summary>
/// Implements Date & Time
/// </summary>

namespace App.Infrastructure.Utilities
{
    public class MachineDateTime : IMachineDateTime
    {
        public DateTime? DefaultNull => null;

        public DateTime Now => DateTime.UtcNow;

        public static int CurrentYear => DateTime.Now.Year;

        public static int CurrentMonth => DateTime.Now.Month;


        public string GetTimeStamp()
        {
            DateTime dateTime = this.Now;

            return dateTime.ToString("yyyyMMddHHmmssffff");
        }

        public string ResolveDate(DateTime? dateTime)
        {
            return dateTime == null ? "" : dateTime?.ToLongDateString();
        }
    }
}

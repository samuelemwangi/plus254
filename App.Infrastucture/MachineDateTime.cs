using System;
using App.Common.Interfaces;

namespace App.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;

        public int CurrentYear => DateTime.Now.Year;
    }
}

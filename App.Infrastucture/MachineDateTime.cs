using System;
using App.Common.Interfaces;

namespace App.Infrastucture
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;

        public int CurrentYear => DateTime.Now.Year;
    }
}

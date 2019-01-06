using System;

namespace App.Domain.Exceptions
{
    class UniqueUserCodeInvalidException : Exception
    {
        public UniqueUserCodeInvalidException(string uniqueUserCode, Exception ex) : base($"Unique User Code \"{uniqueUserCode}\" is invalid.", ex)
        {

        }
    }
}

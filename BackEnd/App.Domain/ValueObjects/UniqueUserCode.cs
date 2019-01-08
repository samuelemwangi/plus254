using App.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using App.Domain.Exceptions;

namespace App.Domain.ValueObjects
{
    public class UniqueUserCode : ValueObject
    {
        private UniqueUserCode()
        {

        }

        public string UserName { get; set; }
        public string Domain { get; set; }

        public static UniqueUserCode For(string uniqueCodeString)
        {
            var uniqueUserCode = new UniqueUserCode();

            try
            {

                var index = uniqueCodeString.IndexOf("@", StringComparison.Ordinal);
                uniqueUserCode.UserName = uniqueCodeString.Substring(0, index);
                uniqueUserCode.Domain = uniqueCodeString.Substring(index + 1);


            }
            catch (Exception ex)
            {
                throw new UniqueUserCodeInvalidException(uniqueCodeString, ex);

            }

            return uniqueUserCode;

        }

        public static implicit operator string(UniqueUserCode uniqueUserCode)
        {
            return uniqueUserCode.ToString();
        }

        public static explicit operator UniqueUserCode(string uniqueCodeString)
        {
            return For(uniqueCodeString);
        }

        public override string ToString()
        {
            return @"{UserName}@{Domain}";
        }


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return UserName;
            yield return Domain;
        }
    }
}

using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Custom validation Exeption class
/// </summary>

namespace App.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        public ValidationException() : base("One or more validation failures occured")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures) : this()
        {

            var PropertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();


            foreach (var PropertName in PropertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == PropertName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(PropertName, propertyFailures);

            }

        }
    }
}

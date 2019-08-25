using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueBoard.Application.Exceptions
{
    /// <summary>
    /// Validation exception
    /// </summary>
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ValidationException"/> class
        /// </summary>
        /// <param name="message">Error message</param>
        public ValidationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ValidationException"/> class
        /// </summary>
        /// <param name="failures">Collection of failures</param>
        public ValidationException(IList<ValidationFailure> failures)
        {
            Failures = new Dictionary<string, string[]>();
            var properties = failures.Select(i => i.PropertyName).Distinct().ToList();

            foreach (var property in properties)
            {
                var propertyFailures = failures.Where(i => i.PropertyName == property)
                    .Select(i => i.ErrorMessage)
                    .ToArray();

                Failures.Add(property, propertyFailures);
            }
        }
    }
}

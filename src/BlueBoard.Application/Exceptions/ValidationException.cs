using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace BlueBoard.Application.Exceptions
{
    /// <summary>
    /// Validation exception
    /// </summary>
    public class ValidationException : BlueBoardBaseException
    {
        #region Fields

        public IDictionary<string, string[]> Failures { get; }
        public IList<string> Errors { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of <see cref="ValidationException"/> class
        /// </summary>
        /// <param name="code">Error code</param>
        public ValidationException(string code) : base(code) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ValidationException"/> class
        /// </summary>
        /// <param name="failures">Collection of failures</param>
        public ValidationException(IList<ValidationFailure> failures) : base(Codes.InvalidData)
        {
            Failures = new Dictionary<string, string[]>();
            Errors = failures.Select(i => i.ErrorCode).Distinct().ToList();

            var properties = failures.Select(i => i.PropertyName).Distinct().ToList();
            foreach (var property in properties)
            {
                var propertyFailures = failures.Where(i => i.PropertyName == property)
                    .Select(i => i.ErrorCode)
                    .ToArray();

                Failures.Add(property, propertyFailures);
            }
        }
    }
}

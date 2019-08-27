using System;

namespace BlueBoard.Application.Exceptions
{
    /// <summary>
    /// Base exception
    /// </summary>
    public abstract class BaseException : Exception
    {
        /// <summary>
        /// Exception code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="BaseException"/>
        /// </summary>
        /// <param name="code">Exception code</param>
        protected BaseException(string code)
        {
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BaseException"/>
        /// </summary>
        /// <param name="code">Exception code</param>
        /// <param name="message">Exception message</param>
        protected BaseException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}

using System;

namespace BlueBoard.Application.Exceptions
{
    /// <summary>
    /// Base exception
    /// </summary>
    public abstract class BlueBoardBaseException : Exception
    {
        /// <summary>
        /// Exception code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="BlueBoardBaseException"/>
        /// </summary>
        /// <param name="code">Exception code</param>
        protected BlueBoardBaseException(string code)
        {
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BlueBoardBaseException"/>
        /// </summary>
        /// <param name="code">Exception code</param>
        /// <param name="message">Exception message</param>
        protected BlueBoardBaseException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}

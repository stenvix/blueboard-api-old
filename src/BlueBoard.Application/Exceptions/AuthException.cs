namespace BlueBoard.Application.Exceptions
{
    /// <summary>
    /// Auth exception
    /// </summary>
    public class AuthException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AuthException"/> class
        /// </summary>
        /// <param name="code">Exception code</param>
        public AuthException(string code) : base(code) { }
    }
}

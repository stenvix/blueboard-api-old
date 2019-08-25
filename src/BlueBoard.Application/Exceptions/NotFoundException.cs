namespace BlueBoard.Application.Exceptions
{
    /// <summary>
    /// Not found exception
    /// </summary>
    public class NotFoundException : BlueBoardBaseException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotFoundException"/> class
        /// </summary>
        /// <param name="name">Entity name</param>
        /// <param name="key">Key</param>
        public NotFoundException(string name, object key) : base(Codes.NotFound, $"Entity \"{name}\" {key} was not found") { }
    }
}

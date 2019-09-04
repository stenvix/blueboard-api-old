namespace BlueBoard.Application.Users.Base
{
    public interface IUserCredentials
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}

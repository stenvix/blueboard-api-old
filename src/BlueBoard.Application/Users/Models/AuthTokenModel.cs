namespace BlueBoard.Application.Users.Models
{
    public class AuthTokenModel
    {
        public string AccessToken { get; set; }
        public long Expires { get; set; }
    }
}

using BlueBoard.Application.Users.Models;
using MediatR;

namespace BlueBoard.Application.Users.Commands.SignUp
{
    public class SignUpCommand : IRequest<AuthTokenModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

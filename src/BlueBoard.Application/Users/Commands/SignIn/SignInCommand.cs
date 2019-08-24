using BlueBoard.Application.Users.Models;
using MediatR;

namespace BlueBoard.Application.Users.Commands.SignIn
{
    public class SignInCommand : IRequest<AuthTokenModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

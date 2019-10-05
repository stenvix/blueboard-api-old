using BlueBoard.Application.Users.Base;
using FluentValidation;

namespace BlueBoard.Application.Users.Commands.Setup
{
    public class SetupUserCommandValidator : AbstractValidator<SetupUserCommand>
    {
        public SetupUserCommandValidator()
        {
            Include(new UserInfoValidator());
        }
    }
}

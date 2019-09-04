using BlueBoard.Application.Common;
using BlueBoard.Application.Users.Base;
using FluentValidation;

namespace BlueBoard.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            Include(new UserNameInfoValidator());
            Include(new UserCredentialsValidator());

            this.ValidatePhone(i => i.Phone, command => !string.IsNullOrEmpty(command.Phone));
        }
    }
}

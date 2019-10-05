using BlueBoard.Application.Common;
using BlueBoard.Application.Users.Base;
using FluentValidation;

namespace BlueBoard.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            Include(new UserInfoValidator());
            this.ValidatePhone(i => i.Phone, command => !string.IsNullOrEmpty(command.Phone));
            this.ValidateEmail(i => i.Email, command => !string.IsNullOrEmpty(command.Email));
            this.ValidatePassword(i => i.Password, i => !string.IsNullOrEmpty(i.Password));
        }
    }
}

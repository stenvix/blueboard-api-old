using BlueBoard.Application.Common;
using FluentValidation;

namespace BlueBoard.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            this.ValidateEmail(i => i.Email);
            this.ValidatePassword(i => i.Password, command => !string.IsNullOrEmpty(command.Password));
            this.ValidatePhone(i => i.Phone, command => !string.IsNullOrEmpty(command.Phone));

            RuleFor(i => i.FirstName)
                .NotEmpty().WithErrorCode(Codes.EmptyFirstName);

            RuleFor(i => i.LastName)
                .NotEmpty().WithErrorCode(Codes.EmptyLastName);
        }
    }
}

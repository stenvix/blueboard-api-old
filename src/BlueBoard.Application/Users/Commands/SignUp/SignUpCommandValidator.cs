using FluentValidation;

namespace BlueBoard.Application.Users.Commands.SignUp
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(i => i.Email).NotEmpty().EmailAddress();
            RuleFor(i => i.Password).NotEmpty().MinimumLength(6);
        }
    }
}

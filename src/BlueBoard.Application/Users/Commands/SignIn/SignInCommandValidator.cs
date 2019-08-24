using FluentValidation;

namespace BlueBoard.Application.Users.Commands.SignIn
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        public SignInValidator()
        {
            RuleFor(i => i.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Password).MinimumLength(6).NotEmpty();
        }
    }
}

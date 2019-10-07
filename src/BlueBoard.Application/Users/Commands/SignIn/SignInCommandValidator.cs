using BlueBoard.Application.Common;
using BlueBoard.Application.Users.Base;
using FluentValidation;
using FluentValidation.Validators;

namespace BlueBoard.Application.Users.Commands.SignIn
{
    /// <summary>
    /// Sign in validator
    /// </summary>
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SignInValidator"/>
        /// </summary>
        public SignInValidator()
        {
            RuleFor(i => i.Login)
                .NotEmpty()
                .WithErrorCode(Codes.EmptyLogin);

            RuleFor(i => i.Login)
                .SetValidator(new EmailValidator())
                .When(i => !string.IsNullOrEmpty(i.Login) && i.Login.Contains('@'))
                .WithErrorCode(Codes.InvalidLogin);

            RuleFor(i => i.Login)
                .SetValidator(new UsernameValidator())
                .When(i => !string.IsNullOrEmpty(i.Login) && !i.Login.Contains("@"))
                .WithErrorCode(Codes.InvalidLogin);

            this.ValidatePassword(i => i.Password);
        }
    }
}

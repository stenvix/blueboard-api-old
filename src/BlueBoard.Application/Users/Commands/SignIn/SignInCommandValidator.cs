using FluentValidation;

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
            RuleFor(i => i.Email)
                .NotEmpty().WithErrorCode(Codes.EmptyEmail)
                .EmailAddress().WithErrorCode(Codes.InvalidEmail);

            RuleFor(i => i.Password)
                .NotEmpty().WithErrorCode(Codes.EmptyPassword)
                .MinimumLength(6).WithErrorCode(Codes.InvalidPasswordLength);
        }
    }
}

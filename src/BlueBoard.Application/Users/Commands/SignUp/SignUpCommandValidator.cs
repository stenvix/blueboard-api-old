using FluentValidation;

namespace BlueBoard.Application.Users.Commands.SignUp
{
    /// <summary>
    /// Sign up command validator
    /// </summary>
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SignUpCommandValidator"/> class
        /// </summary>
        public SignUpCommandValidator()
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

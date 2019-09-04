using BlueBoard.Application.Users.Base;
using BlueBoard.Application.Users.Common;
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
            Include(new UserCredentialsValidator());
        }
    }
}

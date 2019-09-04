using BlueBoard.Application.Users.Base;
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
            Include(new UserCredentialsValidator());
        }
    }
}

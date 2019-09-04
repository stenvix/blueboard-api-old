using BlueBoard.Application.Common;
using FluentValidation;

namespace BlueBoard.Application.Users.Base
{
    public class UserCredentialsValidator : AbstractValidator<IUserCredentials>
    {
        public UserCredentialsValidator()
        {
            this.ValidateEmail(i => i.Email);
            this.ValidatePassword(i => i.Password);

            RuleSet(RuleSetCodes.OptionalPassword, () =>
            {
                this.ValidateEmail(i => i.Email);
                this.ValidatePassword(i => i.Password, i => !string.IsNullOrEmpty(i.Password));
            });
        }
    }
}

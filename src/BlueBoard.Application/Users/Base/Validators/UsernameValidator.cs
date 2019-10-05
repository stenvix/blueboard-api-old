using System.Text.RegularExpressions;
using FluentValidation;

namespace BlueBoard.Application.Users.Base
{
    public class UsernameValidator : AbstractValidator<string>
    {
        private readonly Regex _usernameRegex = new Regex(@"^[a-z0-9_.-]*$");

        public UsernameValidator()
        {
            RuleFor(i => i)
                .Must(i => _usernameRegex.IsMatch(i))
                .WithErrorCode(Codes.InvalidUsername);
        }
    }
}

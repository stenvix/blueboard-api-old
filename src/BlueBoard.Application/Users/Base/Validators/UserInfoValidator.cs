using BlueBoard.Application.Users.Common;
using FluentValidation;

namespace BlueBoard.Application.Users.Base
{
    public class UserInfoValidator : AbstractValidator<IUserNameInfo>
    {
        public UserInfoValidator()
        {
            RuleFor(i => i.Username)
                .NotEmpty().WithErrorCode(Codes.EmptyUsername)
                .SetValidator(new UsernameValidator());

            RuleFor(i => i.FirstName)
                .NotEmpty().WithErrorCode(Codes.EmptyFirstName);

            RuleFor(i => i.LastName)
                .NotEmpty().WithErrorCode(Codes.EmptyLastName);
        }
    }
}

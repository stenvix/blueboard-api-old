using BlueBoard.Application.Users.Common;
using FluentValidation;

namespace BlueBoard.Application.Users.Base
{
    public class UserNameInfoValidator : AbstractValidator<IUserNameInfo>
    {
        public UserNameInfoValidator()
        {
            RuleFor(i => i.FirstName)
                .NotEmpty().WithErrorCode(Codes.EmptyFirstName);

            RuleFor(i => i.LastName)
                .NotEmpty().WithErrorCode(Codes.EmptyLastName);
        }
    }
}

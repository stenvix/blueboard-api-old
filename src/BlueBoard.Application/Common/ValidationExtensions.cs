using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Linq.Expressions;
using BlueBoard.Application.Users.Base;

namespace BlueBoard.Application.Common
{
    public static class ValidationExtensions
    {
        public static void ValidateEmail<T, TProperty>(this AbstractValidator<T> validator, Expression<Func<T, TProperty>> expression, Func<T, bool> when = null)
        {
            var builder = validator.RuleFor(expression)
                 .NotEmpty().WithErrorCode(Codes.EmptyEmail)
                 .SetValidator(new EmailValidator()).WithErrorCode(Codes.InvalidEmail);

            if (when != null) builder.When(when);
        }

        public static void ValidatePassword<T, TProperty>(this AbstractValidator<T> validator, Expression<Func<T, TProperty>> expression, Func<T, bool> when = null)
        {
            var builder = validator.RuleFor(expression)
                .NotEmpty().WithErrorCode(Codes.EmptyPassword)
                .SetValidator(new MinimumLengthValidator(6)).WithErrorCode(Codes.InvalidPasswordLength);

            if (when != null) builder.When(when);
        }

        public static void ValidatePhone<T, TProperty>(this AbstractValidator<T> validator, Expression<Func<T, TProperty>> expression, Func<T, bool> when)
        {
            var builder = validator.RuleFor(expression)
                .SetValidator(new PhoneValidator()).WithErrorCode(Codes.InvalidPhone);

            if (when != null) builder.When(when);
        }
    }
}

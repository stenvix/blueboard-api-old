using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Linq.Expressions;

namespace BlueBoard.Application.Common
{
    public static class ValidationExtensions
    {
        public static void ValidateEmail<T, TProperty>(this AbstractValidator<T> validator, Expression<Func<T, TProperty>> expression)
        {
            validator.RuleFor(expression)
                .NotEmpty().WithErrorCode(Codes.EmptyEmail)
                .SetValidator(new EmailValidator()).WithErrorCode(Codes.InvalidEmail);
        }

        public static void ValidatePassword<T, TProperty>(this AbstractValidator<T> validator, Expression<Func<T, TProperty>> expression)
        {
            validator.RuleFor(expression)
                .NotEmpty().WithErrorCode(Codes.EmptyPassword)
                .SetValidator(new MinimumLengthValidator(6)).WithErrorCode(Codes.InvalidPasswordLength);
        }

        public static void ValidatePhone<T, TProperty>(this AbstractValidator<T> validator, Expression<Func<T, TProperty>> expression, Func<T, bool> when)
        {
            validator.RuleFor(expression)
                .SetValidator(new PhoneValidator()).WithErrorCode(Codes.InvalidPhone)
                .When(when);
        }
    }
}

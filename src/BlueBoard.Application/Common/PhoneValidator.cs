using FluentValidation.Validators;
using PhoneNumbers;

namespace BlueBoard.Application.Common
{
    public class PhoneValidator : PropertyValidator
    {
        private readonly PhoneNumberUtil _util;

        public PhoneValidator() : base("{PropertyName} must be valid phone number.")
        {
            _util = PhoneNumberUtil.GetInstance();
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var property = context.PropertyValue as string;
            try
            {
                var number = _util.Parse(property, null);
                return _util.IsValidNumber(number);
            }
            catch (NumberParseException e)
            {
                return false;
            }
        }
    }
}

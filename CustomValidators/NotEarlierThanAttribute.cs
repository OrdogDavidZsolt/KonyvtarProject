using System.ComponentModel.DataAnnotations;

namespace KonyvtarAPI.CustomValidators
{
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NotEarlierThanAttribute : ValidationAttribute
    {
        private readonly DateOnly _minDate;
        public NotEarlierThanAttribute(string value)
        {
            _minDate = DateOnly.FromDateTime(DateTime.Today);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is DateOnly dateValue)
            {
                if (dateValue >= _minDate)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"The date must not be earlier than {_minDate:yyyy-MM-dd}.");
            }

            return new ValidationResult("Invalid date value.");
        }
    }
}

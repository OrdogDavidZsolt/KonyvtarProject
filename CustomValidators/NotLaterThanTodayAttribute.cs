using System.ComponentModel.DataAnnotations;

namespace KonyvtarAPI.CustomValidators
{
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NotLaterThanTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (value is DateOnly dateValue)
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.Today);
                if (dateValue <= today)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"The date must not be later than today ({today:yyyy-MM-dd}).");
            }
            return new ValidationResult("Invalid date value.");
        }
    }
}

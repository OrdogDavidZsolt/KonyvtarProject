using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class ValidBetweenTodayAndAttribute : ValidationAttribute
{
    private readonly DateTime _minDate;

    public ValidBetweenTodayAndAttribute(string minDate)
    {
        if (!DateTime.TryParse(minDate, out _minDate))
        {
            throw new ArgumentException("Invalid date format. Use a valid date string like '0001-01-01'.");
        }
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success;

        if (value is DateTime dateValue)
        {
            DateTime maxDate = DateTime.Today;

            if (dateValue >= _minDate && dateValue <= maxDate)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                $"The date must be between {_minDate:yyyy-MM-dd} and {maxDate:yyyy-MM-dd}.");
        }

        return new ValidationResult("Invalid date value.");
    }
}

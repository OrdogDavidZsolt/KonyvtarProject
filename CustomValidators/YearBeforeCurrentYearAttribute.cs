using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class YearBeforeCurrentYearAttribute : ValidationAttribute
{
    private readonly int _currentYear;
    private readonly int _lowestYear = 1;

    public YearBeforeCurrentYearAttribute()
    {
        _currentYear = DateTime.Today.Year;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is int YearValue)
        {
            if (YearValue >= _lowestYear && YearValue <= _currentYear)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The year must be between {_lowestYear} and {_currentYear}.");
        }

        return new ValidationResult("Invalid year value.");
    }
}

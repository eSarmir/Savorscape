using System.ComponentModel.DataAnnotations;

namespace Savorscape.API.Validation
{
    public class MustBePositiveIntegerAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var valueToValidate = (int)value;

            if (valueToValidate > 0) 
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The value must be a positive integer.");
        }
    }
}

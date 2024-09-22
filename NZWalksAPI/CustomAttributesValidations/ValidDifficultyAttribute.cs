using NZWalksAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.CustomAttributesValidations
{
    public class ValidDifficultyAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var regionId = (Guid)value;

            if (!dbContext.Difficulties.Any(r => r.Id == regionId))
            {
                return new ValidationResult("Invalid Difficulty ID.");
            }

            return ValidationResult.Success;
        }
    }
}

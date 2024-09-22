using NZWalksAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.CustomAttributesValidations
{
    public class ValidRegionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var regionId = (Guid)value;

            if (!dbContext.Regions.Any(r => r.Id == regionId))
            {
                return new ValidationResult("Invalid Region ID.");
            }

            return ValidationResult.Success;
        }
    }
}

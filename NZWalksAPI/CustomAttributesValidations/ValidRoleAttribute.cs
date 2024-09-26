using NZWalksAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.CustomAttributesValidations
{
    public class ValidRoleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationAuthDbContext)validationContext.GetService(typeof(ApplicationAuthDbContext));
            var roleNames = (Array)value;
            var invalidRoles = new List<string>();

            foreach (var role in roleNames)
            {
                if (!dbContext.Roles.Any(r => r.Name == role))
                {
                    invalidRoles.Add(role.ToString());
                }
            }

            if (invalidRoles.Any())
            {
                return new ValidationResult($"The following roles do not exist: {string.Join(", ", invalidRoles)}");
            }

            return ValidationResult.Success;
        }
    }
}

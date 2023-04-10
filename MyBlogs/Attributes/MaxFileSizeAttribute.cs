using System.ComponentModel.DataAnnotations;

namespace StaffManagment.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSizeKB;

        public MaxFileSizeAttribute(int maxFileSizeKB)
        {
            this.maxFileSizeKB = maxFileSizeKB * 1024;
        }

        protected override ValidationResult IsValid(
            object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > maxFileSizeKB)
                {
                    return new ValidationResult($"The file size exceads the limit allowed { maxFileSizeKB } KB.");
                }
            }
            return ValidationResult.Success;
        }
    }
}

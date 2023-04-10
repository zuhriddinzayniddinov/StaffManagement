using System.ComponentModel.DataAnnotations;

namespace StaffManagment.Attributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] extensions;

    public AllowedExtensionsAttribute(string[] extensions)
    {
        this.extensions = extensions;
    }
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file != null)
        {
            var extens = Path.GetExtension(file.FileName);
            if(!extensions.Contains(extens.ToLower()))
            {
                return new ValidationResult($"Only files with a valid extensions ({string.Join(", ",extensions)}) are allowed.");
            }
        }
        return ValidationResult.Success;
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text;
using PayslipCodingAssignment.Application.DTOs;
using PayslipCodingAssignment.Application.Interfaces;

namespace PayslipCodingAssignment.Application.Validators;
public class EmployeeInputValidator : IDtoValidator<EmployeeInputDto>
{
    public void Validate(EmployeeInputDto input)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(input);

        if (!Validator.TryValidateObject(input, validationContext, validationResults, true))
        {
            var errorMessage = BuildValidationErrorMessage(validationResults);
            throw new ValidationException(errorMessage);
        }
    }

    private static string BuildValidationErrorMessage(List<ValidationResult> validationResults)
    {
        var errorMessageBuilder = new StringBuilder("Validation failed: ");

        foreach (var validationResult in validationResults)
        {
            foreach (var memberName in validationResult.MemberNames)
            {
                errorMessageBuilder.AppendLine($"{memberName}: {validationResult.ErrorMessage}");
            }
        }

        return errorMessageBuilder.ToString();
    }
}

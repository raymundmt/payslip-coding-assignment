using System.ComponentModel.DataAnnotations;
using PayslipCodingAssignment.Application.DTOs;
using PayslipCodingAssignment.Application.Validators;

namespace PayslipCodingAssignment.Application.UnitTests.Validators;
public class EmployeeInputValidatorTests
{
    private readonly EmployeeInputValidator _sut = new();

    [Fact]
    public void Validate_ThrowsValidationException_ForInvalidFirstName()
    {
        // Arrange
        var input = new EmployeeInputDto
        {
            FirstName = "",
            LastName = "Doe",
            AnnualSalary = 50000,
            SuperRate = 9.5M,
            PayPeriod = "March"
        };

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => _sut.Validate(input));
        Assert.Contains("First name is required", exception.Message);
    }

    [Fact]
    public void Validate_ThrowsValidationException_ForInvalidLastName()
    {
        // Arrange
        var input = new EmployeeInputDto
        {
            FirstName = "John",
            LastName = "",
            AnnualSalary = 50000,
            SuperRate = 9.5M,
            PayPeriod = "March"
        };

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => _sut.Validate(input));
        Assert.Contains("Last name is required", exception.Message);
    }

    [Fact]
    public void Validate_ThrowsValidationException_ForInvalidSalary()
    {
        // Arrange
        var input = new EmployeeInputDto
        {
            FirstName = "John",
            LastName = "Doe",
            AnnualSalary = -100,
            SuperRate = 9.5M,
            PayPeriod = "March"
        };

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => _sut.Validate(input));
        Assert.Contains("Annual salary must be a positive number", exception.Message);
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(60)]
    public void Validate_ThrowsValidationException_ForSuperRate(decimal superRate)
    {
        // Arrange
        var input = new EmployeeInputDto
        {
            FirstName = "John",
            LastName = "Doe",
            AnnualSalary = 50000,
            SuperRate = superRate,
            PayPeriod = "March"
        };

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => _sut.Validate(input));
        Assert.Contains("Super rate must be between 0% and 50%", exception.Message);
    }

    [Fact]
    public void Validate_ThrowsValidationException_ForInvalidPayPeriod()
    {
        // Arrange
        var input = new EmployeeInputDto
        {
            FirstName = "John",
            LastName = "Doe",
            AnnualSalary = 50000,
            SuperRate = 9.5M,
            PayPeriod = ""
        };

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => _sut.Validate(input));
        Assert.Contains("Pay period is required", exception.Message);
    }

    [Fact]
    public void Validate_DoesNotThrow_ForValidInput()
    {
        // Arrange
        var input = new EmployeeInputDto
        {
            FirstName = "John",
            LastName = "Doe",
            AnnualSalary = 50000,
            SuperRate = 9.5M,
            PayPeriod = "March"
        };

        // Act & Assert
        var exception = Record.Exception(() => _sut.Validate(input));
        Assert.Null(exception);
    }
}

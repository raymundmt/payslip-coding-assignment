using Moq;
using PayslipCodingAssignment.Application.DTOs;
using PayslipCodingAssignment.Application.Interfaces;
using PayslipCodingAssignment.Application.Services;
using PayslipCodingAssignment.Domain.Interfaces;

namespace PayslipCodingAssignment.Application.UnitTests.Services;
public class PayslipServiceTests
{
    private readonly PayslipService _sut;

    private readonly Mock<IDtoValidator<EmployeeInputDto>> _validator;
    private readonly Mock<IIncomeTaxCalculator> _taxCalculator;
    private readonly Mock<IGrossIncomeCalculator> _grossIncomeCalculator;
    private readonly Mock<ISuperCalculator> _superCalculator;

    public PayslipServiceTests()
    {
        _validator = new Mock<IDtoValidator<EmployeeInputDto>>(MockBehavior.Loose);
        _taxCalculator = new Mock<IIncomeTaxCalculator>(MockBehavior.Strict);
        _grossIncomeCalculator = new Mock<IGrossIncomeCalculator>(MockBehavior.Strict);
        _superCalculator = new Mock<ISuperCalculator>(MockBehavior.Strict);

        _sut = new PayslipService(_validator.Object, _taxCalculator.Object, _grossIncomeCalculator.Object, _superCalculator.Object);
    }

    [Fact]
    public void GeneratePayslip_ReturnsCorrectPayslipDto()
    {
        // Arrange
        var inputDto = new EmployeeInputDto
        {
            FirstName = "John",
            LastName = "Doe",
            AnnualSalary = 60000,
            SuperRate = 9,
            PayPeriod = "March"
        };

        _grossIncomeCalculator.Setup(x => x.CalculateGrossIncome(60000)).Returns(5000);
        _taxCalculator.Setup(x => x.CalculateGrossIncomeTax(60000)).Returns(500);
        _superCalculator.Setup(x => x.CalculateSuper(5000, 0.09M)).Returns(450);

        // Act
        var result = _sut.GeneratePayslip(inputDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal("01 March - 31 March", result.PayPeriod);
        Assert.Equal(5000, result.GrossIncome);
        Assert.Equal(500, result.IncomeTax);
        Assert.Equal(4500, result.NetIncome);
        Assert.Equal(450, result.Super);

        _validator.VerifyAll();
        _taxCalculator.VerifyAll();
        _grossIncomeCalculator.VerifyAll();
        _superCalculator.VerifyAll();
    }
}

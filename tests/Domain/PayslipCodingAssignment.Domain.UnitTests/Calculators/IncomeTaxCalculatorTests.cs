using Moq;
using PayslipCodingAssignment.Domain.Interfaces;
using PayslipCodingAssignment.Domain.Calculators;
using PayslipCodingAssignment.Domain.Entities;

namespace PayslipCodingAssignment.Domain.UnitTests.Calculators;
public class IncomeTaxCalculatorTests
{
    private readonly IncomeTaxCalculator _sut;

    public IncomeTaxCalculatorTests()
    {
        Mock<ITaxBracketService> taxBracketService = new();

        taxBracketService.Setup(x => x.GetTaxBrackets()).Returns(
        [
            new TaxBracket(0m, 14_000m, 0.105m),
            new TaxBracket(14_000m, 48_000m, 0.175m),
            new TaxBracket(48_000m, 70_000m, 0.3m),
            new TaxBracket(70_000m, 180_000m, 0.33m),
            new TaxBracket(180_000m, null, 0.39m),
        ]);

        _sut = new IncomeTaxCalculator(taxBracketService.Object);
    }

    [Theory]
    [InlineData(60_050, 11_035.00)]
    [InlineData(120_000, 30_520)]
    [InlineData(180_100, 50_359)]
    [InlineData(280_000, 89_320.00)]
    public void CalculateIncomeTax(decimal annualSalary, decimal expected)
    {
        var actual = _sut.CalculateIncomeTax(annualSalary);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(60_050, 919.58)]
    [InlineData(120_000, 2_543.33)]
    [InlineData(180_100, 4_196.58)]
    [InlineData(280_000, 7_443.33)]
    public void CalculateGrossIncomeTax(decimal annualSalary, decimal expected)
    {
        var actual = _sut.CalculateGrossIncomeTax(annualSalary);
        Assert.Equal(expected, actual);
    }
}

using PayslipCodingAssignment.Domain.Calculators;

namespace PayslipCodingAssignment.Domain.UnitTests.Calculators;

public class GrossIncomeCalculatorTests
{
    private readonly GrossIncomeCalculator _sut = new();

    [Theory]
    [InlineData(60_050, 5_004.17)]
    [InlineData(120_000, 10_000)]
    public void CalculateGrossIncome(decimal annualSalary, decimal expected)
    {
        var actual = _sut.CalculateGrossIncome(annualSalary);
        Assert.Equal(expected, actual);
    }
}

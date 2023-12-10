using PayslipCodingAssignment.Domain.Calculators;

namespace PayslipCodingAssignment.Domain.UnitTests.Calculators;
public class SuperCalculatorTests
{
    private readonly SuperCalculator _sut = new();

    [Theory]
    [InlineData(5_004.17, 0.09, 450.38)]
    [InlineData(10_000, 0.1, 1_000)]
    public void CalculateSuper(decimal grossIncome, decimal superRate, decimal expected)
    {
        var actual = _sut.CalculateSuper(grossIncome, superRate);
        Assert.Equal(expected, actual);
    }
}

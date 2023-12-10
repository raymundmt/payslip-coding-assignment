using PayslipCodingAssignment.Application.Utilities;

namespace PayslipCodingAssignment.Application.UnitTests.Utilities;
public class DateRangeUtilityTests
{
    [Theory]
    [InlineData("January", "01 January - 31 January")]
    [InlineData("February", "01 February - 28 February")]
    [InlineData("March", "01 March - 31 March")]
    public void GetDateRangeForMonth_ReturnsCorrectRange(string monthName, string expected)
    {
        var actual = DateRangeUtility.GetDateRangeForMonth(monthName);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetDateRangeForMonth_InvalidMonth_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => DateRangeUtility.GetDateRangeForMonth("InvalidMonth"));
    }
}

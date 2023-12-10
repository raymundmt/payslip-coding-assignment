using System.Globalization;

namespace PayslipCodingAssignment.Application.Utilities;
public static class DateRangeUtility
{
    public static string GetDateRangeForMonth(string monthName)
    {
        if (!DateTime.TryParseExact($"01 {monthName}", "dd MMMM",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate))
        {
            throw new ArgumentException($"Invalid month name: {monthName}");
        }

        var endDate = startDate.AddMonths(1).AddDays(-1);
        return $"{startDate:dd MMMM} - {endDate:dd MMMM}";
    }
}

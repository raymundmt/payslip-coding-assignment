namespace PayslipCodingAssignment.Domain.Entities;
public class TaxBracket (decimal lowerBound, decimal? upperBound, decimal rate)
{
    public decimal LowerBound { get; set; } = lowerBound;
    public decimal? UpperBound { get; set; } = upperBound;
    public decimal Rate { get; set; } = rate;
}

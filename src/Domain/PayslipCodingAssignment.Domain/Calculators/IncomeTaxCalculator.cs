using PayslipCodingAssignment.Domain.Interfaces;

namespace PayslipCodingAssignment.Domain.Calculators;
public class IncomeTaxCalculator(ITaxBracketService taxBracketService) : IIncomeTaxCalculator
{
    private readonly ITaxBracketService _taxBracketService = taxBracketService;

    public decimal CalculateIncomeTax(decimal annualSalary)
    {
        var taxBrackets = _taxBracketService.GetTaxBrackets();
        
        decimal tax = 0;
        
        foreach (var bracket in taxBrackets)
        {
            if (annualSalary > bracket.LowerBound)
            {
                var taxableIncome = (bracket.UpperBound.HasValue && annualSalary > bracket.UpperBound.Value)
                                    ? bracket.UpperBound.Value - bracket.LowerBound
                                    : annualSalary - bracket.LowerBound;

                tax += taxableIncome * bracket.Rate;
            }
            else
            {
                break;
            }
        }
        
        return Math.Round(tax, 2);
    }

    public decimal CalculateGrossIncomeTax(decimal annualSalary)
    {
        return Math.Round(CalculateIncomeTax(annualSalary) / 12, 2);
    }
}

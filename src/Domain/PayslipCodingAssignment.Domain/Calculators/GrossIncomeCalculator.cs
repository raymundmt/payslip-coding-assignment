using PayslipCodingAssignment.Domain.Interfaces;

namespace PayslipCodingAssignment.Domain.Calculators;
public class GrossIncomeCalculator : IGrossIncomeCalculator
{
    public decimal CalculateGrossIncome(decimal annualSalary)
    {
        return Math.Round(annualSalary / 12, 2);
    }
}

using PayslipCodingAssignment.Domain.Interfaces;

namespace PayslipCodingAssignment.Domain.Calculators;
public class SuperCalculator : ISuperCalculator
{
    public decimal CalculateSuper(decimal grossIncome, decimal superRate)
    {
        return Math.Round(grossIncome * superRate, 2);
    }
}

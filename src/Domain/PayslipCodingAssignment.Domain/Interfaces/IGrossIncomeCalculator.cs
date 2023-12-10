namespace PayslipCodingAssignment.Domain.Interfaces;
public interface IGrossIncomeCalculator
{
    decimal CalculateGrossIncome(decimal annualSalary);
}

namespace PayslipCodingAssignment.Domain.Interfaces;
public interface IIncomeTaxCalculator
{
    decimal CalculateIncomeTax(decimal annualSalary);

    decimal CalculateGrossIncomeTax(decimal annualSalary);
}

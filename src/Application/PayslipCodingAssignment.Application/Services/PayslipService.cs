using PayslipCodingAssignment.Application.DTOs;
using PayslipCodingAssignment.Application.Interfaces;
using PayslipCodingAssignment.Application.Utilities;
using PayslipCodingAssignment.Domain.Interfaces;

namespace PayslipCodingAssignment.Application.Services;
public class PayslipService(
    IDtoValidator<EmployeeInputDto> validator,
    IIncomeTaxCalculator incomeTaxCalculator,
    IGrossIncomeCalculator grossIncomeCalculator,
    ISuperCalculator superCalculator)
{
    private readonly IDtoValidator<EmployeeInputDto> _validator = validator;
    private readonly IIncomeTaxCalculator _incomeTaxCalculator = incomeTaxCalculator;
    private readonly IGrossIncomeCalculator _grossIncomeCalculator = grossIncomeCalculator;
    private readonly ISuperCalculator _superCalculator = superCalculator;

    public PaySlipDto GeneratePayslip(EmployeeInputDto input)
    {
        _validator.Validate(input);

        var payPeriod = DateRangeUtility.GetDateRangeForMonth(input.PayPeriod);
        var grossIncome = _grossIncomeCalculator.CalculateGrossIncome(input.AnnualSalary);
        var grossIncomeTax = _incomeTaxCalculator.CalculateGrossIncomeTax(input.AnnualSalary);
        var netGrossIncome = grossIncome - grossIncomeTax;
        var super = _superCalculator.CalculateSuper(grossIncome, input.SuperRate / 100);

        return new PaySlipDto
        {
            Name = $"{input.FirstName} {input.LastName}",
            PayPeriod = payPeriod,
            GrossIncome = grossIncome,
            IncomeTax = grossIncomeTax,
            NetIncome = netGrossIncome,
            Super = super
        };
    }
}

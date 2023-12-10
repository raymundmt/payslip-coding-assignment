using PayslipCodingAssignment.Domain.Entities;

namespace PayslipCodingAssignment.Domain.Interfaces;
public interface ITaxBracketService
{
    IEnumerable<TaxBracket> GetTaxBrackets();
}

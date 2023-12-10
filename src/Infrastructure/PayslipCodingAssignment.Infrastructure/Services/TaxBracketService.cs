using PayslipCodingAssignment.Domain.Entities;
using PayslipCodingAssignment.Domain.Interfaces;
using PayslipCodingAssignment.Infrastructure.Extensions;

namespace PayslipCodingAssignment.Infrastructure.Services;

public class TaxBracketService(string filePath) : ITaxBracketService
{
    private readonly string _filePath = filePath;

    public IEnumerable<TaxBracket> GetTaxBrackets()
    {
        var json = File.ReadAllText(_filePath);
        _ = json.TryParseJson(out List<TaxBracket>? result);
        return result ?? Enumerable.Empty<TaxBracket>();
    }
}

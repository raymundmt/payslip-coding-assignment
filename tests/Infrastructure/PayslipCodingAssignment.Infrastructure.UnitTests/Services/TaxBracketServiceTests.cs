using PayslipCodingAssignment.Infrastructure.Services;

namespace PayslipCodingAssignment.Infrastructure.UnitTests.Services;

[UsesVerify]
public class TaxBracketServiceTests
{
    [Theory]
    [InlineData(@"Resources\tax-brackets.json")]
    public Task TaxBracketService(string taxBracketJsonFile)
    {
        TaxBracketService sut = new(taxBracketJsonFile);
        var actual = sut.GetTaxBrackets();
        return Verify(actual);
    }

    [Theory]
    [InlineData(@"Resources\tax-brackets-invalid.json")]
    public void TaxBracketService_InvalidJsonContentFile(string taxBracketJsonFile)
    {
        TaxBracketService sut = new(taxBracketJsonFile);
        var actual = sut.GetTaxBrackets();
        Assert.Empty(actual);
    }
}

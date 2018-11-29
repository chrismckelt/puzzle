using Puzzle.Domain.Products;
using Shouldly;
using Xunit;

namespace Puzzle.Tests.Domain.Products
{
    public class CurrencyConverterShould
    {
        [Theory]
        [InlineData(CurrencyRateType.Aud,136.8750000)]
        [InlineData(CurrencyRateType.Usd,100.00)]
        [InlineData(CurrencyRateType.Gbp,77.95570000)]
        public void Convert_using_currency_rate(CurrencyRateType countryCode, decimal expected)
        {
            const decimal initial = 100.00m;
            CurrencyConverter.Convert(countryCode,initial).ShouldBe(expected);
        }
    }
}

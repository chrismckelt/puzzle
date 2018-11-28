using System;
using Puzzle.Domain.Products;
using Shouldly;
using Xunit;

namespace Puzzle.Tests.Domain.Products
{
    public class CurrencyConverterShould
    {
        [Theory]
        [InlineData("AUD",136.8750000)]
        [InlineData("USD",100.00)]
        [InlineData("GDP",77.95570000)]
        public void Convert_using_currency_rate(string countryCode, decimal expected)
        {
            const decimal initial = 100.00m;
            CurrencyConverter.Convert(countryCode,initial).ShouldBe(expected);
        }

        [Fact]
        public void Throw_error_when_country_code_not_found()
        {
            Assert.Throws<ArgumentException>(() => CurrencyConverter.Convert("asdfasdfasdfasdfsa", 222));
        }

        [Fact]
        public void Throw_error_when_country_code_not_3_chars()
        {
            Assert.Throws<ArgumentException>(() => CurrencyConverter.Convert("111", 222));
        }
    }
}

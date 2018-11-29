using System;
using System.Collections.Generic;
using Puzzle.Infrastructure;

namespace Puzzle.Domain.Products
{
    public static class CurrencyConverter
    {
        /// <summary>
        ///     https://www.xe.com/currencyconverter/convert/?Amount=1&From=USD&To=AUD
        /// </summary>
        public static readonly IDictionary<string, decimal> CountryConversationRates = new Dictionary<string, decimal>
        {
            {"USD", 1},
            {"GBP", 0.779557m},
            {"AUD", 1.36875m}
        };

        public static decimal Convert(CurrencyRateType currencyRate, decimal orignalValue)
        {
            string threeLetterIsoCode = currencyRate.GetDescription();
            if (string.IsNullOrEmpty(threeLetterIsoCode) || threeLetterIsoCode.Length != 3)
            {
                throw new ArgumentException(nameof(threeLetterIsoCode));
            }

            if (orignalValue < 0) return 0;

            var found = CountryConversationRates.TryGetValue(threeLetterIsoCode, out var rate);

            if (!found)
                throw new ArgumentException(nameof(threeLetterIsoCode),
                    $"Country not found in currency rate for {threeLetterIsoCode}");

            return rate * orignalValue;
        }
    }
}
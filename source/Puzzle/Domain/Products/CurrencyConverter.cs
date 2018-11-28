using System;
using System.Collections.Generic;

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
            {"EUR", 0.879518m},
            {"GDP", 0.779557m},
            {"AUD", 1.36875m}
        };

        public static decimal Convert(string threeLetterIsoCode, decimal orignalValue)
        {
            if (string.IsNullOrEmpty(threeLetterIsoCode) || threeLetterIsoCode.Length != 3)
            {
                throw new ArgumentException(nameof(threeLetterIsoCode));
            }

            if (orignalValue < 0) return 0;

            var found = CountryConversationRates.TryGetValue(threeLetterIsoCode, out var currencyRate);

            if (!found)
                throw new ArgumentException(nameof(threeLetterIsoCode),
                    $"Country not found in currency rate for {threeLetterIsoCode}");

            return currencyRate * orignalValue;
        }
    }
}
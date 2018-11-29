using System.ComponentModel;

namespace Puzzle.Domain.Products
{
    public enum CurrencyRateType
    {
        [Description("AUD")]
        Aud,
        [Description("USD")]
        Usd,
        [Description("GBP")]
        Gbp
    }
}

using System.Collections.Generic;

namespace Puzzle.Domain.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(CurrencyRateType? currencyRate = null, int markUpPercentage = 20);
    }
}
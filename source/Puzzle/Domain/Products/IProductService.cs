using System.Collections.Generic;

namespace Puzzle.Domain.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int markUpPercentage = 20);
    }
}
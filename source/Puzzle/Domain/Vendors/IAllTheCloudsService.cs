using System.Collections.Generic;
using Puzzle.Domain.Products;

namespace Puzzle.Domain.Vendors
{
    public interface IAllTheCloudsService
    {
        IEnumerable<Product> GetVendorProducts();
    }
}
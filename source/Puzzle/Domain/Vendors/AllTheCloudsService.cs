using System;
using System.Collections.Generic;
using Puzzle.Domain.Products;
using Puzzle.Domain.Vendors;

namespace Puzzle.Domain
{
    /// <summary>
    /// This would be a REST call to the vendor service - options to cache locally excluded
    /// </summary>
    public class AllTheCloudsService : IAllTheCloudsService
    {
        private static readonly IEnumerable<Product> DummyData = new List<Product>()
        {
            new Product(){Id = Guid.NewGuid(),Name = "Toy 1"},
            new Product(){Id = Guid.NewGuid(),Name = "Bike 1"},
            new Product(){Id = Guid.NewGuid(),Name = "Kite 1"}
        };

        public IEnumerable<Product> GetVendorProducts()
        {
            return DummyData;
        }
    }
}

using System;
using System.Collections.Generic;
using Puzzle.Domain.Products;

namespace Puzzle.Domain.Vendors
{
    /// <summary>
    /// Real world example would potentially use
    /// a cache /  local store to not repeat queries
    /// Retry/Circuit break libary to ensure resilience (eg the Polly library) 
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

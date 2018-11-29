using System;
using System.Collections.Generic;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Orders;
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

        public Guid CreateOrder(Order order)
        {
            Console.WriteLine($"{order.Customer.Id}");
            foreach (var product in order.ProductQuantities)
            {
                Console.WriteLine($"{product.Key.Name} quantity:{product.Value}");
            }

            return Guid.NewGuid(); // return vendors id for order
        }
    }
}

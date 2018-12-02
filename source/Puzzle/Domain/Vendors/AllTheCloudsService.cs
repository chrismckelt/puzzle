using System;
using System.Collections.Generic;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Orders;
using Puzzle.Domain.Products;
using Puzzle.Infrastructure;

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
            new Product()
            {
                Id = Guid.Parse("188f6fb1-f4be-405e-b2ec-323ad0d88f05"),
                Name = "Bike",
                Price = 200
            },
            new Product()
            {
                Id = Guid.Parse("600362ee-81e0-4c86-9d83-0575eaca3802"),
                Name = "Marbles",
                Price = 9
            },
            new Product()
            {
                Id = Guid.Parse("b4f78368-0969-4a7a-b4b8-dad09446e0e3"),
                Name = "Yo Yo",
                Price = 3
            },
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
                Console.WriteLine($"{product.Key} quantity:{product.Value}");
            }

            return Guid.NewGuid(); // return vendors id for order
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Products;

namespace Puzzle.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();//for demo
        public Customer Customer { get; set; }
        public IDictionary<Guid, int> OrderItems { get; set;}
        public IDictionary<Product, int> ProductQuantities { get; set; }

        public void AddProduct(Product product)
        {
            if (ProductQuantities ==null)ProductQuantities = new Dictionary<Product, int>();
            if (!ProductQuantities.ContainsKey(product)) ProductQuantities[product] = 0;

            ProductQuantities[product]++;
        }
    }
}

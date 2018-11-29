using System;
using System.Collections.Generic;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Products;

namespace Puzzle.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public IDictionary<Product, int> ProductQuantities { get; set; } = new Dictionary<Product, int>();

        public void AddProduct(Product product)
        {
            if (!ProductQuantities.ContainsKey(product)) ProductQuantities[product] = 0;

            ProductQuantities[product]++;
        }
    }
}

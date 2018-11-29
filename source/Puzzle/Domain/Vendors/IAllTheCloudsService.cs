using System;
using System.Collections.Generic;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Orders;
using Puzzle.Domain.Products;

namespace Puzzle.Domain.Vendors
{
    public interface IAllTheCloudsService
    {
        IEnumerable<Product> GetVendorProducts();
        Guid CreateOrder(Order order);
    }
}
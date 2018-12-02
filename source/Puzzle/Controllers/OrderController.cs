using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Puzzle.Domain.Customers;
using Puzzle.Domain.Orders;
using Puzzle.Domain.Products;

namespace Puzzle.Controllers
{
    [Route("api/[controller]")]
    public class OrderController
    {
        private readonly IOrderService _orderService;
        private IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        [HttpPost("[action]")]
        public Guid Create([FromBody] Order order)
        {
            if (order?.Customer == null) throw new ArgumentException();

            if (!order.OrderItems.Any()) throw new ArgumentException();  //should do http verbs

            // TODO fix this up 
            // fast fix to push up a dictionary from the client
            foreach (var item in order.OrderItems)
            {
                var prod = _productService.GetProducts().Single(x => x.Id == item.Key);
                order.ProductQuantities.Add(prod,item.Value);
            }

            return _orderService.CreateOrder(order);
        }

        [HttpGet("[action]")]
        public Order View()
        {
            var p = new Product()
            {
                Id = Guid.Parse("188f6fb1-f4be-405e-b2ec-323ad0d88f05"),
                Name = "Bike",
                Price = 200
            };

            var order = new Order()
            {
                Customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "aaa",
                    Surname = "bbb",
                    Email = "test@awe.com",
                    CurrencyRate = CurrencyRateType.Aud,
                    CreatedUtcDateTime = DateTime.UtcNow
                },
                Id = Guid.NewGuid(),
                ProductQuantities = new Dictionary<Product, int>()
            };
        
            order.ProductQuantities.Add(p,3);
            return order;
        }
    }
}

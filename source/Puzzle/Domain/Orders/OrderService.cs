using System;
using Puzzle.Domain.Vendors;

namespace Puzzle.Domain.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IAllTheCloudsService _vendorService;

        public OrderService(IAllTheCloudsService vendorService)
        {
            _vendorService = vendorService;
        }

        public Guid CreateOrder(Order order)
        {
             return _vendorService.CreateOrder(order);
        }
    }
}
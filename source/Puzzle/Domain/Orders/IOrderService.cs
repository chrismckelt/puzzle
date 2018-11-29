using System;

namespace Puzzle.Domain.Orders
{
    public interface IOrderService
    {
        Guid CreateOrder(Order order);
    }
}

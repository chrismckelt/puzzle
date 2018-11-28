using System;

namespace Puzzle.Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedUtcDateTime { get; set; }
    }
}

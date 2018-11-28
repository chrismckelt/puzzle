using System;
using System.Collections.Generic;
using System.Linq;
using Puzzle.Domain.Products;
using Puzzle.Infrastructure;
using Shouldly;
using Xunit;

namespace Puzzle.Tests.Infrastructure
{
    public class ExtensionsShould
    {
        [Theory]
        [InlineData(100,20, 20)]
        [InlineData(40,20, 8)]
        [InlineData(2345234.32,20, 469046.864)]
        public void Percent_calculated(decimal original, int percentage, decimal expected)
        {
            original.Percent(percentage).ShouldBe(expected);
        }

        [Theory]
        [InlineData(100,20, 120)]
        [InlineData(-222,20, -266.4)]
        public void AddPercent_calculated(decimal original, int percentage, decimal expected)
        {
            original.AddPercent(percentage).ShouldBe(expected);
        }

        [Fact]
        public void DeepClone_creates_different_underlying_object()
        {
            // arrange
            var product1 = new Product() {Id = Guid.NewGuid(), Name = "test", Price = 111};
            var list1 = new List<Product> {product1};
            var list2 = new List<Product>(list1);
            
            // act
            var list3 = list1.DeepClone();

            // assert
            list1.First().ShouldBeSameAs(list2.First()); // reference copy to same object
            list1.First().ShouldNotBeSameAs(list3.First()); // new reference

        }
    }
}

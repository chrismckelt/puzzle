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
        public void Percent_calculated_from_double(double original, int percentage, double expected)
        {
            original.Percent(percentage).ShouldBe(expected);
        }

        [Theory]
        [InlineData(100,20, 120)]
        [InlineData(-222,20, -266.4)]
        public void AddPercent_calculated_from_double(double original, int percentage, double expected)
        {
            original.AddPercent(percentage).ShouldBe(expected);
        }
    }
}

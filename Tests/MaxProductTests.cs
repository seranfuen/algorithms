using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MaxProductTests
    {
        [Test]
        public void All_negative_returns_largest_even_group()
        {
            var result = new MaxProduct().Calculate(new[] {-2, -5, -20, -1, -3});
            result.Should().Be(-5 * -20 * -1 * -3);
        }

        [Test]
        public void Empty_returns_0()
        {
            new MaxProduct().Calculate(new int[0]).Should().Be(0);
        }

        [Test]
        public void Mix_negative_positive_numbers()
        {
            var result = new MaxProduct().Calculate(new[] {3, 5, -7, 8, 20, -100, -300});
            result.Should().Be(8 * 20 * -100 * -300);
        }

        [Test]
        public void One_negative_number_returns_0()
        {
            new MaxProduct().Calculate(new[] {-8}).Should().Be(0);
        }

        [Test]
        public void With_zero_considers_largest_subgroup()
        {
            var result = new MaxProduct().Calculate(new[] {5, -3, -8, 0, 5, -5, 2});
            result.Should().Be(5 * -3 * -8);
        }
    }
}
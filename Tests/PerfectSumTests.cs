using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class PerfectSumTests
    {
        [Test]
        public void No_match_returns_empty_set()
        {
            var result = new PerfectSum().Calculate(new[] {5, 10, 12, 13, 15, 18}, 1);
            result.Should().HaveCount(0);
        }

        [Test]
        public void Sample_one()
        {
            var result = new PerfectSum().Calculate(new[] {5, 10, 12, 13, 15, 18}, 30);
            result.Should().HaveCount(3);
            result.Should().ContainSingle(x => x.Count == 2 && x[0] == 12 && x[1] == 18);
            result.Should().ContainSingle(x => x.Count == 3 && x[0] == 5 && x[1] == 12 && x[2] == 13);
            result.Should().ContainSingle(x => x.Count == 3 && x[0] == 5 && x[1] == 10 && x[2] == 15);
        }

        [Test]
        public void Set_contains_self()
        {
            var result = new PerfectSum().Calculate(new[] { 8, 30, 20 }, 30);
            result.Should().HaveCount(1);
            result[0][0].Should().Be(30);
        }
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class PalindromeSubsetTests
    {
        [Test]
        public void Test_one()
        {
            var result = new PalindromeSubset().Find("abb");
            result.Should().HaveCount(2);
            result[0].Should().HaveCount(3);
            result[0].Should().Contain("a").And.Contain("b");
            result[1].Should().Contain("a").And.Contain("bb");
            result[1].Should().HaveCount(2);
        }
    }
}
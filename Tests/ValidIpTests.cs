using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class ValidIpTests
    {
        [Test]
        public void Case1()
        {
            var result = new ValidIp().RestoreIpAddresses("25525511135");
            result.Should().HaveCount(2);
            result[0].Should().Be("255.255.11.135");
            result[1].Should().Be("255.255.111.35");
        }

        [Test]
        public void Case_all_Zero()
        {
            var result = new ValidIp().RestoreIpAddresses("0000");
            result.Should().HaveCount(1);
            result[0].Should().Be("0.0.0.0");
        }
    }
}
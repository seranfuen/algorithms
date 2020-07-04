using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class InversionTests
    {
        [TestCase(null, ExpectedResult = 0)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new[] {1}, ExpectedResult = 0)]
        [TestCase(new[] {1, 2}, ExpectedResult = 0)]
        [TestCase(new[] {2, 1}, ExpectedResult = 1)]
        [TestCase(new[] {2, 1, 1}, ExpectedResult = 2)]
        [TestCase(new[] {3, 2, 1}, ExpectedResult = 3)]
        [TestCase(new[] {6, 5, 4, 3, 2, 1}, ExpectedResult = 15)]
        [TestCase(new[] {1, 3, 5, 2, 4, 6}, ExpectedResult = 3)]
        public int NumberInversionsTests(int[] input)
        {
            return new Inversion().CountInversions(input);
        }
    }
}
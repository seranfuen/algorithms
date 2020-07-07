using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class FindMedianElementTests
    {
        [TestCase(new[] {1, 5, 4, 8}, 2, ExpectedResult = 4)]
        [TestCase(new[] {1, 5, 4, 8}, 1, ExpectedResult = 1)]
        [TestCase(new[] {1, 5, 4, 8}, 4, ExpectedResult = 8)]
        [TestCase(new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}, 5, ExpectedResult = 5)]
        [TestCase(new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}, 10, ExpectedResult = 10)]
        [TestCase(new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}, 1, ExpectedResult = 1)]
        [TestCase(new[] {3, 3, 3}, 1, ExpectedResult = 3)]
        [TestCase(new[] {3, 3, 3}, 2, ExpectedResult = 3)]
        [TestCase(new[] {3, 3, 3}, 3, ExpectedResult = 3)]
        [TestCase(new[] { 3, 1, 5, 4 }, 3, ExpectedResult = 4)]
        public int Test(int[] input, int nPosition)
        {
            return new FindMedianElement().FindMedianPosition(input, nPosition);
        }
    }
}
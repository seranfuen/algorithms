using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SortedListFindIndexEqualValueTests
    {
        [TestCase(new int[] { }, ExpectedResult = false)]
        [TestCase(new[] {0}, ExpectedResult = true)]
        [TestCase(new[] {-1, 1}, ExpectedResult = true)]
        [TestCase(new[] {-1, 2}, ExpectedResult = false)]
        [TestCase(new[] {-1, 2, 5, 5, 5, 5}, ExpectedResult = true)]
        [TestCase(new[] { -1, 2, 4, 4, 5, 5 }, ExpectedResult = true)]
        [TestCase(new[] {4, 4, 4, 4, 4, 4, 4, 4}, ExpectedResult = true)]
        [TestCase(new[] {10, 10, 10, 10, 10, 10}, ExpectedResult = false)]
        public bool Test(int[] array)
        {
            return new SortedListFindIndexEqualValue().HasIndexEqualsValue(array);
        }
    }
}
using NUnit.Framework;

namespace Algo.Tests
{
    [TestFixture]
    public class MergeSortingTests
    {
        [TestCase(new int[] { }, ExpectedResult = new int[] { }, Description = "Fringe case: empty")]
        [TestCase(new[] {5}, ExpectedResult = new[] {5}, Description = "Fringe case: one element")]
        [TestCase(new[] {1, 2, 3, 4, 5, 6}, ExpectedResult = new[] {1, 2, 3, 4, 5, 6},
            Description = "Fringe case: already sorted")]
        [TestCase(new[] {2, 2, 2, 2, 2, 2}, ExpectedResult = new[] {2, 2, 2, 2, 2, 2},
            Description = "Fringe case: duplicated elements")]
        [TestCase(new[] {3, 2, 3}, ExpectedResult = new[] {2, 3, 3})]
        [TestCase(new[] {3, 2, 5}, ExpectedResult = new[] {2, 3, 5})]
        [TestCase(new[] {10, 9, 8, 8, 7, 6, 5}, ExpectedResult = new[] {5, 6, 7, 8, 8, 9, 10})]
        [TestCase(new[] { 0, -1, -2, -3, -4 }, ExpectedResult = new[] { -4, -3, -2, -1, 0 })]
        public int[] Test(int[] input)
        {
            return new MergeSorting().MergeSort(input);
        }
    }
}
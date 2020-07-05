using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class QuickSortTests
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
        [TestCase(new[] {0, -1, -2, -3, -4}, ExpectedResult = new[] {-4, -3, -2, -1, 0})]
        [TestCase(new[] {5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100},
            ExpectedResult = new[] {5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100})]
        public int[] Test(int[] input)
        {
            var sort = new QuickSort().Sort(input.ToArray());
            return sort;
        }
    }
}
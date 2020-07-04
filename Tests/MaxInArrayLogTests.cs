using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MaxInArrayLogTests
    {
        [TestCase(new[] {1}, ExpectedResult = 1)]
        [TestCase(new[] {1, 10}, ExpectedResult = 10)]
        [TestCase(new[] {1, 10, 1}, ExpectedResult = 10)]
        [TestCase(new[] {2, 5, 4, 4, 3, 1, 0}, ExpectedResult = 5)]
        [TestCase(new[] {1, 3, 5, 9, 10, 8, 5, 4, 2, 1}, ExpectedResult = 10)]
        [TestCase(new[] {90, 92, 95, 98, 90, 55, 20, 19, 1}, ExpectedResult = 98)]
        [TestCase(new int[0], ExpectedResult = 0)]
        [TestCase(new[] { 1, 2, 3, 4, 40, 50, 60, 80, 90, 91, 92, 93, 94, 95, 96, 100, 82, 81, 80, 79, 78, 77, 50 }, ExpectedResult = 100)]
        [TestCase(new[] { 1, 2, 3, 4, 40, 50, 60, 80, 90, 91, 92, 93, 94, 95, 96, 100, 101, 102, 103, 104, 105, 106, 200, 201, 82, 81, 80, 79, 78, 77, 50 }, ExpectedResult = 201)]
        [TestCase(new [] {5, 4, 3, 2, 1}, ExpectedResult = 5)]
        public int Tests(int[] array)
        {
            return new MaxInArrayLog().FindMaxLogTime(array);
        }
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class RotateMatrixElementTests
    {
        [Test]
        public void Four_by_four()
        {
            var matrix = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {5, 6, 7, 8},
                new[] {9, 10, 11, 12},
                new[] {13, 14, 15, 16}
            };

            new RotateMatrixElement().Rotate(matrix);

            matrix[0][0].Should().Be(5);
            matrix[0][1].Should().Be(1);
            matrix[0][2].Should().Be(2);
            matrix[0][3].Should().Be(3);

            matrix[1][0].Should().Be(9);
            matrix[1][1].Should().Be(10);
            matrix[1][2].Should().Be(6);
            matrix[1][3].Should().Be(4);

            matrix[2][0].Should().Be(13);
            matrix[2][1].Should().Be(11);
            matrix[2][2].Should().Be(7);
            matrix[2][3].Should().Be(8);

            matrix[3][0].Should().Be(14);
            matrix[3][1].Should().Be(15);
            matrix[3][2].Should().Be(16);
            matrix[3][3].Should().Be(12);
        }

        [Test]
        public void Two_by_two_matrix()
        {
            var matrix = new[]
            {
                new[] {1, 2},
                new[] {3, 4}
            };

            new RotateMatrixElement().Rotate(matrix);

            matrix[0][0].Should().Be(3);
            matrix[0][1].Should().Be(1);
            matrix[1][0].Should().Be(4);
            matrix[1][1].Should().Be(2);
        }

        [Test]
        public void One_by_one_matrix()
        {
            var matrix = new[]
            {
                new[] {1}
            };

            new RotateMatrixElement().Rotate(matrix);

            matrix[0][0].Should().Be(1);
        }
    }
}
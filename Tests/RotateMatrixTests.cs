using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class RotateMatrixTests
    {
        [Test]
        public void Three_by_three_matrix()
        {
            var matrix = new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9}
            };

            new RotateMatrix().RotateRight(matrix);

            matrix[0][0].Should().Be(1);
            matrix[1][0].Should().Be(2);
            matrix[2][0].Should().Be(3);

            matrix[0][1].Should().Be(4);
            matrix[1][1].Should().Be(5);
            matrix[2][1].Should().Be(6);

            matrix[0][2].Should().Be(7);
            matrix[1][2].Should().Be(8);
            matrix[2][2].Should().Be(9);

            // Expected matrix is
            //  1  4  7  
            //  2  5  8
            //  3  6  9
        }

        [Test]
        public void Four_by_four_matrix()
        {
            var matrix = new[]
            {
                new[] {12, 5, 8, 0},
                new[] {1, -3, 2, 1},
                new[] {5, 0, 1, -3},
                new[] {-6, 2, 3, -5}
            };

            new RotateMatrix().RotateRight(matrix);

            matrix[0][0].Should().Be(12);
            matrix[1][0].Should().Be(5);
            matrix[2][0].Should().Be(8);
            matrix[3][0].Should().Be(0);

            matrix[0][1].Should().Be(1);
            matrix[1][1].Should().Be(-3);
            matrix[2][1].Should().Be(2);
            matrix[3][1].Should().Be(1);

            matrix[0][2].Should().Be(5);
            matrix[1][2].Should().Be(0);
            matrix[2][2].Should().Be(1);
            matrix[3][2].Should().Be(-3);

            matrix[0][3].Should().Be(-6);
            matrix[1][3].Should().Be(2);
            matrix[2][3].Should().Be(3);
            matrix[3][3].Should().Be(-5);

            // Expected matrix is
            // 12   1     5    -6
            // 5   -3     0    2
            // 8    2     1    3
            // 0    1    -3    -5
        }

        [Test]
        public void One_by_one_matrix()
        {
            var matrix = new[] {new []{1}};
            new RotateMatrix().RotateRight(matrix);
            matrix[0][0].Should().Be(1);

        }
    }
}
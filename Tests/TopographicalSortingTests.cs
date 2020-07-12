using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class TopographicalSortingTests
    {
        [Test]
        public void Normal_directed_connected_graph()
        {
            var result = new TopographicalSorting().FindOrdering(new[]
            {
                //
                // 0 --> 1    --->   5    --> 6
                //   --> 2 ---> 3 --^ ^
                //         ---> 4 --- ^
                //

                new[] {1, 2}, // node 0
                new[] {2}, // node 1
                new[] {3, 4}, // node 2
                new[] {5}, // node 3
                new[] {5}, // node 4
                new[] {6}, // node 5
                new int[] { } // node 6
            });

            result[0].Should().Be(1);
            result[1].Should().Be(2);
            result[2].Should().Be(3);
            result[3].Should().Be(5);
            result[4].Should().Be(4);
            result[5].Should().Be(6);
            result[6].Should().Be(7);
            result.Should().HaveCount(7);
        }

        [Test]
        public void One_node()
        {
            var result = new TopographicalSorting().FindOrdering(new[]
            {
                new int[] { }
            });

            result[0].Should().Be(1);
            result.Length.Should().Be(1);
        }

        [Test]
        public void Test_empty_graph_returns_empty_result()

        {
            var result = new TopographicalSorting().FindOrdering(new int[0][]);
            result.Length.Should().Be(0);
        }

        [Test]
        public void Test_null_graph_returns_empty_result()

        {
            var result = new TopographicalSorting().FindOrdering(null);
            result.Length.Should().Be(0);
        }

        [Test]
        public void Two_nodes()
        {
            var result = new TopographicalSorting().FindOrdering(new[]
            {
                new[] {1}, // 0
                new int[] { } // 1
            });

            result[0].Should().Be(1);
            result[1].Should().Be(2);
        }

        [Test]
        [Ignore("Just want to see what happens with a loop")]
        public void What_happens_when_loop()
        {
            var result = new TopographicalSorting().FindOrdering(new[]
            {
                //
                // 0 --> 1    --->   5    --> 6
                // ^ --> 2 --> 4 --- ^
                // ^       --> 3- --
                // ---------- loop 3 to 0                
                //

                new[] {1, 2}, // node 0
                new[] {2}, // node 1
                new[] {3, 4}, // node 2
                new[] {2}, // node 3
                new[] {5}, // node 4
                new[] {6}, // node 5
                new int[] { } // node 6
            });

            result[0].Should().Be(1);
            result[1].Should().Be(2);
            result[2].Should().Be(3);
            result[3].Should().Be(5);
            result[4].Should().Be(4);
            result[5].Should().Be(6);
            result[6].Should().Be(7);
            result.Should().HaveCount(7);
        }
    }
}
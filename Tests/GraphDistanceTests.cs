using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class GraphDistanceTests
    {
        [Test]
        public void Empty_graph_returns_empty_result()
        {
            var result = new GraphDistance().CalculateDistancesFromRoot(new int[0][]);
            result.Length.Should().Be(0);
        }

        [Test]
        public void Null_graph_returns_empty_result()
        {
            var result = new GraphDistance().CalculateDistancesFromRoot(null);
            result.Length.Should().Be(0);
        }

        [Test]
        public void Only_one_node_distance_0()
        {
            var result = new GraphDistance().CalculateDistancesFromRoot(new[] {new int[] { }});
            result.Length.Should().Be(1);
            result[0].Should().Be(0);
        }

        [Test]
        public void Tests_distances_properly()
        {
            var adjacencyGraph = new[]
            {
                new[] {1, 2}, // 0
                new[] {3, 0}, // 1
                new[] {3, 4, 0}, // 2
                new[] {5, 1, 2}, // 3
                new[] {2}, // 4
                new[] {3, 6}, // 5
                new[] {5} // 6
            };

            var result = new GraphDistance().CalculateDistancesFromRoot(adjacencyGraph);
            result.Length.Should().Be(7);
            result[0].Should().Be(0);
            result[1].Should().Be(1);
            result[2].Should().Be(1);
            result[3].Should().Be(2);
            result[4].Should().Be(2);
            result[5].Should().Be(3);
            result[6].Should().Be(4);
        }

        [Test]
        public void Unidirectional_one()
        {
            var adjacencyGraph = new[]
            {
                new[] {1}, // 0
                new[] {2}, // 1
                new[] {3}, // 2
                new[] {4}, // 3
                new[] {5}, // 4
                new[] {6}, // 5
                new int[] { } // 6
            };

            var result = new GraphDistance().CalculateDistancesFromRoot(adjacencyGraph);
            result.Length.Should().Be(7);
            result[0].Should().Be(0);
            result[1].Should().Be(1);
            result[2].Should().Be(2);
            result[3].Should().Be(3);
            result[4].Should().Be(4);
            result[5].Should().Be(5);
            result[6].Should().Be(6);
        }

        [Test]
        public void With_disconnected_node_its_distance_is_MaxInteger()
        {
            var adjacencyGraph = new[]
            {
                new[] {1, 2}, // 0
                new[] {3, 0}, // 1
                new[] {3, 4, 0}, // 2
                new[] {5, 1, 2}, // 3
                new[] {2}, // 4
                new[] {3}, // 5
                new[] {5} // 6
            };

            var result = new GraphDistance().CalculateDistancesFromRoot(adjacencyGraph);
            result.Length.Should().Be(7);
            result[0].Should().Be(0);
            result[1].Should().Be(1);
            result[2].Should().Be(1);
            result[3].Should().Be(2);
            result[4].Should().Be(2);
            result[5].Should().Be(3);
            result[6].Should().Be(int.MaxValue);
        }
    }
}
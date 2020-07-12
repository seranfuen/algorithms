using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class UndirectedGraphConnectivityTests
    {
        [Test]
        public void Empty_graph_result_empty()
        {
            var result = new UndirectedGraphConnectivity().FindNumberConnectedElements(new int[0][]);
            result.Should().HaveCount(0);
        }

        [Test]
        public void Null_graph_results_empty_result()
        {
            var result = new UndirectedGraphConnectivity().FindNumberConnectedElements(null);
            result.Should().HaveCount(0);
        }

        [Test]
        public void One_node_one_graph_no_edges()
        {
            var result = new UndirectedGraphConnectivity().FindNumberConnectedElements(new[]
            {
                new int[] { }, // 0
                new int[] { }, // 1
                new int[] { }, // 2
                new int[] { }, // 3
                new int[] { } // 4
            });

            result[0].Should().Be(1);
            result[1].Should().Be(2);
            result[2].Should().Be(3);
            result[3].Should().Be(4);
            result[4].Should().Be(5);
            result.Length.Should().Be(5);
        }

        [Test]
        public void Only_one_group_all_nodes_connected()
        {
            var result = new UndirectedGraphConnectivity().FindNumberConnectedElements(new[]
            {
                new[] {1}, // 0
                new[] {0, 2}, // 1
                new[] {1, 3}, // 2
                new[] {2, 4}, // 3
                new[] {3} // 4
            });

            result[0].Should().Be(1);
            result[1].Should().Be(1);
            result[2].Should().Be(1);
            result[3].Should().Be(1);
            result[4].Should().Be(1);
            result.Length.Should().Be(5);
        }

        [Test]
        public void Test_only_one_node()
        {
            var result = new UndirectedGraphConnectivity().FindNumberConnectedElements(new[] {new int[] { }});
            result[0].Should().Be(1);
        }

        [Test]
        public void Test_three_disconnected_graphs()
        {
            var result = new UndirectedGraphConnectivity().FindNumberConnectedElements(new[]
            {
                new[] {2}, // 0
                new int[] { }, // 1
                new[] {3, 0}, // 2
                new[] {2, 4}, // 3
                new[] {3}, // 4
                new[] {6, 7}, // 5
                new[] {5}, // 6
                new[] {5, 8}, // 7
                new[] {7} // 8
            });
            result.Should().HaveCount(9);
            result.Min().Should().Be(1);
            result.Max().Should().Be(3);
            result[0].Should().Be(1);
            result[1].Should().Be(2);
            result[2].Should().Be(1);
            result[3].Should().Be(1);
            result[4].Should().Be(1);
            result[5].Should().Be(3);
            result[6].Should().Be(3);
            result[7].Should().Be(3);
            result[8].Should().Be(3);
        }

        [Test]
        public void Test_two_disconnected_graphs()
        {
            var result = new UndirectedGraphConnectivity().FindNumberConnectedElements(new[]
            {
                new[] {2}, // 0
                new int[] { }, // 1
                new[] {3, 0}, // 2
                new[] {2} // 3
            });
            result[0].Should().Be(1);
            result[1].Should().Be(2);
            result[2].Should().Be(1);
            result[3].Should().Be(1);
        }
    }
}
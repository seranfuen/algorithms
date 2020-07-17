using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class DijkstraTests
    {
        [Test]
        public void Disconnected_case()
        {
            var graphEdges = new List<GraphEdge>
            {
                new GraphEdge(0, 1, 20),
                new GraphEdge(0, 2, 5),
                new GraphEdge(3, 4, 10)
            };

            var result = new Dijkstra().CalculateMinimumLengthDistanceFromSource(new[] {0, 1, 2, 3}, graphEdges);
            result[0].Should().Be(0);
            result[1].Should().Be(20);
            result[2].Should().Be(5);
            result[3].Should().Be(int.MaxValue);
        }

        [Test]
        public void Many_disconnected_nodes()
        {
            var graphEdges = new List<GraphEdge>
            {
      
            };

            var result = new Dijkstra().CalculateMinimumLengthDistanceFromSource(new[] { 0, 1, 2, 3 }, graphEdges);
            result[0].Should().Be(0); // by definition the first node, which we consider 0 but could be any, has a distance of 0
            result[1].Should().Be(int.MaxValue);
            result[2].Should().Be(int.MaxValue);
            result[3].Should().Be(int.MaxValue);
        }

        [Test]
        public void Normal_case()
        {
            /*
             * Graph is as follows. Between brackets the length
             *   0 --- (20) --> 1 -----(1)------------------------
             *                                                   \/
             *     --- (5) ---> 2 ---- (8) ---> 3 ----- (9) ---> 4    ---- (2) ---> 5
             */

            /*
             * Expected result is Node 0 - 0
             *                    Node 1 - 20
             *                    Node 4 - 20 + 1 = 21
             *                    Node 2 - 5
             *                    Node 3 - 5 + 8 = 13
             *                    Node 5 - 20 + 1 + 2 = 23
             *                  Because route through nodes 2-3-4-5 is actually 5 + 8 + 9 = 22 > 21
             */

            var graphEdges = new List<GraphEdge>
            {
                new GraphEdge(0, 1, 20),
                new GraphEdge(0, 2, 5),
                new GraphEdge(1, 4, 1),
                new GraphEdge(2, 3, 8),
                new GraphEdge(3, 4, 9),
                new GraphEdge(4, 5, 2)
            };

            var result = new Dijkstra().CalculateMinimumLengthDistanceFromSource(new[]
            {
                0, 1, 2, 3, 4, 5
            }, graphEdges);
            result[0].Should().Be(0);
            result[1].Should().Be(20);
            result[2].Should().Be(5);
            result[3].Should().Be(13);
            result[4].Should().Be(21);
            result[5].Should().Be(23);
        }

        [Test]
        public void One_element_graph()
        {
            var graphEdges = new List<GraphEdge>();

            var result = new Dijkstra().CalculateMinimumLengthDistanceFromSource(new[] {0}, graphEdges);
            result[0].Should().Be(0);
        }

        [Test]
        public void Empty_graph_empty_result()
        {
            var graphEdges = new List<GraphEdge>();

            var result = new Dijkstra().CalculateMinimumLengthDistanceFromSource(new int[0], graphEdges);
            result.Should().HaveCount(0);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class GraphDistance
    {
        public int[] CalculateDistancesFromRoot(int[][] adjacencyGraph)
        {
            if (adjacencyGraph?.Length > 0 != true) return new int[0];
            var visitedNodes = new bool[adjacencyGraph.Length];
            var distances = InitializeDistances(adjacencyGraph);

            var queue = new Queue<int>();
            queue.Enqueue(0);
            visitedNodes[0] = true;

            while (queue.Any())
            {
                var node = queue.Dequeue();
                var nodesToVisit = adjacencyGraph[node];
                foreach (var nodeToVisit in nodesToVisit)
                {
                    if (visitedNodes[nodeToVisit]) continue;
                    visitedNodes[nodeToVisit] = true;
                    distances[nodeToVisit] = distances[node] + 1;
                    queue.Enqueue(nodeToVisit);
                }
            }

            return distances;
        }

        private static int[] InitializeDistances(int[][] adjacencyGraph)
        {
            var result = new int[adjacencyGraph.Length];
            for (var i = 1; i < result.Length; i++)
                result[i] = int.MaxValue;
            return result;
        }
    }
}
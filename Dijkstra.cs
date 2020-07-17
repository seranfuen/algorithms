using System.Collections.Generic;

namespace Algorithms
{
    public class Dijkstra
    {
        public int[] CalculateMinimumLengthDistanceFromSource(int[] nodes, List<GraphEdge> graphEdges)
        {
            if (nodes.Length == 0) return new int[0];
            var dijkstraDistance = new int[nodes.Length];
            for (var i = 0; i < nodes.Length; i++)
                dijkstraDistance[i] = int.MaxValue;

            var nodesSeen = new HashSet<int>(nodes.Length) {0};
            dijkstraDistance[0] = 0;
            while (nodesSeen.Count < nodes.Length)
            {
                var bestDistance = int.MaxValue;
                GraphEdge bestEdge = null;

                foreach (var edge in graphEdges)
                {
                    if (!nodesSeen.Contains(edge.Source) || nodesSeen.Contains(edge.Destination)) continue;

                    var distance = dijkstraDistance[edge.Source] + edge.Length;
                    if (distance >= bestDistance) continue;

                    bestDistance = distance;
                    bestEdge = edge;
                }

                if (bestEdge == null) break;

                dijkstraDistance[bestEdge.Destination] = bestDistance;
                nodesSeen.Add(bestEdge.Destination);
            }

            return dijkstraDistance;
        }
    }
}
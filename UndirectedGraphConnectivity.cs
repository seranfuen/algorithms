using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class UndirectedGraphConnectivity
    {
        public int[] FindNumberConnectedElements(int[][] graph)
        {
            if (graph == null) return new int[0];
            var currentConnectedGroup = 0;
            var result = new int[graph.Length];
            var visitedNodes = new bool[graph.Length];
            var queue = new Queue<int>();

            for (var i = 0; i < graph.Length; i++)
            {
                if (visitedNodes[i]) continue;

                visitedNodes[i] = true;
                currentConnectedGroup++;
                result[i] = currentConnectedGroup;
                foreach (var edge in graph[i])
                    queue.Enqueue(edge);

                while (queue.Any())
                {
                    var node = queue.Dequeue();
                    if (visitedNodes[node]) continue;
                    visitedNodes[node] = true;
                    result[node] = currentConnectedGroup;
                    foreach (var child in graph[node])
                        queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
using System.Collections.Generic;

namespace Algorithms
{
    public class TopographicalSorting
    {
        private int _number;
        private int[] _result;
        private bool[] _visitedNodes;

        public int[] FindOrdering(int[][] adjacencyMatrix)
        {
            if (adjacencyMatrix?.Length > 0 != true) return new int[0];
            _visitedNodes = new bool[adjacencyMatrix.Length];
            _result = new int[adjacencyMatrix.Length];
            _number = adjacencyMatrix.Length;

            DepthSearch(adjacencyMatrix, 0);

            return _result;
        }

        private void DepthSearch(IReadOnlyList<int[]> adjacencyMatrix, int currentNode)
        {
            _visitedNodes[currentNode] = true;

            foreach (var node in adjacencyMatrix[currentNode])
            {
                if (_visitedNodes[node]) continue;
                DepthSearch(adjacencyMatrix, node);
            }

            _result[currentNode] = _number--;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class PerfectSum
    {
        private List<List<int>> _result;
        private int _targetSum;

        public List<List<int>> Calculate(int[] input, int targetSum)
        {
            _targetSum = targetSum;
            _result = new List<List<int>>();
            var subset = new List<int>();
            CalculatePerfectSum(input, 0, subset);
            return _result;
        }

        private void CalculatePerfectSum(int[] input, int index, List<int> subset)
        {
            if (IsSum(subset)) _result.Add(subset.ToList());

            for (var j = index; j < input.Length; j++)
            {
                subset.Add(input[j]);
                CalculatePerfectSum(input, j + 1, subset);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        private bool IsSum(List<int> subset)
        {
            var sum = 0;
            for (var i = 0; i < subset.Count; i++)
            {
                sum += subset[i];
                if (sum > _targetSum) return false;
            }

            return sum == _targetSum;
        }
    }
}
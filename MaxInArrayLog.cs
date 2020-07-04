using System;
using Algorithms.Tests;

namespace Algorithms
{
    public class MaxInArrayLog
    {
        private readonly Counter _listener;

        public MaxInArrayLog(Counter listener = null)
        {
            _listener = listener;
        }

        public int FindMaxLogTime(int[] array)
        {
            _listener?.IncreaseCounter();
            if (array.Length == 0) return 0;
            if (array.Length == 1)
                return array[0];

            var middle = array.Length / 2;
            if (array[middle] > array[middle - 1])
                return Math.Max(array[middle], FindMaxLogTime(array[new Range(middle, array.Length)]));
            return Math.Max(array[middle - 1], FindMaxLogTime(array[new Range(0, middle)]));
        }
    }
}
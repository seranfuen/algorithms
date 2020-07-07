using System;
using System.Linq;

namespace Algorithms
{
    public class FindMedianElement
    {
        private readonly Random _random = new Random();

        public int FindMedianPosition(int[] input, int nPosition)
        {
            return FindMedianPositionInternal(input, nPosition - 1, 0, input.Length);
        }

        private int FindMedianPositionInternal(int[] input, int nPosition, int start, int end)
        {
            if (end - start <= 1) return input[start];
            var pivotPosition = Arrange(input, start, end, _random.Next(start, end));

            if (pivotPosition == nPosition) return input[pivotPosition];
            if (pivotPosition < nPosition)
                return FindMedianPositionInternal(input, nPosition, pivotPosition + 1, end);
            return FindMedianPositionInternal(input, nPosition, start, pivotPosition );
        }

        private int Arrange(int[] input, int start, int end, int pivotPosition)
        {
            var i = start + 1;
            var pivotValue = input[pivotPosition];
            input[pivotPosition] = input[start];
            input[start] = pivotValue;

            for (var j = start + 1; j < end; j++)
                if (input[j] < pivotValue)
                {
                    var aux = input[i];
                    input[i] = input[j];
                    input[j] = aux;
                    i++;
                }

            input[start] = input[i - 1];
            input[i - 1] = pivotValue;

            return i - 1;
        }
    }
}
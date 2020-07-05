using System;

namespace Algorithms
{
    public class QuickSort
    {
        private readonly Random _random = new Random();

        public int[] Sort(int[] input)
        {
            SortAux(input, 0, input.Length);
            return input;
        }

        private void SortAux(int[] input, int start, int end)
        {
            if (end - start <= 1) return;
            var pivot = _random.Next(start, end);
            var pivotPosition = Arrange(input, start, pivot, end);

            SortAux(input, start, pivotPosition);
            SortAux(input, pivotPosition + 1, end);
        }

        private int Arrange(int[] input, int start, int pivotPosition, int end)
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
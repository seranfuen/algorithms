using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Algo
{
    public class MergeSorting
    {
        public int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1) return numbers;

            var firstHalf = MergeSort(numbers[new Range(0, numbers.Length / 2)]);
            var secondHalf = MergeSort(numbers[new Range(numbers.Length / 2, numbers.Length)]);

            return Merge(firstHalf, secondHalf);
        }

        private int[] Merge(int[] firstHalf, int[] secondHalf)
        {
            var total = firstHalf.Length + secondHalf.Length;
            var i = 0;
            var j = 0;
            int k;
            var result = new int[total];
            for (k = 0; k < total; k++)
            {
                if (i == firstHalf.Length ||
                    j == secondHalf.Length) break;
                if (firstHalf[i] < secondHalf[j])
                    result[k] = firstHalf[i++];
                else
                    result[k] = secondHalf[j++];
            }

            for (var ii = i; ii < firstHalf.Length; ii++)
            {
                result[k++] = firstHalf[ii];
            }

            for (var jj = j; jj < secondHalf.Length; jj++)
            {
                result[k++] = secondHalf[jj];
            }

            return result;
        }
    }
}
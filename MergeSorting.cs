using System;
using System.Collections.Generic;

namespace Algorithms
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

        private static int[] Merge(IReadOnlyList<int> firstHalf, IReadOnlyList<int> secondHalf)
        {
            var firstHalfCount = firstHalf.Count;
            var secondHalfCount = secondHalf.Count;
            var totalLength = firstHalfCount + secondHalfCount;
            var firstHalfIndex = 0;

            var secondHalfIndex = 0;
            int sortedListIndex;
            var sortedMergedList = new int[totalLength];

            for (sortedListIndex = 0; sortedListIndex < totalLength; sortedListIndex++)
            {
                // If reached the end of one of the lists stop, we'll add the other one at the end
                if (firstHalfIndex == firstHalfCount ||
                    secondHalfIndex == secondHalfCount) break;

                if (firstHalf[firstHalfIndex] < secondHalf[secondHalfIndex])
                    sortedMergedList[sortedListIndex] = firstHalf[firstHalfIndex++];
                else
                    sortedMergedList[sortedListIndex] = secondHalf[secondHalfIndex++];
            }

            // In case we reached the end of one of the lists, populate the rest of result with the other
            for (var i = firstHalfIndex; i < firstHalfCount; i++)
                sortedMergedList[sortedListIndex++] = firstHalf[i];
            for (var j = secondHalfIndex; j < secondHalfCount; j++)
                sortedMergedList[sortedListIndex++] = secondHalf[j];

            return sortedMergedList;
        }
    }
}
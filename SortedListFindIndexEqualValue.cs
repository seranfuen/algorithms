using System.Linq;

namespace Algorithms
{
    public class SortedListFindIndexEqualValue
    {
        public bool HasIndexEqualsValue(int[] array)
        {
            if (array?.Any() != true) return false;
            return HasMatch(0, array.Length - 1, array);
        }

        private static bool HasMatch(int start, int end, int[] array)
        {
            // Cost: 1 recursive call so a = 1 and we have the master method as T(n/2) + o(1)
            // because recombination here is constant
            // this means a = 1, b = 2, d = n^d = 1 --> d = 0
            // so a = b^d and time is n^2d log n --> n^0 log n = log n

            if (end - start < 2) return array[start] == start || array[end] == end;
            // How can we discard right side? if start > final index
            // How can we discard left side? If final < start index
            // This is how we go down from O(n) to O(log n) in the step where we discard one of them
            // so we only make one recursive call
            var middle = start + (end - start) / 2;
            return array[start] <= middle && HasMatch(start, middle, array) ||
                   array[end] >= middle && HasMatch(middle, end, array);
        }
    }
}
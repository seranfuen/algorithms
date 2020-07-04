using System;

namespace Algorithms
{
    public class Inversion
    {
        public int CountInversions(int[] input)
        {
            if (input == null || input.Length <= 1) return 0;
            return CountInversionsInternal(input).Count;
        }

        private InversionData CountInversionsInternal(int[] input)
        {
            if (input.Length <= 1)
                return new InversionData
                {
                    Count = 0,
                    Arr = input
                };

            // 2 recursive calls by dividing into 2, and MergeAndCountSplitInv does 3 separate loops so 3n, so O(n)
            // running time is O(n log n)

            var c = CountInversionsInternal(input[new Range(0, input.Length / 2)]);
            var d = CountInversionsInternal(input[new Range(input.Length / 2, input.Length)]);
            var b = MergeAndCountSplitInv(c.Arr, d.Arr);
            return new InversionData
            {
                Arr = b.Arr,
                Count = c.Count + d.Count + b.Count
            };
        }

        private static InversionData MergeAndCountSplitInv(int[] cArr, int[] dArr)
        {
            var invCount = 0;
            var i = 0;
            var j = 0;
            int k;
            var cCount = cArr.Length;
            var dCount = dArr.Length;
            var total = cCount + dCount;
            var result = new int[total];

            for (k = 0; k < total; k++)
            {
                if (i == cCount ||
                    j == dCount) break;

                if (cArr[i] <= dArr[j])
                {
                    result[k] = cArr[i];
                    i++;
                }
                else
                {
                    result[k] = dArr[j];
                    invCount += cCount - i;
                    j++;
                }
            }

            for (; i < cCount; i++)
                result[k++] = cArr[i];
            for (; j < dCount; j++)
                result[k++] = dArr[j];

            return new InversionData
            {
                Count = invCount,
                Arr = result
            };
        }
    }

    internal struct InversionData
    {
        public int[] Arr;
        public int Count;
    }
}
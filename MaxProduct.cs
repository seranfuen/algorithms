using System;

namespace Algorithms
{
    public class MaxProduct
    {
        public int Calculate(int[] input)
        {
            var seenAnyPositiveNumber = false;
            var currentMaxValueSeen = 0;
            var maxPositive = 1;
            var minNegative = 1;

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] > 0)
                {
                    maxPositive *= input[i];
                    seenAnyPositiveNumber = true;
                }
                else if (input[i] < 0)
                {
                    var currentMax = maxPositive;
                    if (minNegative < 0) // two negative numbers turned into positive
                        seenAnyPositiveNumber = true;

                    maxPositive = Math.Max(1, minNegative * input[i]);
                    minNegative = Math.Min(1, currentMax * input[i]);
                }
                else
                {
                    if (maxPositive > currentMaxValueSeen)
                        currentMaxValueSeen = maxPositive;
                    maxPositive = minNegative = 1;
                }

                if (maxPositive > currentMaxValueSeen)
                    currentMaxValueSeen = maxPositive;
            }

            return seenAnyPositiveNumber ? currentMaxValueSeen : 0;
        }
    }
}
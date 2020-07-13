using System;

namespace Algorithms
{
    public class StringOneDifferenceAway
    {
        public bool AreOneDifferenceAway(string a, string b)
        {
            if (Math.Abs(a.Length - b.Length) > 1) return false;

            if (a.Length == b.Length)
                return CheckDifferences(a, b);
            if (a.Length < b.Length)
                return CheckInsertion(a, b);
            if (a.Length > b.Length)
                return CheckDeletion(a, b);
            return false;
        }

        private bool CheckDeletion(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0) return true;

            var index2 = 0;

            var difFFound = false;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[index2])
                {
                    if (difFFound) return false;
                    difFFound = true;
                }
                else
                {
                    index2++; 
                }
            }

            return true;
        }

        private bool CheckInsertion(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0) return true;

            var index1 = 0;
     
            var foundDiff = false;

            for (var i = 0; i < b.Length; i++)
                if (a[index1] != b[i])
                {
                    if (foundDiff) return false;

                    foundDiff = true;
                }
                else
                {
                    index1++;
                    if (index1 >= a.Length) return true;
                }

            return true;
        }

        private bool CheckDifferences(string a, string b)
        {
            var foundDiff = false;
            for (var i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                {
                    if (foundDiff)
                        return false;

                    foundDiff = true;
                }

            return true;
        }
    }
}
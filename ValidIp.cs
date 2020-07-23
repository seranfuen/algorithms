using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class ValidIp
    {
        private List<string> _result;

        public List<string> RestoreIpAddresses(string A)
        {
            if (A == null || A.Length < 4) return new List<string>();
            if (A.Length > 12) return new List<string>();

            _result = new List<string>();
            var subset = new List<string>();

            PermuteAll(A, 0, 0, subset);
            return _result.OrderBy(x => x).ToList();
        }

        // The idea is to use backtracking
        // If the subset contains all four valid IP elements
        // we add it to results
        // if it contains an impossible one, we stop and go back
        // we only consider 1,2 or 3 digit groups
        private void PermuteAll(string A, int groupsSeen, int index, List<string> subset)
        {
            if (index >= A.Length && groupsSeen < 4)
                return; // nothing to do here, we have reached the end but not found 4 groups
            if (groupsSeen == 4)
            { // we're done with all groups
                if (IsValidSubset(subset))
                {
                    _result.Add(string.Join(".", subset.ToArray()));
                }
                return;
            }

            if (groupsSeen == 3) // we just need to add the rest of the string
            {
                subset.Add(A.Substring(index, A.Length - index));
                PermuteAll(A, groupsSeen + 1, A.Length, subset);
                subset.RemoveAt(subset.Count - 1);
            }
            else
            { // for the next group, we try all lengths of 1, 2 or 3 chars
                for (var j = 1; j <= 3; j++)
                {
                    if (A.Length < index + j) break; // we cannot continue filling groups
                    var digit = A.Substring(index, j);
                    if (!IsValidByte(digit)) break; // byte is probably greater than 255, don't continue for this group
                    subset.Add(digit);
                    PermuteAll(A, groupsSeen + 1, index + j, subset);
                    subset.RemoveAt(subset.Count - 1);
                }
            }
        }

        private bool IsValidSubset(List<string> subset)
        {
            return subset.Count == 4 &&
                IsValidByte(subset[0]) &&
                IsValidByte(subset[1]) &&
                IsValidByte(subset[2]) &&
                IsValidByte(subset[3]);
        }

        private bool IsValidByte(string byteDigit)
        {
            if (byteDigit.Length > 3 || byteDigit.Length == 0) return false;
            var digit = int.Parse(byteDigit);
            return digit >= 100 && digit < 256 ||
            // if digit is less than 10 we do not allow left padding of 0
            digit < 10 && byteDigit.Length == 1 ||
            // if 10 to 100 we do not allow padding also
            digit >= 10 && digit < 100 && byteDigit.Length == 2;
        }
    }
}
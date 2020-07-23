using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class PalindromeSubset
    {
        private List<List<string>> _result;

        public List<List<string>> Find(string str)
        {
            _result = new List<List<string>>();
            var subset = new List<string>();
            FindPalindromeSubsets(str, 0, subset);

            return _result;
        }

        private void FindPalindromeSubsets(string str, int i, IList<string> subset)
        {
            if (i >= str.Length)
            {
                _result.Add(subset.ToList());
                return;
            }

            for (var j = i; j < str.Length; j++)
            {
                var subStr = str.Substring(i, j - i + 1);
                if (IsPalindrome(subStr))
                {
                    subset.Add(subStr);
                    FindPalindromeSubsets(str, j + 1, subset);
                    subset.RemoveAt(subset.Count - 1);
                }
            }
        }

        private static bool IsPalindrome(string subStr)
        {
            for (int i = 0, j = subStr.Length - 1; i < j; i++, j--)
                if (subStr[i] != subStr[j])
                    return false;

            return true;
        }
    }
}
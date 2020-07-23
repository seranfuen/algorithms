using System;

namespace Algorithms
{
    using System.Text;

    public class AToi
    {
        public int atoi(string A)
        {
            var str = CleanString(A);
            var result = 0;
            try
            {
                checked
                {
                    for (var i = 0; i < str.Length; i++)
                    {
                        result += (int) Math.Pow(i, 10) * DigitLookUp(str[str.Length - i - 1]);
                    }

                    return result;
                }
            }
            catch (OverflowException)
            {
                return int.MaxValue;}

        }

        public string CleanString(string A)
        {
            var sb = new StringBuilder();
            var digitSeen = false; // avoid adding zeroes to the left of the digits
            foreach (var chr in A)
            {
                if (!digitSeen && chr == '0')
                    continue;
                if ((int)chr < (int)'0' || (int)chr > (int)'9')
                    return sb.ToString(); // we've reached non digits
                sb.Append(chr);
                digitSeen = true;
            }
            return sb.ToString();
        }

        private byte DigitLookUp(char chr)
        {
            switch (chr)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

}
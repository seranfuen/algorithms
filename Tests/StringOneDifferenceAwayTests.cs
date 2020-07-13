using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class StringOneDifferenceAwayTests
    {
        [TestCase("Mum", "Mam", ExpectedResult = true)]
        [TestCase("Mum", "Mm", ExpectedResult = true)]
        [TestCase("Mum", "am", ExpectedResult = false)]
        [TestCase("Mum", "Muma", ExpectedResult = true)]
        [TestCase("Mum", "Mama", ExpectedResult = false)]
        [TestCase("Mum", "Mad", ExpectedResult = false)]
        [TestCase("", "A", ExpectedResult = true)]
        [TestCase("A", "", ExpectedResult = true)]
        [TestCase("Marke", "Mo", ExpectedResult = false)]
        [TestCase("Abcd", "bcd", ExpectedResult = true)]
        [TestCase("Abcd", "aBcd", ExpectedResult = false, Reason = "Case sensitivity")]
        [TestCase("Acde", "Abcde", ExpectedResult = true)]
        public bool Test(string a, string b)
        {
            return new StringOneDifferenceAway().AreOneDifferenceAway(a, b);
        }
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class HeapTests
    {
        [Test]
        public void MinHeap_always_returns_lesser_element()
        {
            var entityUnderTest = new MinHeap();
            entityUnderTest.Insert(21);
            entityUnderTest.Peek.Should().Be(21);
            entityUnderTest.Insert(25);
            entityUnderTest.Peek.Should().Be(21);
            entityUnderTest.Insert(5);
            entityUnderTest.Peek.Should().Be(5);
            entityUnderTest.Insert(8);
            entityUnderTest.Peek.Should().Be(5);
            entityUnderTest.Insert(3);
            entityUnderTest.Peek.Should().Be(3);

            entityUnderTest.RemoveTop().Should().Be(3);
            entityUnderTest.RemoveTop().Should().Be(5);
            entityUnderTest.RemoveTop().Should().Be(8);
            entityUnderTest.RemoveTop().Should().Be(21);
            entityUnderTest.RemoveTop().Should().Be(25);
            entityUnderTest.Length.Should().Be(0);
        }

        [Test]
        public void MinHeap_kept_consistent_when_removing_and_adding_mixed()
        {
            var entityUnderTest = new MinHeap();
            entityUnderTest.Insert(5);
            entityUnderTest.Length.Should().Be(1);
            entityUnderTest.Insert(2);
            entityUnderTest.Length.Should().Be(2);
            entityUnderTest.RemoveTop();
            entityUnderTest.Length.Should().Be(1);
            entityUnderTest.Peek.Should().Be(5);
            entityUnderTest.Insert(10);
            entityUnderTest.Insert(3);
            entityUnderTest.Peek.Should().Be(3);
            entityUnderTest.Length.Should().Be(3);
            entityUnderTest.RemoveTop();
            entityUnderTest.RemoveTop();
            entityUnderTest.Peek.Should().Be(10);
            entityUnderTest.Length.Should().Be(1);
        }

        [Test]
        public void Accepts_256_elements_grows()
        {
            var entityUnderTest = new MinHeap();
            for (var i = 0; i < 256; i++) 
                entityUnderTest.Insert(256-i);

            entityUnderTest.Length.Should().Be(256);
            entityUnderTest.Peek.Should().Be(1);
        }
    }
}

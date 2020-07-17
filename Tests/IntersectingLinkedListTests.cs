using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class IntersectingLinkedListTests
    {
        [Test]
        public void The_two_intersect_at_one_node_returns_that_node()
        {
            var linkedListOne = new LinkedList(20);
            linkedListOne.Insert(3);
            var intersectNode = linkedListOne.Insert(5);
            linkedListOne.Insert(8);
            linkedListOne.Insert(1);

            var linkedListTwo = new LinkedList(18);
            linkedListTwo.Insert(30);
            var lastNode = linkedListTwo.Insert(21);
            lastNode.Next = intersectNode;

            var entityUnderTest = new IntersectingLinkedList();
            var result = entityUnderTest.FindIntersectingNode(linkedListOne, linkedListTwo);
            result.Should().BeSameAs(intersectNode);
        }

        [Test]
        public void They_do_not_intersect_returns_null()
        {
            var linkedListOne = new LinkedList(20);
            linkedListOne.Insert(3);
            linkedListOne.Insert(5);
            linkedListOne.Insert(8);
            linkedListOne.Insert(1);

            var linkedListTwo = new LinkedList(18);
            linkedListTwo.Insert(30);
            linkedListTwo.Insert(21);

            var entityUnderTest = new IntersectingLinkedList();
            var result = entityUnderTest.FindIntersectingNode(linkedListOne, linkedListTwo);
            result.Should().BeNull();
        }

        [Test]
        public void They_are_the_same_list_returns_first_node()
        {
            var linkedListOne = new LinkedList(20);
            linkedListOne.Insert(3);
            linkedListOne.Insert(5);
            linkedListOne.Insert(8);
            linkedListOne.Insert(1);

            var entityUnderTest = new IntersectingLinkedList();
            var result = entityUnderTest.FindIntersectingNode(linkedListOne, linkedListOne);
            result.Should().BeSameAs(linkedListOne.FirstNode);
        }

    }
}
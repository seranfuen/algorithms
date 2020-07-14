using System;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Access_position_returns_correct_item()
        {
            var firstNode = new LinkedListNode(5);
            firstNode.AddNode(8);

            var entityUnderTest = new LinkedList(firstNode);
            entityUnderTest.GetValueAt(0).Should().Be(5);
            entityUnderTest.GetValueAt(1).Should().Be(8);
        }

        [Test]
        public void Access_position_without_index_throws_exception()
        {
            var firstNode = new LinkedListNode(5);
            firstNode.AddNode(8);

            var entityUnderTest = new LinkedList(firstNode);
            Action act = () => entityUnderTest.GetValueAt(2);
            act.Should().ThrowExactly<IndexOutOfRangeException>();
        }

        [Test]
        public void DeleteNodeNoAccessToPrevious_is_last_node_does_not_work()
        {
            var entityUnderTest = new LinkedList(new LinkedListNode(5));
            Action act = () => entityUnderTest.DeleteNodeNoAccessToPrevious(1);
            act.Should().Throw<Exception>();
        }

        [Test]
        public void DeleteNodeNoAccessToPrevious_no_access_previous()
        {
            var entityUnderTest = new LinkedList(new LinkedListNode(5));
            entityUnderTest.GetValueAt(0).Should().Be(5);
            entityUnderTest.Insert(8);
            entityUnderTest.GetValueAt(1).Should().Be(8);
            entityUnderTest.Insert(12);
            entityUnderTest.GetValueAt(2).Should().Be(12);

            entityUnderTest.DeleteNodeNoAccessToPrevious(1);
            entityUnderTest.GetValueAt(0).Should().Be(5);
            entityUnderTest.GetValueAt(1).Should().Be(12);

            Action act = () => entityUnderTest.GetValueAt(3);
            act.Should().ThrowExactly<IndexOutOfRangeException>();
        }

        [Test]
        public void Insert_inserts_at_end()
        {
            var entityUnderTest = new LinkedList(new LinkedListNode(5));
            entityUnderTest.GetValueAt(0).Should().Be(5);
            entityUnderTest.Insert(8);
            entityUnderTest.GetValueAt(1).Should().Be(8);
            entityUnderTest.Insert(12);
            entityUnderTest.GetValueAt(2).Should().Be(12);
        }

        [Test]
        public void Partition_list_around_pivot_only_one_value_less()
        {
            var entityUnderTest = new LinkedList(new LinkedListNode(3));
            entityUnderTest.Insert(5);
            entityUnderTest.Insert(8);
            entityUnderTest.Insert(5);
            entityUnderTest.Insert(10);
            entityUnderTest.Insert(2);
            entityUnderTest.Insert(1);

            var result = entityUnderTest.PartitionAround(2);

            result.GetValueAt(0).Should().Be(1);
            result.GetValueAt(1).Should().Be(3);
            result.GetValueAt(2).Should().Be(5);
            result.GetValueAt(3).Should().Be(8);
            result.GetValueAt(4).Should().Be(5);
            result.GetValueAt(5).Should().Be(10);
            result.GetValueAt(6).Should().Be(2);
        }

        [Test]
        public void Partition_list_around_pivot_value()
        {
            var entityUnderTest = new LinkedList(new LinkedListNode(3));
            entityUnderTest.Insert(5);
            entityUnderTest.Insert(8);
            entityUnderTest.Insert(5);
            entityUnderTest.Insert(10);
            entityUnderTest.Insert(2);
            entityUnderTest.Insert(1);

            var result = entityUnderTest.PartitionAround(5);

            result.GetValueAt(0).Should().BeLessThan(5);
            result.GetValueAt(1).Should().BeLessThan(5);
            result.GetValueAt(2).Should().BeLessThan(5);
            result.GetValueAt(3).Should().BeGreaterOrEqualTo(5);
            result.GetValueAt(4).Should().BeGreaterOrEqualTo(5);
            result.GetValueAt(5).Should().BeGreaterOrEqualTo(5);
            result.GetValueAt(6).Should().BeGreaterOrEqualTo(5);
        }

        [Test]
        public void Partition_list_around_pivot_value_less_than_all()
        {
            var entityUnderTest = new LinkedList(new LinkedListNode(3));
            entityUnderTest.Insert(5);
            entityUnderTest.Insert(8);
            entityUnderTest.Insert(5);
            entityUnderTest.Insert(10);
            entityUnderTest.Insert(2);
            entityUnderTest.Insert(1);

            var result = entityUnderTest.PartitionAround(15);

            result.GetValueAt(0).Should().Be(1);
            result.GetValueAt(1).Should().Be(2);
            result.GetValueAt(2).Should().Be(10);
            result.GetValueAt(3).Should().Be(5);
            result.GetValueAt(4).Should().Be(8);
            result.GetValueAt(5).Should().Be(5);
            result.GetValueAt(6).Should().Be(3);
        }
    }
}
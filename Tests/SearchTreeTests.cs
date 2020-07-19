using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SearchTreeTests
    {
        [Test]
        public void Delete_maintains_tree_consistency()
        {
            var entityUnderTest = new SearchTree();
            entityUnderTest.Insert(20);
            entityUnderTest.Insert(8);
            entityUnderTest.Insert(25);
            entityUnderTest.Insert(9);
            entityUnderTest.Insert(6);
            entityUnderTest.Insert(80);

            /*
             * The tree is 
             *            20
             *          /    \
             *        8      25
             *     /    \      \
             *    6      9      80
             *            
             */

            entityUnderTest.Delete(20);
            entityUnderTest.Root.Value.Should().Be(9);

            /*
            * The tree is  now
            *            9
            *          /    \
            *        8      25
            *     /           \
            *    6             80
            *            
            */

            entityUnderTest.Delete(25);
            entityUnderTest.Root.Value.Should().Be(9);

            /*
              * The tree is  now
              *            9
              *          /    \
              *        8      80
              *      /           
              *    6         
              *            
              */

            entityUnderTest.Root.RightChild.Value.Should().Be(80);
            entityUnderTest.Root.LeftChild.Value.Should().Be(8);
            entityUnderTest.Root.LeftChild.LeftChild.Value.Should().Be(6);
            entityUnderTest.Root.LeftChild.RightChild.Should().BeNull();
            entityUnderTest.Root.RightChild.HasChildren.Should().BeFalse();
        }

        [Test]
        public void Search_finds_element()
        {
            var entityUnderTest = new SearchTree();
            entityUnderTest.Insert(20);
            entityUnderTest.Insert(8);
            entityUnderTest.Insert(25);
            entityUnderTest.Insert(9);
            entityUnderTest.Insert(13);
            entityUnderTest.Insert(80);

            var node80 = entityUnderTest.Find(80);
            node80.Parent.Value.Should().Be(25);
            node80.Value.Should().Be(80);
            node80.RightChild.Should().BeNull();
            node80.LeftChild.Should().BeNull();

            var node8 = entityUnderTest.Find(8);
            node8.RightChild.Value.Should().Be(9);
            node8.LeftChild.Should().BeNull();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class IntersectingLinkedList
    {
        public LinkedListNode FindIntersectingNode(LinkedList linkedListOne, LinkedList linkedListTwo)
        {
            var stackOne = StackNodesFrom(linkedListOne);
            var stackTwo = StackNodesFrom(linkedListTwo);

            var currentNode1 = stackOne.Pop();
            var currentNode2 = stackTwo.Pop();
            LinkedListNode lastCommonNode = null;

            while (currentNode1.Equals(currentNode2) && stackOne.Any() && stackTwo.Any())
            {
                lastCommonNode = currentNode1;
                currentNode1 = stackOne.Pop();
                currentNode2 = stackTwo.Pop();
            }

            return currentNode1.Equals(currentNode2) ? currentNode1 : lastCommonNode;
        }

        private static Stack<LinkedListNode> StackNodesFrom(LinkedList linkedList)
        {
            var stack = new Stack<LinkedListNode>();
            var node = linkedList.FirstNode;
            while (node != null)
            {
                stack.Push(node);
                node = node.Next;
            }

            return stack;
        }
    }
}
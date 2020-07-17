using System;

namespace Algorithms
{
    public class LinkedList
    {
        public LinkedList(LinkedListNode firstNode)
        {
            FirstNode = firstNode;
        }

        public LinkedList(int value)
        {
            FirstNode = new LinkedListNode(value);
        }

        public LinkedListNode FirstNode { get; }

        public int GetValueAt(int position)
        {
            var node = FirstNode;
            while (position-- > 0) node = node.Next ?? throw new IndexOutOfRangeException();

            return node.Data;
        }

        public LinkedListNode Insert(int value)
        {
            var node = FirstNode;

            while (node.Next != null)
                node = node.Next;

            node.AddNode(value);
            return node.Next;
        }


        public void DeleteNodeNoAccessToPrevious(int position)
        {
            var nodeAtPosition = GetNodeAtPosition(position);
            nodeAtPosition.Data = nodeAtPosition.Next.Data;
            nodeAtPosition.Next = nodeAtPosition.Next;
        }

        public LinkedList PartitionAround(int valueToPartition)
        {
            var head = FirstNode;
            var tail = FirstNode;

            var node = FirstNode;
            while (node != null)
            {
                var next = node.Next;
                if (node.Data < valueToPartition)
                {
                    node.Next = head;
                    head = node;
                }
                else
                {
                    if (tail == null)
                    {
                        tail = node;
                    }
                    else
                    {
                        tail.Next = node;
                        tail = node;
                    }
                }

                node = next;
            }

            if (tail != null)
                tail.Next = null;

            return new LinkedList(head ?? tail);
        }

        private LinkedListNode GetNodeAtPosition(int position)
        {
            var node = FirstNode;
            while (position-- > 0) node = node.Next;

            return node;
        }
    }
}
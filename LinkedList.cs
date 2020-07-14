using System;

namespace Algorithms
{
    public class LinkedList
    {
        private readonly LinkedListNode _firstNode;

        public LinkedList(LinkedListNode firstNode)
        {
            _firstNode = firstNode;
        }

        public int GetValueAt(int position)
        {
            var node = _firstNode;
            while (position-- > 0) node = node.Next ?? throw new IndexOutOfRangeException();

            return node.Data;
        }

        public void Insert(int value)
        {
            var node = _firstNode;

            while (node.Next != null)
                node = node.Next;

            node.AddNode(value);
        }


        public void DeleteNodeNoAccessToPrevious(int position)
        {
            var nodeAtPosition = GetNodeAtPosition(position);
            nodeAtPosition.Data = nodeAtPosition.Next.Data;
            nodeAtPosition.Next = nodeAtPosition.Next;
        }

        public LinkedList PartitionAround(int valueToPartition)
        {
            var head = _firstNode;
            var tail = _firstNode;

            var node = _firstNode;
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
            var node = _firstNode;
            while (position-- > 0) node = node.Next;

            return node;
        }
    }
}
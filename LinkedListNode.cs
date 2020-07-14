namespace Algorithms
{
    public class LinkedListNode
    {
        public LinkedListNode(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public LinkedListNode Next { get; set; }

        public void AddNode(int data)
        {
            Next = new LinkedListNode(data);
        }
    }
}
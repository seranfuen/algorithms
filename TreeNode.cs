namespace Algorithms
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public TreeNode Parent { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public bool HasChildren => LeftChild != null || RightChild != null;

        public void RemoveFromParent()
        {
            Parent.RemoveChild(this);
            Parent = null;
        }

        private void RemoveChild(TreeNode treeNode)
        {
            if (Equals(RightChild, treeNode))
                RightChild = null;
            else if (Equals(LeftChild, treeNode))
                LeftChild = null;
        }
    }
}
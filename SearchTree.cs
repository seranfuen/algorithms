using System;

namespace Algorithms
{
    public class SearchTree
    {
        public TreeNode Root { get; private set; }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
                return;
            }

            var parent = FindSuitableParent(value, Root);
            if (parent.Value >= value)
            {
                if (parent.LeftChild != null)
                    throw new InvalidOperationException(
                        "We expected to put the new node as left child, but this node already has one. It's not a suitable parent");
                parent.LeftChild = new TreeNode(value)
                {
                    Parent = parent
                };
            }
            else
            {
                if (parent.RightChild != null)
                    throw new InvalidOperationException(
                        "We expected to put the new node as right child, but this node already has one. It's not a suitable parent");
                parent.RightChild = new TreeNode(value) {Parent = parent};
            }
        }

        public TreeNode Find(int value)
        {
            return Find(value, Root);
        }

        public void Delete(int value)
        {
            var find = Find(value);
            if (find == null) return;


            if (!find.HasChildren) // is leaf
            {
                if (find.Parent == null) // is also root, so we just remove it as root
                    Root = null;
                else // remove the references the parent has to this leaf
                    find.RemoveFromParent();
            }
            else if (find.LeftChild == null && find.RightChild != null) // if only one child, we just swap them
            {
                SwapWithRightChild(find);
            }
            else if (find.RightChild == null && find.LeftChild != null)
            {
                SwapWithLeftChild(find);
            }
            else // two children, we need to replace it with its predecessor which is the maximum value of its left branch
                // i.e. the highest value smaller or equal to itself
            {
                var predecessor = FindMaxInBranch(find.LeftChild);
                SwapNodeWithPredecessor(predecessor, find);
            }

            find.Parent = null;
            find.LeftChild = null;
            find.RightChild = null;
        }

        private void SwapNodeWithPredecessor(TreeNode predecessor, TreeNode find)
        {
            predecessor.RemoveFromParent();
            predecessor.Parent = find.Parent; // replace node with predecessor in the hierarchy
            // now predecessor get the removed node's left tree and right trees
            predecessor.LeftChild = find.LeftChild;
            if (predecessor.LeftChild != null) predecessor.LeftChild.Parent = predecessor;
            predecessor.RightChild = find.RightChild;
            if (predecessor.RightChild != null) predecessor.RightChild.Parent = predecessor;
            if (find.Equals(Root))
                Root = predecessor;
        }

        private static void SwapWithLeftChild(TreeNode find)
        {
            find.LeftChild.Parent = find.Parent;
            if (find.Parent.RightChild != null && find.Parent.RightChild.Equals(find))
                find.Parent.RightChild = find.LeftChild;
            else if (find.Parent.LeftChild != null && find.Parent.LeftChild.Equals(find))
                find.Parent.LeftChild = find.LeftChild;
        }

        private static void SwapWithRightChild(TreeNode node)
        {
            node.RightChild.Parent = node.Parent;
            if (node.Parent.RightChild != null && node.Parent.RightChild.Equals(node))
                node.Parent.RightChild = node.RightChild;
            else if (node.Parent.LeftChild != null && node.Parent.LeftChild.Equals(node))
                node.Parent.LeftChild = node.RightChild;
        }

        private static TreeNode FindSuitableParent(int value, TreeNode currentNode)
        {
            if (value <= currentNode.Value)
            {
                if (currentNode.LeftChild == null) return currentNode;
                return FindSuitableParent(value, currentNode.LeftChild);
            }

            if (currentNode.RightChild == null) return currentNode;
            return FindSuitableParent(value, currentNode.RightChild);
        }

        private static TreeNode Find(int value, TreeNode currentNode)
        {
            if (currentNode == null) throw new ArgumentNullException(nameof(currentNode));
            if (value == currentNode.Value)
                return currentNode;
            if (value < currentNode.Value)
                return currentNode.LeftChild != null ? Find(value, currentNode.LeftChild) : null;
            return currentNode.RightChild != null ? Find(value, currentNode.RightChild) : null;
        }

        private static TreeNode FindMaxInBranch(TreeNode node)
        {
            while (node.RightChild != null) node = node.RightChild;

            return node;
        }
    }
}
namespace Algorithms
{
    public class MinHeap
    {
        private int[] _binaryTree = new int[128];
        private int _nextFree = 1;

        public int Peek => _binaryTree[1];
        public int Length { get; private set; }

        public void Insert(int value)
        {
            CheckTreeLength();

            _binaryTree[_nextFree++] = value;
            FixMinHeapAfterInsertion();
            Length++;
        }

        public int RemoveTop()
        {
            var top = Peek;

            Length--;
            _binaryTree[1] = _binaryTree[--_nextFree];
            FixMinHeapAfterTopRemoval();
            return top;
        }

        private void FixMinHeapAfterTopRemoval()
        {
            var currentIndex = 1;
            while (currentIndex <= Length)
            {
                var leftChildIndex = currentIndex * 2;
                if (leftChildIndex > Length) break;
                var originalPointer = currentIndex;
                var leftChild = _binaryTree[leftChildIndex];
                var rightChildIndex = leftChildIndex + 1;
                var rightChild = rightChildIndex > Length ? int.MinValue : _binaryTree[rightChildIndex];

                if (_binaryTree[currentIndex] > leftChild && (leftChild < rightChild || rightChild == int.MinValue))
                {
                    _binaryTree[leftChildIndex] = _binaryTree[currentIndex];
                    _binaryTree[currentIndex] = leftChild;
                    currentIndex *= 2;
                }
                else if (_binaryTree[currentIndex] > rightChild && rightChild != int.MinValue)
                {
                    _binaryTree[rightChildIndex] = _binaryTree[currentIndex];
                    _binaryTree[currentIndex] = rightChild;
                    currentIndex = rightChildIndex;
                }

                if (originalPointer == currentIndex) break;
            }
        }

        private void FixMinHeapAfterInsertion()
        {
            var pointer = _nextFree - 1;
            while (CurrentNodeSmallerThanParent(pointer))
            {
                var temp = _binaryTree[pointer / 2];
                _binaryTree[pointer / 2] = _binaryTree[pointer];
                _binaryTree[pointer] = temp;
                pointer /= 2;
            }
        }

        private bool CurrentNodeSmallerThanParent(int pointer)
        {
            return pointer > 1 && _binaryTree[pointer] < _binaryTree[pointer / 2];
        }

        private void CheckTreeLength()
        {
            if (_binaryTree.Length == _nextFree)
                DuplicateBinaryTree();
        }

        private void DuplicateBinaryTree()
        {
            var newBinaryTree = new int[_binaryTree.Length * 2];
            for (var i = 0; i < _binaryTree.Length; i++)
                newBinaryTree[i] = _binaryTree[i];

            _binaryTree = newBinaryTree;
        }
    }
}
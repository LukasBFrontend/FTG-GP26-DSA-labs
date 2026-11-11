using System;
using System.Collections.Generic;

namespace DSA.Lab04B
{
    /// <summary>
    /// Priority queue implemented with a binary min-heap.
    ///
    /// Invariant:
    /// each parent's Priority is <= the Priority of each of its children.
    ///
    /// The heap is NOT fully sorted.
    /// </summary>
    public sealed class BinaryHeapDispatchQueue<T>
    {
        private readonly List<PriorityEntry<T>> _heap = new();

        public int Count => _heap.Count;

        public void Enqueue(T item, int priority)
        {
            _heap.Add(new (item, priority));
            SiftUp(_heap.Count - 1);
        }

        public PriorityEntry<T> PeekNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            return _heap[0];
        }

        public PriorityEntry<T> DequeueNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            var oldRoot = _heap[0];
            int lastIndex = _heap.Count - 1;

            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            if (_heap.Count > 0)
            {
                SiftDown(0);
            }

            return oldRoot;
        }

        private void SiftUp(int index)
        {
            int currentIndex = index;
            int parentIndex = ParentIndex(currentIndex);

            while (_heap[currentIndex].Priority < _heap[parentIndex].Priority)
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = ParentIndex(currentIndex);
            }
        }

        private void SiftDown(int index)
        {
            int currentIndex = index;
            int smallestChildIndex = IndexOfLowestPriorityChild(currentIndex);

            while (_heap[currentIndex].Priority > _heap[smallestChildIndex].Priority)
            {
                Swap(currentIndex, smallestChildIndex);

                currentIndex = smallestChildIndex;
                smallestChildIndex = IndexOfLowestPriorityChild(currentIndex);
            }
        }

        private int IndexOfLowestPriorityChild(int index)
        {
            int result = index;
            var children = GetChildrenIndices(index);

            if (children.Count == 1)
            {
                result = children[0];
            }
            else if (children.Count == 2)
            {
                result = _heap[children[0]].Priority < _heap[children[1]].Priority
                    ? children[0]
                    : children[1]
                ;
            }

            return result;
        }

        private IReadOnlyList<int> GetChildrenIndices(int index)
        {
            List<int> result = new();

            int leftChildIndex = LeftChildIndex(index);
            int rightChildIndex = RightChildIndex(index);

            if (leftChildIndex < _heap.Count)
            {
                result.Add(leftChildIndex);
            }

            if (rightChildIndex < _heap.Count)
            {
                result.Add(rightChildIndex);
            }

            return result;
        }

        private static int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }


        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int a, int b)
        {
            PriorityEntry<T> temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }
    }
}

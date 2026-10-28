using System;

namespace DSA.Lab02
{
    public sealed class RingQueue<T>
    {
        private readonly T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public RingQueue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                throw new InvalidOperationException(nameof(Enqueue));
            }

            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;

            _count++;
        }

        public T Peek()
        {
            return _items[_head];
        }

        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException(nameof(Dequeue));
            }

            T item = _items[_head];
            _items[_head] = default!;

            _count--;
            _head = (_head + 1) % _items.Length;

            return item;
        }
    }
}

using System;
using System.Diagnostics;

namespace Intura.Collections
{
    /// <summary>
    /// A collection of objects stored in a stack, representing a FIFO
    /// (First-In-First-Out) queue.
    /// </summary>
    /// <typeparam name="T">The type for the collection.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class Stack<T>
    {
        private T[] _storage;
        private int _position;
        private readonly int _initialCapacity;

        /// <summary>
        /// Initialize an instance of the Stack class.
        /// </summary>
        public Stack()
        {
            _initialCapacity = 10;
            _position = -1;
            ResetStorage();
        }

        /// <summary>
        /// Initialize an instance of the Stack class by defining the initial capacity.
        /// </summary>
        /// <param name="initialCapacity">The initial capacity of the collection.</param>
        public Stack(int initialCapacity)
        {
            if (initialCapacity < 1)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Must be greater than zero.");

            _initialCapacity = initialCapacity;
            _position = -1;
            ResetStorage();
        }

        /// <summary>
        /// Push an item on to the top of the stack.
        /// </summary>
        /// <param name="item">An object of type T.</param>
        public void Push(T item)
        {
            // Resize the array if necessary
            if (_position + 1 == _storage.Length)
            {
                // Double the array size
                var tmp = new T[_storage.Length*2];
                _storage.CopyTo(tmp, 0);
                _storage = tmp;
            }

            _position++;
            _storage[_position] = item;
        }

        /// <summary>
        /// Pop an item off the top of the stack.
        /// </summary>
        /// <returns>An object of type T.</returns>
        /// <exception cref="CollectionEmptyException">If the collection is empty an exception will be thrown.</exception>
        public T Pop()
        {
            if (_position < 0)
                throw new CollectionEmptyException("The collection is empty");

            var item = _storage[_position];
            _position--;

            // If we have emptied the stack then we can reset the array
            if (_position < 0)
                ResetStorage();
            // Or if the data in the array is half the size, we can shrink it
            else if (_position < (_storage.Length / 2) -1)
                Array.Resize(ref _storage, _storage.Length / 2);

            return item;
        }

        /// <summary>
        /// Take a look at the next item in the stack.
        /// </summary>
        /// <returns>An object of type T.</returns>
        /// <exception cref="CollectionEmptyException">If the collection is empty an exception will be thrown.</exception>
        public T Peek()
        {
            if (_position < 0)
                throw new CollectionEmptyException("The collection is empty");

            return _storage[_position];
        }

        /// <summary>
        /// Clear the data from the stack.
        /// </summary>
        public void Clear()
        {
            Array.Clear(_storage, 0, _storage.Length);
            _position = -1;
        }

        public bool IsEmpty => _position < 0;

        public int Count => _position < 0 ? 0 : _position+1;

        public int Capacity => _storage.Length;

        private void ResetStorage()
        {
            _storage = new T[_initialCapacity];
        }
    }
}
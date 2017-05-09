using System;
using System.Runtime.CompilerServices;

namespace Intura.Collections
{
    public class CollectionEmptyException : ApplicationException
    {
        public CollectionEmptyException()
        {}

        public CollectionEmptyException(string message) : base(message)
        {}

        public CollectionEmptyException(string message, Exception e) : base(message, e)
        {}
    }
}
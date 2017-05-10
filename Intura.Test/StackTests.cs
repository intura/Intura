using System;
using System.Diagnostics.Contracts;
using Intura.Collections;
using NUnit.Framework;

namespace Intura.Test
{
    [TestFixture]
    public class StackTests
    {
        /// <summary>
        /// Default capacity is 10.
        /// </summary>
        [Test]
        public void CanCreateStackWithDefaultCapacity()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(10, stack.Capacity);
        }

        /// <summary>
        /// Can set a custom capacity.
        /// </summary>
        [Test]
        public void CanCreateStackWithCustomCapacity()
        {
            var stack = new Stack<int>(500);
            Assert.AreEqual(500, stack.Capacity);
        }

        /// <summary>
        /// Can push items onto the stack and pop them off in the correct order.
        /// </summary>
        [Test]
        public void CanPushAndPop()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.AreEqual(5, stack.Count);

            var one = stack.Pop();
            Assert.AreEqual(5, one);
            Assert.AreEqual(4, stack.Count);

            var two = stack.Pop();
            Assert.AreEqual(4, two);
            Assert.AreEqual(3, stack.Count);

            var three = stack.Pop();
            Assert.AreEqual(3, three);
            Assert.AreEqual(2, stack.Count);

            var four = stack.Pop();
            Assert.AreEqual(2, four);
            Assert.AreEqual(1, stack.Count);

            var five = stack.Pop();
            Assert.AreEqual(1, five);
            Assert.AreEqual(0, stack.Count);
        }

        /// <summary>
        /// The stack will double in size when the capacity is used up and
        /// will shrink when the data is smaller than half of the current
        /// capacity.
        /// </summary>
        [Test]
        public void WillGrowAndShrinkCapacityWithData()
        {
            var stack = new Stack<int>(5);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual(5, stack.Capacity);

            stack.Push(6);

            Assert.AreEqual(6, stack.Count);
            Assert.AreEqual(10, stack.Capacity);

            stack.Pop();

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual(10, stack.Capacity);

            stack.Pop();

            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual(5, stack.Capacity);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsExceptionWhenCapacityIsLessThanOne()
        {
            var stack = new Stack<int>(0);
        }

        [Test]
        public void CanClearCollection()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(10, stack.Capacity);

        }
    }
}
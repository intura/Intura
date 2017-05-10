using Intura.Collections;
using NUnit.Framework;

namespace Intura.Test
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void CanCreateStackWithDefaultCapacity()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(100, stack.Capacity);
        }

        [Test]
        public void CanCreateStackWithCustomCapacity()
        {
            var stack = new Stack<int>(500);
            Assert.AreEqual(500, stack.Capacity);
        }

        [Test]
        public void CanPushAndPop()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.AreEqual(5, stack.Size);

            var one = stack.Pop();
            Assert.AreEqual(5, one);
            Assert.AreEqual(4, stack.Size);

            var two = stack.Pop();
            Assert.AreEqual(4, two);
            Assert.AreEqual(3, stack.Size);

            var three = stack.Pop();
            Assert.AreEqual(3, three);
            Assert.AreEqual(2, stack.Size);

            var four = stack.Pop();
            Assert.AreEqual(2, four);
            Assert.AreEqual(1, stack.Size);

            var five = stack.Pop();
            Assert.AreEqual(1, five);
            Assert.AreEqual(0, stack.Size);
        }

        [Test]
        public void WillGrowAndShrinkCapacityWithData()
        {
            var stack = new Stack<int>(5);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.AreEqual(5, stack.Size);
            Assert.AreEqual(5, stack.Capacity);

            stack.Push(6);

            Assert.AreEqual(6, stack.Size);
            Assert.AreEqual(10, stack.Capacity);

            stack.Pop();

            Assert.AreEqual(5, stack.Size);
            Assert.AreEqual(10, stack.Capacity);

            stack.Pop();

            Assert.AreEqual(4, stack.Size);
            Assert.AreEqual(5, stack.Capacity);

        }
    }
}
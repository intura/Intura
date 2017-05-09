using Intura.Collections;
using NUnit.Framework;

namespace Intura.Test
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void CanCreateStack()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(100, stack.Capacity);
        }
    }
}
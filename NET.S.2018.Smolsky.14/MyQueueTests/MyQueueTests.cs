using System;
using MyQueue;
using NUnit.Framework;

namespace MyQueueTests
{
    [TestFixture]
    public class MyQueueTests
    {
        [Test]
        public void MyQueueEnqueueOperationTest()
        {
            var q = new Queue<int>();
            q.Enqueue(7);
            q.Enqueue(9);
            Assert.AreEqual(7, q.Dequeue(), "element retrieved from the queue is not the expected one");
        }
    }
}
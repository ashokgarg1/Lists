using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;

using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.Tests
{
    [TestClass()]
    public class ListQueueTests
    {
        [TestMethod()]
        public void EnqueTest()
        {
            IListQueueable<QueueItem> listQueue = new ListQueue<QueueItem>();
            var startTime = DateTime.Now;

            listQueue.Enqueue(new QueueItem("SPY", 411.99, "BullishScan"));
            listQueue.Enqueue(new QueueItem("QQQ"));

            //tests: Values are valid
            QueueItem queueItem = listQueue.Dequeue();
            listQueue.Enqueue(new QueueItem("BABA", 91.70, "BearishScan"));

            queueItem = listQueue.Dequeue();
            queueItem = listQueue.Dequeue();

            Assert.AreEqual("BABA", queueItem.Key);
            Assert.AreEqual(91.70, queueItem.Value);
            Assert.AreEqual("BearishScan", queueItem.Description);


            //queueItem Millisecond part is valid
            Assert.IsTrue(startTime.Millisecond - queueItem.Datetime.Millisecond <= 10);
            Assert.IsTrue(queueItem.Datetime.Millisecond - startTime.Millisecond >= 0);

        }

        [TestMethod()]
        public void DequeueTest()
        {
            IListQueueable<QueueItem> listQueue = new ListQueue<QueueItem>();
            var startTime = DateTime.Now;

            listQueue.Enqueue(new QueueItem("SPY", 411.99, "BullishScan"));
            listQueue.Enqueue(new QueueItem("QQQ"));
            listQueue.Enqueue(new QueueItem("BABA", 91.70, "BearishScan"));

            //tests: Values are valid
            QueueItem queueItem = listQueue.Dequeue();
            queueItem = listQueue.Dequeue();

            Assert.AreEqual("QQQ", queueItem.Key);
            Assert.AreEqual(0, queueItem.Value);
            Assert.AreEqual("", queueItem.Description);

            queueItem = listQueue.Dequeue();

            //queueItem Millisecond part is valid
            Assert.IsTrue(startTime.Millisecond - queueItem.Datetime.Millisecond <= 10);
            Assert.IsTrue(queueItem.Datetime.Millisecond - startTime.Millisecond >= 0);

            //Not Null Tests
            Assert.IsNotNull(queueItem.Datetime);
            Assert.IsNotNull(queueItem.Value);
            Assert.IsNotNull(queueItem.Description);

            //Values are valid tests
            Assert.AreEqual("BABA", queueItem.Key);
            Assert.AreEqual(91.70, queueItem.Value);
            Assert.AreEqual("BearishScan", queueItem.Description);

        }

        [TestMethod()]
        public void PushToTopTest()
        {
            IListQueueable<QueueItem> listQueue = new ListQueue<QueueItem>();
            listQueue.Enqueue(new QueueItem("SPY", 411.99, "BullishScan"));
            listQueue.Enqueue(new QueueItem("QQQ"));
            listQueue.Enqueue(new QueueItem("GILD", 55.70, "BearishScan"));

            listQueue.PushToTop(new QueueItem("GILD"));
            var queueItem = listQueue.Peek();
            Assert.AreEqual("GILD", queueItem.Key);

            listQueue.PushToTop(new QueueItem("QQQ"));
            queueItem = listQueue.Dequeue();
            Assert.AreEqual("QQQ", queueItem.Key);
            queueItem = listQueue.Dequeue();
            Assert.AreEqual("GILD", queueItem.Key);

            queueItem = listQueue.Dequeue();
            Assert.AreEqual(queueItem.Key, "SPY");

        }

        [TestMethod()]
        public void GetKeysAsStringTest()
        {
            IListQueueable<QueueItem> listQueue = new ListQueue<QueueItem>();
            listQueue.Enqueue(new QueueItem("SPY", 411.99, "BullishScan"));
            listQueue.Enqueue(new QueueItem("QQQ"));
            listQueue.Enqueue(new QueueItem("MSFT", 278.84, "BullishScan"));

            var keys = listQueue.GetKeysAsString(",");
            Assert.AreEqual("SPY,QQQ,MSFT", keys);
        }

        [TestMethod()]
        public void UpdateValueTest()
        {
            //todonow:
        }

        [TestMethod()]
        public void PeekTest()
        {
            //todonow:
        }

        [TestMethod()]
        public void ContainsTest()
        {
            //todonow:
        }

    }
}
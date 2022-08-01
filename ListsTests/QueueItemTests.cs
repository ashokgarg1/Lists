using System;
using System.Collections.Generic;
using System.Text;

using Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListsTests
{
    [TestClass()]
    public class QueueItemTests
    {
        [TestMethod()]
        public void QueueItemTest()
        {
            var startTime = DateTime.Now;
            var queueItem = new QueueItem("SPY");

            Assert.IsTrue(startTime.Millisecond - queueItem.Datetime.Millisecond <= 10);
            Assert.IsTrue(queueItem.Datetime.Millisecond - startTime.Millisecond >= 0);

            Assert.AreEqual("SPY", queueItem.Key);
            Assert.AreEqual(0, queueItem.Value);
            Assert.AreEqual("", queueItem.Description);
        }
    }
}

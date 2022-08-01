using System;
using System.Threading.Tasks;

namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _ = Demo();
            Console.ReadLine();
        }

        private static async Task Demo()
        {
            IListQueueable<QueueItem> listQueue = new ListQueue<QueueItem>();
            var startTime = DateTime.Now;

            listQueue.Enqueue(new QueueItem("SPY", 411.99, "BullishScan"));
            listQueue.Enqueue(new QueueItem("QQQ", 376.45, "BullishScan"));
            listQueue.Enqueue(new QueueItem("BABA", 91.70, "BearishScan"));

            int count = await DequeueAndShow(listQueue);

            Console.WriteLine("All done, press any key to continue...");

        }

        private static async Task<int> DequeueAndShow(IListQueueable<QueueItem> listQueue)
        {
            int count = listQueue.Count;

            Console.WriteLine($"Queued {count} items, will dequeue shortly...");

            for (int i = 0; i < count; i++)
            {
                await Task.Delay(2000);
                var item = listQueue.Dequeue();
                Console.WriteLine($"Dequeued {item.Key} {item.Datetime} {item.Value} {item.Description}");
            }
            await Task.Delay(2000);

            return count;

        }
    }
}

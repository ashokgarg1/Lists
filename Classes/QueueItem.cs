using System;

namespace Lists
{
    public class QueueItem : IQueueable
    {
        public QueueItem(string key, double value = 0, string desc = "")
        {
            Key = key;
            Value = value;
            Description = desc;
            Datetime = DateTime.Now;
        }

        public string Key { get; set; }
        public DateTime Datetime { get; set; }
        public double Value { get; set; } = 0;
        public string Description { get; set; } = "";


    }
}
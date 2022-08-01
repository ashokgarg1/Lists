using System;

namespace Lists
{

    public interface IQueueable
    {
        string Key { get; set; }

        DateTime Datetime { get; set; }
    }
}
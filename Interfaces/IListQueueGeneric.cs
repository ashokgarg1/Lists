using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public interface IListQueueGeneric<T> where T : IQueueable
    {
        int Count { get; }
        bool Contains(string key);
        void PushToTop(T item);

        T Dequeue();
        void Enqueue(T item);
        string GetKeysAsString(string separator = ", ");
        int GetHashCode(T item);
        T Peek();
        List<T> ToList();
        bool UpdateValue(T item);
    }
}

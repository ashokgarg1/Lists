using System.Collections.Generic;

namespace Lists
{
    public interface IListQueueable<T> where T : IQueueable
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
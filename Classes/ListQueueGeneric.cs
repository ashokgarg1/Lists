using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Lists
{
    public class ListQueueGeneric<T> : IListQueueGeneric<T>, IEqualityComparer<T>, IEnumerable<T>
        where T:IQueueable
    {
        private List<T> _listQueueItems = new List<T>();
        //private Hashtable _keysHash = new Hashtable();

        public int MaxSize { get; set; } = int.MaxValue;
        public int Count => _listQueueItems.Count;

        /// <summary>
        /// Enque will be ignored if key already exists in queue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        public void Enqueue(T item)
        {
            if (!Contains(item.Key))   // the queue holds only unique keys. Value, description dont need to be updated// the queue holds only unique keys. Value, description dont need to be updated
            {
                _listQueueItems.Add(item);

                if (Count > MaxSize)
                    Dequeue();
            }
        }

        /// <summary>
        /// Move the item to top of queue so that it is the very next item to be dequeued
        /// </summary>
        /// <param name="key"></param>
        public virtual void PushToTop(T item)
        {
            T queueItem = _listQueueItems.FirstOrDefault(p => p.Key == item.Key);
            if (queueItem != null)
            {
                lock (_listQueueItems)
                {
                    if (_listQueueItems.Remove(queueItem))
                        _listQueueItems.Insert(0, queueItem);
                }
            }
        }

        public bool UpdateValue(T item)
        {
            var queueItem = _listQueueItems.FirstOrDefault(p => p.Key.Equals(item.Key, StringComparison.OrdinalIgnoreCase));

            if (queueItem != null)
            {
                queueItem = item;
                return true;
            }
            //just ignore if not found, do not throw exception
            //else
            //    throw new ArgumentException($"key {key} not found in QueueList", key);

            return false;
        }

        public T Dequeue()
        {
            if (_listQueueItems.Count > 0)
            {
                lock (_listQueueItems)
                {
                    T item = _listQueueItems[0];
                    _listQueueItems.RemoveAt(0);

                    return item;
                }
            }
            return default(T);
        }

        public T Peek()
        {
            if (_listQueueItems.Count > 0)
            {
                lock (_listQueueItems)
                {
                    if (_listQueueItems.Count > 0)
                        return _listQueueItems[0];
                    else
                        return default(T);
                }
            }
            else
                return default(T);
        }

        public List<T> ToList()
        {
            return _listQueueItems.ToList();
        }

        public virtual string GetKeysAsString(string separator = ", ")
        {
            if (_listQueueItems.Count > 0)
            {
                lock (_listQueueItems)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < _listQueueItems.Count; i++)
                    {
                        if (i > 0)
                            sb.Append(separator);   //do not place the separator before first key
                        sb.Append(_listQueueItems[i].Key);
                    }

                    return sb.ToString();
                }
            }
            else
                return "";
        }

        public bool Contains(string key)
        {
            lock (_listQueueItems)
            {
                return _listQueueItems.Any(p => p.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
            }
        }

        public bool Equals(T x, T y)
        {
            return x.Key.Equals(y.Key, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(T queueItem)
        {
            return queueItem.Key.GetHashCode();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _listQueueItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _listQueueItems.GetEnumerator();
        }

    }
}
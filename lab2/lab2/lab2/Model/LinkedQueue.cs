using System;
using System.Collections;
using System.Collections.Generic;

namespace lab2.Model
{
    public class LinkedQueue<T> : IEnumerable<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;

        public int Count { get; private set; }

        public LinkedQueue() { }

        public LinkedQueue(T data)
        {
            SetHeadItem(data);
        }

        private void SetHeadItem(T data)
        {
            var item = new QueueItem<T>(data);
            head = item;
            tail = item;
            Count = 1;
        }
        
        public void Enqueue(T data)
        {
            if (Count == 0)
            {
                SetHeadItem(data);
                return;
            }
            var item = new QueueItem<T>(data)
            {
                Next = tail
            };
            tail = item;
            Count++;

            return;
        }

        public T Dequeue()
        {
            var data = head.Data;
            var current = tail.Next;
            var previous = tail;

            while (current != null && current.Next != null)
            {
                previous = current;
                current = current.Next;
            }
            head = previous;
            head.Next = null;
            Count--;
            return data;
        }

        public T Pick()
        {
            return head.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            QueueItem<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

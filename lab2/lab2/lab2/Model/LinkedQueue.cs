using System;
using System.Collections;
using System.Collections.Generic;

namespace lab2.Model
{
    public class LinkedQueue<T> : IEnumerable<float>
    {
        private QueueItem<float> head;
        private QueueItem<float> tail;

        public int Count { get; private set; }

        public LinkedQueue() { }

        public LinkedQueue(float data)
        {
            SetHeadItem(data);
        }

        private void SetHeadItem(float data)
        {
            var item = new QueueItem<float>(data);
            head = item;
            tail = item;
            Count = 1;
        }
        
        public void Enqueue(float data)
        {
            if (Count == 0)
            {
                SetHeadItem(data);
                return;
            }
            var item = new QueueItem<float>(data)
            {
                Next = tail
            };
            tail = item;
            Count++;

            return;
        }

        public float Dequeue()
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

        public float Pick()
        {
            return head.Data;
        }

        public float GetAverage()
        {
            QueueItem<float> current = tail;
            float average = 0;
            while(current != null)
            {
                average += current.Data;
                current = current.Next;
            }

            return average / Count;
        }

        public float GetMinOrMax(int MinOrMax)
        {
            float max = Pick();
            QueueItem<float> current = tail;

            while (current != null)
            {
                if (MinOrMax == 1 ? current.Data < max : current.Data > max)
                {
                    max = current.Data;
                }
                current = current.Next;
            }

            return max;
        }
        
        public float GetFoursEl()
        {
            float fours = 0;

            QueueItem<float> current = tail;
            int counter = 0;
            int indexToFind = Count - 4;
            while(current != null)
            {
                if(counter == indexToFind)
                {
                    fours = current.Data;
                }
                current = current.Next;
                counter++;
            }
            return fours; 
        }

        public void WriteElBeforeMin()
        {
            float min = GetMinOrMax(1);
            QueueItem<float> current = tail;
            Console.WriteLine("--------------");

            if (current.Data == min)
            {
                Console.WriteLine("Min - первый элемент");
            }
            while(current != null)
            {
                if(current.Next == null)
                {
                    return;
                }
                if(current.Next.Data == min)
                {
                    Console.WriteLine(current.Data);
                }
                current = current.Next;
            }
            Console.WriteLine("--------------");

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            QueueItem<float> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

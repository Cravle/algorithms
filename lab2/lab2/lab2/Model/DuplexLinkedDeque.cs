using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace lab2.Model
{
    public class DuplexLinkedDeque<T> : IEnumerable<float>
    {
        private DuplexItem<float> Head;
        private DuplexItem<float> Tail;

        public int Count { get; private set; }

        public DuplexLinkedDeque()
        {

        }

        public DuplexLinkedDeque(float data)
        {
            SetHeadItem(data);
        }

        private void SetHeadItem(float data)
        {
            var item = new DuplexItem<float>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public void PushBack(float data)
        {
            if (Count == 0)
            {
                SetHeadItem(data);
                return;
            }

            var item = new DuplexItem<float>(data);
            item.Next = Tail;
            Tail.Previous = item;
            Tail = item;
            Count++;
        }
        public void PushFront(float data)
        {
            if (Count == 0)
            {
                SetHeadItem(data);
                return;
            }

            var item = new DuplexItem<float>(data);
            item.Previous = Head;
            Head.Next = item;
            Head = item;
            Count++;
        }

        public float PopBack()
        {
            if(Count > 0)
            {
                var result = Tail.Data;
                var current = Tail.Next;
                current.Previous = null;
                Tail = current;
                Count--;
                return result;
            }
            else
            {
                return default(float);
            }
        }

        public float PopFront()
        {
            if (Count > 0)
            {
                var result = Head.Data;
                var current = Head.Previous;
                current.Next = null;
                Head = current;
                Count--;
                return result;
            }
            else
            {
                return default(float);
            }
            
        }

        public float PeekBack()
        {
            return Tail.Data;
        }
        public float PeekFront()
        {
            return Head.Data;
        }

        public void ClearDeq()
        {
            Tail = null;
            Count = 0;
        }

        public float GetSixs()
        {
            float sixs = 0;

            DuplexItem<float> current = Head;
            int counter = 0;
            while (current != null)
            {
                if (counter == 5)
                {
                    sixs = current.Data;
                }
                current = current.Previous;
                counter++;
            }
            return sixs;

        }

        public void SetThird(float el)
        {
            DuplexItem<float> current = Head;
            int counter = 0;
            while (current != null)
            {
                if (counter == 2)
                {
                    current.Data = el;
                }
                current = current.Previous;
                counter++;
            }

        }

        public void SetTail (float el)
        {
            Tail.Data = el;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            DuplexItem<float> current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

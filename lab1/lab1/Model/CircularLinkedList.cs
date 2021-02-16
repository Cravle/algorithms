using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab1.Model
{
    public class CircularLinkedList<T> : IEnumerable
    {
        public DuplexItem<T> Head { get; set; }

        public int Count { get; set; }

        public CircularLinkedList() { }

        public CircularLinkedList(T data)
        {
            SetHeadItem(data);
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                SetHeadItem(data);
                return;
            }

            var item = new DuplexItem<T>(data);
            item.Next = Head;
            item.Previous = Head.Previous;
            Head.Previous.Next = item;
            Head.Previous = item;
            Count++;
        }

        public void Delete(T data)
        {
            if (Head.Data.Equals(data))
            {
                RemoveItem(Head);
                Head = Head.Next;
            }

            var current = Head.Next;
            for(int i = Count; i>=  0; i--)
            {
                if (current != null && current.Data.Equals(data))
                {
                    RemoveItem(current);
                }
                current = current.Next;
            }
        }
        public void DeleteByID(int id)
        {
            if (id == 0)
            {
                RemoveItem(Head);
                Head = Head.Next;
                return;
            }

            var current = Head.Next;
            for(int i = Count; i>=  0; i--)
            {
                if (current != null && i == Count - id + 1)
                {
                    RemoveItem(current);
                    return;
                }
                current = current.Next;
            }

            
        }

        public void SwapById(int id)
        {
            if (Head == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            var current = Head;
            int i = 0;
            while (i < Count - 1)
            {
                if (i == id)
                {
                    var temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    return;
                }
                current = current.Next;
                i++;
            }

        }

        private void RemoveItem(DuplexItem<T> current)
        {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            Count--;
        }

        private void SetHeadItem(T data)
        {
            Head = new DuplexItem<T>(data);
            Head.Next = Head;
            Head.Previous = Head;
            Count = 1;
        }

        public void Print()
        {
            Console.WriteLine("--------------------------------------------");

            var current = Head;
            while (current != null)
            {
                Console.Write(current + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            for(int i = 0; i < Count; i++)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

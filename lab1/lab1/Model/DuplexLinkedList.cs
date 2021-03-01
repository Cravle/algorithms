using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab1.Model
{
    public class DuplexLinkedList<T>: IEnumerable<T>
    {
        public DuplexItem<T> Head { get; set; }
        public DuplexItem<T> Tail { get; set; }
        public int Count { get; set; }

        public DuplexLinkedList() { }

        public DuplexLinkedList(T data)
        {
            var item = new DuplexItem<T>(data);
            Head = item;
            Tail = item;
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

        public void Add(T data)
        {
            var item = new DuplexItem<T>(data);

            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }

            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }

        public void DeleteByID(int id)
        {
            var current = Head;
            int i = 0;
            while(current != null)
            {

                if (id == 0)
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                if (id == Count - 1)
                {
                    Tail.Previous.Next = null;
                    Count--;
                    return;
                }


                if(i == id)
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }


                current = current.Next;
                i++;
            }
        }

        public void SwapById(int id)
        {
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

        public void Clear()
        { 
            Head = null;
            Tail = null;
            Count = 0;
        }

        public DuplexLinkedList<T> Reverse()
        {
            var result = new DuplexLinkedList<T>();

            var current = Tail;
            while(current != null)
            {
                result.Add(current.Data);
                current = current.Previous;
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        
    }

   
}

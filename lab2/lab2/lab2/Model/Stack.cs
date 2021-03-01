using System;
using System.Collections.Generic;
using System.Collections;

namespace lab2.Model
{
    public class LinkedStack<T> : IEnumerable<T>
    {

        public Item<T> Head { get; set; }
        public int Count { get; set; }


        public LinkedStack()
        {

            Head = null;
            Count = 0;
        }

        public LinkedStack(T data)
        {
            Head = new Item<T>(data);
            Count = 1;
        }

        public void Push(T data)
        {
            var item = new Item<T>(data);
            item.Previous = Head;
            Head = item;
            Count++;
        }

        public T Pop()
        {
            if (Count > 0)
            {

                var item = Head;
                Head = Head?.Previous;
                Count--;
                return item.Data;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }

        public void HeadToTail(Stack<T> old)
        {
            var temp = new Stack<T>();


            for (int i = 0; i < Count; i++)
            {
                temp.Push(old.Pop());

            }

        }

        public T Peek()
        {
            if (Count > 0)
            {
                return Head.Data;
            }
            else
            {
                throw new NullReferenceException("стек пуст");
            }
        }




        

        



        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }




    }
}

using System;
using System.Collections;


namespace lab1.Model
{
    /// <summary>
    /// односвязный список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// первый элемент списка
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// последний элемент списка
        /// </summary>
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Создать пустой список
        /// </summary>
        public LinkedList()
        {
            Clear();
        }

        

        /// <summary>
        /// Создать список с начальным элементом
        /// </summary>
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            SetHeadAndTail(data);
        }

        /// <summary>
        /// Вывод списка через его метод
        /// </summary>
        public void Print()
        {
            Console.WriteLine("--------------------------------------------");

            var current = Head;
            while(current != null)
            {
                Console.Write(current + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Добавить данные в конец списка
        /// </summary>
        public void Add(T data)
        {
         

            if(Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);

            }
        }


        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>

        public void Delete(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previus = Head;

                while(current != null)
                {
                    if(current.Data.Equals(data))
                    {
                        previus.Next = current.Next;
                        Count--;
                        return;
                    }
                   
                    previus = current;
                    current = current.Next;
                }
            }
        }

        public void DeleteById(int id)
        {
            if (Head != null)
                if(id < Count)
                {
                    if (id == 0)
                    {
                        Head = Head.Next;
                        Count--;
                        return;
                    }

                    var current = Head.Next;
                    var previus = Head;
                    int i = 0;
                    while (id != Count)
                    {

                        if (i == id)
                        {
                            previus.Next = current.Next;
                            Count--;
                            return;
                        }

                        previus = current;
                        current = current.Next;
                        i++;
                    }
                }
        }


        /// <summary>
        /// Добавить данные в начала списка
        /// </summary>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }

        public void Swap(T data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    var temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    return;
                }
                current = current.Next;
                
            }
        }

        public void SwapById(int id)
        {
            var current = Head;
            int i = 0;
            while (i < Count - 1 )
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

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
       
        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }


        /// <summary>
        /// получить перечесление всех элементов списка
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return "Linked List " + Count + " элементов";
        }
    }
}

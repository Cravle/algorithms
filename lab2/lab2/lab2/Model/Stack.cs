using System;
using System.Collections.Generic;
using System.Collections;

namespace lab2.Model
{
    public class LinkedStack<T> : IEnumerable<float>
    {

        public Item<float> Head { get; set; }
        public int Count { get; set; }


        public LinkedStack()
        {

            Head = null;
            Count = 0;
        }

        public LinkedStack(float data)
        {
            Head = new Item<float>(data);
            Count = 1;
        }

        public void Push(float data)
        {
            var item = new Item<float>(data);
            item.Previous = Head;
            Head = item;
            Count++;
        }

        public float Pop()
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

        public void HeadToTail()
        {
            Item<float> current = Head;
            float first = Head.Data;
            float last = Head.Data;

            while(current != null) {
                if (current.Previous == null)
                {
                    last = current.Data;
                }
                current = current.Previous;

            }

            current = Head;
            Head.Data = last;
            while(current != null)
            {
                if (current.Previous == null)
                {
                    current.Data = first;
                }
                current = current.Previous;

            }

        }
        private void deleteByIndex(int indexToDelete)
        {
            Item<float> current = Head;
            Item<float> next = null;
            int counter = 0;

            
            while (current != null)
            {
                if (counter == indexToDelete)
                {
                    if (current == Head)                   
                        Head = Head.Previous;
                    else                    
                        next.Previous = current.Previous;                     
                    Count--;

                }
                next = current;
                
                current = current.Previous;
                counter++;
            }
        }
        public void DeleteCenter()
        {     
            if (Count % 2 == 1)
            { 
                int indexToDelete = Count / 2 ;
                deleteByIndex(indexToDelete);          
            }
            else
            {
                int firstToDelete = Count / 2;
                int secondToDelete = Count / 2 - 1;
                deleteByIndex(firstToDelete);
                deleteByIndex(secondToDelete);
            }
            Count--;
        }
        public void delteEverySecond()
        {
            int counter = 1;
            Item<float> current = Head;
            int index = 1;
            while (current != null)
            {
                if(counter % 2 == 1)
                {
                    deleteByIndex(index);
                    index++;
                }
                counter++;
                current = current.Previous;

            }
        }
        public float Peek()
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

        private void AddByIndex(int index, float value)
        {
            Item<float> current = Head;
            int counter = 0;

            while(current != null)
            {
                if(counter == index)
                {
                    Item<float> item = new Item<float>(value) ;

                    item.Previous = current.Previous;
                    current.Previous = item;
                    Count++;
                    return;
                }
                counter++;
                current = current.Previous;
            }
        }

        public void AddElInCenter(float value)
        {
            int index = Count % 2 == 0 ? Count / 2 - 1 : Count/2 ;
            AddByIndex(index, value);
        }

        public void AddZeroAfterMinOrMax(int MinOrMax)
        {
            int counter = 0;
            float max = Peek();
            Item<float> current = Head;

            while (current != null)
            {
                if (MinOrMax == 1 ? current.Data < max : current.Data > max)
                {
                    max = current.Data;
                }
                current = current.Previous;
            }

            current = Head;

            while (current != null)
            {
                if (current.Data == max )
                {
                    AddByIndex(counter, 0);
                    counter++;
                    current = current.Previous;

                }

                current = current.Previous;
                
                counter++;
            }


        }

        public void deleteMinOrMax(int MinOrMax)
        {
            int counter = 0;
            float max = Peek();
            Item<float> current = Head;

            while (current != null)
            {
                if (MinOrMax == 1 ? current.Data < max : current.Data > max)
                {
                    max = current.Data;
                }
                current = current.Previous;
            }

            current = Head;

            while (current != null)
            {
                if (current.Data == max)
                {
                    deleteByIndex(counter);
                }

                current = current.Previous;
                counter++;
            }

        }

        public void DeleteExceptFirstOrLast(int firstOrLast)
        {
            if(firstOrLast == 1)
                Head.Previous = null;
            else
            {
                Item<float> current = Head;
                while(current != null)
                {
                    if (current.Previous == null)
                        Head = current;
                    current = current.Previous;
                }
            }

        }

        public void minToZero()
        {
            float max = Peek();
            Item<float> current = Head;

            while (current != null)
            {
                max = current.Data;
                if (current.Data < max)
                    max = current.Data; 
                current = current.Previous;

            }
            current = Head;
            while(current != null)
            {
                if (current.Data == max)
                    current.Data = 0;
                current = current.Previous;
            }
        }




        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            Item<float> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }




    }
}

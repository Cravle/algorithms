using lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class OperationStack
    {


        /// <summary>
        /// 	розгорнути стек, тобто зробити "дно" стека вершиною, а вершину - "дном";
        /// </summary>
        public LinkedStack<float> Razv(LinkedStack<float> old)
        {
            var temp = new LinkedStack<float>();

            while (old.Count != 0)
            {
                temp.Push(old.Pop());

            }


            return temp;

        }

        /// <summary>
        /// 	поміняти місцями перший і останній елементи стека
        /// </summary>
        public  LinkedStack<float> HeadToTail(LinkedStack<float> old)
        {
            var temp = new LinkedStack<float>();
            float headValue = old.Peek();
            float tailValue = 0;

            foreach (var el in old)
            {
                tailValue = el;

            }
            int counter = 0;

            old = Razv(old);

            foreach (var el in old)
            {
                if (counter == 0)
                {
                    temp.Push(headValue);
                    counter++;
                }
                else if (counter == old.Count - 1)
                {
                    temp.Push(tailValue);
                    counter++;
                }
                else
                {
                    temp.Push(el);
                    counter++;
                }

            }

            return temp;

        }

        /// <summary>
        /// 	видалити елемент, що знаходиться в середині стека, якщо число елементів непарне, або 2 середніх елемента, якщо число елементів парне;
        /// </summary>
        public  LinkedStack<float> DeletCenter(LinkedStack<float> old)
        {
            var temp = new LinkedStack<float>();
            old = Razv(old);
            int counter = 0;
            if (old.Count % 2 == 1)
            {
                int indexToDelete = old.Count / 2 + 1;
                foreach (var el in old)
                {
                    if (counter != indexToDelete)
                    {
                        temp.Push(el);
                    }
                    counter++;
                }
            }
            else
            {
                int firstToDelete = old.Count / 2;
                int secondToDelete = old.Count / 2 + 1;
                foreach (var el in old)
                {
                    if (counter != firstToDelete - 1 && counter != secondToDelete - 1)
                    {
                        temp.Push(el);
                    }
                    counter++;
                }
            }


            return temp;

        }
        /// <summary>
        /// 	видалити кожен другий елемент стека;
        /// </summary>
        public  LinkedStack<float> DeleteEverySecond(LinkedStack<float> old)
        {
            var temp = new LinkedStack<float>();

            int counter = 0;

            old = Razv(old);
            foreach (var el in old)
            {
                if (counter % 2 == 1)
                {
                    temp.Push(el);
                }

                counter++;
            }
            return temp;

        }

        /// <summary>
        /// 	вставити символ '*' в середину стека, якщо число елементів парне, або після середнього елемента, якщо число елементів непарне;
        /// </summary>
        public  LinkedStack<float> AddElInCenter(LinkedStack<float> old, float num)
        {
            var temp = new LinkedStack<float>();

            int counter = 0;

            old = Razv(old);

            if (old.Count % 2 == 1)
            {
                int centrIndex = old.Count / 2 - 1;
                foreach (var el in old)
                {
                    temp.Push(el);

                    if (counter == centrIndex)
                    {
                        temp.Push(num);
                    }
                    counter++;
                }
            }
            else
            {
                int centrIndex = old.Count / 2;
                foreach (var el in old)
                {
                    temp.Push(el);

                    if (counter == centrIndex - 1)
                    {
                        temp.Push(num);
                    }
                    counter++;
                }
            }

            return temp;

        }

        /// <summary>
        /// 		знайти мінімальний елемент і вставити після нього 0;
        ///	знайти максимальний елемент і вставити після нього 0;
        /// </summary>
        public  LinkedStack<float> AddZeroAfterMinOrMax(LinkedStack<float> old, int num)
        {
            // 1- min 0 -max

            var temp = new LinkedStack<float>();
            old = Razv(old);


            float max = old.Peek();

            foreach (var el in old)
            {
                if (num == 1 ? el < max : el > max)
                {
                    max = el;
                }

            }

            foreach (var el in old)
            {
                if (el == max)
                {
                    temp.Push(0);
                }
                temp.Push(el);

            }


            Console.WriteLine(max);
            return temp;

        }


        /// <summary>
        /// 	видалити мінімальний елемент;
        /// 	видалити максимальний елемент;
        /// </summary>
        public  LinkedStack<float> DeleteMinOrMax(LinkedStack<float> old, int num)
        {
            // 1- min 0 -max
            var temp = new LinkedStack<float>();
            float max = old.Peek();

            foreach (var el in old)
            {
                if (num == 1 ? el < max : el > max)
                {
                    max = el;
                }
            }

            foreach (var el in old)
            {
                if (el != max)
                {
                    temp.Push(el);
                }

            }

            return temp;

        }

        /// <summary>
        /// 	знайти мінімальний елемент і вставить на його місце 0;
        /// </summary>
        public  LinkedStack<float> MinToZERO(LinkedStack<float> old)
        {

            var temp = new LinkedStack<float>();
            float min = old.Peek();

            foreach (var el in old)
            {
                if (el < min)
                {
                    min = el;
                }
            }

            foreach (var el in old)
            {
                if (el == min)
                {
                    temp.Push(0);
                }
                else
                    temp.Push(el);

            }

            return temp;

        }

        /// <summary>
        /// 	видалити всі елементи, крім  першого;
        /// 	видалити всі елементи, крім останнього;
        /// </summary>

        public LinkedStack<float> DeleteFirstOrLast(LinkedStack<float> old, int num)
        {
            //0 - first 1 - last
            var temp = new LinkedStack<float>();
            if (num == 1)
            {
                old = Razv(old);
            }
            temp.Push(old.Peek());

            return temp;

        }

        public void menu()
        {

            Console.WriteLine("Введите начальную очередь: ");
            string str = Console.ReadLine();
            var stack = new LinkedStack<float>();

            string[] strArr = str.Split(' ');
            foreach(var el in strArr)
            {
                if(el != "")
                {
                    stack.Push(Convert.ToInt32(el));
                }
            }
            Console.WriteLine("--------------");
            foreach (var el in stack)
            {
                Console.WriteLine(el);
            }

            while(true)
            {
                Console.WriteLine("1- поміняти місцями перший і останній елементи стека");
                Console.WriteLine("2- розгорнути стек, тобто зробити дно стека вершиною, а вершину -дном");
                Console.WriteLine("3- видалити елемент, що знаходиться в середині стека, якщо число елементів непарне, або 2 середніх елемента, якщо число елементів парне");
                Console.WriteLine("4- видалити кожен другий елемент стека");
                Console.WriteLine("5- поміняти місцями перший і останній елементи стека");
                Console.WriteLine("6- поміняти місцями перший і останній елементи стека");
                Console.WriteLine("7- поміняти місцями перший і останній елементи стека");
                Console.WriteLine("8- поміняти місцями перший і останній елементи стека");

                Console.ReadLine();
            }
            //int menu = Convert.ToInt32(Console.ReadLine());
             
        }
    }
}

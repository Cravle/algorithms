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


        public void menu()
        {
            var stack = new LinkedStack<float>();

            void addStack()
            {
                Console.WriteLine("Введите стек: ");
                string str = Console.ReadLine();

                string[] strArr = str.Split(' ');
                foreach (var el in strArr)
                {
                    if (el != "")
                    {
                        stack.Push(Convert.ToInt32(el));
                    }
                }
            }

            void WriteStack()
            {
                Console.WriteLine("--------------");
                foreach (var el in stack)
                {
                    Console.Write(el + " ");
                }

                Console.WriteLine("");
                Console.WriteLine("--------------");

            }


            addStack();

            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(1);



            WriteStack();

            int minOrMax = 0;

            while (true)
            {
                Console.WriteLine("11- Добавить элементы стека");
                Console.WriteLine("1- поменять местами первый и последний элементы стека");
                Console.WriteLine("2- развернуть стек, то есть сделать дно стека вершиной, а вершину -дном");
                Console.WriteLine("3- удалить элемент, находящийся в середине стека, если число элементов нечетное, или 2 средних элемента, если число элементов четное");
                Console.WriteLine("4- удалить каждый второй элемент стека");
                Console.WriteLine("5- вставить символ '*' в середину стека, если число элементов четное или после среднего элемента, если число элементов нечетное;");
                Console.WriteLine("6- найти min/max элемент и вставить после него 0");
                Console.WriteLine("7- удалить min/max");
                Console.WriteLine("8- Удалить все, кроме ...");
                Console.WriteLine("9- найти минимальный элемент и вставить на его место 0");
                Console.WriteLine("66- Выйти");

                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 11:
                        addStack();
                        break;
                    case 1:
                        stack.HeadToTail();
                        break;
                    case 2:
                        stack =  Razv(stack);
                        break;
                    case 3:
                        stack.DeleteCenter();
                        break;
                    case 4:
                        stack.delteEverySecond();
                        break;
                    case 5:
                        Console.WriteLine("Введите елемент типа float");
                        float el = float.Parse(Console.ReadLine());
                        stack.AddElInCenter(el);
                        break;
                    case 6:
                        Console.WriteLine("1 - min");
                        Console.WriteLine("0 - max");
                        minOrMax = Convert.ToInt32(Console.ReadLine());
                        stack.AddZeroAfterMinOrMax(minOrMax);
                        break;
                    case 7:
                        Console.WriteLine("1 - min");
                        Console.WriteLine("0 - max");
                        minOrMax = Convert.ToInt32(Console.ReadLine());
                        stack.deleteMinOrMax(minOrMax);
                        break;
                    case 8:
                        Console.WriteLine("1 - первый");
                        Console.WriteLine("0 - последний");
                        minOrMax = Convert.ToInt32(Console.ReadLine());
                        stack.DeleteExceptFirstOrLast(minOrMax);
                        break;
                    case 9:
                        stack.minToZero();
                        break;
                    case 66:
                        Console.Clear();
                        return;
                    default:
                        break;
                }
                        WriteStack();

            }

        }
    }
}

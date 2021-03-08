using lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class OpDeq
    {
        public void menu()
        {
            var deque = new DuplexLinkedDeque<float>();

            void addDeque()
            {
                Console.WriteLine("Введите очередь: ");
                string str = Console.ReadLine();

                string[] strArr = str.Split(' ');
                foreach (var el in strArr)
                {
                    if (el != "")
                    {
                        deque.PushBack(Convert.ToInt32(el));
                    }
                }
            }

            void WriteDequeue()
            {
                Console.WriteLine("--------------");
                foreach (var el in deque)
                {
                    Console.Write(el + " ");
                }

                Console.WriteLine("");
                Console.WriteLine("--------------");

            }

            //deque.PushBack(1);
            //deque.PushBack(2);
            //deque.PushBack(3);
            //deque.PushBack(4);
            //deque.PushBack(5);
            //deque.PushBack(6);


            addDeque();
            WriteDequeue();

            while (true)
            {
                Console.WriteLine("11- Быстро добавить элементы Дека");
                Console.WriteLine("1- очистить дек (создать структуру пустой)");
                Console.WriteLine("2- проверить на пустоту");
                Console.WriteLine("3- Добавить елмент");
                Console.WriteLine("4- Взять елмент");
                Console.WriteLine("5- прочитать шестой элемент");
                Console.WriteLine("6- прочитать последний элемент");
                Console.WriteLine("7- записать третий элемент");
                Console.WriteLine("8- записать последний элемент");
                Console.WriteLine("66- Выйти");



                int menu = Convert.ToInt32(Console.ReadLine());
                int submenu = 0;
                int el = 0;
                switch (menu)
                {
                    case 11:
                        addDeque();
                        break;
                    case 1:
                        deque.ClearDeq();
                        break;
                    case 2:
                        if (deque.Count == 0)
                            Console.WriteLine("Дек пустой");
                        else
                            Console.WriteLine($"Дек имеет {deque.Count} елментов");
                        break;
                    case 3:
                        Console.WriteLine("0- В начало");
                        Console.WriteLine("1- В конец");
                        submenu = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите елмент");
                        el = Convert.ToInt32(Console.ReadLine());
                        if (submenu == 0)
                            deque.PushFront(el);
                        else
                            deque.PushBack(el);
                        break;
                    case 4:
                        Console.WriteLine("0- С начала");
                        Console.WriteLine("1- С конца");
                        submenu = Convert.ToInt32(Console.ReadLine());
                        if (submenu == 0)
                            Console.WriteLine($"Результат: {deque.PopFront()}");
                        else
                            Console.WriteLine($"Результат: {deque.PopBack()}");
                        break;

                    case 5:
                        if (deque.Count < 6)
                            Console.WriteLine("Дек имеет меньше 6 елементов");
                        else
                            Console.WriteLine($"Результат {deque.GetSixs()}");
                        break;
                    case 6:
                        Console.WriteLine($"Результат: {deque.PeekBack()}");
                        break;
                    case 7:
                        Console.WriteLine("Введите елмент");
                        el = Convert.ToInt32(Console.ReadLine());
                        deque.SetThird(el);
                        break;

                    case 8:
                        Console.WriteLine("Введите елмент");
                        el = Convert.ToInt32(Console.ReadLine());
                        deque.SetTail(el);
                        break;
                    case 66:
                        Console.Clear();
                        return;
                    default:
                        break;
                }

                WriteDequeue();

            }
        }
    }
}

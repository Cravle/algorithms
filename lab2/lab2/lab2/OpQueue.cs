using lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class OpQueue
    {
        public void menu()
        {
            var queue = new LinkedQueue<float>();

            void addQueue()
            {
                Console.WriteLine("Введите очередь: ");
                string str = Console.ReadLine();

                string[] strArr = str.Split(' ');
                foreach (var el in strArr)
                {
                    if (el != "")
                    {
                        queue.Enqueue(Convert.ToInt32(el));
                    }
                }
            }

            void WriteQueue()
            {
                Console.WriteLine("--------------");
                foreach (var el in queue)
                {
                    Console.Write(el + " ");
                }

                Console.WriteLine("");
                Console.WriteLine("--------------");

            }

            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(1);
            //queue.Enqueue(1);

            //queue.Enqueue(3);
            //queue.Enqueue(1);


            addQueue();
            WriteQueue();

            while (true)
            {
                Console.WriteLine("11- Добавить элементы очереди");
                Console.WriteLine("1- найти и вывести количество элементов очереди");
                Console.WriteLine("2- найти и вывести среднее арифметическое сохранившихся элементов");
                Console.WriteLine("3- найти и вывести минимальный и максимальный элемент");
                Console.WriteLine("4- найти и вывести четвертый элемент последовательности");
                Console.WriteLine("5- найти и вывести элемент, идущий перед минимальным элементом");
                Console.WriteLine("66- Выйти");

                int menu = Convert.ToInt32(Console.ReadLine());


                switch(menu)
                {
                    case 11:
                        addQueue();
                        break;
                    case 1:
                        Console.WriteLine($"Количество елементов очереди {queue.Count}");
                        break;
                    case 2:
                        Console.WriteLine($"Среднее арифметическое: {queue.GetAverage()}");
                        break;
                    case 3:
                        Console.WriteLine($"min = {queue.GetMinOrMax(1)}");
                        Console.WriteLine($"min = {queue.GetMinOrMax(0)}");
                        break;
                    case 4:
                        if (queue.Count < 4)
                            Console.WriteLine("В очереди менее 4х элементов");
                        else
                            Console.WriteLine($"id4 = {queue.GetFoursEl()}");
                        break;
                    case 5:
                        queue.WriteElBeforeMin();
                        break;
                    case 66:
                        Console.Clear();
                        return;
                    default:
                        break;
                }

                WriteQueue();

            }
        }
    }
}

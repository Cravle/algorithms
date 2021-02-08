using System;

namespace lab1
{


    class Program
    {
        
        static void menu1()
        {
            var list = new Model.LinkedList<int>();
            while (true)
            {

                Console.WriteLine($"Количество узлов в списке: {list.Count}");
                int menu;
                Console.WriteLine("1. Вывод списка");
                Console.WriteLine("2. Добавить елемент списка / создать его");
                Console.WriteLine("3. Удалить узел по значению");
                Console.WriteLine("4. Узнать количество елментов списка");
                Console.WriteLine("5. Поменять местами два соседних елемента");


                menu = Convert.ToInt32(Console.ReadLine());
                int data;
                int id;
                switch (menu)
                {
                    case 1:
                        list.Print();
                        break;
                    case 2:
                        Console.Write("Введите значение: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.Add(data);

                        break;
                    case 3:
                        Console.Write("Введите значение: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        list.DeleteById(id);
                        break;
                    case 4:
                        Console.WriteLine($"В списке: {list.Count} элементов");
                        break;
                    case 5:
                        Console.Write("Введите значение: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        list.SwapById(id);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                Console.WriteLine("--------------------------------------------");

            }
        }

        static void Main(string[] args)
        {
            menu1();
            
        }
    }
}

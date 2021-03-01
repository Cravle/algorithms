using System;

namespace lab1
{


    class Program
    {
        static void Start()
        {
            Console.WriteLine("1. Вывод списка");
            Console.WriteLine("2. Добавить елемент списка / создать его");
            Console.WriteLine("3. Удалить узел по id");
            Console.WriteLine("4. Узнать количество елментов списка");
            Console.WriteLine("5. Поменять местами два соседних елемента");
            Console.WriteLine("6. Дописать и обьеденить 2 списка");
            Console.WriteLine("7. Очистить список");
            Console.WriteLine("8. Добавилть елменты с файла");
            Console.WriteLine("9. Записать текущий список в int.txt");
            Console.WriteLine("0. Выход");
        }
        
        static void menu1()
        {
            var list = new Model.LinkedList<int>();
            while (true)
            {

                Console.WriteLine($"Количество узлов в списке: {list.Count}");
                Start();
                int menu;

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
                    case 6:
                        var temp = new Model.LinkedList<int>();
                        Console.Write("Введите значения: ");
                        string str = Console.ReadLine();
                        string[] elements = str.Split(' ');
                       foreach(var el in elements)
                       {
                           temp.Add(Convert.ToInt32(el));
                       }
                        foreach (var e in temp)
                        {
                            list.Add(Convert.ToInt32(e));
                        }
                        break;
                    case 7:
                        list.Clear();
                        break;
                    case 8:
                        string text = System.IO.File.ReadAllText(@"C:\Users\Mi Store\source\repos\algorithms\lab1\lab1\int.txt");
                        string[] elementsFromFile = text.Split(' ');
                        foreach (var el in elementsFromFile)
                        {
                            if(el != "")
                                list.Add(Convert.ToInt32(el));
                        }
                        
                        break;
                    case 9:
                        string elToFile = "";
                        foreach(var el in list)
                        {
                            elToFile += $"{Convert.ToString(el)} ";
                        }
                        //Console.WriteLine(elToFile);
                        System.IO.File.WriteAllText(@"C:\Users\Mi Store\source\repos\algorithms\lab1\lab1\int.txt", elToFile);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                Console.WriteLine("--------------------------------------------");

            }
        }

        static void menu2() 
        {
            var duplexList = new Model.DuplexLinkedList<int>();
            int menu;
            while (true)
            {
                Start();


                menu = Convert.ToInt32(Console.ReadLine());
                int data;
                int id;
                switch (menu)
                {
                    case 1:
                        duplexList.Print();
                        break;
                    case 2:
                        Console.Write("Введите значение: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        duplexList.Add(data);

                        break;
                    case 3:
                        Console.Write("Введите значение: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        duplexList.DeleteByID(id);
                        break;
                    case 4:
                        Console.WriteLine($"В списке: {duplexList.Count} элементов");
                        break;
                    case 5:
                        Console.Write("Введите значение: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        duplexList.SwapById(id);
                        break;
                    case 6:
                        var temp = new Model.DuplexLinkedList<int>();
                        Console.Write("Введите значения: ");
                        string str = Console.ReadLine();
                        string[] elements = str.Split(' ');
                        foreach (var el in elements)
                        {
                            temp.Add(Convert.ToInt32(el));
                        }
                        foreach (var e in temp)
                        {
                            duplexList.Add(Convert.ToInt32(e));
                        }
                        break;
                    case 7:
                        duplexList.Clear();
                        break;
                    case 8:
                        string text = System.IO.File.ReadAllText(@"C:\Users\Mi Store\source\repos\algorithms\lab1\lab1\int.txt");
                        string[] elementsFromFile = text.Split(' ');
                        foreach (var el in elementsFromFile)
                        {
                            if (el != "")
                                duplexList.Add(Convert.ToInt32(el));
                        }

                                break;
                    case 9:
                        string elToFile = "";
                        foreach (var el in duplexList)
                        {
                            elToFile += $"{Convert.ToString(el)} ";
                        }
                        //Console.WriteLine(elToFile);
                        System.IO.File.WriteAllText(@"C:\Users\Mi Store\source\repos\algorithms\lab1\lab1\int.txt", elToFile);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                Console.WriteLine("--------------------------------------------");
            }
        }
    

        

        static void menu3()
        {
            var circularList = new Model.CircularLinkedList<int>();

            int menu;
            while (true)
            {
                Start();


                menu = Convert.ToInt32(Console.ReadLine());
                int data;
                int id;
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------");
                        foreach (var item in circularList)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Введите значение: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        circularList.Add(data);

                        break;
                    case 3:
                        Console.Write("Введите значение: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        circularList.DeleteByID(id);
                        break;
                    case 4:
                        Console.WriteLine($"В списке: {circularList.Count} элементов");
                        break;
                    case 5:
                        Console.Write("Введите значение: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        circularList.SwapById(id);
                        break;
                    case 6:
                        var temp = new Model.CircularLinkedList<int>();
                        Console.Write("Введите значения: ");
                        string str = Console.ReadLine();
                        string[] elements = str.Split(' ');
                        foreach (var el in elements)
                        {
                            temp.Add(Convert.ToInt32(el));
                        }
                        foreach (var e in temp)
                        {
                            circularList.Add(Convert.ToInt32(e));
                        }
                        break;
                    case 7:
                        circularList.Clear();
                        break;
                    case 8:
                        string text = System.IO.File.ReadAllText(@"C:\Users\Mi Store\source\repos\algorithms\lab1\lab1\int.txt");
                        string[] elementsFromFile = text.Split(' ');
                        foreach (var el in elementsFromFile)
                        {
                            if (el != "")
                                circularList.Add(Convert.ToInt32(el));
                        }

                        break;
                    case 9:
                        string elToFile = "";
                        foreach (var el in circularList)
                        {
                            elToFile += $"{Convert.ToString(el)} ";
                        }
                        //Console.WriteLine(elToFile);
                        System.IO.File.WriteAllText(@"C:\Users\Mi Store\source\repos\algorithms\lab1\lab1\int.txt", elToFile);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void Main(string[] args)
        {
            
            int menu;
            while (true)
            {
                Console.WriteLine("1. Односвязный");
                Console.WriteLine("2. Двусвязный");
                Console.WriteLine("3. Кольцевой");
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        menu1();

                        break;
                    case 2:
                        menu2();

                        break;
                    case 3:
                        menu3();

                        break;
                    default:
                        return;

                }
            }
        }
    }
}

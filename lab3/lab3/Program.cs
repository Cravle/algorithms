using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab3
{
    

    class Program
    {

        static void Print(Node<int> node, int l)
        {
            int i;
            
            if (node != null)
            {
                Print(node.Right, l + 1);
                for (i = 0; i < l; i++)
                    Console.Write("                 ");
                Console.Write(node);
                 Print(node.Left, l + 1);
                
            }
            else Console.WriteLine();
        }

        static void PrintRB(RBTreeNode node, int l)
        {
            int i;

            if (node != null)
            {
                PrintRB(node.right, l + 1);
                for (i = 0; i < l; i++)
                    Console.Write("                 ");
                Console.Write(node);
                PrintRB(node.left, l + 1);

            }
            else Console.WriteLine();
        }

        static void PrintInFileTree(Node<int> node, int l)
        {
            int i;
            string path = @"C:\Users\Mi Store\source\repos\algorithms\lab3\lab3\tree.txt";
                if (node != null)
            {
                PrintInFileTree(node.Right, l + 1);
                    for (i = 0; i < l; i++)
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write("                 ");                            
                        }
                    }
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(node.ToString());
                }

                PrintInFileTree(node.Left, l + 1);

            }
            else using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine();
                }
        }

        static Tree<int> NewTreeByPasId(Tree<int> old)
        {
            Tree<int> newtree = new Tree<int>();

            foreach(var item in old.Preorder())
            {
                newtree.AddByPasId(item.Name, item.PasId, item.Age);
            }

            old.Clear(old.Root);

            return newtree;

        }

        


        

        static void Main(string[] args) 
        {
            var tree = new Tree<int>();


            void FastAdd()
            {
                tree.Add("Катя", 4444, 16);
                tree.Add("Олег", 1111, 18);

                tree.Add("Маша", 2222, 17);
                tree.Add("Никита", 6666, 34);

                tree.Add("Федр", 5555, 34);
                tree.Add("Зоя", 3333, 34);
                tree.Add("Ира", 7777, 20);
                tree.Add("Анастасия", 9999, 20);
            }

            void Split()
            {
                Console.WriteLine("------------------------------------------------------------------");
            }

            




            //Print(tree.Root, 0);
            //Console.WriteLine("-----------------------------");


            //Console.WriteLine($"количество: {tree.Count}");

            //tree = NewTreeByPasId(tree);



            //Print(tree.Root, 0);


            RBTree rbtTree = new RBTree();

            string name;
            int pasId;
            int age;
            int counter = 0;



            Date temp;

            //PrintRB(rbtTree.rootnode, 0);
            Console.WriteLine($"количество: {rbtTree.Count}");


            while(true)
            {
                Console.WriteLine("11- Быстрое заполнение дерева");
                Console.WriteLine("1- Печать дерева");
                Console.WriteLine("2- Найти средний возраст");
                Console.WriteLine("3- Сделать 3 разных обхода дерева");
                Console.WriteLine("4- Удаление...");
                Console.WriteLine("5- Пересыпать дерево по id");
                Console.WriteLine("6- Переделать дерево в красно-черное");
                Console.WriteLine("7- Вывести красно-черное дерево");
                Console.WriteLine("8- Сделать 3 обхода красно-черного дерева");
                Console.WriteLine("9- Добавить елемент в красночерное дерево");
                Console.WriteLine("10- Удалить елмент с красночерного дерева");
                Console.WriteLine("12- Запись дерева в файл");
                Console.WriteLine("13- Удалить левое поддерево");
                Console.WriteLine("14- Удалить правое поддерево");
                Console.WriteLine("15- Удалить корень");

                Console.WriteLine("66- Выйти");

                int menu = Convert.ToInt32(Console.ReadLine());
                
                switch(menu)
                {
                    case 11:
                        FastAdd();
                        break;
                    case 1:
                        Print(tree.Root, 0);
                        break;
                    case 2:
                        Console.WriteLine("Средний возраст: " + tree.GetAverage());
                        break;
                    case 3:
                        Console.WriteLine("Количество: " + tree.Count);
                        tree.Preorder2(tree.Root);
                        Split();
                        Console.WriteLine("Количество: " + tree.Count);
                        tree.Postorder(tree.Root);
                        Split();
                        Console.WriteLine("Количество: " + tree.Count);
                        tree.Symmetric(tree.Root);                        
                        break;
                    case 4:
                        tree.Clear(tree.Root);
                        break;
                    case 5:
                        tree = NewTreeByPasId(tree);
                        break;
                    case 6:
                        foreach (var el in tree.Preorder())
                        {
                            rbtTree.Insert(el.Name, el.PasId, el.Age);
                        }
                        break;
                    case 7:
                        PrintRB(rbtTree.rootnode, 0);
                        break;
                    case 8:
                        counter = 0;
                        Split();
                        rbtTree.Preorder2(rbtTree.rootnode,ref counter);
                        Console.WriteLine("Количество: " + counter);

                        Split();
                        counter = 0;
                        rbtTree.Postorder(rbtTree.rootnode,ref counter);
                        Console.WriteLine("Количество: " + counter);

                        Split();
                        counter = 0;
                        rbtTree.Symmetric(rbtTree.rootnode, ref counter);
                        Console.WriteLine("Количество: " + counter);

                        break;
                    case 9:
                        Console.WriteLine("Введите имя");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите pasId");
                        pasId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите возраст");
                        age = Convert.ToInt32(Console.ReadLine());
                        rbtTree.Insert(name, pasId, age);
                        break;
                    case 10:
                        Console.WriteLine("Введите имя");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите pasId");
                        pasId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите возраст");
                        age = Convert.ToInt32(Console.ReadLine());
                        temp = new Date(name, pasId, age);
                        rbtTree.remove(temp);
                        break;
                    case 12:
                        System.IO.File.WriteAllText(@"C:\Users\Сralve\source\repos\algoritms\lab3\lab3\tree.txt", "");
                        PrintInFileTree(tree.Root, 0);
                        break;
                    case 13:
                        tree.DeleteLeftOrRight(tree.Root.Left, 1);
                        
                        break;
                    case 14:
                        tree.DeleteLeftOrRight(tree.Root.Right, 0);
                        break;
                    case 15:
                        tree.Clear(tree.Root);
                        break;
                    case 66:
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                Split();
            }









        }
    }
}

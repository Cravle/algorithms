using lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{


    class Program
    {
        static void Main(string[] args)
        {
            //stack
            var funcStack = new OperationStack();

            //funcStack.menu();


            //queue
            var funcQueue = new OpQueue();

            //


            //deque
            var funcDeque = new OpDeq();
            while (true)
            {
                Console.WriteLine("1- Стек");
                Console.WriteLine("2- Очередь");
                Console.WriteLine("3- Дек");
                Console.WriteLine("66- Закрыть");

                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        funcStack.menu();
                        break;
                    case 2:
                        funcQueue.menu();
                        break;
                    case 3:
                        funcDeque.menu();
                        break;

                    case 66:
                        return;
                        break;
                }
            }
        }
    }
}

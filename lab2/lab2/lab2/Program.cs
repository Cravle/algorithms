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
            //var funcStack = new OperationStack();

            //funcStack.menu();


            var deq = new DuplexLinkedDeque<double>();
            deq.PushBack(1);
            deq.PushBack(3);
            deq.PushBack(2);
            deq.PushFront(4);

            foreach (var el in deq)
            {
                Console.WriteLine(el);
            }

            deq.PopBack();
            deq.PopFront();
            Console.WriteLine();

            foreach (var el in deq)
            {
                Console.WriteLine(el);
            }


            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab3
{
    public class RBTree<T>
        where T : IComparable, IComparable<T>
    {
        public RbNode<T> Root { get; private set; }
        public int Count { get; private set; }


        public void Add(string name, int pasId, int age)
        {
            Date data = new Date(name, pasId, age);

            if (Root == null)
            {
                Root = new RbNode<T>(data, null);
                Count = 1;
                return;
            }

            Root.Add(data, Root);
            Count++;
        }

        

       
    }
}

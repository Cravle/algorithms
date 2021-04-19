using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Tree<T>
        where T:IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int Count{ get; private set; }

        public void Add(string name, int pasId, int age)
        {
            Date data = new Date(name, pasId, age);

            if(Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Count++;
        }

        public List<Date> Preorder()
        {

            if (Root == null)
            {
                return new List<Date>();
            }

            return Preorder(Root);

            
        }

        public void AddByPasId(string name, int pasId, int age)
        {
            Date data = new Date(name, pasId, age);

            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.addByPasId(data);
            
        }



        private List<Date> Preorder(Node<T> node)
        {
            var list = new List<Date>();
            if(node != null)
            {
                list.Add(node.Data);

                if(node.Left != null)
                {
                    list.AddRange((IEnumerable<Date>)Preorder(node.Left));
                }

                if(node.Right != null)
                {
                    list.AddRange((IEnumerable<Date>)Preorder(node.Right));
                }

            }

            return list;
        }

        public void Preorder2(Node<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Data);
                Preorder2(node.Left);
                Preorder2(node.Right);

            }
        }

        public void Postorder(Node<T> node)
        {
            if (node != null)
            {
                Postorder(node.Left);
                Postorder(node.Right);
                Console.WriteLine(node.Data);
                

            }
        }

        public void Symmetric(Node<T> node)
        {
            if (node != null)
            {
                Symmetric(node.Left);
                Console.WriteLine(node.Data);
                Symmetric(node.Right);


            }
        }

        public int GetAverage()
        {
            int counter = 0;
            foreach (var item in Preorder())
            {
                counter += item.Age;
            }

            return counter / Count;



        }


        public void Clear(Node<T> node)
        {
            if (node != null)
            {

                Clear(node.Left);
                Clear(node.Right);
                node.Delete();
                

            }
            Root = null;
        }
        /// <summary>
        ///  1 - left| 0 -right
        /// </summary>
        /// <param name="node"></param>
        /// <param name="choice"></param>
        public void DeleteLeftOrRight(Node<T> node, int choice)
        {
            if (node != null)
            {

                DeleteLeftOrRight(node.Left, choice);
                DeleteLeftOrRight(node.Right, choice);
                node.Delete();

            }

            if (choice == 1)
            {
                Root.DeleteLeft();
                
            } else
            {
                Root.DeleteRight();
            }

            
            
        }



        





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab3
{
    public class Node<T>: IComparable<T>, IComparable
        where T: IComparable, IComparable<T>
    {
        public Date Data { get; private set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        public Node(Date data)
        {
            Data = data;
        }

        public Node(Date data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
         
        public void Add(Date data)
        {
            var node = new Node<T>(data);

            if (node.Data.CompareTo(Data.Name) == -1)
            {

                if(Left == null)
                { 
                    Left = node;
                }
                else
                {
                    Left.Add(data); 
                }
            }
            else
            {
                if(Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public void addByPasId(Date data)
        {
            var node = new Node<T>(data);

            if (node.Data.PasId.CompareTo(Data.PasId) == -1)
            {

                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.addByPasId(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.addByPasId(data);
                }
            }
        }


        public void Delete()
        {
            Left = null;
            Right = null;
        }

        public void DeleteLeft()
        {
            Left = null;
        }


        public void DeleteRight()
        {
            Right = null;
        }

        public int CompareTo(object obj)
        {
            if(obj is Node<T> item)
            {
                return Data.CompareTo(item);

            }
            else
            {
                throw new ArgumentException("Не совпадение типов");
            }
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }


        public override string ToString()
        {
            return Data.ToString();
        }
    }
}

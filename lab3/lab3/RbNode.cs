using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class RbNode<T> : IComparable<T>, IComparable
        where T : IComparable, IComparable<T>
    {
        public Date Data { get; private set; }
        public RbNode<T> Left { get; private set; }
        public RbNode<T> Right { get; private set; }

        public RbNode<T> Parent { get; private set; }

       public string Color { get; private set; }



        public RbNode(Date data, RbNode<T> parent)
        {
            Data = data;
            Color = "red";
            Parent = parent;
        }

        public RbNode(Date data, RbNode<T> left, RbNode<T> right, RbNode<T> parent)
        {
            Data = data;
            Left = left;
            Right = right;
            Parent = parent;
        }

        public void Add(Date data, RbNode<T> parent)
        {
            var node = new RbNode<T>(data, parent);

            if (node.Data.CompareTo(Data.Name) == -1)
            {

                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data, Left);
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
                    Right.Add(data, Right);
                }

            }

            Fix(parent, node);


        }

        public void RotateLeft(RbNode<T> Node, RbNode<T> Current)
        {
            RbNode<T> ptr = Current.Right;
            Current.Right = ptr.Left;
            if (ptr.Left != null) ptr.Left.Parent = Current;
            if (ptr != null) ptr.Parent = Current.Parent;
            if (Current.Parent != null)
            {
                if (Current == Current.Parent.Left)
                    Current.Parent.Left = ptr;
                else
                    Current.Parent.Right = ptr;
                
            }
            else
            {
                Node = ptr;
            }
            ptr.Left = Current;
            if (Current != null) Current.Parent = ptr;
        }

        public void RotateRight(RbNode<T> Node, RbNode<T> Current)
        {
            RbNode<T> ptr = Current.Left;
            Current.Right = ptr.Right;
            if (ptr.Right != null) ptr.Right.Parent = Current;
            if (ptr != null) ptr.Parent = Current.Parent;
            if (Current.Parent != null)
            {
                if (Current == Current.Parent.Right)
                    Current.Parent.Right = ptr;
                else
                    Current.Parent.Left = ptr;

            }
            else
            {
                Node = ptr;
            }
            ptr.Right = Current;
            if (Current != null) Current.Parent = ptr;
        }

        public void Fix(RbNode<T> Node, RbNode<T> newNode)
        {
            RbNode<T> current = newNode;
            //Проверка свойств
            while (current != Node && current.Parent.Color == "red")
            {
                //Проверка нарушений правил
                if (current.Parent == current.Parent.Parent.Left)
                {
                    RbNode<T> ptr = current.Parent.Parent.Right;
                    if (ptr.Color == "red")
                    {
                        ptr.Color = "black";
                        current.Parent.Parent.Color = "red";
                        current = current.Parent.Parent;
                    }

                    else
                    {
                        if (current == current.Parent.Parent.Right)
                        {
                            //Сделать Current левым потомком
                            current = current.Parent;
                            RotateLeft(Node, current);
                            //Перекрасить и повернуть
                            current.Parent.Color = "black";
                            current.Parent.Parent.Color = "red";
                            RotateRight(Node, current.Parent.Parent);
                        }
                    }
                }
                else
                {
                    RbNode<T> ptr = current.Parent.Parent.Left;
                    if(ptr.Color == "red")
                    {
                        current.Parent.Color = "black";
                        ptr.Color = "black";
                        current.Parent.Parent.Color = "red";
                        current = current.Parent.Parent;
                    }
                    else
                    {
                        if(current == current.Parent.Left)
                        {
                            current = current.Parent;
                            RotateRight(Node, current);
                        }
                        current.Parent.Color = "black";
                        current.Parent.Parent.Color = "red";
                        RotateLeft(Node, current.Parent.Parent);
                    }
                }


            }
            Node.Color = "black";
        }

        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
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
            return $"{Color} " + Data.ToString();
        }
    }
}

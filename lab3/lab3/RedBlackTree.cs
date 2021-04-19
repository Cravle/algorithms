using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class RBTree
    {
        public RBTreeNode rootnode;
        public int Count { get; set; }

        public void Insert(string name, int pasId, int age)
        {
            Date item = new Date(name, pasId, age);
            if (rootnode == null)
            {
                rootnode = new RBTreeNode(item, Color.black);
                Count = 1;
            }
            else
            {
                var newnode = Inserts(item);
                InsertFixUp(newnode);
                Count++;
            }
        }
        public RBTreeNode Inserts(Date item)
        {
            var node = rootnode;
            var newnode = new RBTreeNode(item, Color.red);
            while (true)
            {
                if (item.CompareTo(node.key.Name) == 1)
                {
                    if (node.right == null)
                    {
                        
                        newnode.parent = node;
                        node.right = newnode;
                        break;
                    }
                    node = node.right;
                }
                else if (item.CompareTo(node.key.Name) == -1)
                {
                    if (node.left == null)
                    {
                        newnode.parent = node;
                        node.left = newnode;
                        break;
                    }
                    node = node.left;
                }
            }
            return newnode;
        }

        
        public void InsertFixUp(RBTreeNode node)
        {
            var parentnode = node.parent;
            if (parentnode != null && parentnode.color == Color.red)
            {
                var gparent = parentnode.parent;

                if (parentnode == gparent.left)
                {
                    var unclenode = gparent.right;
                    if (unclenode != null && unclenode.color == Color.red)
                    {
                        setRed(gparent);
                        setBlack(parentnode);
                        setBlack(unclenode);
                        InsertFixUp(gparent);
                    }
                    else
                    {
                        if (node == parentnode.left)
                        {
                            setBlack(parentnode);
                            setRed(gparent);
                            Rightrotate(gparent);
                        }
                        else if (node == parentnode.right)
                        {
                            LeftRotate(parentnode);
                            InsertFixUp(parentnode);
                        }
                    }
                }
                else
                {
                    var unclenode = gparent.left;
                    if (unclenode != null && unclenode.color == Color.red)
                    {
                        setBlack(parentnode);
                        setBlack(unclenode);
                        setRed(gparent);
                        InsertFixUp(gparent);
                    }
                    else
                    {
                        if (node == parentnode.right)
                        {
                            setBlack(parentnode);
                            setRed(gparent);
                            LeftRotate(gparent);
                        }
                        else if (node == parentnode.left)
                        {
                            Rightrotate(parentnode);
                            InsertFixUp(parentnode);
                        }
                    }
                }
            }
            setBlack(rootnode);
        }

        public RBTreeNode find(Date key)
        {
            RBTreeNode current = rootnode;
            while (current.key != key)
            {
                if (current.key.CompareTo(key.Name) == 0)
                    return current;
                if (current.key.CompareTo(key.Name) == 1 )
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
                if (current == null)
                {
                    return null;
                }
            }
            return current;
        }

        public bool remove(Date key)
        {
            RBTreeNode node;
            node = find(key);
            if (node == null)
            {
                return false;
            }
            RBTreeNode child, parent;
            Count--;
            Color color;
            if (node.left == null && node.right == null)
            {//No child nodes
                if (node == rootnode)
                {
                    rootnode = null;
                    return true;
                }
                if (node.parent.left == node)
                {
                    node.parent.left = null;
                }
                else
                {
                    node.parent.right = null;
                }
                return true;
            }
            if ((node.left != null) && (node.right != null))
            {//There are two child nodes
                //1. Get subsequent nodes
                RBTreeNode replace = node;
                replace = replace.right;
                while (replace.left != null)
                {
                    replace = replace.left;
                }
                //2. Connect parent node and successor node
                if (node.parent != null)
                {
                    if (node == node.parent.left)
                    {
                        node.parent.left = replace;
                    }
                    else
                    {
                        node.parent.right = replace;
                    }
                }
                else
                {//If it is the root node
                    rootnode = replace;
                }
                //3. Dealing with relationship issues
                child = replace.right;
                parent = replace.parent;
                color = replace.color;
                if (parent == node)
                {//The successor is the child node of the deleted node
                    parent = replace;
                }
                else
                {
                    if (child != null)
                    {
                        child.parent = parent;
                    }
                    parent.left = child;
                    replace.right = node.right;
                    node.right.parent = replace;
                }
                replace.parent = node.parent;
                replace.color = node.color;
                replace.left = node.left;
                node.left.parent = replace;
                //4. The subsequent node is black, then the red-black tree needs to be corrected
                if (color == Color.black)
                {
                    removeFix(child, parent);
                }
                node = null;
                return true;
            }
            else
            {
                if (node.left == null)
                {
                    if (node == rootnode)
                    {
                        rootnode = node.right;
                        node.parent = null;
                        return true;
                    }
                    if (node.parent.left == node)
                    {
                        node.parent.left = node.right;

                    }
                    else
                    {
                        node.parent.right = node.right;
                    }
                    node.right.parent = node.parent;
                    if (node.color == Color.black)
                    {
                        removeFix(node.right, node.right.parent);
                    }
                    node = null;
                }
                else
                {
                    if (node == rootnode)
                    {
                        rootnode = node.left;
                        node.parent = null;
                        return true;
                    }
                    if (node.parent.left == node)
                    {
                        node.parent.left = node.left;
                    }
                    else
                    {
                        node.parent.right = node.left;
                    }
                    node.left.parent = node.parent;
                    if (node.color == Color.black)
                    {
                        removeFix(node.left, node.left.parent);
                    }
                    node = null;
                }
                return true;
            }

        }

        private void removeFix(RBTreeNode node, RBTreeNode parent)
        {
            RBTreeNode other;
            while ((node == null || node.color == Color.black) && node != rootnode)
            {
                if (parent.left == node)
                {//One, node is the left child node
                    other = parent.right;
                    if (other.color != Color.black)
                    {//1.node's sibling node other is red
                        other.color = Color.black;
                        parent.color = Color.red;
                        LeftRotate(parent);
                        other = parent.right;
                    }
                    if ((other.left == null || other.left.color == Color.black) && (other.right == null || other.right.color == Color.black))
                    {//2. The sibling node other of node is black, and the two child nodes of other are also black
                        other.color = Color.red;
                        node = parent;
                        parent = node.parent;
                    }
                    else
                    {//3. The sibling node other of node is black, and the left child node of other is red, and the right child node is black
                        if (other.right == null || other.right.color == Color.black)
                        {
                            other.left.color = Color.black;
                            other.color = Color.red;
                            Rightrotate(other);
                            other = parent.right;
                        }
                        //4. The sibling node of node is black, and the right child node of other is red, and the left child node is any color
                        other.color = parent.color;
                        parent.color = Color.black;
                        other.right.color = Color.black;
                        LeftRotate(parent);
                        node = this.rootnode;
                        break;
                    }
                }
                else
                {
                    other = parent.left;
                    if (other.color == Color.red)
                    {
                        other.color = Color.black;
                        parent.color = Color.red;
                        Rightrotate(parent);
                        other = parent.left;
                    }
                    if ((other.left == null || other.left.color == Color.black) && (other.right == null || other.right.color == Color.black))
                    {
                        other.color = Color.red;
                        node = parent;
                        parent = node.parent;
                    }
                    else
                    {
                        if (other.left == null || other.left.color == Color.black)
                        {
                            other.right.color = Color.black;
                            other.color = Color.red;
                            LeftRotate(other);
                            other = parent.left;
                        }
                        other.color = parent.color;
                        parent.color = Color.black;
                        other.left.color = Color.black;
                        Rightrotate(parent);
                        node = rootnode;
                        break;
                    }
                }
            }
            if (node != null)
            {
                node.color = Color.black;
            }
        }

        public void Preorder2(RBTreeNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node);
                Preorder2(node.left);
                Preorder2(node.right);

            }
        }

        public void Postorder(RBTreeNode node)
        {
            if (node != null)
            {
                Postorder(node.left);
                Postorder(node.right);
                Console.WriteLine(node);


            }
        }

        public void Symmetric(RBTreeNode node)
        {
            if (node != null)
            {
                Symmetric(node.left);
                Console.WriteLine(node);
                Symmetric(node.right);


            }
        }


        private void LeftRotate(RBTreeNode node)
        {
            var temp = node.right;
            node.right = temp.left;
            if (temp.left != null)
            {
                temp.left.parent = node;
            }
            temp.parent = node.parent;
            if (node.parent == null)
            {
                rootnode = temp;
            }
            else
            {
                if (node == node.parent.left)
                {
                    node.parent.left = temp;
                }
                else
                {
                    node.parent.right = temp;
                }
            }
            temp.left = node;
            node.parent = temp;

        }

        private void Rightrotate(RBTreeNode node)
        {
            var temp = node.left;
            node.left = temp.right;
            if (temp.right != null)
            {
                temp.right.parent = node;
            }
            temp.parent = node.parent;
            if (node.parent == null)
            {
                rootnode = temp;
            }
            else
            {
                if (node == node.parent.left)
                {
                    node.parent.left = temp;
                }
                else if (node == node.parent.right)
                {
                    node.parent.right = temp;
                }
            }
            temp.right = node;
            node.parent = temp;
        }

        public void setBlack(RBTreeNode node)
        {
            node.color = Color.black;
        }

        public void setRed(RBTreeNode node)
        {
            node.color = Color.red;
        }

        

    }
}

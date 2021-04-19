namespace lab3
{
    public enum Color
    {
        red, black
    }

    public class RBTreeNode
    {
        public Date key;
        public RBTreeNode left;
        public RBTreeNode right;
        public Color color;

        public RBTreeNode parent;
        public RBTreeNode(Date item, Color color)
        {
            key = item;
            left = null;
            right = null;
            this.color = color;
        }
        public override string ToString()
        {
            return key + "（" + color.ToString() + ")";
        }
    }
}

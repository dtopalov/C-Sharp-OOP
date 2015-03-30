namespace _06.BST
{
    using System;

    public class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode(T value)
        {
            Data = value;
        }

        public T Data
        {
            get;
            set;
        }

        public TreeNode<T> Left;

        public TreeNode<T> Right;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

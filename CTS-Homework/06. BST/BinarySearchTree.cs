namespace _06.BST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public int Count { get; set; }

        public void Insert(T value)
        {
            var node = new TreeNode<T>(value);

            Insert(node);
        }

        public void Insert(TreeNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }

            if (root == null)
            {
                root = node;
            }
            else
            {
                Insert(node, ref root);
            }

            Count++;
        }

        public void Delete(T value, bool rebalanceTree)
        {
            TreeNode<T> parentNode;
            TreeNode<T> foundNode = null;
            TreeNode<T> tree = parentNode = root;

            while (tree != null)
            {
                if (value.CompareTo(tree.Data) == 0)
                {
                    foundNode = tree;
                    break;
                }
                else if (value.CompareTo(tree.Data) < 0)
                {
                    parentNode = tree;
                    tree = tree.Left;
                }
                else if (value.CompareTo(tree.Data) > 0)
                {
                    parentNode = tree;
                    tree = tree.Right;
                }
            }

            if (foundNode == null)
            {
                throw new Exception("Node not found");
            }


            bool leftOrRightNode = foundNode != parentNode.Left;

            if (foundNode == parentNode)
            {
                if (rebalanceTree)
                {
                    IList<TreeNode<T>> listOfNodes = new List<TreeNode<T>>();

                    FillListInOrder(root, listOfNodes);
                    RemoveChildren(listOfNodes);
                    listOfNodes.Remove(parentNode);

                    root = null;
                    int count = Count - 1;
                    Count = 0;

                    BalanceTree(0, count - 1, listOfNodes);
                }
                else
                {
                    TreeNode<T> leftMost = FindLeftMost(parentNode.Right, true);

                    if (leftMost != null)
                    {
                        leftMost.Left = parentNode.Left;
                        leftMost.Right = parentNode.Right;
                        root = leftMost;
                    }
                }
            }
            else if (foundNode.Left == null && foundNode.Right == null) //This is a leaf node
            {
                //Just set it to null
                if (leftOrRightNode)
                {
                    parentNode.Right = null;
                }
                else
                {
                    parentNode.Left = null;
                }
            }
            else if (foundNode.Left != null && foundNode.Right != null) //This is a node with two children
            {
                if (leftOrRightNode)
                {
                    parentNode.Right = foundNode.Right;
                    parentNode.Right.Left = foundNode.Left;
                }
                else
                {
                    parentNode.Left = foundNode.Right;
                    parentNode.Left.Left = foundNode.Left;
                }
            }

            else if (foundNode.Left != null || foundNode.Right != null) //This is a node with a single child
            {
                if (foundNode.Left != null)
                {
                    if (leftOrRightNode)
                    {
                        parentNode.Right = foundNode.Left;
                    }
                    else
                    {
                        parentNode.Left = foundNode.Left;
                    }
                }
                else
                {
                    if (leftOrRightNode)
                    {
                        parentNode.Right = foundNode.Right;
                    }
                    else
                    {
                        parentNode.Left = foundNode.Right;
                    }
                }
            }
        }

        private TreeNode<T> FindLeftMost(TreeNode<T> node, bool setParentToNull)
        {
            TreeNode<T> leftMost = null;
            TreeNode<T> current = leftMost = node;
            TreeNode<T> parent = null;

            while (current != null)
            {
                if (current.Left != null)
                {
                    parent = current;
                    leftMost = current.Left;
                }

                current = current.Left;
            }

            if (parent != null && setParentToNull)
            {
                parent.Left = null;
            }

            return leftMost;
        }

        public TreeNode<T> Search(T value)
        {
            TreeNode<T> tree = root;

            while (tree != null)
            {
                if (value.CompareTo(tree.Data) == 0)
                {
                    return tree;
                }
                else if (value.CompareTo(tree.Data) < 0)
                {
                    tree = tree.Left;
                }
                else if (value.CompareTo(tree.Data) > 0)
                {
                    tree = tree.Right;
                }
            }

            return null;
        }

        public IEnumerable<TreeNode<T>> BreadthFirstTraversal()
        {
            var queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode<T> current = queue.Dequeue();

                if (current != null)
                {
                    queue.Enqueue(current.Left);
                    queue.Enqueue(current.Right);

                    yield return current;
                }
            }
        }

        public IEnumerable<TreeNode<T>> DepthFirstTraversal()
        {
            var queue = new Stack<TreeNode<T>>();

            queue.Push(root);

            while (queue.Count != 0)
            {
                TreeNode<T> current = queue.Pop();

                if (current != null)
                {
                    queue.Push(current.Right);
                    queue.Push(current.Left);

                    yield return current;
                }
            }
        }

        public void BalanceTree()
        {
            IList<TreeNode<T>> listOfNodes = new List<TreeNode<T>>();

            FillListInOrder(root, listOfNodes);
            RemoveChildren(listOfNodes);

            root = null;
            int count = this.Count;
            this.Count = 0;

            BalanceTree(0, count - 1, listOfNodes);
        }

        private void Insert(TreeNode<T> node, ref TreeNode<T> parent)
        {
            if (parent == null)
            {
                parent = node;
            }
            else
            {
                if (node.Data.CompareTo(parent.Data) < 0)
                {
                    Insert(node, ref parent.Left);
                }
                else if (node.Data.CompareTo(parent.Data) > 0)
                {
                    Insert(node, ref parent.Right);
                }
                else if (node.Data.CompareTo(parent.Data) == 0)
                {
                    throw new ArgumentException("Duplicate node");
                }
            }
        }

        private void BalanceTree(int min, int max, IList<TreeNode<T>> list)
        {
            if (min <= max)
            {
                var middleNode = (int)Math.Ceiling(((double)min + max) / 2);

                if (list.Count > middleNode) Insert(list[middleNode]);

                BalanceTree(min, middleNode - 1, list);

                BalanceTree(middleNode + 1, max, list);
            }
        }

        private void FillListInOrder(TreeNode<T> node, ICollection<TreeNode<T>> list)
        {
            if (node != null)
            {
                FillListInOrder(node.Left, list);

                list.Add(node);

                FillListInOrder(node.Right, list);
            }
        }

        private void RemoveChildren(IEnumerable<TreeNode<T>> list)
        {
            foreach (TreeNode<T> node in list)
            {
                node.Left = null;
                node.Right = null;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var item in this.DepthFirstTraversal())
            {
                result.Append(item.Data);
                result.Append(" ");
            }
            result.Length--;

            return result.ToString();
        }

        public override int GetHashCode()
        {
            return this.root.GetHashCode() ^ this.root.Data.GetHashCode() ^ this.Count.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherTree = obj as BinarySearchTree<T>;
            if (this.Count != otherTree.Count)
            {
                return false;
            }

            var arr1 = this.DepthFirstTraversal().ToArray();
            var arr2 = otherTree.DepthFirstTraversal().ToArray();

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].Data.CompareTo(arr2[i].Data) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator ==(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
        {
            return tree1.Equals(tree2);
        }

        public static bool operator !=(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
        {
            return !tree1.Equals(tree2);
        }

        /// <summary>Traverses and prints the tree in
        /// Depth-First Search (DFS) manner</summary>
        public void TraverseDFS()
        {
            this.PrintDFS(this.root, string.Empty);
        }

        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Data);

            TreeNode<T> child = null;
            if (root.Left != null)
            {
                child = root.Left;
                PrintDFS(child, spaces + "   ");    
            }
            if (root.Right != null)
            {
                child = root.Right;
                PrintDFS(child, spaces + "   ");   
            }
        }

        public object Clone()
        {
            if (this.root == null)
            {
                return null;
            }

            var clone = new BinarySearchTree<T>();

            clone.Insert((TreeNode<T>)this.root.Clone());

            if (this.root.Left != null && clone.Search(this.root.Left.Data) == null)
            {
                clone.Insert((TreeNode<T>)this.root.Left.Clone());
            }

            if (this.root.Right != null && clone.Search(this.root.Right.Data) == null)
            {
                clone.Insert((TreeNode<T>)this.root.Right.Clone());
            }

            return clone;
        } 
    }
}

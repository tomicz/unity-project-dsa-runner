using System;
using TOMICZ.Debugger;

namespace TOMICZ.DSARunner.Trees
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public class TreeNode
        {
            public T value;

            public TreeNode left;
            public TreeNode right;

            public TreeNode(T value)
            {
                this.value = value;
            }

            public TreeNode(T value, TreeNode left, TreeNode right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode root;

        public void Insert(T value)
        {
            if(root == null)
            {
                root = new TreeNode(value);
            }

            var current = root;

            if (value.CompareTo(root.value) < 0)
            {
                current.left = new TreeNode(value);
                current = current.left;
            }
            else if(value.CompareTo(root.value) > 0)
            {
                current.right = new TreeNode(value);
                current = current.right;
            }
        }
    }
}
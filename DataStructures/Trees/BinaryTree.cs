using System;
using System.Collections.Generic;
using TOMICZ.Debugger;

namespace TOMICZ.DSARunner.Trees
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public enum TraversalType
        {
            LevelOrder,
            PreOrder,
            InOrder,
            PostOrder
        }

        public class Node
        {
            public T value;

            public Node left;
            public Node right;

            public Node(T value)
            {
                this.value = value;
            }

            public Node(T value, Node left, Node right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }

        public Node root;

        public void Insert(T value)
        {
            if(root == null)
            {
                root = new Node(value);
                return;
            }

            var current = root;

            while(current != null)
            {
                if (value.CompareTo(root.value) < 0)
                {
                    if(current.left == null)
                    {
                        current.left = new Node(value);
                        return;
                    }

                    current = current.left;
                }
                if (value.CompareTo(root.value) > 0)
                {
                    if(current.right == null)
                    {
                        current.right = new Node(value);
                        return;
                    }

                    current = current.right;
                }
            }
        }

        public void Traverse(TraversalType traversalType)
        {
            switch (traversalType)
            {
                case TraversalType.LevelOrder:
                    LevelOrder();
                    break;
                case TraversalType.PreOrder:
                    RuntimeConsole.Log("Preorder traversal not added.");
                    break;
                case TraversalType.InOrder:
                    RuntimeConsole.Log("Inorder traversal not added.");
                    break;
                case TraversalType.PostOrder:
                    RuntimeConsole.Log("Postorder traversal not added.");
                    break;
            }
        }

        private void LevelOrder()
        {
            if(root == null)
            {
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node tempNode = queue.Dequeue();
                RuntimeConsole.Log($"Node value: {tempNode.value}");

                if (tempNode.left != null)
                {
                    queue.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    queue.Enqueue(tempNode.right);
                }
            }
        }
    }
}
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

        public int Count { get; private set; }

        public void Insert(T value)
        {
            if(root == null)
            {
                root = new Node(value);
                Count++;
                return;
            }

            Node currentNode = root;

            while(true)
            {
                if (value.CompareTo(currentNode.value) < 0)
                {
                    if(currentNode.left == null)
                    {
                        currentNode.left = new Node(value);
                        Count++;
                        return;
                    }

                    currentNode = currentNode.left;
                }
                if (value.CompareTo(currentNode.value) > 0)
                {
                    if(currentNode.right == null)
                    {
                        currentNode.right = new Node(value);
                        Count++;
                        return;
                    }

                    currentNode = currentNode.right;
                }
            }
        }

        public Node Find(T value)
        {
            if(root == null)
            {
                return null;
            }

            if(root != null && root.Equals(value))
            {
                return root;
            }

            Node currentNode = root;

            while(currentNode != null)
            {
                if (value.CompareTo(currentNode.value) < 0)
                {
                    currentNode = currentNode.left;
                }
                if (value.CompareTo(currentNode.value) > 0)
                {
                    currentNode = currentNode.right;
                }

                if (value.Equals(currentNode.value))
                {
                    return currentNode;
                }
                else
                {
                    throw new Exception($"Node of value {value} does not exist in current tree.");
                }
            }

            throw new Exception($"Node of value {value} does not exist in current tree.");
        }

        public void Traverse(TraversalType traversalType)
        {
            switch (traversalType)
            {
                case TraversalType.LevelOrder:
                    TraverseLevelOrder();
                    break;
                case TraversalType.PreOrder:
                    RuntimeConsole.Log("Preorder traversal not added.");
                    break;
                case TraversalType.InOrder:
                    TraverseInorder();
                    break;
                case TraversalType.PostOrder:
                    RuntimeConsole.Log("Postorder traversal not added.");
                    break;
            }
        }

        public int GetHeight()
        {
            if(root == null)
            {
                return -1;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            int height = -1;

            while(q.Count > 0)
            {
                int size = q.Count;

                height++;

                while (size > 0)
                {
                    Node tempNode = q.Dequeue();
                    RuntimeConsole.Log(tempNode.value.ToString());

                    if(tempNode.left != null)
                    {
                        q.Enqueue(tempNode.left);
                    }
                    if(tempNode.right != null)
                    {
                        q.Enqueue(tempNode.right);
                    }

                    size--;
                }
            }

            return height;
        }

        public bool IsInTree(T value)
        {
            if(root == null)
            {
                return false;
            }

            var currentNode = root;

            while (currentNode != null)
            {
                if (IsEqual(value, currentNode.value))
                {
                    return true;
                }

                if (IsLessThan(value, currentNode.value))
                {
                    currentNode = currentNode.left;
                }

                if (IsGreaterThan(value, currentNode.value))
                {
                    currentNode = currentNode.right;
                }
            }

            return false;
        }

        public void DeleteTree() => root = null;

        public T GetMin()
        {
            if(root == null)
            {
                return default;
            }

            Node currentNode = root;
            T minValue = default;

            while(currentNode != null)
            {
                minValue = currentNode.value;
                currentNode = currentNode.left;
            }

            return minValue;
        }

        public T GetMax()
        {
            if (root == null)
            {
                return default;
            }

            Node currentNode = root;
            T maxValue = default;

            while (currentNode != null)
            {
                maxValue = currentNode.value;
                currentNode = currentNode.right;
            }

            return maxValue;
        }

        private bool IsLessThan(T valueA, T valueB) => valueA.CompareTo(valueB) < 0;

        private bool IsGreaterThan(T valueA, T valueB) => valueA.CompareTo(valueB) > 0;

        private bool IsEqual(T valueA, T valueB) => valueA.Equals(valueB);

        private void TraverseLevelOrder()
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

        private void TraverseInorder()
        {
            if(root == null)
            {
                return;
            }

            Stack<Node> stack = new Stack<Node>();
            Node currentNode = root;

            while(currentNode != null || stack.Count > 0)
            {
                while(currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();
                RuntimeConsole.Log($"Node value: {currentNode.value}");
                currentNode = currentNode.right;
            }
        }
    }
}
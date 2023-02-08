using System;
using TOMICZ.Debugger;

namespace TOMICZ.DSARunner.LinkedLists
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public int Length { get; private set; }

        /// <summary>
        /// Add a new node to the end of linked list.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value, null);

            if(Head == null)
            {
                Head = newNode;
                Tail = Head;
                Length++;

                return;
            }

            Tail.Next = newNode;
            Tail = Tail.Next;
            Length++;
        }

        /// <summary>
        /// Adds a new node to the beginning of the list.
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value, null);

            if(Head == null)
            {
                Head = newNode;
                Length++;
                return;
            }

            newNode.Next = Head;
            Head = newNode;
            Length++;
        }

        /// <summary>
        /// Returns node value by an index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetValueAt(int index)
        {
            int currentIndex = -1;
            Node<T> currentNode = Head;

            while(currentNode != null)
            {
                currentIndex++;

                if(currentIndex == index)
                {
                    return currentNode.Value;
                }

                currentNode = currentNode.Next;
            }

            throw new IndexOutOfRangeException("Index out of range");
        }

        /// <summary>
        /// Removes first node in a list;
        /// </summary>
        /// <returns></returns>
        public Node<T> PopFront()
        {
            var tempNode = Head;
            Head = Head.Next;
            Length--;
            return tempNode;
        }

        /// <summary>
        /// Removes last node in a list.
        /// </summary>
        /// <returns></returns>
        public Node<T> PopLast()
        {
            if(Head == null)
            {
                return null;
            }

            if(Head == Tail)
            {
                Tail = null;
                Head = null;
                Length--;
                return null;
            }

            var currentNode = Head;

            while(currentNode != null)
            {
                if(currentNode.Next == Tail)
                {
                    var tempNode = Tail;
                    currentNode.Next = null;
                    Tail = currentNode;
                    Length--;
                    return tempNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        /// <summary>
        /// Inserts new value to the list by an index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            int currentIndex = -1;

            if(Head == null)
            {
                AddLast(value);
                return;
            }

            var currentNode = Head;

            if (currentNode.Next == null)
            {
                AddLast(value);
                return;
            }

            while (currentNode.Next != null)
            {
                currentIndex++;

                if(currentIndex == index)
                {
                    var tempValue = currentNode.Next;
                    currentNode.Next = new Node<T>(value, tempValue);
                    Length++;
                    return;
                }

                currentNode = currentNode.Next;
            }

            AddLast(value);
        }

        /// <summary>
        /// Removes value by an index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAtIndex(int index)
        {
            int currentIndex = 0;

            if(Head.Next == null)
            {
                PopFront();
                return;
            }

            var currentNode = Head;

            while(currentNode.Next.Next != null)
            {
                currentIndex++;

                if(index == 0)
                {
                    PopFront();
                    return;
                }

                if (currentIndex == index)
                {
                    currentNode.Next = currentNode.Next.Next;
                    Length--;

                    return;
                }

                currentNode = currentNode.Next;
            }

            currentIndex++;

            if(currentIndex == index)
            {
                PopLast();
            }
        }

        /// <summary>
        /// Removes existing value. If value is not found, then returns null;
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            if(Head == null)
            {
                return;
            }

            if (Head.Equals(value))
            {
                PopFront();
                return;
            }

            if(Head.Next == null)
            {
                return;
            }

            var currentNode = Head;

            while(currentNode.Next.Next != null)
            {
                if(currentNode.Next.Equals(value))
                {
                    currentNode.Next = currentNode.Next.Next;
                    Length--;
                    return;
                }

                currentNode = currentNode.Next;
            }

            if (currentNode.Next.Equals(value))
            {
                PopLast();
            }
        }

        /// <summary>
        /// Reverses list;
        /// </summary>
        public void Reverse()
        {
            Node<T> prev = null;

            while(Head != null)
            {
                var temp = Head.Next;
                Head.Next = prev;
                prev = Head;
                Head = temp;
            }

            Head = prev;
        }

        /// <summary>
        /// Checks if list is empty or not.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Length == 0;
            }
        }

        public void PrintValues(LinkedList<T> linkedList)
        {
            int currentIndex = -1;
            var current = linkedList.Head;

            while (current != null)
            {
                currentIndex++;
                RuntimeConsole.Log($"Index: {currentIndex}, Value: {current.Value}");
                current = current.Next;
            }
        }
    }
}
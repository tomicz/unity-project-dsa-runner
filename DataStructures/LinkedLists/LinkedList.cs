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
        public void Append(T value)
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

        public void Prepend(T value)
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

        public Node<T> PopFront()
        {
            var tempNode = Head;
            Head = Head.Next;
            Length--;
            return tempNode;
        }

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

        public void Insert(int index, T value)
        {
            int currentIndex = -1;

            if(Head == null)
            {
                RuntimeConsole.Log("0");
                Append(value);
                return;
            }

            var currentNode = Head;

            if (currentNode.Next == null)
            {
                RuntimeConsole.Log("1");
                Append(value);
                return;
            }

            while (currentNode.Next != null)
            {
                currentIndex++;

                if(currentIndex == index)
                {
                    RuntimeConsole.Log("2");
                    var tempValue = currentNode.Next;
                    currentNode.Next = new Node<T>(value, tempValue);
                    Length++;
                    return;
                }

                currentNode = currentNode.Next;
            }

            RuntimeConsole.Log("3");
            Append(value);
        }

        public void Remove(int index)
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
                    var previousNode = currentNode;
                    var nextNode = currentNode.Next.Next;

                    RuntimeConsole.Log($"Removed node at index: {currentIndex} of value: {currentNode.Next.Value}");

                    previousNode.Next = nextNode;
                    Length--;

                    return;
                }

                currentNode = currentNode.Next;
            }

            PopLast();
        }

        public bool IsEmpty
        {
            get
            {
                return Length == 0;
            }
        }
    }
}
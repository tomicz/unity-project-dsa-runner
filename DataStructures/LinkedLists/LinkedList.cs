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
            int currentIndex = 0;
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

        public bool IsEmpty
        {
            get
            {
                if(Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
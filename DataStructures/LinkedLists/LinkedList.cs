using TOMICZ.Debugger;

namespace TOMICZ.DSARunner.LinkedLists
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public int Length { get; private set; }

        public LinkedList(T value)
        {
            Head = new Node<T>(value, null);
            Tail = Head;
            Length = 1;
        }

        /// <summary>
        /// Add a new node to the end of linked list.
        /// </summary>
        /// <param name="value"></param>
        public void Append(T value)
        {
            Node<T> newNode = new Node<T>(value, null);
            Tail.Next = newNode;
            Tail = Tail.Next;
            Length++;
        }

        public void Prepend(T value)
        {
            Node<T> newNode = new Node<T>(value, null);

            newNode.Next = Head;
            Head = newNode;
            Length++;
        }
    }
}
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
            Node<T> node = new Node<T>(value, null);
            Tail.Next = node;
            Length++;
        }
    }
}
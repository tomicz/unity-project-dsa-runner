using System.Collections.Generic;

namespace TOMICZ.DSARunner.LinkedLists
{
    public class LinkedListProblems
    {
        /// <summary>
        /// Is Palindrome
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(Node<int> head)
        {
            if(head == null)
            {
                return false;
            }

            Stack<int> stack = new Stack<int>();
            var current = head;

            while(current != null)
            {
                stack.Push(current.Value);
                current = current.Next;
            }

            current = head;

            while(current != null)
            {
                if(current.Value != stack.Peek() || stack.Count == 0)
                {
                    return false;
                }

                stack.Pop();
                current = current.Next;
            }

            return true;
        }

        public Node<int> DeleteDuplicates(Node<int> head)
        {
            var dummy = new Node<int>(-1, null);
            var current = dummy;

            while(head != null)
            {
                if(current.Value != head.Value)
                {
                    current.Next = new Node<int>(head.Value, null);
                    current = current.Next;
                }
                head = head.Next;
            }

            return dummy.Next;
        }
    }
}
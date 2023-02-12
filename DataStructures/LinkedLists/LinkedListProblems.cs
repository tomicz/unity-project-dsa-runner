using System.Collections.Generic;
using TOMICZ.Debugger;

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
                RuntimeConsole.Log($"C: {current.Value}, HV: {head.Value}");
                if(current.Value != head.Value)
                {
                    current.Next = new Node<int>(head.Value, null);
                    current = current.Next;
                }
                head = head.Next;
            }

            return dummy.Next;
        }

        public Node<int> AddTwoNumbers(Node<int> l1, Node<int> l2)
        {
            Node<int> dummy = new Node<int>(-1, null);
            Node<int> current = dummy;

            int carry = 0;

            while(l1 != null || l2 != null)
            {
                int sumA = l1 == null ? 0 : l1.Value;
                int sumB = l2 == null ? 0 : l2.Value;

                int sum = sumA + sumB + carry;
                carry = sum / 10;
                int reminder = sum % 10;

                Node<int> tempNode = new Node<int>(reminder, null);
                current.Next = tempNode;

                if(l1 != null)
                {
                    l1 = l1.Next;
                }
                if(l2 != null)
                {
                    l2 = l2.Next;
                }

                current = current.Next;
            }

            if(carry > 0)
            {
                current.Next = new Node<int>(1, null);
                current = current.Next;
            }

            return dummy.Next;
        }
    }
}
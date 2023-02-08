using System;
using System.Collections.Generic;

namespace TOMICZ.DSARunner.LinkedLists
{
    public class Node<T> : IEquatable<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

        public bool Equals(T other)
        {
            return EqualityComparer<T>.Default.Equals(Value, other);
        }
    }
}
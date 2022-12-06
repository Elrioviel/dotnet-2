using System;

namespace BinaryTree
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> LeftNode { get; set; }

        public Node(T value)
        {
            Data = value;
        }

        public int CompareTo(Node<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}

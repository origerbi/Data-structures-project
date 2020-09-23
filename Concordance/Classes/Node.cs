using System;
using System.Text;

namespace Concordance.Classes
{
    class Node<T>
    {
        // Properties
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        // Constructors
        public Node()
        {
            Data = default;
            Next = null;
        }
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
﻿using System;
//using System.Collections.Generic;
using System.Text;

namespace Concordance.Classes
{
    class Node<T>
    {
        // Fields
        private T data;
        private Node<T> next;

        // Properties
        public T Data { get; private set; }
        public Node<T> Next { get; set; }

        // Constructors
        public Node()
        {
            Data = default(T);
            Next = null;
        }
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}

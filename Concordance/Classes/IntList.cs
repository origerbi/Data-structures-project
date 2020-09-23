using System;
using System.Text;

namespace Concordance.Classes
{
    class IntList
    {
        // Properties
        public Node<int> Head { get; private set; }
        public Node<int> Tail { get; private set; }
        public int Count { get; private set; }

        // Constructors
        public IntList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public IntList(int[] arr)
        {
            foreach (int item in arr)
                Add(item);
        }

        // Methods
        public void Add(int data)
        {
            Node<int> newNode = new Node<int>(data);

            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = Tail.Next;
            }
            Count++;
        }
        public int IndexOf(int data)
        {
            Node<int> trav = Head;
            int index = 0;

            while (trav != null)
            {
                if (trav.Data.Equals(data))
                    return index;

                index++;
                trav = trav.Next;
            }

            return -1;
        }
        public bool Contains(int data) { return IndexOf(data) != -1; }
        public int[] ToArray()
        {
            int[] arr = new int[Count];
            int index = 0;
            Node<int> trav = Head;

            while (trav != null)
            {
                arr[index++] = trav.Data;
                trav = trav.Next;
            }

            return arr;
        }
        public override string ToString()
        {
            Node<int> trav = Head;
            string str = string.Empty;

            while (trav != null)
            {
                str += trav.Data + "->";
                trav = trav.Next;
            }
            str = str.Remove(str.Length - 2, 2); // Removes the last -> in the string

            return str;
        }
    }
}
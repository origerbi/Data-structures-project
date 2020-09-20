using System;
using System.Text;

namespace Concordance.Classes
{
    class IntList
    {
        // Properties
        public Node<int> Head { get; private set; }
        public Node<int> Current { get; private set; }
        public int Count { get; private set; }

        // Constructors
        public IntList()
        {
            Head = null;
            Current = null;
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
                Current = newNode;
            }
            else
            {
                Current.Next = newNode;
                Current = Current.Next;
            }
            Count++;
        }

        public int IndexOf(int data)
        {
            Node<int> trav = Head;
            int index = 0;

            while (trav.Next != null)
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
            string list = string.Empty;

            while (trav != null)
            {
                list += trav.Data + " -> ";
                trav = trav.Next;
            }
            list += "|";

            return list;
        }
    }
}

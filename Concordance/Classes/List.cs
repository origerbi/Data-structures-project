using System;
//using System.Collections.Generic;
using System.Text;

namespace Concordance.Classes
{
    class List<T>
    {
        // Fields
        private Node<T> head;
        private Node<T> current;  // This node looks on the last node in the list
        private int count;

        // Properties
        public Node<T> Head { get; private set; }
        public Node<T> Current { get; private set; }
        public int Count { get; private set; }

        // Constructors
        public List()
        {
            Head = null;
            Current = null;
            Count = 0;
        }
        public object this[int i]
        {
            get { return ToArray()[i]; }
            set { ToArray()[i] = (int)value; }
        }

        // Methods
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            Current.Next = newNode;
            Current = newNode;
            Count++;
        }

        public int IndexOf(T data)
        {
            Node<T> trav = head;
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

        public bool Contains(T data) { return IndexOf(data) != -1; }

        public int[] ToArray()
        {
            int[] arr = new int[Count];
            int index = 0;
            Node<T> trav = Head;

            while (trav.Next != null)
            {
                arr[index++] = Convert.ToInt32(trav.Data);
                trav = trav.Next;
            }

            return arr;
        }

        private int GetMaxData()
        {
            Node<T> trav = head;
            int max = Convert.ToInt32(trav.Data), currentValue;
            while (trav.Next != null)
            {
                currentValue = Convert.ToInt32(trav.Data);
                max = max < currentValue ? currentValue : max;
            }

            return max;
        }

        private void CountSort(int[] arr, int n, int exp)
        {
            int[] count = new int[10], output = new int[n];
            int i;

            //initializing all elements of count to 0 
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]  
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual  
            //  position of this digit in output[]  
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array  
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now  
            // contains sorted numbers according to current digit  
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }

        private void Radixsort(int[] arr, int n)
        {
            int maxData = GetMaxData();

            for (int exp = 1; (maxData / exp) > 0; exp *= 10)
                CountSort(arr, n, exp);
        }

        public void Sort() { Radixsort(ToArray(), Count); }
    }
}

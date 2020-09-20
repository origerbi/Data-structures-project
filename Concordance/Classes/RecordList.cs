using System;
using System.Text;

namespace Concordance.Classes
{
    class RecordList
    {
        // Properties
        public Node<Record> Head { get; private set; }
        public Node<Record> Current { get; private set; }
        public int Count { get; private set; }

        // Constructors
        public RecordList()
        {
            Head = null;
            Current = null;
            Count = 0;
        }
        public RecordList(Record[] arr)
        {
            foreach (Record item in arr)
                Add(item);
        }

        public Record this[int i]
        {
            get { return ToArray()[i]; }
            set { ToArray()[i] = (Record)value; }
        }


        // Methods
        public void Add(Record record)
        {
            Node<Record> newNode = new Node<Record>(record);
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

        public void Add(string key, IntList value)
        {
            Node<Record> newNode = new Node<Record>(new Record(key, value));
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

        public int IndexOf(Record data)
        {
            Node<Record> trav = Head;
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

        public bool Contains(Record data) { return IndexOf(data) != -1; }

        public Record[] ToArray()
        {
            Record[] arr = new Record[Count];
            int index = 0;
            Node<Record> trav = Head;

            while (trav != null)
            {
                arr[index++] = trav.Data;
                trav = trav.Next;
            }

            return arr;
        }

        public string[] ToKeyArray()
        {
            Record[] recordsArr = ToArray();
            string[] keys = new string[Count];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = recordsArr[i].Key;
            }
            return keys;
        }

        public int StringCompare(string str1,string str2)
        {
            str1 = str1.ToLower();
            str2 = str2.ToLower();
            for (int i = 0; (i < str1.Length) && (i < str2.Length); i++)
            {
                if ((int)str1[i] == (int)str2[i])
                    continue;
                else
                    return (int)str1[i] - (int)str2[i];
            }

            // Edge case for strings like 
            // String 1="Geeky" and String 2="Geekyguy" 
            if (str1.Length < str2.Length)
                return (str1.Length - str2.Length);
            else if (str1.Length > str2.Length)
                return (str1.Length - str2.Length);
            // If none of the above conditions is true, 
            // it implies both the strings are equal 
            return 0;
        }


        public string[] QuicksortString(string[] elements, int left, int right)
        {
            int i = left, j = right;
            string pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (StringCompare(elements[i],pivot) < 0)
                    i++;

                while (StringCompare(elements[j], pivot) > 0)
                    j--;

                if (i <= j)
                {
                    // Swap
                    string tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
                
            }
            // Recursive calls

            if (left < j)
                QuicksortString(elements, left, j);
            if (i < right)
                QuicksortString(elements, i, right);

            return elements;
        }

        public override string ToString()
        {
            Node<Record> trav = Head;
            string list = string.Empty;
            while (trav != null)
            {
                list += trav.Data.ToString() + "\n";
                trav = trav.Next;
            }

            return list;
        }
    }
}

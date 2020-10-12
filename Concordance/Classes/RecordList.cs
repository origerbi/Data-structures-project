
namespace Concordance.Classes
{
    class RecordList
    {
        // Properties
        public Node<Record> Head { get; private set; }
        public Node<Record> Tail { get; private set; }
        public int Count { get; private set; }

        // Constructors
        public RecordList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public RecordList(Record[] arr)
        {
            foreach (Record item in arr)
                Add(item);
        }
        private Record this[int i] // Accessing an item in the list by its index, like in array
        {
            get { return ToArray()[i]; }
            set
            {
                Node<Record> trav = Head;

                for (; (i > 0) && (trav != null); i--, trav = trav.Next) ;
                trav.Data = value;
            }
        }
        public Record this[string key] // Accessing an item in the list by its key
        {
            get { return ContainsKey(key) ? this[IndexOfKey(key)] : null; }
            set
            {
                if (ContainsKey(key))
                    this[IndexOfKey(key)] = value;
            }
        }

        // Methods
        public void Add(Record record)
        {
            Node<Record> newNode = new Node<Record>(record);

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
        public void Add(string key, IntList value)
        {
            Node<Record> newNode = new Node<Record>(new Record(key, value));

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
        public bool Contains(Record record) { return IndexOf(record) != -1; }
        public bool ContainsKey(string key) { return IndexOfKey(key) != -1; }
        public bool ContainsValue(IntList value) { return IndexOfValue(value) != -1; }
        public int IndexOf(Record record)
        {
            Node<Record> trav = Head;
            int index = 0;

            while (trav != null)
            {
                if (trav.Data.Equals(record))
                    return index;

                index++;
                trav = trav.Next;
            }

            return -1;
        }
        public int IndexOfKey(string key)
        {
            Node<Record> trav = Head;
            int index = 0;

            while (trav != null)
            {
                if (trav.Data.Key.Equals(key))
                    return index;

                index++;
                trav = trav.Next;
            }

            return -1;
        }
        public int IndexOfValue(IntList value)
        {
            Node<Record> trav = Head;
            int index = 0;

            while (trav != null)
            {
                if (trav.Data.Value.Equals(value))
                    return index;

                index++;
                trav = trav.Next;
            }

            return -1;
        }
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
                keys[i] = recordsArr[i].Key;

            return keys;
        }
      
        public string[] Quicksortstring(string[] elements, int left, int right)
        {
            int i = left, j = right;
            string tempStr, pivot = elements[(left + right) / 2];
            Record tempRecord;

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                    i++;
                while (elements[j].CompareTo(pivot) > 0)
                    j--;

                if (i <= j)
                {
                    // Swaps the strings 
                    tempStr = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tempStr;

                    // Swaps the records
                    tempRecord = this[i];
                    this[i] = this[j];
                    this[j] = tempRecord;

                    i++;
                    j--;
                }
            }

            if (left < j)
                Quicksortstring(elements, left, j);
            if (i < right)
                Quicksortstring(elements, i, right);

            return elements;
        }
        public override string ToString()
        {
            Node<Record> trav = Head;
            string str = string.Empty;

            while (trav != null)
            {
                str += trav.Data.ToString() + "\n";
                trav = trav.Next;
            }

            return str;
        }
    }
}
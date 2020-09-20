using System;
using System.Text;

namespace Concordance.Classes
{
    class HashTable
    {
        // Properties
        public RecordList Records { get; private set; }

        // Constructors
        public HashTable()
        {
            Records = new RecordList();
        }

        public HashTable(Record[] records)
        {
            Records = new RecordList(records);
        }

        // Methods

        public void Add(string key, IntList value)
        {
            Records.Add( key, value);
        }

       public bool ContainsKey(string key)
        {
            return Records.Contains(new Record(key));
        }

        public bool ContainsValue(IntList data)
        {
            for (int i = 0; i < Records.Count; i++)
            {
                if (Records[i].Value == data)
                    return true;
            }
            return false;
            
        }

        public string[] Sort()
        {
           return Records.QuicksortString(Records.ToKeyArray(),0,Records.Count - 1);
        }

        public override string ToString()
        {
            return Records.ToString();
        }

    }
}

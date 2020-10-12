
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
        public Record this[string key] // Accessing an item in the list by its key
        {
            get { return Records[key]; }
            set { Records[key] = value; }
        }

        // Methods
        public void Add(string key, IntList value) { Records.Add(key, value); }
        public bool ContainsKey(string key) { return Records.ContainsKey(key); }
        public bool ContainsValue(IntList value) { return Records.ContainsValue(value); }
        public void Sort() { Records.Quicksortstring(Records.ToKeyArray(), 0, Records.Count - 1); }
        public override string ToString() { return Records.ToString(); }
    }
}

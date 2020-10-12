
namespace Concordance.Classes
{
    class Record
    {
        // Properties
        public string Key { get; private set; }
        public IntList Value { get; private set; }

        // Constructors
        public Record(string key)
        {
            Key = key;
            Value = new IntList();
        }
        public Record(string key,IntList value)
        {
            Key = key;
            Value = value;
        }

        // Methods
        public override string ToString()
        {
            return string.Format("[Word: \"{0}\" | Appearances: {1}]", Key, Value.ToString());
        }
    }
}
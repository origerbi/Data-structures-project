using System;
//using System.Collections.Generic;
using System.Text;

namespace Concordance.Classes
{
    class Hashtable<K, V>
    {
        // Fields
        private List<K> keys;
        private List<V> values;

        // Properties
        public List<K> Keys { get; private set; }
        public List<V> Values { get; private set; }

        // Constructors
        public Hashtable()
        {
            Keys = new List<K>();
            Values = new List<V>();
        }

        public Hashtable(List<K> keys, List<V> values)
        {
            Keys = keys;
            Values = values;
        }
        public object this[K key]
        {
            get { return Values[Keys.IndexOf(key)]; }
            set { Values[Keys.IndexOf(key)] = value; }
        }

        // Methods
        public void Add(K key, V value)
        {
            if (!Keys.Contains(key))
            {
                Keys.Add(key);
                this[key] = value;
            }
        }

        public bool ContainsKey(K key) { return Keys.Contains(key); }
        public bool ContainsValue(V value) { return Values.Contains(value); }
        public void Sort()
        {
            List<V> currentValuesList = null;

            //Keys.Sort();

            // Sorts all the page numbers for each word in the concodance
            for (int i = 0; i < Keys.Count; i++)
            {
                currentValuesList = (List<V>)Values[i];
                currentValuesList.Sort();
            }
        }
    }
}

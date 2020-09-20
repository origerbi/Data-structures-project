using System;
//using System.Collections.Generic;
using System.Text;

namespace Concordance.Classes
{
    class Concordance
    {
        // Fields
        private Hashtable<string, List<int>> hashtable;

        // Properties
        public Hashtable<string, List<int>> Hashtable { get; private set; }

        // Constructors
        public Concordance(string[] rows)
        {
            Hashtable = new Hashtable<string, List<int>>();

            FillConcordance(rows);
        }

        // Methods
        private void FillConcordance(string[] rows)
        {
            string[] wordsInRow = null;
            List<int> currentWordIndexesList = null;

            for (int rowOffset = 0; rowOffset < rows.Length; rowOffset++)
            {
                wordsInRow = rows[rowOffset].Split(' ');
                foreach (string currentWord in wordsInRow)
                {
                    if (!Hashtable.ContainsKey(currentWord))
                        Hashtable.Add(currentWord, new List<int>());
                    currentWordIndexesList = (List<int>)Hashtable[currentWord];
                    currentWordIndexesList.Add(rowOffset + 1); // rowOffset is zero-based
                }
            }
        }
        public override string ToString()
        {
            // TODO: COMPLETE
            return base.ToString();
        }
    }
}

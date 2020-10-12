using Concordance.Classes;
using System;
using System.IO;

namespace Concordance
{
    class Program
    {
        // Methods
        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success: " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Warning: " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            string filePath = string.Empty, capitalizedWord = string.Empty;
            string[] rowsInFile, wordsInRow;
            HashTable concordance = new HashTable();
            string[] seperators = { " ", ",", ".", ":", ";", "/", "\\", "-", "\"", "“", "”", "?", "!", "(", ")", "[", "]", "{", "}", "'s", "'", "–", "—", "*"};
            Console.Title = "Concordance by Ran Yunger and Ori Gerbi";
            // Gets the file path from the user
            do
            {
                Console.WriteLine("Insert the full path of a .txt file to analyze: ");
                filePath = Console.ReadLine();
                if (!File.Exists(filePath))
                {
                    WriteError("File not found.");
                    filePath = string.Empty;
                }

            } while (filePath.Equals(string.Empty));
            
            Console.Clear();
            WriteSuccess(string.Format("File found: \"{0}\"", filePath));
            WriteWarning("Analyzing file...");
            rowsInFile = File.ReadAllLines(filePath);
            for (int i = 0; i < rowsInFile.Length; i++)
            {
                wordsInRow = rowsInFile[i].Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                for (int wordOffset = 0; wordOffset < wordsInRow.Length; wordOffset++)
                {
                    capitalizedWord = wordsInRow[wordOffset].ToUpper();
                    if (!concordance.ContainsKey(capitalizedWord))
                        concordance.Add(capitalizedWord, new IntList());
                    concordance[capitalizedWord].Value.Add(i + 1);
                }
            }
            concordance.Sort();

            WriteSuccess("File analyze completed.");
            using (StreamWriter sw = File.CreateText(Environment.CurrentDirectory + "\\ConcordanceOutput.txt"))
                sw.WriteLine(concordance.ToString());
            Console.WriteLine("The Concordance for the given file can be found in ConcordanceOutput.txt");

            Console.ReadLine();
        }
    }
}

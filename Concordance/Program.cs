using Concordance.Classes;
using System;
using System.IO;
using System.Security.Cryptography;

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
            string filePath = string.Empty;
            string[] rowsInFile, wordsInRow;
            HashTable concordance = new HashTable();
            char[] ignoredChars = { ' ', ',', '.', ':', ';', '-', '"', '?', '!', '(', ')' };
            
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
                wordsInRow = rowsInFile[i].Split(ignoredChars, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in wordsInRow)
                {
                    if (!concordance.ContainsKey(word))
                        concordance.Add(word, new IntList());
                    if (!concordance[word].Value.Contains(i + 1))
                        concordance[word].Value.Add(i + 1);
                }
            }
            concordance.Sort();

            WriteSuccess("File analyze completed.");
            Console.WriteLine("Here's the Concordance for the given file:");
            Console.WriteLine(concordance.ToString());

            Console.ReadLine();
        }
    }
}

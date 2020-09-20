using Concordance.Classes;
using System;
using System.IO;

namespace Concordance
{
    class Program
    {
        // Methods
        public static void WriteSuccess(String message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success: " + message);
            Console.ResetColor();
        }
        public static void WriteWarning(String message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Warning: " + message);
            Console.ResetColor();
        }
        public static void WriteError(String message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.ResetColor();
        }
        public static void PrintCorcondance(Hashtable<K, V> hashTable)
        {
            // TODO: COMPLETE
        }

        static void Main(string[] args)
        {
            String filePath = string.Empty;
            String[] rowsInFile, wordsInRow;

            // Gets the file path from the user
            do
            {
                Console.WriteLine("Insert a .txt file path: ");
                filePath = Console.ReadLine();
                if (!File.Exists(filePath))
                {
                    WriteError("File not found.");
                    filePath = string.Empty;
                }

            } while (filePath.Equals(string.Empty));

            WriteSuccess("File found.");
            rowsInFile = File.ReadAllLines(filePath);
            WriteWarning("Analyzing file...");
            foreach (String row in rowsInFile)
            {
                wordsInRow = row.Split(' ');
                // TODO: COMPLETE (check if any word exists in hashtable, add new record / row index)
            }
            WriteSuccess("File analyzed completed. Here is the Concordance\n: ");
            PrintCorcondance(null);

            Console.ReadLine();
        }
    }
}

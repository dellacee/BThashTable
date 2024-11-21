using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai3
{
    public class Hash
    {
        private const int TableSize = 101; // Prime number for better distribution
        private ArrayList[] table;

        public Hash()
        {
            // Initialize the table with ArrayLists for each bucket
            table = new ArrayList[TableSize];
            for (int i = 0; i < TableSize; i++)
            {
                table[i] = new ArrayList();
            }
        }

        // Hash function to calculate hash index
        private int HashFunction(string key)
        {
            long total = 0;
            foreach (char c in key)
            {
                total += 37 * total + c;
            }
            return (int)(total % TableSize);
        }

        // Add key-value pair to the hash table
        public void Add(string key, string value)
        {
            int index = HashFunction(key);
            foreach (DictionaryEntry entry in table[index])
            {
                if (entry.Key.Equals(key))
                {
                    throw new Exception("Duplicate key detected.");
                }
            }
            table[index].Add(new DictionaryEntry(key, value));
        }

        // Get value for a given key
        public string Get(string key)
        {
            int index = HashFunction(key);
            foreach (DictionaryEntry entry in table[index])
            {
                if (entry.Key.Equals(key))
                {
                    return entry.Value.ToString();
                }
            }
            return "Not Found";
        }

        // Remove key-value pair from the hash table
        public void Remove(string key)
        {
            int index = HashFunction(key);
            for (int i = 0; i < table[index].Count; i++)
            {
                DictionaryEntry entry = (DictionaryEntry)table[index][i];
                if (entry.Key.Equals(key))
                {
                    table[index].RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Key not found.");
        }

        // Return all keys for display purposes
        public List<string> GetAllKeys()
        {
            List<string> keys = new List<string>();
            foreach (ArrayList bucket in table)
            {
                foreach (DictionaryEntry entry in bucket)
                {
                    keys.Add(entry.Key.ToString());
                }
            }
            return keys;
        }
    }
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

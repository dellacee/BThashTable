using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlossaryApp
{
    public class CustomHash
    {
        private const int SIZE = 101; // Kích thước bảng băm
        private ArrayList[] buckets; // Mảng chứa các bucket

        public CustomHash()
        {
            buckets = new ArrayList[SIZE];
            for (int i = 0; i < SIZE; i++)
                buckets[i] = new ArrayList();
        }

        // Hàm băm
        public int HashFunction(string key)
        {
            long hash = 0;
            foreach (char c in key)
                hash = (hash * 31 + c) % SIZE;
            return (int)Math.Abs(hash);
        }

        // Thêm từ vào bảng băm
        public void Add(string key, string value)
        {
            int index = HashFunction(key);
            foreach (DictionaryEntry entry in buckets[index])
            {
                if ((string)entry.Key == key)
                    throw new Exception("Key already exists!");
            }
            buckets[index].Add(new DictionaryEntry(key, value));
        }

        // Lấy giá trị theo từ khóa
        public string Retrieve(string key)
        {
            int index = HashFunction(key);
            foreach (DictionaryEntry entry in buckets[index])
            {
                if ((string)entry.Key == key)
                    return (string)entry.Value;
            }
            return "Not Found";
        }

        // Xóa một từ khỏi bảng băm
        public void Remove(string key)
        {
            int index = HashFunction(key);
            for (int i = 0; i < buckets[index].Count; i++)
            {
                var entry = (DictionaryEntry)buckets[index][i];
                if ((string)entry.Key == key)
                {
                    buckets[index].RemoveAt(i);
                    return;
                }
            }
        }

        // Lấy danh sách các khóa
        public ArrayList GetKeys()
        {
            ArrayList keys = new ArrayList();
            foreach (var bucket in buckets)
            {
                foreach (DictionaryEntry entry in bucket)
                    keys.Add(entry.Key);
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

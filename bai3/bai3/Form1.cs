using System;
using System.Security.Policy;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
namespace GlossaryApp
{
    public class Hash
    {
        private const int Size = 100; // Kích thước của bảng băm
        private LinkedList<KeyValuePair<string, string>>[] buckets;

        public Hash()
        {
            buckets = new LinkedList<KeyValuePair<string, string>>[Size];
            for (int i = 0; i < Size; i++)
            {
                buckets[i] = new LinkedList<KeyValuePair<string, string>>();
            }
        }

        private int GetHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash = (hash * 31 + c) % Size;
            }
            return Math.Abs(hash);
        }

        public void Add(string key, string value)
        {
            int index = GetHash(key);
            foreach (var kvp in buckets[index])
            {
                if (kvp.Key == key)
                {
                    throw new ArgumentException($"Key '{key}' đã tồn tại trong bảng băm.");
                }
            }
            buckets[index].AddLast(new KeyValuePair<string, string>(key, value));
        }

        public string Get(string key)
        {
            int index = GetHash(key);
            foreach (var kvp in buckets[index])
            {
                if (kvp.Key == key)
                {
                    return kvp.Value;
                }
            }
            return null;
        }

        // Hàm GetAllKeys: Lấy tất cả các key từ bảng băm
        public List<string> GetAllKeys()
        {
            List<string> keys = new List<string>();

            foreach (var bucket in buckets)
            {
                foreach (var kvp in bucket)
                {
                    keys.Add(kvp.Key);
                }
            }

            return keys;
        }
    }


    public partial class Form1 : System.Windows.Forms.Form
    {
        private Hash glossary;

        public Form1()
        {
            InitializeComponent();
            glossary = new Hash();
            LoadGlossary();
            DisplayWords();         
        }

        private void LoadGlossary()
        {
            // Add sample glossary terms to the Hash table
            glossary.Add("query", "a request for data or information from a database");
            glossary.Add("underflow", "a condition where a calculation results in a number too small to be represented");
            glossary.Add("variable", "a location in memory that contains a data value");
            glossary.Add("node", "a point of connection in a network");
        }

        private void DisplayWords()
        {
            lstWords.Items.Clear();
            foreach (string word in glossary.GetAllKeys())
            {
                lstWords.Items.Add(word);
            }
        }

        private void lstWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWords.SelectedItem != null)
            {
                string selectedWord = lstWords.SelectedItem.ToString();
                txtDefinition.Text = glossary.Get(selectedWord);
            }
        }
    }
}

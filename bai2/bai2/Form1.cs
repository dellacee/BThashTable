using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpellingChecker
{
    public partial class MainForm : Form
    {
        private Hashtable dictionary;

        public MainForm()
        {
            InitializeComponent();
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            // Initialize the dictionary with some common words
            dictionary = new Hashtable
            {
                { "the", true },
                { "is", true },
                { "and", true },
                { "to", true },
                { "a", true },
                { "in", true },
                { "that", true },
                { "it", true },
                { "of", true },
                { "you", true },
                { "he", true },
                { "she", true },
                { "we", true },
                { "they", true },
                { "on", true },
                { "this", true },
                { "with", true },
                { "an", true },
                { "be", true },
                { "for", true }
                // Add more words as needed
            };
        }

        public void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select a Text File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                CheckSpelling(filePath);
            }
        }

        private void CheckSpelling(string filePath)
        {
            listBoxErrors.Items.Clear();

            string text = File.ReadAllText(filePath);
            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' },
                                        StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                string lowerWord = word.ToLower(); // Convert to lowercase for case-insensitive matching

                if (!dictionary.ContainsKey(lowerWord))
                {
                    listBoxErrors.Items.Add(lowerWord);
                }
            }

            if (listBoxErrors.Items.Count == 0)
            {
                MessageBox.Show("No spelling errors found!", "Spelling Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Spelling errors found!", "Spelling Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);

        }
    }
}

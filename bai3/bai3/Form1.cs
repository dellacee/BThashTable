using System;
using System.Security.Policy;
using System.Windows.Forms;

namespace GlossaryApp
{
    public partial class Form1 : Form
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

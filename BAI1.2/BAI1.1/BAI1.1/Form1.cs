
using System;
using System.Windows.Forms;

namespace GlossaryApp
{
    public partial class Form1 : Form
    {
        private CustomHash glossary = new CustomHash();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu từ file
            LoadGlossary();
            // Hiển thị từ lên ListBox
            DisplayWords();
        } 

        private void LoadGlossary()
        {
            string[] lines = System.IO.File.ReadAllLines("words.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                    glossary.Add(parts[0], parts[1]);


            }
        }

        private void DisplayWords()
        {
            var keys = glossary.GetKeys();
            foreach (var key in keys)
                lstWords.Items.Add(key);
        }

        private void lstWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWords.SelectedItem != null)
            {
                string selectedWord = lstWords.SelectedItem.ToString();
                txtDefinition.Text = glossary.Retrieve(selectedWord);
            }
        }

        private Label lblWords;
        private Label lblDefinition;


     


        private void InitializeComponent()
        {
            this.lblWords = new System.Windows.Forms.Label();
            this.lblDefinition = new System.Windows.Forms.Label();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDefinition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(22, 29);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(44, 16);
            this.lblWords.TabIndex = 0;
            this.lblWords.Text = "label1";
            // 
            // lblDefinition
            // 
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.Location = new System.Drawing.Point(181, 29);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(44, 16);
            this.lblDefinition.TabIndex = 1;
            this.lblDefinition.Text = "label2";
            // 
            // lstWords
            // 
            this.lstWords.FormattingEnabled = true;
            this.lstWords.ItemHeight = 16;
            this.lstWords.Location = new System.Drawing.Point(25, 95);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(120, 84);
            this.lstWords.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // txtDefinition
            // 
            this.txtDefinition.Location = new System.Drawing.Point(170, 95);
            this.txtDefinition.Name = "txtDefinition";
            this.txtDefinition.Size = new System.Drawing.Size(100, 22);
            this.txtDefinition.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.txtDefinition);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.lblWords);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ListBox lstWords;
        private TextBox textBox1;
        private TextBox txtDefinition;
    }
}

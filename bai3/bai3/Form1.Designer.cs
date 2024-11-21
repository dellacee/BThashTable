namespace GlossaryApp
{
    partial class Form1
    {
        private System.Windows.Forms.ListBox lstWords;
        private System.Windows.Forms.TextBox txtDefinition;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.Label lblDefinition;

        private void InitializeComponent()
        {
            this.lstWords = new System.Windows.Forms.ListBox();
            this.txtDefinition = new System.Windows.Forms.TextBox();
            this.lblWords = new System.Windows.Forms.Label();
            this.lblDefinition = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lstWords
            this.lstWords.Location = new System.Drawing.Point(12, 30);
            this.lstWords.Size = new System.Drawing.Size(150, 200);
            this.lstWords.SelectedIndexChanged += new System.EventHandler(this.lstWords_SelectedIndexChanged);

            // txtDefinition
            this.txtDefinition.Location = new System.Drawing.Point(180, 30);
            this.txtDefinition.Size = new System.Drawing.Size(200, 200);
            this.txtDefinition.Multiline = true;

            // lblWords
            this.lblWords.Location = new System.Drawing.Point(12, 10);
            this.lblWords.Text = "Words";

            // lblDefinition
            this.lblDefinition.Location = new System.Drawing.Point(180, 10);
            this.lblDefinition.Text = "Definition";

            // Form1
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.txtDefinition);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.lblDefinition);
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = "Glossary App";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

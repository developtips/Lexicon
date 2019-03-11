namespace Lexicon.Presentation.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWords = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPerusal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPerusalWord = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOperation,
            this.tsmiPerusal});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(946, 24);
            this.MainMenu.TabIndex = 1;
            // 
            // tsmiOperation
            // 
            this.tsmiOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWords});
            this.tsmiOperation.Name = "tsmiOperation";
            this.tsmiOperation.Size = new System.Drawing.Size(72, 20);
            this.tsmiOperation.Text = "Operation";
            // 
            // tsmiWords
            // 
            this.tsmiWords.Name = "tsmiWords";
            this.tsmiWords.Size = new System.Drawing.Size(152, 22);
            this.tsmiWords.Text = "Words";
            this.tsmiWords.Click += new System.EventHandler(this.tsmiWords_Click);
            // 
            // tsmiPerusal
            // 
            this.tsmiPerusal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPerusalWord});
            this.tsmiPerusal.Name = "tsmiPerusal";
            this.tsmiPerusal.Size = new System.Drawing.Size(57, 20);
            this.tsmiPerusal.Text = "Perusal";
            // 
            // tsmiPerusalWord
            // 
            this.tsmiPerusalWord.Name = "tsmiPerusalWord";
            this.tsmiPerusalWord.Size = new System.Drawing.Size(152, 22);
            this.tsmiPerusalWord.Text = "PerusalWord";
            this.tsmiPerusalWord.Click += new System.EventHandler(this.tsmiPerusalWord_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 495);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiWords;
        private System.Windows.Forms.ToolStripMenuItem tsmiPerusal;
        private System.Windows.Forms.ToolStripMenuItem tsmiPerusalWord;
    }
}
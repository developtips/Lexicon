namespace Lexicon.Presentation.UserControls.LookUp
{
    partial class FrmVsLookUp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVsLookUp));
            this.dgvVsLookUp = new System.Windows.Forms.DataGridView();
            this.pnlFormTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVsLookUp)).BeginInit();
            this.pnlFormTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVsLookUp
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvVsLookUp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVsLookUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVsLookUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVsLookUp.Location = new System.Drawing.Point(0, 37);
            this.dgvVsLookUp.Name = "dgvVsLookUp";
            this.dgvVsLookUp.Size = new System.Drawing.Size(475, 225);
            this.dgvVsLookUp.TabIndex = 0;
            this.dgvVsLookUp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVsLookUp_CellDoubleClick);
            this.dgvVsLookUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvVsLookUp_KeyPress);
            this.dgvVsLookUp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvVsLookUp_KeyUp);
            // 
            // pnlFormTop
            // 
            this.pnlFormTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFormTop.Controls.Add(this.btnExit);
            this.pnlFormTop.Controls.Add(this.txtSearch);
            this.pnlFormTop.Controls.Add(this.lblSearch);
            this.pnlFormTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFormTop.Name = "pnlFormTop";
            this.pnlFormTop.Size = new System.Drawing.Size(475, 37);
            this.pnlFormTop.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(77, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(173, 21);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblSearch.ForeColor = System.Drawing.Color.Blue;
            this.lblSearch.Location = new System.Drawing.Point(12, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSearch.Size = new System.Drawing.Size(59, 13);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search By:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(440, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(23, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmVsLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 262);
            this.Controls.Add(this.dgvVsLookUp);
            this.Controls.Add(this.pnlFormTop);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVsLookUp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmVsLookUp";
            this.Load += new System.EventHandler(this.FrmVsLookUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVsLookUp)).EndInit();
            this.pnlFormTop.ResumeLayout(false);
            this.pnlFormTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVsLookUp;
        private System.Windows.Forms.Panel pnlFormTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnExit;
    }
}
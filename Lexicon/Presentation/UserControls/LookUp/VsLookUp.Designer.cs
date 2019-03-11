namespace Lexicon.Presentation.UserControls.LookUp
{
    partial class VsLookUp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsLookUp));
            this.pnlCode = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnVsLookUpSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlCode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCode
            // 
            this.pnlCode.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlCode.Controls.Add(this.txtCode);
            this.pnlCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCode.Location = new System.Drawing.Point(222, 0);
            this.pnlCode.Name = "pnlCode";
            this.pnlCode.Size = new System.Drawing.Size(60, 25);
            this.pnlCode.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.Size = new System.Drawing.Size(60, 21);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // btnVsLookUpSearch
            // 
            this.btnVsLookUpSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVsLookUpSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnVsLookUpSearch.Image")));
            this.btnVsLookUpSearch.Location = new System.Drawing.Point(198, 0);
            this.btnVsLookUpSearch.Name = "btnVsLookUpSearch";
            this.btnVsLookUpSearch.Size = new System.Drawing.Size(24, 25);
            this.btnVsLookUpSearch.TabIndex = 3;
            this.btnVsLookUpSearch.UseVisualStyleBackColor = true;
            this.btnVsLookUpSearch.Click += new System.EventHandler(this.btnRegVsLookUpSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.txtDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 25);
            this.panel1.TabIndex = 4;
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(198, 21);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TabStop = false;
            // 
            // VsLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVsLookUpSearch);
            this.Controls.Add(this.pnlCode);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "VsLookUp";
            this.Size = new System.Drawing.Size(282, 25);
            this.pnlCode.ResumeLayout(false);
            this.pnlCode.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCode;
        private System.Windows.Forms.Button btnVsLookUpSearch;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDesc;
    }
}

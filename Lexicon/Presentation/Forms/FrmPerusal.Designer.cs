namespace Lexicon.Presentation.Forms
{
    partial class FrmPerusal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPerusalHeader = new System.Windows.Forms.Panel();
            this.btnPrintPerusal = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnDeletePerusalHeader = new System.Windows.Forms.Button();
            this.btnSavePerusalHeader = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtToWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPerusalHeader = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPerusalDetail = new System.Windows.Forms.Panel();
            this.btnGetPrevWord = new System.Windows.Forms.Button();
            this.lblSymphonic = new System.Windows.Forms.Label();
            this.lblSynonym = new System.Windows.Forms.Label();
            this.lblEngDesc = new System.Windows.Forms.Label();
            this.lblFarsiDesc = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnShowAnswer = new System.Windows.Forms.Button();
            this.btnGetNextWord = new System.Windows.Forms.Button();
            this.lblShowWord = new System.Windows.Forms.Label();
            this.btnPerusalDetail = new System.Windows.Forms.Button();
            this.btnPerusalHeader = new System.Windows.Forms.Button();
            this.btnDeletePerusalDetail = new System.Windows.Forms.Button();
            this.dgvPerusalDetail = new System.Windows.Forms.DataGridView();
            this.DetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailWordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPerusalHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerusalHeader)).BeginInit();
            this.panelPerusalDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerusalDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPerusalHeader
            // 
            this.pnlPerusalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.pnlPerusalHeader.Controls.Add(this.btnPrintPerusal);
            this.pnlPerusalHeader.Controls.Add(this.lblTotalCount);
            this.pnlPerusalHeader.Controls.Add(this.btnDeletePerusalHeader);
            this.pnlPerusalHeader.Controls.Add(this.btnSavePerusalHeader);
            this.pnlPerusalHeader.Controls.Add(this.label3);
            this.pnlPerusalHeader.Controls.Add(this.txtComment);
            this.pnlPerusalHeader.Controls.Add(this.txtToWord);
            this.pnlPerusalHeader.Controls.Add(this.label2);
            this.pnlPerusalHeader.Controls.Add(this.txtFromWord);
            this.pnlPerusalHeader.Controls.Add(this.label1);
            this.pnlPerusalHeader.Controls.Add(this.dgvPerusalHeader);
            this.pnlPerusalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPerusalHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlPerusalHeader.Name = "pnlPerusalHeader";
            this.pnlPerusalHeader.Size = new System.Drawing.Size(762, 195);
            this.pnlPerusalHeader.TabIndex = 0;
            // 
            // btnPrintPerusal
            // 
            this.btnPrintPerusal.Image = global::Lexicon.Properties.Resources.print;
            this.btnPrintPerusal.Location = new System.Drawing.Point(635, 73);
            this.btnPrintPerusal.Name = "btnPrintPerusal";
            this.btnPrintPerusal.Size = new System.Drawing.Size(33, 40);
            this.btnPrintPerusal.TabIndex = 24;
            this.btnPrintPerusal.UseVisualStyleBackColor = true;
            this.btnPrintPerusal.Click += new System.EventHandler(this.btnPrintPerusal_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalCount.Location = new System.Drawing.Point(287, 17);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(123, 20);
            this.lblTotalCount.TabIndex = 11;
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeletePerusalHeader
            // 
            this.btnDeletePerusalHeader.Image = global::Lexicon.Properties.Resources.trash_2_512;
            this.btnDeletePerusalHeader.Location = new System.Drawing.Point(674, 43);
            this.btnDeletePerusalHeader.Name = "btnDeletePerusalHeader";
            this.btnDeletePerusalHeader.Size = new System.Drawing.Size(24, 24);
            this.btnDeletePerusalHeader.TabIndex = 10;
            this.btnDeletePerusalHeader.UseVisualStyleBackColor = true;
            this.btnDeletePerusalHeader.Click += new System.EventHandler(this.btnDeletePerusalHeader_Click);
            // 
            // btnSavePerusalHeader
            // 
            this.btnSavePerusalHeader.Image = global::Lexicon.Properties.Resources.Add16;
            this.btnSavePerusalHeader.Location = new System.Drawing.Point(644, 43);
            this.btnSavePerusalHeader.Name = "btnSavePerusalHeader";
            this.btnSavePerusalHeader.Size = new System.Drawing.Size(24, 24);
            this.btnSavePerusalHeader.TabIndex = 9;
            this.btnSavePerusalHeader.UseVisualStyleBackColor = true;
            this.btnSavePerusalHeader.Click += new System.EventHandler(this.btnSavePerusalHeader_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(77, 43);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(561, 20);
            this.txtComment.TabIndex = 5;
            // 
            // txtToWord
            // 
            this.txtToWord.Location = new System.Drawing.Point(211, 17);
            this.txtToWord.Name = "txtToWord";
            this.txtToWord.Size = new System.Drawing.Size(70, 20);
            this.txtToWord.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Word";
            // 
            // txtFromWord
            // 
            this.txtFromWord.Location = new System.Drawing.Point(77, 17);
            this.txtFromWord.Name = "txtFromWord";
            this.txtFromWord.Size = new System.Drawing.Size(70, 20);
            this.txtFromWord.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Word";
            // 
            // dgvPerusalHeader
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvPerusalHeader.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPerusalHeader.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(220)))), ((int)(((byte)(57)))));
            this.dgvPerusalHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerusalHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FromWord,
            this.ToWord,
            this.Comment,
            this.Count,
            this.ShCreateDate});
            this.dgvPerusalHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPerusalHeader.Location = new System.Drawing.Point(0, 73);
            this.dgvPerusalHeader.Name = "dgvPerusalHeader";
            this.dgvPerusalHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerusalHeader.Size = new System.Drawing.Size(762, 122);
            this.dgvPerusalHeader.TabIndex = 0;
            this.dgvPerusalHeader.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvPerusalHeader_RowStateChanged);
            this.dgvPerusalHeader.SelectionChanged += new System.EventHandler(this.dgvPerusalHeader_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // FromWord
            // 
            this.FromWord.DataPropertyName = "FromWord";
            this.FromWord.HeaderText = "FromWord";
            this.FromWord.Name = "FromWord";
            this.FromWord.Width = 65;
            // 
            // ToWord
            // 
            this.ToWord.DataPropertyName = "ToWord";
            this.ToWord.HeaderText = "ToWord";
            this.ToWord.Name = "ToWord";
            this.ToWord.Width = 65;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.Width = 300;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.Width = 60;
            // 
            // ShCreateDate
            // 
            this.ShCreateDate.DataPropertyName = "ShCreateDate";
            this.ShCreateDate.HeaderText = "ShCreateDate";
            this.ShCreateDate.Name = "ShCreateDate";
            // 
            // panelPerusalDetail
            // 
            this.panelPerusalDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.panelPerusalDetail.Controls.Add(this.btnGetPrevWord);
            this.panelPerusalDetail.Controls.Add(this.lblSymphonic);
            this.panelPerusalDetail.Controls.Add(this.lblSynonym);
            this.panelPerusalDetail.Controls.Add(this.lblEngDesc);
            this.panelPerusalDetail.Controls.Add(this.lblFarsiDesc);
            this.panelPerusalDetail.Controls.Add(this.btnAddToList);
            this.panelPerusalDetail.Controls.Add(this.btnShowAnswer);
            this.panelPerusalDetail.Controls.Add(this.btnGetNextWord);
            this.panelPerusalDetail.Controls.Add(this.lblShowWord);
            this.panelPerusalDetail.Controls.Add(this.btnPerusalDetail);
            this.panelPerusalDetail.Controls.Add(this.btnPerusalHeader);
            this.panelPerusalDetail.Controls.Add(this.btnDeletePerusalDetail);
            this.panelPerusalDetail.Controls.Add(this.dgvPerusalDetail);
            this.panelPerusalDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPerusalDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panelPerusalDetail.Location = new System.Drawing.Point(0, 195);
            this.panelPerusalDetail.Name = "panelPerusalDetail";
            this.panelPerusalDetail.Size = new System.Drawing.Size(762, 267);
            this.panelPerusalDetail.TabIndex = 1;
            // 
            // btnGetPrevWord
            // 
            this.btnGetPrevWord.Location = new System.Drawing.Point(111, 223);
            this.btnGetPrevWord.Name = "btnGetPrevWord";
            this.btnGetPrevWord.Size = new System.Drawing.Size(94, 32);
            this.btnGetPrevWord.TabIndex = 23;
            this.btnGetPrevWord.Text = "Get Prev";
            this.btnGetPrevWord.UseVisualStyleBackColor = true;
            this.btnGetPrevWord.Click += new System.EventHandler(this.btnGetPrevWord_Click);
            // 
            // lblSymphonic
            // 
            this.lblSymphonic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.lblSymphonic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSymphonic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSymphonic.Location = new System.Drawing.Point(447, 229);
            this.lblSymphonic.Name = "lblSymphonic";
            this.lblSymphonic.Size = new System.Drawing.Size(304, 20);
            this.lblSymphonic.TabIndex = 22;
            this.lblSymphonic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSynonym
            // 
            this.lblSynonym.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.lblSynonym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSynonym.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSynonym.Location = new System.Drawing.Point(447, 202);
            this.lblSynonym.Name = "lblSynonym";
            this.lblSynonym.Size = new System.Drawing.Size(304, 20);
            this.lblSynonym.TabIndex = 21;
            this.lblSynonym.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEngDesc
            // 
            this.lblEngDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(145)))));
            this.lblEngDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEngDesc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblEngDesc.Location = new System.Drawing.Point(447, 175);
            this.lblEngDesc.Name = "lblEngDesc";
            this.lblEngDesc.Size = new System.Drawing.Size(304, 20);
            this.lblEngDesc.TabIndex = 20;
            this.lblEngDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFarsiDesc
            // 
            this.lblFarsiDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.lblFarsiDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFarsiDesc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFarsiDesc.Location = new System.Drawing.Point(447, 148);
            this.lblFarsiDesc.Name = "lblFarsiDesc";
            this.lblFarsiDesc.Size = new System.Drawing.Size(304, 20);
            this.lblFarsiDesc.TabIndex = 19;
            this.lblFarsiDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(211, 223);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(94, 32);
            this.btnAddToList.TabIndex = 18;
            this.btnAddToList.Text = "AddToList";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnShowAnswer
            // 
            this.btnShowAnswer.Location = new System.Drawing.Point(327, 171);
            this.btnShowAnswer.Name = "btnShowAnswer";
            this.btnShowAnswer.Size = new System.Drawing.Size(94, 40);
            this.btnShowAnswer.TabIndex = 17;
            this.btnShowAnswer.Text = "Show Answer";
            this.btnShowAnswer.UseVisualStyleBackColor = true;
            this.btnShowAnswer.Click += new System.EventHandler(this.btnShowAnswer_Click);
            // 
            // btnGetNextWord
            // 
            this.btnGetNextWord.Location = new System.Drawing.Point(11, 223);
            this.btnGetNextWord.Name = "btnGetNextWord";
            this.btnGetNextWord.Size = new System.Drawing.Size(94, 32);
            this.btnGetNextWord.TabIndex = 16;
            this.btnGetNextWord.Text = "Get Next";
            this.btnGetNextWord.UseVisualStyleBackColor = true;
            this.btnGetNextWord.Click += new System.EventHandler(this.btnGetNextWord_Click);
            // 
            // lblShowWord
            // 
            this.lblShowWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblShowWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShowWord.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblShowWord.Location = new System.Drawing.Point(11, 171);
            this.lblShowWord.Name = "lblShowWord";
            this.lblShowWord.Size = new System.Drawing.Size(310, 40);
            this.lblShowWord.TabIndex = 15;
            this.lblShowWord.Text = "Word";
            this.lblShowWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPerusalDetail
            // 
            this.btnPerusalDetail.Location = new System.Drawing.Point(111, 127);
            this.btnPerusalDetail.Name = "btnPerusalDetail";
            this.btnPerusalDetail.Size = new System.Drawing.Size(94, 32);
            this.btnPerusalDetail.TabIndex = 13;
            this.btnPerusalDetail.Text = "Perusal Detail";
            this.btnPerusalDetail.UseVisualStyleBackColor = true;
            this.btnPerusalDetail.Click += new System.EventHandler(this.btnPerusalDetail_Click);
            // 
            // btnPerusalHeader
            // 
            this.btnPerusalHeader.Location = new System.Drawing.Point(11, 127);
            this.btnPerusalHeader.Name = "btnPerusalHeader";
            this.btnPerusalHeader.Size = new System.Drawing.Size(94, 32);
            this.btnPerusalHeader.TabIndex = 12;
            this.btnPerusalHeader.Text = "Perusal Header";
            this.btnPerusalHeader.UseVisualStyleBackColor = true;
            this.btnPerusalHeader.Click += new System.EventHandler(this.btnPerusalHeader_Click);
            // 
            // btnDeletePerusalDetail
            // 
            this.btnDeletePerusalDetail.Image = global::Lexicon.Properties.Resources.trash_2_512;
            this.btnDeletePerusalDetail.Location = new System.Drawing.Point(644, 0);
            this.btnDeletePerusalDetail.Name = "btnDeletePerusalDetail";
            this.btnDeletePerusalDetail.Size = new System.Drawing.Size(24, 24);
            this.btnDeletePerusalDetail.TabIndex = 11;
            this.btnDeletePerusalDetail.UseVisualStyleBackColor = true;
            this.btnDeletePerusalDetail.Click += new System.EventHandler(this.btnDeletePerusalDetail_Click);
            // 
            // dgvPerusalDetail
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvPerusalDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPerusalDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.dgvPerusalDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerusalDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailId,
            this.colDetailWordId,
            this.Word});
            this.dgvPerusalDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPerusalDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPerusalDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvPerusalDetail.Name = "dgvPerusalDetail";
            this.dgvPerusalDetail.Size = new System.Drawing.Size(762, 121);
            this.dgvPerusalDetail.TabIndex = 0;
            this.dgvPerusalDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerusalDetail_CellDoubleClick);
            // 
            // DetailId
            // 
            this.DetailId.DataPropertyName = "Id";
            this.DetailId.HeaderText = "Id";
            this.DetailId.Name = "DetailId";
            this.DetailId.Visible = false;
            // 
            // colDetailWordId
            // 
            this.colDetailWordId.DataPropertyName = "WordId";
            this.colDetailWordId.HeaderText = "wordId";
            this.colDetailWordId.Name = "colDetailWordId";
            this.colDetailWordId.Visible = false;
            // 
            // Word
            // 
            this.Word.DataPropertyName = "WordName";
            this.Word.HeaderText = "Word";
            this.Word.Name = "Word";
            this.Word.Width = 200;
            // 
            // FrmPerusal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 462);
            this.Controls.Add(this.panelPerusalDetail);
            this.Controls.Add(this.pnlPerusalHeader);
            this.Name = "FrmPerusal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perusal";
            this.Load += new System.EventHandler(this.FrmPerusal_Load);
            this.pnlPerusalHeader.ResumeLayout(false);
            this.pnlPerusalHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerusalHeader)).EndInit();
            this.panelPerusalDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerusalDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPerusalHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtToWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPerusalHeader;
        private System.Windows.Forms.Button btnDeletePerusalHeader;
        private System.Windows.Forms.Button btnSavePerusalHeader;
        private System.Windows.Forms.Panel panelPerusalDetail;
        private System.Windows.Forms.Button btnDeletePerusalDetail;
        private System.Windows.Forms.DataGridView dgvPerusalDetail;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblShowWord;
        private System.Windows.Forms.Button btnPerusalDetail;
        private System.Windows.Forms.Button btnPerusalHeader;
        private System.Windows.Forms.Label lblEngDesc;
        private System.Windows.Forms.Label lblFarsiDesc;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnShowAnswer;
        private System.Windows.Forms.Button btnGetNextWord;
        private System.Windows.Forms.Label lblSymphonic;
        private System.Windows.Forms.Label lblSynonym;
        private System.Windows.Forms.Button btnGetPrevWord;
        private System.Windows.Forms.Button btnPrintPerusal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailWordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
    }
}
using System.Data;
using System.Windows.Forms;

namespace Lexicon.Presentation.UserControls.LookUp
{
    public partial class FrmVsLookUp : Form
    {
        private DataTable _dataTable;
        public FrmVsLookUp()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            _dataTable = new DataTable();
            dgvVsLookUp.AutoGenerateColumns = false;
            dgvVsLookUp.AllowUserToAddRows = false;
            dgvVsLookUp.AllowUserToDeleteRows = false;
            dgvVsLookUp.ReadOnly = true;
            txtSearch.ReadOnly = true;
            txtSearch.TabStop = false;
            btnExit.TabStop = false;
        }

        private int lastRowIndex = 0, lastColIndex = 0;

        public string KeyColumnName { get; set; }
        public string IdColumnName { get; set; }
        public string DescColumnName { get; set; }
        public bool MultiSelection { get; set; } = false;
        public string ValueId { get; set; }
        public string ValueKey { get; set; }
        public string ValueDesc { get; set; }

        public void AddColumn(string colName, string headerText, string dataPropertyName, int width, bool visible)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = colName,
                HeaderText = headerText,
                Width = width,
                DataPropertyName = dataPropertyName,
                Visible = visible
            };
            dgvVsLookUp.Columns.Add(col);
        }

        public void ResetColumn()
        {
            dgvVsLookUp.Columns.Clear();
        }

        public void SetDataSource(object dataSource)
        {
            dgvVsLookUp.DataSource = dataSource;
            _dataTable = GetDataTableFromGrid(dgvVsLookUp);
            dgvVsLookUp.DataSource = _dataTable;
        }

        public string GetCode()
        {
            string result = string.Empty;
            if (GridHasRows())
            {
                if (this.MultiSelection)
                {}
                else
                {
                    if (dgvVsLookUp.CurrentRow != null)
                        result = dgvVsLookUp.CurrentRow.Cells[KeyColumnName].Value.ToString();
                }
            }
            else
            {}

            return result;
        }

        private bool GridHasRows()
        {
            return dgvVsLookUp.RowCount > 0;
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            FilterGrid();
//            LookUpGrid(txtSearch.Text.Trim());
        }

        private void ResetFilter()
        {
            txtSearch.Clear();
            _dataTable.DefaultView.RowFilter = string.Empty;
            SetCurrentCell();
        }
        private void FilterGrid()
        {
            if (!GridHasRows())
            {
                ResetFilter();
            }
            if(dgvVsLookUp.CurrentCell == null) return;

            SetGridCurrentCell();
            _dataTable.DefaultView.RowFilter = string.Format(dgvVsLookUp.Columns[dgvVsLookUp.CurrentCell.ColumnIndex].DataPropertyName + " like '%{0}%'", txtSearch.Text);
            SetCurrentCell();
        }

        private void SetCurrentCell()
        {
            if (GridHasRows())
            {
                dgvVsLookUp.CurrentCell =
                    dgvVsLookUp[this.lastColIndex, dgvVsLookUp.RowCount - 1 > this.lastRowIndex ? this.lastRowIndex : dgvVsLookUp.RowCount - 1];
            }
        }
        private void SetGridCurrentCell()
        {
            if (GridHasRows())
            {
                this.lastColIndex = dgvVsLookUp.CurrentCell.ColumnIndex;
                this.lastRowIndex = dgvVsLookUp.CurrentCell.RowIndex;
            }
        }

        private void LookUpGrid(string lookupWord)
        {
            if (dgvVsLookUp.CurrentCell == null) return;

            foreach (DataGridViewRow r in dgvVsLookUp.Rows)
            {
                if (string.IsNullOrWhiteSpace(lookupWord))
                {
                    dgvVsLookUp.Rows[r.Index].Selected = false;
                }
                else if ((r.Cells[dgvVsLookUp.CurrentCell.ColumnIndex].Value).ToString().ToUpper().Contains(lookupWord.ToUpper()))
                {
                    dgvVsLookUp.Rows[r.Index].Visible = true;
                    dgvVsLookUp.Rows[r.Index].Selected = true;
                }
                else
                {
//                    dgvVsLookUp.CurrentCell = null;
                    dgvVsLookUp.Rows[r.Index].Selected = false;
                }
            }
        }

        private void dgvVsLookUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Space))
            {
                txtSearch.Text = txtSearch.Text + e.KeyChar;
                SetSearchLabelCaption();
            }

            if (e.KeyChar == (char) 8)
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = txtSearch.Text.Remove(txtSearch.Text.Length - 1);
                }
            }

            if (e.KeyChar == (char)27)
            {
                CloseForm();
            }
        }

        private void SetSearchLabelCaption()
        {
            if (dgvVsLookUp.CurrentCell != null)
            {
                lblSearch.Text = @"Search By " + dgvVsLookUp.Columns[dgvVsLookUp.CurrentCell.ColumnIndex].HeaderText + @" :";
                txtSearch.Left = lblSearch.Left + lblSearch.Width + 10;
            }
        }

        private void CloseForm()
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        private void SetResultAndClose()
        {
            if(!GridHasRows())return;

            SetResultValues();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetResultValues()
        {
            if (dgvVsLookUp.CurrentRow != null)
            {
                this.ValueId = dgvVsLookUp.CurrentRow.Cells[IdColumnName].Value.ToString();
                this.ValueKey = dgvVsLookUp.CurrentRow.Cells[KeyColumnName].Value.ToString();
                this.ValueDesc = dgvVsLookUp.CurrentRow.Cells[DescColumnName].Value.ToString();
            }
            else
            {
                this.ValueId = string.Empty;
                this.ValueKey = string.Empty;
                this.ValueDesc = string.Empty;
            }
        }

        public bool SetResultFromCode(string code)
        {
            ResetFilter();
            if (GridHasRows())
            {
                var keyColumn = dgvVsLookUp.Columns[KeyColumnName];
                if (keyColumn != null)
                {
                    _dataTable.DefaultView.RowFilter = string.Format(keyColumn.DataPropertyName + " = '{0}'", code);
                    SetResultValues();
                    return !string.IsNullOrWhiteSpace(this.ValueDesc);
                }
            }
            return false;
        }
        private void FrmVsLookUp_Load(object sender, System.EventArgs e)
        {
            ResetFilter();
            if (!GridHasRows())
            {
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
            dgvVsLookUp.Select();
        }

        private void dgvVsLookUp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SetResultAndClose();
            }
        }

        private void dgvVsLookUp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetResultAndClose();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public DataTable GetDataTableFromGrid(DataGridView dgv)
        {
            var dt = new DataTable();
            if (dgv.RowCount <= 0) return dt;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }
    }
}
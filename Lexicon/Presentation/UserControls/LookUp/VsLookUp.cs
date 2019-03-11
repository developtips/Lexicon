using System.Drawing;
using System.Windows.Forms;

namespace Lexicon.Presentation.UserControls.LookUp
{
    public partial class VsLookUp : UserControl
    {
        private FrmVsLookUp FrmLookUp;

        public VsLookUp()
        {
            InitializeComponent();
            InitializeForm();
            InitializeControl();
        }

        private void InitializeControl()
        {
            txtDesc.ReadOnly = true;
            txtDesc.TabStop = false;
            btnVsLookUpSearch.TabStop = false;
        }


        private void InitializeForm()
        {
            FrmLookUp = new FrmVsLookUp();
        }

        public string KeyColumnName
        {
            get { return this.FrmLookUp.KeyColumnName; }
            set { this.FrmLookUp.KeyColumnName = value; }
        }

        public string DescColumnName
        {
            get { return this.FrmLookUp.DescColumnName; }
            set { this.FrmLookUp.DescColumnName = value; }
        }

        public string IdColumnName
        {
            get { return this.FrmLookUp.IdColumnName; }
            set { this.FrmLookUp.IdColumnName = value; }
        }

        public string KeyValue { get; set; } = string.Empty;
        public string IdValue { get; set; } = string.Empty;
        public string DescriptionValue { get; set; } = string.Empty;

        public bool MultiSelection
        {
            get { return this.FrmLookUp.MultiSelection; }
            set { this.FrmLookUp.MultiSelection = value; }
        }

        public string LookUpCaption
        {
            get { return this.FrmLookUp.Text; }
            set { this.FrmLookUp.Text = value; }
        }

        public int CodeWidth
        {
            get { return pnlCode.Width; }
            set { pnlCode.Width = value; }
        }

        public bool HasResult { get; set; } = false;

        public void ResetColumn()
        {
            FrmLookUp.ResetColumn();
        }

        public void AddColumn(string colName, string headerText, string dataPropertyName, int width)
        {
            FrmLookUp.AddColumn(colName, headerText, dataPropertyName, width, true);
        }

        public void AddColumn(string colName, string headerText, string dataPropertyName, int width, bool visible)
        {
            FrmLookUp.AddColumn(colName, headerText, dataPropertyName, width, visible);
        }

        public void SetDataSource(object dataSource)
        {
            FrmLookUp.SetDataSource(dataSource);
        }

        private void btnRegVsLookUpSearch_Click(object sender, System.EventArgs e)
        {
            ShowModalForm();
        }

        private void ShowModalForm()
        {
            ClearFields();
            this.FrmLookUp.StartPosition = FormStartPosition.Manual;
            this.FrmLookUp.Location = this.PointToScreen(Point.Empty);

            if (this.FrmLookUp.ShowDialog() == DialogResult.OK)
            {
                SetTextBoxSpecification();
                txtCode.Select();
            }
        }

        public new void Select()
        {
            txtCode.Select();
        }

        private void ClearFields()
        {
            txtCode.Clear();
            txtDesc.Clear();
            this.KeyValue = string.Empty;
            this.DescriptionValue = string.Empty;
            this.IdValue = string.Empty;
            HasResult = false;
        }

        public void Clear()
        {
            this.ClearFields();
        }

        private void SetTextBoxSpecification()
        {
            txtCode.Text = FrmLookUp.ValueKey;
            this.KeyValue = FrmLookUp.ValueKey;

            txtDesc.Text = FrmLookUp.ValueDesc;
            this.DescriptionValue = FrmLookUp.ValueDesc;

            this.IdValue = FrmLookUp.ValueId;

            HasResult = true;
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Space)
            {
                ShowModalForm();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtCode.Text.Trim()))
                {
                    SetValue(txtCode.Text);
                }
            }
        }

        public void SetValue(string code)
        {
            if (this.FrmLookUp.SetResultFromCode(code))
            {
                SetTextBoxSpecification();
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                txtDesc.Clear();
                this.HasResult = false;
            }
        }
    }
}
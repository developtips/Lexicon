using System.Windows.Forms;

namespace Lexicon.Presentation.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tsmiWords_Click(object sender, System.EventArgs e)
        {
            FrmWords frm = new FrmWords();
            frm.Show();
        }

        private void tsmiPerusalWord_Click(object sender, System.EventArgs e)
        {
            FrmPerusal frmPerusal = new FrmPerusal();
            frmPerusal.Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Ikco.Data;
using Lexicon.Class;
using Lexicon.DAL;
using Lexicon.DAL.Model;
using Lexicon.Properties;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace Lexicon.Presentation.Forms
{
    public partial class FrmPerusal : Form
    {
        private PerusalItrate _perusalItrate;

        public FrmPerusal()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
        }

        private void LoadPerusalHeader()
        {
            var dbContext = MyDbContext.Instance;

            var predicate = PredicateBuilder.True<PerusalHeader>();
            var items = dbContext.PerusalHeaders.Where(predicate)
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.FromWord,
                    c.ToWord,
                    c.Comment,
                    ShCreateDate = Functions.ConvertDateToShamsi(c.CreateDate, "D"),
                    c.Details.Count
                });

            dgvPerusalHeader.AutoGenerateColumns = false;
            dgvPerusalHeader.DataSource = items.AsNoTracking().ToList();
        }

        private void LoadPerusalDetail()
        {
            if (dgvPerusalHeader.CurrentRow == null) return;

            var headerId = Convert.ToInt32(dgvPerusalHeader.CurrentRow.Cells["Id"].Value);

            var dbContext = MyDbContext.Instance;
            var predicate = PredicateBuilder.True<PerusalDetail>();
            predicate = predicate.And(c => c.HeaderId == headerId);

            var items = dbContext.PerusalDetails.Where(predicate)
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.WordId,
                    c.Word.WordName
                });

            dgvPerusalDetail.AutoGenerateColumns = false;
            dgvPerusalDetail.DataSource = items.AsNoTracking().ToList();
        }

        private void ClearControls()
        {
            txtToWord.Clear();
            txtFromWord.Clear();
            txtComment.Clear();
        }

        private void FrmPerusal_Load(object sender, System.EventArgs e)
        {
            try
            {
                LoadPerusalHeader();
                SetTotalCount();
                SetAnswerLabelText();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void SetAnswerLabelText()
        {
            lblEngDesc.Text = "English Desc";
            lblFarsiDesc.Text = "Farsi Desc";
            lblSymphonic.Text = "Symphonics";
            lblSynonym.Text = "Synonyms";
        }

        private void SetTotalCount()
        {
            var dbContext = MyDbContext.Instance;
            lblTotalCount.Text = @"Total Count: " + dbContext.Words.Count();
        }

        private void btnSavePerusalHeader_Click(object sender, EventArgs e)
        {
            try
            {
                SavePerusalHeader();
                LoadPerusalHeader();
                ClearControls();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePerusalHeader()
        {
            ValidationInputWord();

            var dbContext = MyDbContext.Instance;
            var perusalHeader = new PerusalHeader();

            perusalHeader.FromWord = Convert.ToInt32(txtFromWord.Text);
            perusalHeader.ToWord = Convert.ToInt32(txtToWord.Text);
            perusalHeader.Comment = string.IsNullOrWhiteSpace(txtComment.Text) ? null : txtComment.Text;
            perusalHeader.CreateDate = DateTime.Now;

            dbContext.PerusalHeaders.Add(perusalHeader);
            dbContext.SaveChanges();
        }

        private void ValidationInputWord()
        {
            int i;
            if (!int.TryParse(txtFromWord.Text, out i))
            {
                throw new ApplicationException("FromWord Is Incorrect!");
            }
            if (!int.TryParse(txtToWord.Text, out i))
            {
                throw new ApplicationException("ToWord Is Incorrect!");
            }
        }

        private void btnDeletePerusalHeader_Click(object sender, EventArgs e)
        {
            try
            {
                DeletePerusalHeader();
                LoadPerusalHeader();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletePerusalHeader()
        {
            if (!GridHeaderHasRows()) return;
            var dbContext = MyDbContext.Instance;

            var row = dgvPerusalHeader.CurrentRow;
            if (row == null) return;

            var id = Convert.ToInt32(row.Cells["Id"].Value);
            var item = dbContext.PerusalHeaders.Find(id);

            if (item != null)
            {
                if (
                    MessageBox.Show(@"Are You Sure? " + "\n\r" + item.FromWord + @" To: " + item.ToWord, "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    dbContext.PerusalHeaders.Remove(item);
                    dbContext.SaveChanges();
                    LoadPerusalHeader();
                }
            }
        }

        private void btnPerusalHeader_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAnswerLabels();
                DoPerusalHeader();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DoPerusalHeader()
        {
            int toWord = -1, fromWord = -1;
            var dbContext = MyDbContext.Instance;
            SetFromAndToWord(ref fromWord, ref toWord);
            var items = GetItemsToDoPerusal(dbContext, toWord, fromWord - 1);
            CheckValidateItems(items);
            SetPerusalItrate(items);
            ItrateItemsTodoPerusal(true);
        }

        private void SetPerusalItrate(List<Word> items)
        {
            this._perusalItrate = new PerusalItrate(items);
        }

        private void CheckValidateItems(List<Word> items)
        {
            if (items == null || items.Count <= 0)
            {
                throw new ApplicationException("Items Is Empty!");
            }
        }

        private void ItrateItemsTodoPerusal(bool forward)
        {
            if (this._perusalItrate == null || !this._perusalItrate.HasValue()) return;

            var word = forward ? _perusalItrate.GetNextWord() : _perusalItrate.GetPrevWord();
            if (word != null)
            {
                lblShowWord.Text = word.WordName;
            }
        }

        private int SetFromAndToWord(ref int fromWord, ref int toWord)
        {
            if (GridHeaderHasRows())
            {
                fromWord = Convert.ToInt32(dgvPerusalHeader.CurrentRow.Cells["FromWord"].Value);
                toWord = Convert.ToInt32(dgvPerusalHeader.CurrentRow.Cells["ToWord"].Value);
            }
            else
            {
                throw new ApplicationException("Perusal Header Is Empty!");
            }
            return fromWord;
        }

        private static List<Word> GetItemsToDoPerusal(MyDbContext dbContext, int toWord, int fromWord)
        {
            return dbContext.Words.OrderBy(c => c.Id).Skip(fromWord).Take(toWord - fromWord).AsNoTracking().ToList();
        }

        private static List<Word> GetItemsToDoPerusalDetail(MyDbContext dbContext, int headerId)
        {
            var detailIds = dbContext.PerusalDetails.Where(c => c.HeaderId == headerId).Select(c => c.WordId);
            return dbContext.Words.Where(c => detailIds.Contains(c.Id)).ToList();
        }

        private bool GridHeaderHasRows()
        {
            return dgvPerusalHeader.RowCount > 0;
        }

        private void btnGetNextWord_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAnswerLabels();
                ItrateItemsTodoPerusal(true);
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetPrevWord_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAnswerLabels();
                ItrateItemsTodoPerusal(false);
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                ClearLabelAndShowAnswerFromItrator();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearLabelAndShowAnswerFromItrator()
        {
            IsValidItrotor();
            ClearAnswerLabels();
            ShowAnswer(GetCurrentWordIdFromItrator());
        }

        private void IsValidItrotor()
        {
            if (this._perusalItrate == null || !this._perusalItrate.HasValue())
            {
                throw new ApplicationException("Itrator Is Null!!!");
            }
        }

        private int GetCurrentWordIdFromItrator()
        {
            return this._perusalItrate.GetCurrentWord().Id;
        }

        private void ShowAnswer(int currentWordId)
        {
            ShowFarsiDescs(currentWordId);
            ShowEngDescs(currentWordId);
            ShowSynonyms(currentWordId);
            ShowSymphonics(currentWordId);
        }

        private void ShowSymphonics(int currentWordId)
        {
            var dbContext = MyDbContext.Instance;
            lblSymphonic.Text = String.Join(",",
                dbContext.Symphonics.Where(c => c.WordId == currentWordId).Select(c => c.SymphonicWord.WordName));
        }

        private void ShowSynonyms(int currentWordId)
        {
            var dbContext = MyDbContext.Instance;
            lblSynonym.Text = String.Join(",",
                dbContext.Synonyms.Where(c => c.WordId == currentWordId).Select(c => c.SynonymWord.WordName));
        }

        private void ShowEngDescs(int currentWordId)
        {
            var dbContext = MyDbContext.Instance;
            lblEngDesc.Text = String.Join(",",
                dbContext.EnglishDescriptions.Where(c => c.WordId == currentWordId).Select(c => c.Description));
        }

        private void ShowFarsiDescs(int currentWordId)
        {
            var dbContext = MyDbContext.Instance;
            lblFarsiDesc.Text = String.Join(",",
                dbContext.FarsiDescriptions.Where(c => c.WordId == currentWordId).Select(c => c.Description));
        }

        private void ClearAnswerLabels()
        {
            lblFarsiDesc.Text = string.Empty;
            lblEngDesc.Text = string.Empty;
            lblSynonym.Text = string.Empty;
            lblSymphonic.Text = string.Empty;
        }

        private void btnPerusalDetail_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAnswerLabels();
                DoPerusalDetail();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DoPerusalDetail()
        {
            if (!GridDetailHasRows()) return;
            var headerId = Convert.ToInt32(dgvPerusalHeader.CurrentRow.Cells["Id"].Value);

            var dbContext = MyDbContext.Instance;

            var items = GetItemsToDoPerusalDetail(dbContext, headerId);
            CheckValidateItems(items);
            SetPerusalItrate(items);
            ItrateItemsTodoPerusal(true);
        }

        private bool GridDetailHasRows()
        {
            return dgvPerusalDetail.RowCount > 0;
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                AddCurrentWordToList();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void AddCurrentWordToList()
        {
            if (this._perusalItrate == null || !this._perusalItrate.HasValue()) return;
            if (!GridHeaderHasRows()) return;

            var headerId = Convert.ToInt32(dgvPerusalHeader.CurrentRow.Cells["Id"].Value);

            var addToListWord = new PerusalDetail
            {
                HeaderId = headerId,
                WordId = this._perusalItrate.GetCurrentWord().Id
            };

            var dbContext = MyDbContext.Instance;
            dbContext.PerusalDetails.Add(addToListWord);
            dbContext.SaveChanges();

            LoadPerusalDetail();
        }

        private void dgvPerusalHeader_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }

        private void dgvPerusalHeader_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPerusalDetail();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletePerusalDetail_Click(object sender, EventArgs e)
        {
            try
            {
                DeletePerusalDetail();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletePerusalDetail()
        {
            if (!GridDetailHasRows()) return;
            var dbContext = MyDbContext.Instance;

            var row = dgvPerusalDetail.CurrentRow;
            if (row == null) return;

            var id = Convert.ToInt32(row.Cells["DetailId"].Value);
            var item = dbContext.PerusalDetails.Find(id);

            if (item != null)
            {
                if (
                    MessageBox.Show(@"Are You Sure? " + "\n\r" + row.Cells["Word"].Value, "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    dbContext.PerusalDetails.Remove(item);
                    dbContext.SaveChanges();
                    LoadPerusalDetail();
                }
            }
        }

        private void btnPrintPerusal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GridHeaderHasRows()) return;

                PrintPerusalDetail();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private List<int> GetSelectedHeader()
        {
            List<int> selectedItems = new List<int>();
            if (GridHeaderHasRows())
            {
                foreach (DataGridViewRow row in dgvPerusalHeader.SelectedRows)
                {
                    selectedItems.Add(Convert.ToInt32(row.Cells["Id"].Value));
                }
            }
            return selectedItems;
        }

        private void PrintPerusalDetail()
        {
            var fromWord = dgvPerusalHeader.CurrentRow.Cells["FromWord"].Value.ToString();
            var toWord = dgvPerusalHeader.CurrentRow.Cells["ToWord"].Value.ToString();
            List<int> headerIds = GetSelectedHeader();

            var dbContext = MyDbContext.Instance;
            var predicate = PredicateBuilder.True<PerusalDetail>();
            predicate = predicate.And(c => headerIds.Contains(c.HeaderId));

            var items = dbContext.PerusalDetails.Where(predicate)
                .Select(c => new
                {
                    c.Id,
                    c.WordId,
                    c.Word.WordName,
                }).AsEnumerable().Select(c => new
                {
                    c.Id,
                    c.WordName,
                    FarsiDescs =
                    String.Join(",",
                        dbContext.FarsiDescriptions.Where(s => s.WordId == c.WordId).Select(s => s.Description)),
                    EngDescs =
                    String.Join(",",
                        dbContext.EnglishDescriptions.Where(s => s.WordId == c.WordId).Select(s => s.Description)),
                    Synonyms =
                    String.Join(",",
                        dbContext.Synonyms.Where(s => s.WordId == c.WordId).Select(s => s.SynonymWord.WordName)),
                    Symphonics =
                    String.Join(",",
                        dbContext.Symphonics.Where(s => s.WordId == c.WordId).Select(s => s.SymphonicWord.WordName))
                })
                .ToList();


            var report = new StiReport();
            if (true) //
            {
                string path = "";
                string[] s = {"\\bin"};
                path = Environment.CurrentDirectory + "\\Reports";
                path = path + "\\RptPerusalDetail.mrt";
                report.Load(path);


                StiText txtFromWord = report.GetComponentByName("txtFromWord") as StiText;
                txtFromWord.Text.Value = fromWord;

                StiText txtToWord = report.GetComponentByName("txtToWord") as StiText;
                txtToWord.Text.Value = toWord;


                //StiImage imgLogo = report.GetComponentByName("imgLogo") as StiImage;
                //imgLogo.Image = Resources.Resource1.IKCO_logo_FA_Small;

                /*use List*/
                report.Dictionary.Report.BusinessObjectsStore.Clear();

                report.RegBusinessObject("Words", items);

                report.Dictionary.SynchronizeBusinessObjects();
                /*use List*/
                report.Dictionary.Synchronize();
                report.Compile();
                report.Render(true);
                report.Show(false);
            }
            this.Cursor = Cursors.Default;
        }

        private int GetCurrentWordIdFromDetailGrid()
        {
            return GridDetailHasRows()
                ? Convert.ToInt32(dgvPerusalDetail.CurrentRow.Cells["colDetailWordId"].Value)
                : -1;
        }

        private void dgvPerusalDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClearAnswerLabels();
                ShowAnswer(GetCurrentWordIdFromDetailGrid());
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
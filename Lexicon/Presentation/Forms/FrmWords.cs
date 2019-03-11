using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Ikco.Data;
using Lexicon.DAL;
using Lexicon.DAL.Model;

namespace Lexicon.Presentation.Forms
{
    public partial class FrmWords : Form
    {
        private readonly MyDbContext _dbContext;
        private int currentWordId = -1;

        private IList<Word> wholeWords;

        public FrmWords()
        {
            InitializeComponent();
            _dbContext = MyDbContext.Instance;
        }

        private void SaveWord()
        {
            ValidationInputWord();

            _dbContext.Reset();
            var word = new Word
            {
                WordName = txtWord.Text.Trim(),
                CreateDate = DateTime.Now
            };

            _dbContext.Words.Add(word);
            _dbContext.SaveChanges();
        }

        private void LoadWords()
        {
            var predicate = PredicateBuilder.True<Word>();
            predicate = predicate.And(c => true);

            this.wholeWords = _dbContext.Words.Where(predicate)
                .OrderByDescending(c => c.Id).Where(predicate).AsNoTracking().ToList().AsEnumerable()
                .Select(c => new Word()
                {
                    Id = c.Id,
                    WordName = c.WordName,
                    CreateDate = c.CreateDate,
                    ShCreateDate = MiladiToShamsi(c.CreateDate) //Functions.ConvertDateToShamsi(c.CreateDate, "D")
                }).ToList();

            dgvWords.AutoGenerateColumns = false;
            dgvWords.DataSource = this.wholeWords;
        }

        private void ValidationInputWord()
        {
            if (string.IsNullOrWhiteSpace(txtWord.Text))
                throw new ApplicationException("Word Is Empty!");
            CheckRepeatedWord();
        }

        public string MiladiToShamsi(DateTime myDate)
        {
            PersianCalendar dateNow = new PersianCalendar();
            return dateNow.GetYear(myDate) + "/" + dateNow.GetMonth(myDate) + "/" + dateNow.GetDayOfMonth(myDate);
        }

        private void CheckRepeatedWord()
        {
            var word = this._dbContext.Words.FirstOrDefault(c => c.WordName == txtWord.Text.Trim());
            if (word != null)
            {
                throw new ApplicationException("Word Is Repeated! \n\r =>" + word.WordName);
            }
        }

        private void FrmWords_Load(object sender, System.EventArgs e)
        {
            try
            {
                LoadWords();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegWord_Click(object sender, EventArgs e)
        {
            try
            {
                SaveNewWordAndSetCurrentWord();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveNewWordAndSetCurrentWord()
        {
            SaveWord();
            LoadWords();
            SetCurrentWord();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EditWord();
                LoadWords();
                LookUpCurrent(txtWord.Text.Trim());
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void LookUpCurrent(string word)
        {
            LookUpGrid(word);
        }

        private void LookUpGrid(string lookupWord)
        {
            dgvWords.DataSource =
                new List<Word>(this.wholeWords.Where(c => c.WordName.ToUpper().Contains(lookupWord.ToUpper())).ToList());
        }

        private void EditWord()
        {
            if (string.IsNullOrEmpty(txtWord.Text)) return;

            if (
                MessageBox.Show("Are You Sure? \n\r" + this.Text, "Edit", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
            {
                int id = this.currentWordId;
                var word = _dbContext.Words.Find(id);
                word.WordName = txtWord.Text.Trim();
                _dbContext.SaveChanges();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LookUpGrid(txtSearch.Text.Trim());
        }

        private void dgvWords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetCurrentWord();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void SetCurrentWord()
        {
            if (dgvWords.CurrentRow == null) return;
            txtWord.Text = dgvWords.CurrentRow.Cells["colWordName"].Value.ToString();
            this.Text = "Current Word is: " + txtWord.Text;
            ClearOtherDescs();
            SetCurrentWordId();
            LoadWordSpecifications();
        }

        private void ClearOtherDescs()
        {
            txtFarsiDescription.Clear();
            txtFarsiComment.Clear();
            txtEngDesc.Clear();
            txtEngComment.Clear();

            lkpSymphonic.Clear();
            lkpSynonyms.Clear();
        }

        private void LoadWordSpecifications()
        {
            LoadFarsiDescription();
            LoadEngDescription();
            SetSynonymLookUp();
            SetSymphonicLookUp();
            LoadSynonym();
            LoadSymphonic();
        }

        private void SetCurrentWordId()
        {
            this.currentWordId = Convert.ToInt32(dgvWords.CurrentRow.Cells[0].Value);
        }

        private void SetSynonymLookUp()
        {
            lkpSynonyms.ResetColumn();
            lkpSynonyms.AddColumn("Id", "", "Id", 60);
            lkpSynonyms.AddColumn("WordName", "WordName", "WordName", 150);

            var items = _dbContext.Words
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.WordName,
                    c.CreateDate
                });
            lkpSynonyms.KeyColumnName = "Id";
            lkpSynonyms.IdColumnName = "Id";
            lkpSynonyms.DescColumnName = "WordName";
            lkpSynonyms.SetDataSource(items.AsNoTracking().ToList());
        }

        private void SetSymphonicLookUp()
        {
            lkpSymphonic.ResetColumn();
            lkpSymphonic.AddColumn("Id", "", "Id", 60);
            lkpSymphonic.AddColumn("WordName", "WordName", "WordName", 150);

            var items = _dbContext.Words
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.WordName,
                    c.CreateDate
                });
            lkpSymphonic.KeyColumnName = "Id";
            lkpSymphonic.IdColumnName = "Id";
            lkpSymphonic.DescColumnName = "WordName";
            lkpSymphonic.SetDataSource(items.AsNoTracking().ToList());
        }

        private void LoadEngDescription()
        {
            var predicate = PredicateBuilder.True<EnglishDescription>();
            predicate = predicate.And(c => c.WordId == currentWordId);

            var items = _dbContext.EnglishDescriptions.Where(predicate)
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.WordId,
                    c.Description,
                    c.Comment
                });

            dgvEngDesc.AutoGenerateColumns = false;
            dgvEngDesc.DataSource = items.AsNoTracking().ToList();
        }

        private void LoadFarsiDescription()
        {
            var predicate = PredicateBuilder.True<FarsiDescription>();
            predicate = predicate.And(c => c.WordId == currentWordId);

            var items = _dbContext.FarsiDescriptions.Where(predicate)
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.WordId,
                    c.Description,
                    c.Comment
                });

            dgvFarsiDescription.AutoGenerateColumns = false;
            dgvFarsiDescription.DataSource = items.AsNoTracking().ToList();
        }

        private void btnRegFarsiDescription_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAndReadyToNewFarsiDescription();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveAndReadyToNewFarsiDescription()
        {
            SaveFarsiDescription();
            LoadFarsiDescription();
            ClearFarsiFields();
            txtFarsiDescription.Select();
        }

        private void ClearFarsiFields()
        {
            txtFarsiDescription.Clear();
            txtFarsiComment.Clear();
        }

        private void SaveFarsiDescription()
        {
            ValidateCurrentWordSet();
            ValidationInputFarsiDescription();

            _dbContext.Reset();
            var farsiDescription = new FarsiDescription
            {
                WordId = currentWordId,
                Description = txtFarsiDescription.Text,
                Comment = string.IsNullOrWhiteSpace(txtFarsiComment.Text)
                    ? null
                    : txtFarsiComment.Text.Trim()
            };

            _dbContext.FarsiDescriptions.Add(farsiDescription);
            _dbContext.SaveChanges();
        }

        private void ValidateCurrentWordSet()
        {
            if (this.currentWordId == -1)
            {
                throw new ApplicationException("Current word is not set!");
            }
        }

        private void ValidationInputFarsiDescription()
        {
            if (string.IsNullOrWhiteSpace(txtFarsiDescription.Text))
            {
                throw new ApplicationException("txtFarsiDescription Is Empty!");
            }
        }

        private void btnEditFarsiDescription_Click(object sender, EventArgs e)
        {
            try
            {
                EditFarsiDescription();
                LoadFarsiDescription();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void EditFarsiDescription()
        {
            if (dgvFarsiDescription.RowCount <= 0) return;
            if (string.IsNullOrEmpty(txtFarsiDescription.Text)) return;

            if (
                MessageBox.Show("Are You Sure? \n\r" + txtFarsiDescription.Text, "Edit", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
            {
                int id = Convert.ToInt32(dgvFarsiDescription.CurrentRow.Cells["FarsiId"].Value);
                var farsiDescription = _dbContext.FarsiDescriptions.Find(id);
                farsiDescription.Description = txtFarsiDescription.Text.Trim();
                farsiDescription.Comment = string.IsNullOrWhiteSpace(txtFarsiComment.Text)
                    ? null
                    : txtFarsiComment.Text.Trim();
                _dbContext.SaveChanges();
            }
        }

        private void dgvFarsiDescription_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                txtFarsiDescription.Text = dgvFarsiDescription.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                txtFarsiComment.Text = Convert.ToString(dgvFarsiDescription.Rows[e.RowIndex].Cells[2].Value);
                txtFarsiDescription.Select();
            }
        }

        private void dgvEngDesc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                txtEngDesc.Text = dgvEngDesc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                txtEngComment.Text = Convert.ToString(dgvEngDesc.Rows[e.RowIndex].Cells[3].Value);
                txtEngDesc.Select();
            }
        }

        private void btnRegEngDesc_Click(object sender, EventArgs e)
        {
            try
            {
                SaveEngDescription();
                LoadEngDescription();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveEngDescription()
        {
            ValidateCurrentWordSet();
            ValidationInputEngDescription();

            _dbContext.Reset();
            var engdesc = new EnglishDescription
            {
                WordId = currentWordId,
                Description = txtEngDesc.Text,
                Comment = string.IsNullOrWhiteSpace(txtEngComment.Text)
                    ? null
                    : txtEngComment.Text.Trim()
            };

            _dbContext.EnglishDescriptions.Add(engdesc);
            _dbContext.SaveChanges();
        }

        private void ValidationInputEngDescription()
        {
            if (string.IsNullOrWhiteSpace(txtEngDesc.Text))
            {
                throw new ApplicationException("English Description Is Empty!");
            }
        }

        private void btnEditEngDesc_Click(object sender, EventArgs e)
        {
            try
            {
                EditEngDescription();
                LoadEngDescription();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void EditEngDescription()
        {
            if (dgvEngDesc.RowCount <= 0) return;
            if (string.IsNullOrEmpty(txtEngDesc.Text)) return;

            if (
                MessageBox.Show("Are You Sure? \n\r" + txtEngDesc.Text, "Edit", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
            {
                int id = Convert.ToInt32(dgvEngDesc.CurrentRow.Cells["EngDescId"].Value);
                var engDescription = _dbContext.EnglishDescriptions.Find(id);
                engDescription.Description = txtEngDesc.Text.Trim();
                engDescription.Comment = string.IsNullOrWhiteSpace(txtEngComment.Text)
                    ? null
                    : txtEngComment.Text.Trim();
                _dbContext.SaveChanges();
            }
        }

        private void btnRegSynonym_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSynonym();
                LoadSynonym();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSynonym()
        {
            var predicate = PredicateBuilder.True<Synonym>();
            predicate = predicate.And(c => c.WordId == currentWordId);

            var items = _dbContext.Synonyms.Where(predicate)
                .Select(c => new
                {
                    c.Id,
                    c.WordId,
                    c.SynonymWord.WordName,
                    FarsiDesc = c.SynonymWord.FarsiDescriptions.FirstOrDefault().Description
//                    FarsiDesc = _dbContext.FarsiDescriptions.FirstOrDefault(u => u.WordId == c.SynonymWordId).Description
                });

            dgvSynonym.AutoGenerateColumns = false;
            dgvSynonym.DataSource = items.AsNoTracking().ToList();
        }

        private void SaveSynonym()
        {
            ValidateCurrentWordSet();
            ValidationInputSynonym();

            _dbContext.Reset();
            var synonym = new Synonym
            {
                WordId = currentWordId,
                SynonymWordId = Convert.ToInt32(lkpSynonyms.IdValue)
            };

            _dbContext.Synonyms.Add(synonym);
            _dbContext.SaveChanges();
        }

        private void ValidationInputSynonym()
        {
            if (!lkpSynonyms.HasResult)
            {
                throw new ApplicationException("Synonym Is Empty!");
            }
        }

        private void btnDeleteSynonym_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteSynonym();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteSynonym()
        {
            if (dgvSynonym.RowCount <= 0) return;

            var row = dgvSynonym.CurrentRow;
            if (row == null) return;

            var id = Convert.ToInt32(row.Cells["colId"].Value);
            var item = _dbContext.Synonyms.Find(id);

            if (item != null)
            {
                if (
                    MessageBox.Show(@"Are You Sure? " + "\n\r" + item.Id + " " + row.Cells["conSynonymWordName"].Value,
                        "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    _dbContext.Synonyms.Remove(item);
                    _dbContext.SaveChanges();
                    LoadSynonym();
                }
            }
        }

        private void btnRegSymphonic_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSymphonic();
                LoadSymphonic();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSymphonic()
        {
            var predicate = PredicateBuilder.True<Symphonic>();
            predicate = predicate.And(c => c.WordId == currentWordId);

            var items = _dbContext.Symphonics.Where(predicate)
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.WordId,
                    c.SymphonicWord.WordName,
                    FarsiDesc = c.SymphonicWord.FarsiDescriptions.FirstOrDefault().Description
                });

            dgvSymphonic.AutoGenerateColumns = false;
            dgvSymphonic.DataSource = items.AsNoTracking().ToList();
        }

        private void SaveSymphonic()
        {
            ValidateCurrentWordSet();
            ValidationInputSymphonic();

            _dbContext.Reset();
            var symphonic = new Symphonic
            {
                WordId = currentWordId,
                SymphonicWordId = Convert.ToInt32(lkpSymphonic.IdValue)
            };

            _dbContext.Symphonics.Add(symphonic);
            _dbContext.SaveChanges();
        }

        private void ValidationInputSymphonic()
        {
            if (!lkpSymphonic.HasResult)
            {
                throw new ApplicationException("Symphonic Is Empty!");
            }
        }

        private void btnDeleteSymphonic_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteSymphonic();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteSymphonic()
        {
            if (dgvSymphonic.RowCount <= 0) return;

            var row = dgvSymphonic.CurrentRow;
            if (row == null) return;

            var id = Convert.ToInt32(row.Cells["colSymphonicId"].Value);
            var item = _dbContext.Symphonics.Find(id);

            if (item != null)
            {
                if (
                    MessageBox.Show(
                        @"Are You Sure? " + "\n\r" + item.SymphonicWordId + " " +
                        row.Cells["colSymphonicWordName"].Value, "Delete", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    _dbContext.Symphonics.Remove(item);
                    _dbContext.SaveChanges();
                    LoadSymphonic();
                }
            }
        }

        private void btnDeleteFarsiDescription_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteFarsiDescription();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteFarsiDescription()
        {
            if (dgvFarsiDescription.RowCount <= 0) return;

            var row = dgvFarsiDescription.CurrentRow;
            if (row == null) return;

            var id = Convert.ToInt32(row.Cells["FarsiId"].Value);
            var item = _dbContext.FarsiDescriptions.Find(id);

            if (item != null)
            {
                if (
                    MessageBox.Show(@"Are You Sure? " + "\n\r" + item.Description, "Delete", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    _dbContext.FarsiDescriptions.Remove(item);
                    _dbContext.SaveChanges();
                    LoadFarsiDescription();
                }
            }
        }

        private void btnDeleteEndDesc_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteEnglishDescription();
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteEnglishDescription()
        {
            if (dgvEngDesc.RowCount <= 0) return;

            var row = dgvEngDesc.CurrentRow;
            if (row == null) return;

            var id = Convert.ToInt32(row.Cells["EngDescId"].Value);
            var item = _dbContext.EnglishDescriptions.Find(id);

            if (item != null)
            {
                if (
                    MessageBox.Show(@"Are You Sure? " + "\n\r" + item.Description, "Delete", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    _dbContext.EnglishDescriptions.Remove(item);
                    _dbContext.SaveChanges();
                    LoadEngDescription();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                switch (keyData)
                {
                    case Keys.F1:
                        ReadyFormForNewWord();
                        break;
                    case Keys.F2:
                        ReadyFormForNewFarsiDesc();
                        break;
                    case Keys.F3:
                        ReadyFormForNewEngDesc();
                        break;
                    case Keys.F4:
                        ReadyFormForNewSynonym();
                        break;
                    case Keys.F5:
                        ReadyFormForNewSymphonic();
                        break;
                    case Keys.F12:
                        SetFocusWordGrid();
                        break;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                MessageBox.Show(ex.Message);
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void SetFocusWordGrid()
        {
            dgvWords.Select();
        }

        private void ReadyFormForNewSymphonic()
        {
            lkpSymphonic.Clear();
            lkpSymphonic.Select();
        }

        private void ReadyFormForNewSynonym()
        {
            lkpSynonyms.Clear();
            lkpSynonyms.Select();
        }

        private void ReadyFormForNewEngDesc()
        {
            txtEngDesc.Clear();
            txtEngComment.Clear();
            txtEngDesc.Select();
        }

        private void ReadyFormForNewFarsiDesc()
        {
            txtFarsiDescription.Clear();
            txtFarsiComment.Clear();
            txtFarsiDescription.Select();
        }

        private void ReadyFormForNewWord()
        {
            ClearOtherDescs();
            ClearWordFields();
            FocusStartNew();
        }

        private void FocusStartNew()
        {
            txtWord.Select();
        }

        private void ClearWordFields()
        {
            txtWord.Clear();
            txtSearch.Clear();
        }

        private void dgvWords_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                SetCurrentWord();
            }
        }

        private void txtFarsiDescription_Enter(object sender, EventArgs e)
        {
            ChangeKeyboardToFarsi();
        }

        private static void ChangeKeyboardToFarsi()
        {
            var original = InputLanguage.CurrentInputLanguage;
            var culture = System.Globalization.CultureInfo.GetCultureInfo("fa-IR");
            var language = InputLanguage.FromCulture(culture);
            if (InputLanguage.InstalledInputLanguages.IndexOf(language) >= 0)
                InputLanguage.CurrentInputLanguage = language;
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void txtEngDesc_Enter(object sender, EventArgs e)
        {
            ChangeKeyboardToEnglish();
        }

        private static void ChangeKeyboardToEnglish()
        {
            var original = InputLanguage.CurrentInputLanguage;
            var culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            var language = InputLanguage.FromCulture(culture);
            if (InputLanguage.InstalledInputLanguages.IndexOf(language) >= 0)
                InputLanguage.CurrentInputLanguage = language;
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void txtFarsiComment_Enter(object sender, EventArgs e)
        {
            ChangeKeyboardToFarsi();
        }

        private void txtWord_Enter(object sender, EventArgs e)
        {
            ChangeKeyboardToEnglish();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            ChangeKeyboardToEnglish();
        }

        private void txtEngComment_Enter(object sender, EventArgs e)
        {
            ChangeKeyboardToEnglish();
        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            LookUpGrid(txtWord.Text.Trim());
        }

        private void txtFarsiDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveAndReadyToNewFarsiDescription();
            }
        }

        private void txtEngDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveAndReadyToNewEnglishDescription();
            }
        }

        private void SaveAndReadyToNewEnglishDescription()
        {
            SaveEngDescription();
            LoadEngDescription();
            ClearEngFields();
            txtEngDesc.Select();
        }

        private void ClearEngFields()
        {
            txtEngDesc.Clear();
            txtEngComment.Clear();
        }

        private void txtWord_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveAndReadyToNewWord();
            }
        }

        private void SaveAndReadyToNewWord()
        {
            SaveNewWordAndSetCurrentWord();
        }
    }
}
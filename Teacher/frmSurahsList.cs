using Alrahman_Allama_Allquran.Global_Class;
using Alrahman_Allama_Allquran.Revision;
using Alrahman_Allama_Allquran.Student;
using alrahman_Allama_Alquran_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran.Teacher
{
    public partial class frmSurahsList : Form
    {
        public frmSurahsList()
        {
            InitializeComponent();
        }

        private string _JuzName = "";

        private int _StudentID = -1;

        clsStudent _Student;

        private string _JuzNumber = "";

        private clsJuzPagesRecord _JuzPagesRecords;

        byte MemorizedPageCount_ = 0;

        short CurrentMemorizingPageCount = 0;

        public frmSurahsList(string JuzName, string JuzNumber, int StudentID)
        {
            InitializeComponent();
            _JuzNumber = JuzNumber;
            _JuzName = JuzName;
            _StudentID = StudentID;
        }

        private string _GetAyetCountForJuz(string JuzName)
        {
            string Ayetcount = clsSurah.GetAyetcountInJuz(JuzName).ToString();
            return Ayetcount;
        }

        private void GetRevisionDateTime()
        {
            string LastRevisionDate = clsRevision_Record.GetLastRevisionByStudetnIDJuzID(_StudentID, Convert.ToInt16(_JuzNumber));
            if (!string.IsNullOrEmpty(LastRevisionDate))
            {
                txtLastRevisionDate.Text = LastRevisionDate.ToString();
                btnAddREvision.Enabled = true;
                btnAllStudentRecords.Enabled = true;
            }
            else
            {
                txtLastRevisionDate.Text = "There Is No Revision For This Juz";
                btnAllStudentRecords.Enabled = false;
            }
        }

        private int GetRevisionCount()
        {
            short RevisionCount = clsRevision_Record.GetRevisionCount(_StudentID, Convert.ToInt16(_JuzNumber));
            return RevisionCount;
        }

        private void GetRevisionCountByDelegate(object sender, int RevisionID)
        {
            int RevisionCount = 0;
            if (RevisionID != -1)
            {
                RevisionCount = GetRevisionCount();
                txtRevisionCount.Text = RevisionCount.ToString();
            }
        }

        private void EnableAllcheckBoxes(bool isEnabled = false)
        {
            if (isEnabled)
            {
                chbpage1.Enabled = true;
                chbpage2.Enabled = true;
                chbpage3.Enabled = true;
                chbpage4.Enabled = true;
                chbpage5.Enabled = true;
                chbpage6.Enabled = true;
                chbpage7.Enabled = true;
                chbpage8.Enabled = true;
                chbpage9.Enabled = true;
                chbpage10.Enabled = true;
                chbpage11.Enabled = true;
                chbpage12.Enabled = true;
                chbpage13.Enabled = true;
                chbpage14.Enabled = true;
                chbpage15.Enabled = true;
                chbpage16.Enabled = true;
                chbpage17.Enabled = true;
                chbpage18.Enabled = true;
                chbpage19.Enabled = true;
                chbpage20.Enabled = true;
            }
            else
            {
                chbpage1.Enabled = false;
                chbpage2.Enabled = false;
                chbpage3.Enabled = false;
                chbpage4.Enabled = false;
                chbpage5.Enabled = false;
                chbpage6.Enabled = false;
                chbpage7.Enabled = false;
                chbpage8.Enabled = false;
                chbpage9.Enabled = false;
                chbpage10.Enabled = false;
                chbpage11.Enabled = false;
                chbpage12.Enabled = false;
                chbpage13.Enabled = false;
                chbpage14.Enabled = false;
                chbpage15.Enabled = false;
                chbpage16.Enabled = false;
                chbpage17.Enabled = false;
                chbpage18.Enabled = false;
                chbpage19.Enabled = false;
                chbpage20.Enabled = false;
            }
        }

        private void LoadJuzRecordData()
        {
            byte UnMemorizedPageCount = 0;
            EnableAllcheckBoxes();
            if (_JuzPagesRecords != null)
            {
                CheckBox[] checkboxes = {chbpage1, chbpage2, chbpage3, chbpage4, chbpage5,
                                         chbpage6, chbpage7, chbpage8, chbpage9, chbpage10,
                                         chbpage11, chbpage12, chbpage13, chbpage14, chbpage15,
                                         chbpage16, chbpage17, chbpage18, chbpage19, chbpage20};

                short[] pageNumbers = { _JuzPagesRecords.pageNumber1, _JuzPagesRecords.pageNumber2, _JuzPagesRecords.pageNumber3,
                                        _JuzPagesRecords.pageNumber4, _JuzPagesRecords.pageNumber5, _JuzPagesRecords.pageNumber6,
                                        _JuzPagesRecords.pageNumber7, _JuzPagesRecords.pageNumber8, _JuzPagesRecords.pageNumber9,
                                        _JuzPagesRecords.pageNumber10, _JuzPagesRecords.pageNumber11, _JuzPagesRecords.pageNumber12,
                                        _JuzPagesRecords.pageNumber13, _JuzPagesRecords.pageNumber14, _JuzPagesRecords.pageNumber15,
                                        _JuzPagesRecords.pageNumber16, _JuzPagesRecords.pageNumber17, _JuzPagesRecords.pageNumber18,
                                        _JuzPagesRecords.pageNumber19, _JuzPagesRecords.pageNumber20 };

                for (int i = 0; i < checkboxes.Length; i++)
                {
                    if (pageNumbers[i] == 1)
                    {
                        checkboxes[i].Checked = true;
                        checkboxes[i].Enabled = true;
                        checkboxes[i].ForeColor = Color.Green;
                        MemorizedPageCount_ += 1;
                        txtMemorizedPageCount.Text = MemorizedPageCount_.ToString();
                        EnableNextCheckbox(checkboxes[i]);
                    }
                    else
                    {
                        checkboxes[i].Checked = false;
                        checkboxes[i].ForeColor = Color.Red;
                        UnMemorizedPageCount += 1;
                        txtUnMemorizedPageCount.Text = UnMemorizedPageCount.ToString();
                    }
                }
                if (MemorizedPageCount_ > 0)
                {
                    if (MemorizedPageCount_ == 20)
                    {
                        lblJuzMessage.Text = "Is The Best , This Juz Is Complited.";
                    }
                    btnAllStudentRecords.Enabled = true;
                    btnAddREvision.Enabled = true;
                }
                GetRevisionDateTime();
                txtRevisionCount.Text = GetRevisionCount().ToString();
            }
        }

        private void _ResetDefualtValues()
        {
            _JuzPagesRecords = new clsJuzPagesRecord();
            EnableAllcheckBoxes();
            txtMemorizedPageCount.Text = "0";
            txtUnMemorizedPageCount.Text = "0";
            txtLastRevisionDate.Text = "No Revision Avilibel";
            txtRevisionCount.Text = "0";
            dtpmemorizingStartDate.Value = DateTime.Now;
            btnAddREvision.Enabled = false;
            btnAllStudentRecords.Enabled = false;
            chbpage1.Enabled = true;
        }

        private void _ResetSurahListValues()
        {
            DataTable dtAllSurahsInJuz = clsSurah.GetAllSurahsInJuz(_JuzName);
            dataGridView1.DataSource = dtAllSurahsInJuz;
            txtAyetCount.Text = _GetAyetCountForJuz(_JuzName);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Surah Order";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Surah Name";
                dataGridView1.Columns[1].Width = 60;
                dataGridView1.Columns[2].HeaderText = "Ayet Count";
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].HeaderText = "Page Count";
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[4].HeaderText = "Juz Name";
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[5].HeaderText = "Revelation Place";
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[6].HeaderText = "Starts";
                dataGridView1.Columns[6].Width = 50;
                dataGridView1.Columns[7].HeaderText = "Ends";
                dataGridView1.Columns[7].Width = 60;
            }
            txtsurahCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void _FillRecordInfo()
        {
            clsJuzRecord CurrentMemorizingRecord = new clsJuzRecord();
            CurrentMemorizingRecord.JuzID = Convert.ToInt16(_JuzNumber);
            CurrentMemorizingRecord.StudentID = _StudentID;
            CurrentMemorizingRecord.AnyNotes = txtNots.Text;
            CurrentMemorizingRecord.MemorizedDate = dtpmemorizingStartDate.Value;
            CurrentMemorizingRecord.AddMemorizingRecord();
        }
       
        private void EnableNextCheckbox(CheckBox currentCheckbox)
        {
            List<CheckBox> checkboxes = new List<CheckBox> { chbpage1, chbpage2, chbpage3, chbpage4, chbpage5, chbpage6, chbpage7, chbpage8, chbpage9, chbpage10,
                                                             chbpage11, chbpage12, chbpage13, chbpage14, chbpage15, chbpage16, chbpage17, chbpage18, chbpage19, chbpage20,};
            int currentIndex = checkboxes.IndexOf(currentCheckbox);
            if (currentIndex >= 0 && currentIndex < checkboxes.Count - 1)
            {
                checkboxes[currentIndex + 1].Enabled = true;
            }
        }
       
        private void txtRevisionCount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToUInt16(txtRevisionCount.Text) > 0)
            {
                btnAllStudentRecords.Enabled = true;
            }
        }

        private void frmSurahsList_Load_1(object sender, EventArgs e)
        {
            _ResetSurahListValues();
            //Make another object to store the student info 
            _Student = clsStudent.FindByStudentID(_StudentID);
            if (_Student == null)
            {
                MessageBox.Show("This Student Is Not Found chooce Another One");
                return;
            }
            lblStudentName.Text = _Student.PersonInfo.FullName;
            _JuzPagesRecords = clsJuzPagesRecord.FindJuzInfoByStudentIDJuzID(_StudentID, Convert.ToInt16(_JuzNumber));
            if (_JuzPagesRecords == null)
            {
                _ResetDefualtValues();
                lblJuzMessage.Text = "Has Not Memorized This Juz Yet.";
            }
            else
            {
                LoadJuzRecordData();
            }
            btnSave.Enabled = false;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _JuzPagesRecords.StudentID = _StudentID;
            _JuzPagesRecords.JuzID = Convert.ToInt16(_JuzNumber);
            _JuzPagesRecords.pageNumber1 = (byte)(chbpage1.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber2 = (byte)(chbpage2.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber3 = (byte)(chbpage3.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber4 = (byte)(chbpage4.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber5 = (byte)(chbpage5.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber6 = (byte)(chbpage6.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber7 = (byte)(chbpage7.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber8 = (byte)(chbpage8.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber9 = (byte)(chbpage9.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber10 = (byte)(chbpage10.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber11 = (byte)(chbpage11.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber12 = (byte)(chbpage12.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber13 = (byte)(chbpage13.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber14 = (byte)(chbpage14.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber15 = (byte)(chbpage15.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber16 = (byte)(chbpage16.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber17 = (byte)(chbpage17.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber18 = (byte)(chbpage18.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber19 = (byte)(chbpage19.Checked ? 1 : 0);
            _JuzPagesRecords.pageNumber20 = (byte)(chbpage20.Checked ? 1 : 0);

            if (_JuzPagesRecords.RecorderID == -1)
            {
                if (_JuzPagesRecords.AddMemorizingRecord())
                {
                    MessageBox.Show("The Student Information Saved Successfuly", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAddREvision.Enabled = true;
                }
                else
                {
                    MessageBox.Show("The Student Information Not Saved", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (_JuzPagesRecords.UpdateMemorizingRecord())
                {
                    MessageBox.Show("The Student Information Saved Successfuly", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Student Information Not Saved", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnSave.Enabled = false;

            _FillRecordInfo();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddREvision_Click(object sender, EventArgs e)
        {
            short JuzID = Convert.ToInt16(_JuzNumber);
            frmAddRevision frm = new frmAddRevision(_StudentID, _Student.PersonInfo.FullName, JuzID, MemorizedPageCount_);
            frm.ShowDialog();
            btnAllStudentRecords.Enabled = true;
        }

        private void All_CheckBox(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (!checkbox.Checked)
            {
                checkbox.Checked = true;
            }
            checkbox.CheckState = CheckState.Checked;
            checkbox.ForeColor = Color.Green;
            MemorizedPageCount_ += 1;
            CurrentMemorizingPageCount += 1;
            txtMemorizedPageCount.Text = MemorizedPageCount_.ToString();
            txtUnMemorizedPageCount.Text = ((byte)(20 - MemorizedPageCount_)).ToString();
            EnableNextCheckbox(checkbox);
            btnSave.Enabled = true;
        }

        private void btnAllStudentRecords_Click(object sender, EventArgs e)
        {
            short JuziD = Convert.ToInt16(_JuzNumber);
            frmAllStudentRevsionRecords frm = new frmAllStudentRevsionRecords(_StudentID, JuziD);
            //frm.DataBack += GetRevisionCountByDelegate;
            frm.ShowDialog();
        }
    }
}
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

namespace Alrahman_Allama_Allquran.Revision
{
    public partial class frmAddRevision : Form
    {
        public frmAddRevision()
        {
            InitializeComponent();
        }

        public delegate void DataBackEventHandler(object sender, int RevisionID);
        public event DataBackEventHandler DataBack;

        int _StudentID = -1;

        string _StudentName = "";

        short _JuzID = -1;

        byte _MemorizedPageCount = 0;

        public frmAddRevision(int StudentID, string StudentName, short JuzID, byte MemorizedPageCount)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _StudentName = StudentName;
            _JuzID = JuzID;
            _MemorizedPageCount = MemorizedPageCount;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("There Is An Empty Fields Fill It Please :).");
            }

            clsRevision_Record NewRevision = new clsRevision_Record();

            NewRevision.StudentNo = _StudentID;

            short Pagecount = Convert.ToInt16(txtMemorizedPageCount.Text);

            NewRevision.RevisionPageCount = Pagecount;

            NewRevision.RevisionDate = dtpmemorizingStartDate.Value;

            NewRevision.anyNotes = txtNots.Text;

            NewRevision.JuzID = Convert.ToInt16(_JuzID);

            int mistakeCount;

            if (!int.TryParse(txtMistakeCount.Text, out mistakeCount))
            {
                MessageBox.Show("Please enter a valid number for Mistake Count.");
                return;
            }
            else
            {
                NewRevision.MistakeCount = mistakeCount;
            }
            if (NewRevision.AddNewRevision() != -1)
            {
                MessageBox.Show("Revision Record Saved Successfuly ", "Dont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, NewRevision.RevisionRecordID);
            }
            else
            {
                MessageBox.Show("Revision Record Faild Saving ", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMemorizedPageCount_Validating_1(object sender, CancelEventArgs e)
        {
            if (Convert.ToUInt16(txtMemorizedPageCount.Text) > _MemorizedPageCount)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMemorizedPageCount, "The Page Count Does Not Match The Memorized Page.");
            }
            else
            {
                errorProvider1.SetError(txtMemorizedPageCount, "");
            }
        
        }

        private void frmAddRevision_Load_1(object sender, EventArgs e)
        {
            lblStudentName.Text = _StudentName;
            txtStudentID.Text = _StudentID.ToString();
            txtJuzID.Text = _JuzID.ToString();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

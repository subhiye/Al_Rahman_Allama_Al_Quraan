using Alrahman_Allama_Allquran.Teacher;
using Alrahman_Allama_Allquran.Teacher.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran.Student
{
    public partial class frmShowStudentInfoCard : Form
    {
        private int _StudentID = -1;
        private string _StudentName = "";
        public frmShowStudentInfoCard(int StudentID, string StudentName)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _StudentName = StudentName;
        }
        private void btnAddMemorizing_Click_1(object sender, EventArgs e)
        {
            int StudentID = _StudentID;
            frmAddingQuraan frm = new frmAddingQuraan(_StudentID, _StudentName);
            frm.ShowDialog();
        }

        private void frmShowStudentInfoCard_Load_1(object sender, EventArgs e)
        {
            ctrlStudentInfoCard1.LoadStudentInfo(_StudentID);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
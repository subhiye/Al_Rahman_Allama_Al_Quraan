using Alrahman_Allama_Allquran.Global_Class;
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

namespace Alrahman_Allama_Allquran.Parent
{
    public partial class frmParentChildrenList : Form
    {
        public frmParentChildrenList()
        {
            InitializeComponent();
        }
        private static DataTable _dtAllChildren = clsParent.ListOfChildrenHasParent(clsGlobalObjects.CurrentParent.ParentID);
        
        private DataTable _dtPeople = _dtAllChildren.DefaultView.ToTable(false, "StudentID", "Student_Name", "Teacher_Name",
                                                        "DateOfBirth", "NationalNumber", "Gender",
                                                       "PhoneNum", "MembershipStartDate", "MemberEndDate", "Age");

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmParentChildrenList_Load(object sender, EventArgs e)
        {
            string Parent = clsGlobalObjects.CurrentParent.PersonInfo.FullName;
            lblParentName.Text = Parent;
            dgvChildren.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvChildren.Rows.Count.ToString();
            if (dgvChildren.Rows.Count > 0)
            {
                dgvChildren.Columns[0].HeaderText = "Student ID";
                dgvChildren.Columns[0].Width = 110;
                dgvChildren.Columns[1].HeaderText = " Student Name";
                dgvChildren.Columns[1].Width = 110;
                dgvChildren.Columns[2].HeaderText = "Teacher Name";
                dgvChildren.Columns[2].Width = 150;
                dgvChildren.Columns[3].HeaderText = "Date Of Birth";
                dgvChildren.Columns[3].Width = 150;
                dgvChildren.Columns[4].HeaderText = "National Number";
                dgvChildren.Columns[4].Width = 150;
                dgvChildren.Columns[5].HeaderText = "Gender";
                dgvChildren.Columns[5].Width = 120;
                dgvChildren.Columns[6].HeaderText = "Phone Number";
                dgvChildren.Columns[6].Width = 150;
                dgvChildren.Columns[7].HeaderText = "MembershipStartDate";
                dgvChildren.Columns[7].Width = 150;
                dgvChildren.Columns[8].HeaderText = "MembershipEndDate";
                dgvChildren.Columns[8].Width = 150;
                dgvChildren.Columns[9].HeaderText = "Age";
                dgvChildren.Columns[9].Width = 150;
            }
            else
            {
                string childrenCount = lblRecordsCount.Text = dgvChildren.Rows.Count.ToString();
                MessageBox.Show("You Have No Children In Our System If You Want Add One Or More child ", "Sorry");
            }
        }

        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int StudentID = (int)dgvChildren.CurrentRow.Cells[0].Value;
            frmChildGradesDetails details = new frmChildGradesDetails(StudentID);
            details.ShowDialog();
        }
    }
}
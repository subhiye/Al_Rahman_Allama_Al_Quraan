using Alrahman_Allama_Allquran.Global_Class;
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
    public partial class frmStudentListForTeacher : Form
    {
        public frmStudentListForTeacher()
        {
            InitializeComponent();
        }

        private DataTable _dtAllStudents = clsStudent.GetAllStudents();

        private void _RefreshStudentList()
        {
            _dtAllStudents = clsStudent.GetAllStudents();
            dgvStudents.DataSource = _dtAllStudents;
            lblRecordsCount.Text = dgvStudents.Rows.Count.ToString();
        }
       
        private void frmStudentListForTeacher_Load_1(object sender, EventArgs e)
        {
            dgvStudents.DataSource = _dtAllStudents;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvStudents.Rows.Count.ToString();
            if (dgvStudents.Rows.Count > 0)
            {
                dgvStudents.Columns[0].HeaderText = "Student ID";
                dgvStudents.Columns[0].Width = 100;

                dgvStudents.Columns[1].HeaderText = "Teacher Name";
                dgvStudents.Columns[1].Width = 100;

                dgvStudents.Columns[2].HeaderText = "Parent Name";
                dgvStudents.Columns[2].Width = 100;

                dgvStudents.Columns[3].HeaderText = "Student Name";
                dgvStudents.Columns[3].Width = 100;

                dgvStudents.Columns[4].HeaderText = "Student Nick Name";
                dgvStudents.Columns[4].Width = 100;

                dgvStudents.Columns[5].HeaderText = "Address";
                dgvStudents.Columns[5].Width = 100;

                dgvStudents.Columns[6].HeaderText = "Email";
                dgvStudents.Columns[6].Width = 100;

                dgvStudents.Columns[7].HeaderText = "Date Of Birth";
                dgvStudents.Columns[7].Width = 100;

                dgvStudents.Columns[8].HeaderText = "Country Name";
                dgvStudents.Columns[8].Width = 100;

                dgvStudents.Columns[9].HeaderText = "National Number";
                dgvStudents.Columns[9].Width = 100;

                dgvStudents.Columns[10].HeaderText = "Gender";
                dgvStudents.Columns[10].Width = 100;

                dgvStudents.Columns[11].HeaderText = "Phone Number";
                dgvStudents.Columns[11].Width = 100;

                dgvStudents.Columns[12].HeaderText = "MembershipStartDate";
                dgvStudents.Columns[12].Width = 100;

                dgvStudents.Columns[13].HeaderText = "MembershipEndDate";
                dgvStudents.Columns[13].Width = 100;

                dgvStudents.Columns[14].HeaderText = "Age";
                dgvStudents.Columns[14].Width = 100;
            }
            lblTeacherName.Text = clsGlobalObjects.CurrentTeacher.PersonInfo.FullName;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmStudentsOrdering frm = new frmStudentsOrdering();
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int StudentID = (int)dgvStudents.CurrentRow.Cells[0].Value;
            string StudentName = (string)dgvStudents.CurrentRow.Cells[3].Value;
            frmShowStudentInfoCard frm = new frmShowStudentInfoCard(StudentID, StudentName);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmAddUpdateStudent frm = new frmAddUpdateStudent();
            frm.ShowDialog();
            _RefreshStudentList();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int StudentID = (int)dgvStudents.CurrentRow.Cells[0].Value;
            frmAddUpdateStudent frm = new frmAddUpdateStudent(StudentID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvStudents.CurrentRow.Cells[0].Value + "]?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsStudent.DeleteStudent((int)dgvStudents.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Student deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshStudentList();
                }
                else
                {
                    MessageBox.Show("Student was not deleted because it has information linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvStudents_DoubleClick_1(object sender, EventArgs e)
        {
            int StudentID = (int)dgvStudents.CurrentRow.Cells[0].Value;
            string StudentName = (string)dgvStudents.CurrentRow.Cells[3].Value;
            frmShowStudentInfoCard frm = new frmShowStudentInfoCard(StudentID, StudentName);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("I Will Develop This Unit In Shaa ALLAH As Soon As Possible.", "Want to tell You");
        }

        private void phoneCallToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("I Will Develop This Unit In Shaa ALLAH As Soon As Possible.", "Want to tell You");
        }
    }
}
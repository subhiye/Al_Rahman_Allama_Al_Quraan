using Alrahman_Allama_Allquran.Parent;
using Alrahman_Allama_Allquran.People.Controls;
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

namespace Alrahman_Allama_Allquran.Student
{
    public partial class frmAddUpdateStudent : Form
    {
        enum EnMode
        {
            AddNew = 0,
            Update = 1
        }

        EnMode _Mode;

        private int _StudentID = -1;

        private clsStudent _Student;

        public frmAddUpdateStudent()
        {
            InitializeComponent();
            _Mode = EnMode.AddNew;
        }

        public frmAddUpdateStudent(int? StudentID)
        {
            InitializeComponent();
            _StudentID = (int)StudentID;
            _Mode = EnMode.Update;
        }

        private void _ResetDefualtValues()
        {
            _FillTeachresNames();
            if (_Mode == EnMode.AddNew)
            {
                lblTitle.Text = "Add New Student";
                this.Text = "Add New Student";
                _Student = new clsStudent();
                tpLoginInfo.Enabled = false;
                ctrlPersonCardInfoWithFilter1.FilterFocus();
                linkLabel1.Visible = false;
            }
            else
            {
                lblTitle.Text = "Update Student";
                this.Text = "Update Student";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            txtStudentNickName.Text = "";
            txtPassword.Text = "";
            txtParentName.Text = "";
           
            dtpMemberShipStartDate.Value = DateTime.Now;
            dtpMemberShipExpireDate.Value = DateTime.Now;
        }

        private void _LoadData()
        {
            _Student = clsStudent.FindByStudentID(_StudentID);
            ctrlPersonCardInfoWithFilter1.FilterEnabled = false;

            if (_Student == null)
            {
                MessageBox.Show("No Student with ID = " + _StudentID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            txtStudentID.Text = _Student.StudentID.ToString();
            txtStudentNickName.Text = _Student.StudentNickName;
            txtPassword.Text = _Student.Password;

            if(_Student.ParentInfo.PersonInfo.FullName != null)
            {
                txtParentName.Text = _Student.ParentInfo.PersonInfo.FullName;
            }
            if (_Student.ParentInfo.PersonInfo.FullName != null)
            {
                string FullTeachername = _Student.TeacherInfo.PersonInfo.FullName;

                cbTeachersName.SelectedIndex = cbTeachersName.FindString(FullTeachername);
            }

            // error place 

            ctrlPersonCardInfoWithFilter1.LoadPersonInfo(_Student.PersonID);
        }

        private void _FillTeachresNames()
        {
            DataTable dtAllTeachers = clsTeacher.GetAllTeachers();
            foreach (DataRow row in dtAllTeachers.Rows)
            {
                cbTeachersName.Items.Add(row["Teacher_Name"]);
            }
        }

        private void frmAddUpdateStudent_Load_1(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == EnMode.Update)
                _LoadData();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Student.PersonID = ctrlPersonCardInfoWithFilter1.PersonID;
            _Student.StudentNickName = txtStudentNickName.Text.Trim();
            _Student.Password = txtPassword.Text.Trim();
            _Student.MembershipStartDate = dtpMemberShipStartDate.Value;

            if (_Student.MemberEndDate != null)
                _Student.MemberEndDate = dtpMemberShipExpireDate.Value;
            else
            { _Student.MemberEndDate = DateTime.Now; }

            string ParentName = txtParentName.Text;
            int ParentID = -1;
            ParentID = clsParent.GetParentIDByParentFullName(ParentName);
            if (ParentID != -1)
            {
                _Student.ParentID = (int)ParentID;
            }
            else
            {
                MessageBox.Show("This Parent Is Not Found Add A Parent To Add It Here ");
                linkLabel1.Visible = true;
            }

            string TeacherName = cbTeachersName.SelectedItem?.ToString();

            int TeacherID = (int)clsTeacher.FindbyFullName(TeacherName);
            if (TeacherID != -1)
            {
                _Student.TeacherID = TeacherID;
            }
            else
            {
                MessageBox.Show("This Teacher Is Not Found Choose Another One");
            }

            if (_Student.Save())
            {
                txtStudentID.Text = _Student.StudentID.ToString();
                _Mode = EnMode.Update;
                lblTitle.Text = "Update Student";
                this.Text = "Update Student";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnPersonInfoNext_Click_1(object sender, EventArgs e)
        {
            if (_Mode == EnMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }
            if (ctrlPersonCardInfoWithFilter1.PersonID != -1)
            {
                if (clsStudent.IsStudentFound(ctrlPersonCardInfoWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a Student, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardInfoWithFilter1.Focus();
                    btnSave.Enabled = false;
                    tpLoginInfo.Enabled = false;

                    return;
                }
                if (clsTeacher.IsTeachreFoundByPersonID(ctrlPersonCardInfoWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person Cant Be A Student Because He Is A Teacher, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardInfoWithFilter1.Focus();
                    btnSave.Enabled = false;
                    tpLoginInfo.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardInfoWithFilter1.FilterFocus();
            }
            btnPersonInfoNext.Enabled = false;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStudentNickName_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentNickName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtStudentNickName, "Student Name cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtStudentNickName, null);
            };

            if (_Student.StudentNickName != txtStudentNickName.Text.Trim())
            {
                if (clsStudent.IsStudentFound(txtStudentNickName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtStudentNickName, "Student Name is used by another Student");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtStudentNickName, null);
                };
            }
        }

        private void txtPassword_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password Cannot Be Blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateParent frm = new frmAddUpdateParent();
            frm.ShowDialog();
        }

        private void txtParentName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtParentName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "You Must Add A Parent Name");
                return;
            }
            else
            {
                errorProvider1.SetError(txtParentName, null);
            };

            if (clsParent.GetParentIDByParentFullName(txtParentName.Text.Trim()) == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtParentName, "Selected Person Not Found , Add It As A Parent.");

                linkLabel1.Visible = true;
                return;
            }
            else
            {
                errorProvider1.SetError(txtParentName, null);
            }
        }
    }
}

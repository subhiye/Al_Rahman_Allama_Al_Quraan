using Alrahman_Allama_Allquran.Global_Class;
using Alrahman_Allama_Allquran.Parent;
using Alrahman_Allama_Allquran.Properties;
using Alrahman_Allama_Allquran.Student;
using Alrahman_Allama_Allquran.Teacher;
using alrahman_Allama_Alquran_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran
{
    public partial class frmLogin : Form
    {
        enum EnGendor {Male = 0, Female = 1 }

        public frmLogin()
        {
            InitializeComponent();
        }

        private clsPerson _Person;

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                comboBox1.Items.Add(row["CountryName"]);
            }
        }
       
        private void _ResetDefualtValues()
        {
            _FillCountriesInComoboBox();
            _Person = new clsPerson();
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNationalNo.Text = string.Empty;

            if (rbFemale.Checked)

                pbPersonPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;

            else

                pbPersonPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;

            llRemoveImage.Visible = (pbPersonPicture.ImageLocation != null);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-5);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            comboBox1.SelectedIndex = comboBox1.FindString("Syria");
            rbFemale.Checked = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            chbLogin.Checked = true;
        }
        
        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonPicture.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    { }
                }

                if (pbPersonPicture.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonPicture.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonPicture.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage())
                return;
            int CountryID = clsCountry.Find(comboBox1.Text).CountryID;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNumber = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.PhoneNum = txtPhoneNumber.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked)
                _Person.Geder = (short)EnGendor.Male;
            else
                _Person.Geder = (short)EnGendor.Female;
            _Person.CountryID = CountryID;
            if (pbPersonPicture.ImageLocation != null)
                _Person.ImagePath = pbPersonPicture.ImageLocation;
            else
                _Person.ImagePath = "";
            if (_Person.Save())
            {
                txtAddress.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtNationalNo.Text = "";
                txtPhoneNumber.Text = "";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"{_Person.PersonID}", "Your Person Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                frmStudentAdding frm = new frmStudentAdding(_Person.PersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Data Faild Saving", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonPicture.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonPicture.ImageLocation = null;
            if (rbMale.Checked)
                pbPersonPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;
            else
                pbPersonPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;
            llRemoveImage.Visible = false;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbPersonPicture.ImageLocation == null)
                pbPersonPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbPersonPicture.ImageLocation == null)
                pbPersonPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;
        }

        private void txtNationalNo_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
            //Make sure the national number is not used by another person
            if (txtNationalNo.Text.Trim() != _Person.NationalNumber && clsPerson.IsPersonFound(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (!rbParent.Checked && !rbStudent.Checked && !rbTeacher.Checked)
            {
                MessageBox.Show("Please choose an option (student, teacher, or parent).", "Attention");
                return;
            }

            string nickname = txtNichName.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (rbParent.Checked)
            {
                clsParent Parent = clsParent.FindByParentNickNameAndPasssword(nickname, password);
                if (Parent != null)
                {
                    clsGlobalObjects.CurrentParent = Parent;
                    Form frm = new frmParentChildrenList();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Name Or Password");
                }
            }
            else if (rbStudent.Checked)
            {
                clsStudent Student = clsStudent.FindByStudentNickNameAndPasssword(nickname, password);
                if (Student != null)
                {
                    clsGlobalObjects.CurrentStudent = Student;
                    Form frm = new frmStudentAdding();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Name Or Password");
                }
            }
            else
            {
                clsTeacher Teacher = clsTeacher.FindByTeacherNickNameAndPassword(nickname, password);
                if (Teacher != null)
                {
                    clsGlobalObjects.CurrentTeacher = Teacher;
                    frmStudentListForTeacher frm2 = new frmStudentListForTeacher();
                    frm2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Name Or Password");
                }
            }

            txtNichName.Text = "";
            txtpassword.Text = "";
            this.Close();
        }

        private void Validating_Text_Boxes(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoginPerson_Click(object sender, EventArgs e)
        {
            
            int PersonID = Convert.ToInt32(txtPersonID.Text);
            string personName = txtPersonName.Text.Trim();
            bool PersonExists = clsPerson.FindPersonIDPersonName(PersonID, personName);

            if (!PersonExists)
            {
                MessageBox.Show("This person is not found.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsTeacher Teacher = clsTeacher.FindByPersonID(PersonID);
            clsStudent Student = clsStudent.FindByPersonID(PersonID);
            clsParent Parent = clsParent.FindByPersonID(PersonID);

            if (Parent != null || Student != null || Teacher != null)
            {
                MessageBox.Show("This Person Is Found In Our System , Please log in from the other side.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmStudentAdding frm = new frmStudentAdding(PersonID);
            frm.ShowDialog();
            
        }

        private void txtPersonName_Validating_1(object sender, CancelEventArgs e)
        {
            if (chbPersonLogin.Checked)
            {
                if (string.IsNullOrEmpty(txtPersonName.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPersonName, "This Field Is Required!");
                }
                else
                {
                    errorProvider1.SetError(txtPersonName, null);
                }
            }
            else
            {
                txtPersonName = null;
            }
        }

        private void txtPersonID_Validating_1(object sender, CancelEventArgs e)
        {
            if (chbPersonLogin.Checked)
            {
                if (string.IsNullOrEmpty(txtPersonID.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPersonName, "This Field Is Required!");
                }
                else
                {
                    errorProvider1.SetError(txtPersonID, null);
                }
            }
            else
            {
                txtPersonID = null;
            }
        }

        private void chbSignUp_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSignUp.Checked)
            {
                chbLogin.Checked = false;
                chbPersonLogin.Checked = false;

                rbFemale.Enabled = true;
                rbMale.Enabled = true;
                btnSignUp.Enabled = true;
                txtEmail.Enabled = true;
                txtAddress.Enabled = true;
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtPhoneNumber.Enabled = true;
                txtNationalNo.Enabled = true;
                dtpDateOfBirth.Enabled = true;
                comboBox1.Enabled = true;
                lblFirstName.Enabled = true;
                lblLastName.Enabled = true;
                label7.Enabled = true;
                lblPhoneNumber.Enabled = true;
                Email.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                label12.Enabled = true;
                Gender.Enabled = true;
                label3.Enabled = true;
                lblSetImage.Enabled = true;
                pbPersonPicture.Enabled = true;
                btnLoginPerson.Enabled = false;
                txtPersonID.Enabled = false;
                txtPersonName.Enabled = false;
                label6.Enabled = false;
                label4.Enabled = false;
                rbParent.Enabled = false;
                rbTeacher.Enabled = false;
                rbStudent.Enabled = false;
                lblYourPassword.Enabled = false;
                lblYourNickName.Enabled = false;
                txtNichName.Enabled = false;
                txtpassword.Enabled = false;
                btnLogin.Enabled = false;
            }
        }

        private void chbLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLogin.Checked)
            {
                chbSignUp.Checked = false;
                chbPersonLogin.Checked = false;

                rbParent.Enabled = true;
                rbTeacher.Enabled = true;
                rbStudent.Enabled = true;
                lblYourPassword.Enabled = true;
                lblYourNickName.Enabled = true;
                txtNichName.Enabled = true;
                txtpassword.Enabled = true;
                btnLogin.Enabled = true;
                rbFemale.Enabled = false;
                rbMale.Enabled = false;
                btnLoginPerson.Enabled = false;
                btnSignUp.Enabled = false;
                txtEmail.Enabled = false;
                txtAddress.Enabled = false;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtPhoneNumber.Enabled = false;
                txtNationalNo.Enabled = false;
                txtPersonID.Enabled = false;
                txtPersonName.Enabled = false;
                dtpDateOfBirth.Enabled = false;
                comboBox1.Enabled = false;
                lblFirstName.Enabled = false;
                lblLastName.Enabled = false;
                label7.Enabled = false;
                lblPhoneNumber.Enabled = false;
                Email.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label12.Enabled = false;
                Gender.Enabled = false;
                label3.Enabled = false;
                lblSetImage.Enabled = false;
                pbPersonPicture.Enabled = false;
            }
        }

        private void chbPersonLogin_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chbPersonLogin.Checked)
            {
                chbSignUp.Checked = false;
                chbLogin.Checked = false;

                btnLoginPerson.Enabled = true;
                txtPersonID.Enabled = true;
                txtPersonName.Enabled = true;
                label6.Enabled = true;
                label4.Enabled = true;
                rbFemale.Enabled = false;
                rbMale.Enabled = false;
                btnSignUp.Enabled = false;
                txtEmail.Enabled = false;
                txtAddress.Enabled = false;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtPhoneNumber.Enabled = false;
                txtNationalNo.Enabled = false;
                dtpDateOfBirth.Enabled = false;
                comboBox1.Enabled = false;
                lblFirstName.Enabled = false;
                lblLastName.Enabled = false;
                label7.Enabled = false;
                lblPhoneNumber.Enabled = false;
                Email.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label12.Enabled = false;
                Gender.Enabled = false;
                label3.Enabled = false;
                lblSetImage.Enabled = false;
                pbPersonPicture.Enabled = false;
                rbParent.Enabled = false;
                rbTeacher.Enabled = false;
                rbStudent.Enabled = false;
                lblYourPassword.Enabled = false;
                lblYourNickName.Enabled = false;
                txtNichName.Enabled = false;
                txtpassword.Enabled = false;
                btnLogin.Enabled = false;
            }
        }
    }
}
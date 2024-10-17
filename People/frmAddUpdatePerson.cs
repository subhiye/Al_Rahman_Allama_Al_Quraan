using Alrahman_Allama_Allquran.Global_Class;
using Alrahman_Allama_Allquran.Properties;
using alrahman_Allama_Alquran_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace Alrahman_Allama_Allquran.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        public enum EnMode { AddNew = 0, Update = 1 };

        public enum EnGendor { Male = 0, Female = 1 };

        private EnMode _Mode;

        private int _PersonID = -1;

        clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = EnMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = EnMode.Update;
        }

        private void _ResetDefualtValues()
        {
            _FillCountriesInComoboBox();
            if (_Mode == EnMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;
            else
                pbPersonImage.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-5);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedIndex = cbCountry.FindString("Syria");
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbFemale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblPerson.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNumber;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Geder == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.PhoneNum;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.countryInfo.CountryName);
            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
            llRemoveImage.Visible = (_Person.ImagePath != "");
        }
       
        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
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

                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
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
       
        private void TextBoxes_Validation(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void rbMale_Click_1(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;
        }

        private void rbFemale_Click_1(object sender, EventArgs e)
        {

            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;
        }

        private void frmAddUpdatePerson_Load_1(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == EnMode.Update)
                _LoadData();
        }

        private void llSetImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;
            else
                pbPersonImage.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;
            llRemoveImage.Visible = false;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage())
                return;
            int NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNumber = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.PhoneNum = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked)
                _Person.Geder = (short)EnGendor.Male;
            else
                _Person.Geder = (short)EnGendor.Female;
            _Person.CountryID = NationalityCountryID;
            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPerson.Text = _Person.PersonID.ToString();
                //change form mode to update.
                _Mode = EnMode.Update;
                lblTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);
                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
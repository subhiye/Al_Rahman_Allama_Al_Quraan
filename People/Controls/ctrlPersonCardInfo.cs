using Alrahman_Allama_Allquran.Properties;
using alrahman_Allama_Alquran_Business;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Alrahman_Allama_Allquran.People.Controls
{
    public partial class ctrlPersonCardInfo : UserControl
    {
        public ctrlPersonCardInfo()
        {
            InitializeComponent();
        }

        private clsPerson _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Geder == 0)
                pbStudentPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;
            else
                pbStudentPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;
            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbStudentPicture.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNumber;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.Geder == 0 ? "Male" : "Female";
            lblEmaill.Text = _Person.Email;
            lblPhone.Text = _Person.PhoneNum;
            lblDateOfBrith.Text = _Person.DateOfBirth.ToShortDateString();
            lblcountry.Text = clsCountry.Find(_Person.CountryID).CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendor.Text = "[????]";
            lblEmaill.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBrith.Text = "[????]";
            lblcountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbStudentPicture.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;
        }

        private void llEditPersonInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
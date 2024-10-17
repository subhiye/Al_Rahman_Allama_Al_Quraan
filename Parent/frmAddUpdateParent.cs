using alrahman_Allama_Alquran_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran.Parent
{
    public partial class frmAddUpdateParent : Form
    {
        enum EnMode { AddNew = 0, Update = 1 }

        EnMode _Mode;

        private clsParent _Parent;

        private int _ParentID;

        public frmAddUpdateParent()
        {
            InitializeComponent();
            _Mode = EnMode.AddNew;
        }

        public frmAddUpdateParent(int ParentID)
        {
            InitializeComponent();
            _Mode = EnMode.AddNew;
            _ParentID = ParentID;
        }
        
        private void _ResetDefualtValues()
        {
            if (_Mode == EnMode.AddNew)
            {
                lblTitle.Text = "Add New Parent";
                this.Text = "Add New Parent";
                _Parent = new clsParent();
                tpLoginInfo.Enabled = false;
                ctrlPersonCardInfoWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update Parent";
                this.Text = "Update Parent";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            txtParentNickName.Text = "";
            txtPassword.Text = "";
        }

        private void _LoadData()
        {
            _Parent = clsParent.FindByParentID(_ParentID);
            ctrlPersonCardInfoWithFilter1.FilterEnabled = false;

            if (_Parent == null)
            {
                MessageBox.Show("No User with ID = " + _ParentID, "Parent Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            txtParentID.Text = _Parent.ParentID.ToString();
            txtParentNickName.Text = _Parent.ParentNickName;
            txtPassword.Text = _Parent.Password;
        }

        private void frmAddUpdateParent_Load_1(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == EnMode.Update)
                _LoadData();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds Are Not Valide!, Put The Mouse Over The Red Icon To See The Error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Parent.PersonID = ctrlPersonCardInfoWithFilter1.PersonID;
            _Parent.ParentNickName = txtParentNickName.Text.Trim();
            _Parent.Password = txtPassword.Text.Trim();

            if (_Parent._AddNewParent())
            {
                txtParentID.Text = _Parent.ParentID.ToString();

                _Mode = EnMode.Update;
                lblTitle.Text = "Update Parent";
                this.Text = "Update Parent";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
                if (clsParent.IsParentFoundByPersonID(ctrlPersonCardInfoWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a Parent, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardInfoWithFilter1.Focus();
                    btnSave.Enabled = false;
                    tpLoginInfo.Enabled = false;
                    return;
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
    }
}
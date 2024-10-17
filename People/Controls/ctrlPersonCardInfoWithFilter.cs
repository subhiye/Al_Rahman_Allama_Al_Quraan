using alrahman_Allama_Alquran_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran.People.Controls
{
    public partial class ctrlPersonCardInfoWithFilter : UserControl
    {
        public ctrlPersonCardInfoWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            OnPersonSelected?.Invoke(PersonID); // Raise the event with the parameter
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            cbFilters.SelectedIndex = 1;
            tbFilter.Text = PersonID.ToString();
            ctrlPersonCardInfo1.LoadPersonInfo(PersonID);
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int PersonID
        {
            get { return ctrlPersonCardInfo1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCardInfo1.SelectedPersonInfo; }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = "";
            tbFilter.Focus();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilters.SelectedIndex = 1;
            tbFilter.Text = PersonID.ToString();
            FindNow();
        }

        private void FindNow()
        {
            switch (cbFilters.Text)
            {
                case "Person ID":
                    ctrlPersonCardInfo1.LoadPersonInfo(int.Parse(tbFilter.Text));
                    break;
                case "National No.":
                    ctrlPersonCardInfo1.LoadPersonInfo(tbFilter.Text);
                    break;
                default:
                    break;
            }

            OnPersonSelected?.Invoke(ctrlPersonCardInfo1.PersonID); // Raise the event with a parameter
        }

        public void FilterFocus()
        {
            tbFilter.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Hover over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }

        private void ctrlPersonCardInfo1_Load_1(object sender, EventArgs e)
        {
            cbFilters.SelectedIndex = 0;
            tbFilter.Focus();
        }

        private void ctrlPersonCardInfoWithFilter_Load_1(object sender, EventArgs e)
        {
            cbFilters.SelectedIndex = 1;
            tbFilter.Focus();
        }

        private void tbFilter_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
            if (cbFilters.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm1 = new frmAddUpdatePerson();
            frm1.DataBack += DataBackEvent;
            frm1.ShowDialog();
        }

        private void tbFilter_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFilter, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(tbFilter, null);
            }
        }
    }
}
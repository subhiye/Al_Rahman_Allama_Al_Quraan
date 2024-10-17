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

namespace Alrahman_Allama_Allquran.Teacher.Controls
{
    public partial class ctrlStudentInfoCard : UserControl
    {
        public ctrlStudentInfoCard()
        {
            InitializeComponent();
        }
        private clsStudent _Student;
        private int _StudentID = -1;
        public int StudentID
        {
            get { return _StudentID; }
        }
        public void LoadStudentInfo(int StudentID)
        {
            _Student = clsStudent.FindByStudentID(StudentID);
            if (_Student == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + StudentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillStudentInfo();
        }

        private void _FillStudentInfo()
        {
            ctrlPersonCardInfo1.LoadPersonInfo(_Student.PersonID);
            lblStudentID.Text = _Student.StudentID.ToString();
            lblStudentNickName.Text = _Student.StudentNickName.ToString();
            lblParentName.Text = _Student.ParentInfo.PersonInfo.FullName;
            lblMemberShipStartDate.Text = _Student.MembershipStartDate.ToString();
            lblMembershipExpireDate.Text = _Student.MemberEndDate.ToString();
        }

        private void _ResetPersonInfo()
        {
            ctrlPersonCardInfo1.ResetPersonInfo();
            lblStudentID.Text = "[???]";
            lblStudentNickName.Text = "[???]";
            lblParentName.Text = "[???]";
            lblMembershipExpireDate.Text = "[???]";
            lblMemberShipStartDate.Text = "[???]";
        }

       
    }
}

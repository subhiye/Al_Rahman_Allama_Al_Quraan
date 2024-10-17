using Alrahman_Allama_Allquran.Races;
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
    public partial class frmStudentAdding : Form
    {
       
        enum EnStatus { AddStudent = 0, Exists };
        EnStatus _Status = EnStatus.Exists;
        private int _PersonID = -1;

        public frmStudentAdding()
        {
            InitializeComponent();
            _Status = EnStatus.Exists;
        }

        public frmStudentAdding(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Status = EnStatus.AddStudent;
        }

        private void _ResetDefualtValuesForAddNewStatus()
        {
            btnAddStudent.Visible = true;
            btnAddStudent.Enabled = true;
            btnChat.Visible = true;
            btnChat.Enabled = false;
            button2.Visible = true;
        }

        private void _ResetDefualtValuesForStudentExistsStatus()
        {
            btnChat.Visible = true;
            btnChat.Enabled = true;
            button2.Visible = true;
        }
       
        private void frmStudentAdding_Load_1(object sender, EventArgs e)
        {
            btnAddStudent.Visible = false;
            btnChat.Visible = false;
            button2.Visible = false;
        }

        private void btnMain_Click_1(object sender, EventArgs e)
        {
            if (_Status == EnStatus.AddStudent)
            {
                _ResetDefualtValuesForAddNewStatus();
            }
            else
            {
                _ResetDefualtValuesForStudentExistsStatus();
            }
        }

        private void btnChat_Click_1(object sender, EventArgs e)
        {
            frmStudentChatPage frm = new frmStudentChatPage();
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddStudent_Click_1(object sender, EventArgs e)
        {
            frmAddUpdateStudent frm = new frmAddUpdateStudent();
            frm.ShowDialog();
            btnChat.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmLocalRaceChoosingPage_ frm = new frmLocalRaceChoosingPage_();
            frm.ShowDialog();
        }
    }
}

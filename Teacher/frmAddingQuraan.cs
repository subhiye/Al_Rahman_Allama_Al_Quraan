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
    public partial class frmAddingQuraan : Form
    {
        public frmAddingQuraan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int _StudentID = -1;
        private string _StudentName = "";


        public frmAddingQuraan(int StudentID, string StudentName)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _StudentName = StudentName;
        }
        private void frmAddingQuraan_Load(object sender, EventArgs e)
        {
            clsStudent Student = clsStudent.FindByStudentID(_StudentID);
            lblStudentName.Text = _StudentName;
        }
      
        private void btn_All_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string JuzName = "Juz " + btn.Tag.ToString();
            string JuzNumber = btn.Tag.ToString();
            frmSurahsList surList = new frmSurahsList(JuzName, JuzNumber, _StudentID);
            surList.ShowDialog();
        }
    }
}
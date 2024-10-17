using Alrahman_Allama_Allquran.Properties;
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

namespace Alrahman_Allama_Allquran.Parent
{
    public partial class frmChildGradesDetails : Form
    {
        public frmChildGradesDetails()
        {
            InitializeComponent();
        }

        private string _StudentName = "";
        private int _StudentAge = 0;
        private int _StudentID = 0;
        clsStudent _Student;

        public frmChildGradesDetails(int StudentiD)
        {
            InitializeComponent();
            _StudentID = StudentiD;
        }
        private int CalculateAge(DateTime birthdate, DateTime currentDate)
        {
            int age = currentDate.Year - birthdate.Year;
            if (birthdate > currentDate.AddYears(-age))
                age--;
            return age;
        }

        private int GetPersonAge(DateTime DateOfBirth)
        {
            DateTime dateOfBirth = DateOfBirth;
            DateTime currentDate = DateTime.Now;
            int age = CalculateAge(dateOfBirth, currentDate);
            return age;
        }

        private void SetInformation()
        {
            _Student = clsStudent.FindByStudentID(_StudentID);

            lblAge.Text = GetPersonAge(_Student.PersonInfo.DateOfBirth).ToString();
            lblStudentName.Text = _Student.PersonInfo.FullName;

            if (_Student.PersonInfo.ImagePath == "" || _Student.PersonInfo.ImagePath == null)
            {
                if (_Student.PersonInfo.Geder == 0)
                {
                    pbStudent.Image = Resources.Ekran_görüntüsü_2024_10_07_135238;
                }
                else
                {
                    pbStudent.Image = Resources.Ekran_görüntüsü_2024_10_07_135130;
                }
            }
            else
            {
                if (_Student.PersonInfo.ImagePath != "" || _Student.PersonInfo.ImagePath != null)
                {
                    pbStudent.ImageLocation = _Student.PersonInfo.ImagePath;
                }
            }
        }

        private short GetMemorizingPageCount(int JuzID)
        {
            short MemorizingRecordPageCount = clsJuzRecord.FindMemorizingRecord(_StudentID, JuzID);
            return MemorizingRecordPageCount;
        }

        private void GetMemorizingPagesCounts(Button btnJuzNum, ProgressBar pbJuzProgres, Label lblProgress)
        {
            pbJuzProgres.Value = 0;
            pbJuzProgres.Maximum = 100;
            pbJuzProgres.Minimum = 0;

            ushort JuzID = Convert.ToUInt16(btnJuzNum.Tag);
            short Juz1MemorizedPageCount = GetMemorizingPageCount(JuzID);

            if (Juz1MemorizedPageCount > 0)
            {
                float percentageMemorized = (Juz1MemorizedPageCount / 20.0f) * 100;

                pbJuzProgres.Value = (int)percentageMemorized;

                lblProgress.Text = percentageMemorized + "%";
            }
            else
            {
                lblProgress.Text = "0";
                pbJuzProgres.Value = 0;
            }
        }

        private void frmChildGradesDetails_Load_1(object sender, EventArgs e)
        {
            SetInformation();
            GetMemorizingPagesCounts(btn1, p1, lbl1);
            GetMemorizingPagesCounts(btn2, p2, lbl2);
            GetMemorizingPagesCounts(btn3, p3, lbl3);
            GetMemorizingPagesCounts(btn4, p4, lbl4);
            GetMemorizingPagesCounts(btn5, p5, lbl5);
            GetMemorizingPagesCounts(btn6, p6, lbl6);
            GetMemorizingPagesCounts(btn7, p7, lbl7);
            GetMemorizingPagesCounts(btn8, p8, lbl8);
            GetMemorizingPagesCounts(btn9, p9, lbl9);
            GetMemorizingPagesCounts(btn10, p10, lbl10);
            GetMemorizingPagesCounts(btn11, p11, lbl11);
            GetMemorizingPagesCounts(btn12, p12, lbl12);
            GetMemorizingPagesCounts(btn13, p13, lbl13);
            GetMemorizingPagesCounts(btn14, p14, lbl14);
            GetMemorizingPagesCounts(btn15, p15, lbl15);
            GetMemorizingPagesCounts(btn16, p16, lbl16);
            GetMemorizingPagesCounts(btn17, p17, lbl17);
            GetMemorizingPagesCounts(btn18, p18, lbl18);
            GetMemorizingPagesCounts(btn19, p19, lbl19);
            GetMemorizingPagesCounts(btn20, p20, lbl20);
            GetMemorizingPagesCounts(btn21, p21, lbl21);
            GetMemorizingPagesCounts(btn22, p22, lbl22);
            GetMemorizingPagesCounts(btn23, p23, lbl23);
            GetMemorizingPagesCounts(btn24, p24, lbl24);
            GetMemorizingPagesCounts(btn25, p25, lbl25);
            GetMemorizingPagesCounts(btn26, p26, lbl26);
            GetMemorizingPagesCounts(btn27, p27, lbl27);
            GetMemorizingPagesCounts(btn28, p28, lbl28);
            GetMemorizingPagesCounts(btn29, p29, lbl29);
            GetMemorizingPagesCounts(btn30, p30, lbl30);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
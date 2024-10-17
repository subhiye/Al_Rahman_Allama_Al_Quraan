using Alrahman_Allama_Allquran.Global_Class;
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

namespace Alrahman_Allama_Allquran.chat
{
    public partial class frmDisplayMessagesPage : Form
    {
        public frmDisplayMessagesPage()
        {
            InitializeComponent();
        }
        enum EnStatus { ShowCurrentStudentMessages = 1, ShowAnotherStudentMessages = 2 }

        private EnStatus _Status;

        private string _StudentUrl = "";

        private int _StudentID = -1;

        public frmDisplayMessagesPage(int AnotherStudentID, string StudentImagePath)
        {
            InitializeComponent();
            _StudentID = AnotherStudentID;
            _StudentUrl = StudentImagePath;
            _Status = EnStatus.ShowAnotherStudentMessages;
        }
        public frmDisplayMessagesPage(string AnotherStudentUrl, int StudentID)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _StudentUrl = AnotherStudentUrl;
            _Status = EnStatus.ShowCurrentStudentMessages;
        }

        private void GetSenderPicture(int StudentID, string ImagePath)
        {
            if (ImagePath != null && ImagePath != "")
            {
                pictureBox1.ImageLocation = ImagePath;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.Ekran_görüntüsü_2024_10_07_135130;
            }
        }

        private void frmDisplayMessagesPage_Load_1(object sender, EventArgs e)
        {
            int CurrentStudentID = clsGlobalObjects.CurrentStudent.StudentID;

            List<clsStudentMessages> StudentMessages;

            if (_Status == EnStatus.ShowCurrentStudentMessages)
            {
                StudentMessages = clsStudentMessages.GetAllStudentMessages(_StudentID, clsGlobalObjects.CurrentStudent.StudentID);
                GetSenderPicture(clsGlobalObjects.CurrentStudent.StudentID, _StudentUrl);
            }
            else
            {
                StudentMessages = clsStudentMessages.GetAllStudentMessages(clsGlobalObjects.CurrentStudent.StudentID, _StudentID);
                GetSenderPicture(_StudentID, _StudentUrl);
            }
            if (StudentMessages.Count <= 0)
            {
                // MessageBox.Show("Sorry Your Don't Have Any Messages", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblEmpty.Text = "There Is No Messages You Got.";
            }
            else
            {
                int ControlsLocationset = 10;

                foreach (var Message in StudentMessages)
                {
                    Label contentLabel = new Label();
                    contentLabel.Text = Message.Content;
                    contentLabel.Location = new Point(10, ControlsLocationset);
                    contentLabel.AutoSize = true;
                    contentLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                    contentLabel.ForeColor = Color.Black;
                    this.Controls.Add(contentLabel);

                    Label dateLabel = new Label();
                    dateLabel.Text = Message.SentAt.ToString();
                    dateLabel.Location = new Point(10, ControlsLocationset + 20);
                    dateLabel.AutoSize = true;
                    dateLabel.Font = new Font("Arial", 16, FontStyle.Italic);
                    dateLabel.ForeColor = Color.White;
                    this.Controls.Add(dateLabel);


                    ControlsLocationset += 100;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
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
    public partial class frmSendMessage : Form
    {
        private int _StudentID = -1;
        private string _STudentName = "";
        private int _JuzID = 0;
        private string _StudentPageUrl = "";

        public frmSendMessage()
        {
            InitializeComponent();
        }

        public frmSendMessage(int StudentID, string StudetnName, int JuzID, string StudentPageUrl)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _STudentName = StudetnName;
            _JuzID = JuzID;
            _StudentPageUrl = StudentPageUrl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetStudentInfo()
        {
            txtJuzCount.Text = _JuzID.ToString();
            txtStudentName.Text = _STudentName;
            txtStudentNumber.Text = _StudentID.ToString();
            pictureBox1.ImageLocation = _StudentPageUrl;
        }
        private void MessageCountPerStudent(int StudentID, int SenderID, Label label)
        {
            label.Text = clsStudentMessages.MessageCountPerStudent(StudentID, SenderID).ToString();
        }

        private void frmSendMessage_Load(object sender, EventArgs e)
        {
            GetStudentInfo();
            MessageCountPerStudent(clsGlobalObjects.CurrentStudent.StudentID, _StudentID, label4);
            MessageCountPerStudent(_StudentID, clsGlobalObjects.CurrentStudent.StudentID, label5);
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "this Message Is Not Valid Becuase It is Empty Fill The Field Please");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "this Message Is Not Valid Becuase It is Empty Fill The Field Please");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            clsStudentMessages StudentsMessages = new clsStudentMessages();
            StudentsMessages.ReceiverID = _StudentID;
            StudentsMessages.SenderID = clsGlobalObjects.CurrentStudent.StudentID;
            StudentsMessages.Content = textBox1.Text;
            StudentsMessages.SentAt = DateTime.Now;
            clsStudent _Receiver = clsStudent.FindByStudentID(_StudentID);
            if (_Receiver != null && StudentsMessages.ReceiverID != StudentsMessages.SenderID)
            {
                if(StudentsMessages.AddNewMessage())
                {
                    MessageBox.Show("Your Message Sent Successfully ", "Nice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageCountPerStudent(_StudentID, clsGlobalObjects.CurrentStudent.StudentID, label5);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Faild Sent Your Message", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Faild Sent Your Message , this Student Is Not Found In OUr System", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDisplayMessagesPage frm = new frmDisplayMessagesPage(_StudentPageUrl,_StudentID);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDisplayMessagesPage frm = new frmDisplayMessagesPage(_StudentID, _StudentPageUrl);
            frm.ShowDialog();
        }
    }
}

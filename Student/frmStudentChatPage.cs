using Alrahman_Allama_Allquran.chat;
using Alrahman_Allama_Allquran.Global_Class;
using alrahman_Allama_Alquran_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran.Student
{
    public partial class frmStudentChatPage : Form
    {
        public frmStudentChatPage()
        {
            InitializeComponent();
        }
        private int _StudentID = -1;

        private string _StudentName = "";

        private int _JuzID = 0;

        private string _StudentPageUrl = "";
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int StudentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (StudentID == clsGlobalObjects.CurrentStudent.StudentID)
            {
                MessageBox.Show("You Can't choose Your Self Please choose Another Student !", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _StudentID = ((int)dataGridView1.CurrentRow.Cells[0].Value);
                _StudentName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtStudentName.Text = _StudentName;
                _JuzID = (int)dataGridView1.CurrentRow.Cells[2].Value;
                clsStudent Student = clsStudent.FindByStudentID(((int)dataGridView1.CurrentRow.Cells[0].Value));
                _StudentPageUrl = Student.PersonInfo.ImagePath;
            }
        }

        private void frmStudentChatPage_Load_1(object sender, EventArgs e)
        {
            DataTable dtStudentsListRanke = clsStudentRank.GetStudetnsRanks();
            if (dtStudentsListRanke.Rows.Count > 0)
            {
                dtStudentsListRanke.Columns.Add("Image", typeof(Image));
                foreach (DataRow row in dtStudentsListRanke.Rows)
                {
                    string imagePath = row["ImagePath"].ToString();
                    if (File.Exists(imagePath)) row["Image"] = Image.FromFile(imagePath);
                    else
                    {
                        string gender = row["Gender"].ToString();
                        if (gender == "Male") row["Image"] = Properties.Resources.Ekran_görüntüsü_2024_10_07_135238;
                        else row["Image"] = Properties.Resources.Ekran_görüntüsü_2024_10_07_135130;
                    }
                }
                dataGridView1.DataSource = dtStudentsListRanke;
                dataGridView1.Columns["StudentID"].HeaderText = "Student ID";
                dataGridView1.Columns["StudentID"].Width = 100;
                dataGridView1.Columns["FullName"].HeaderText = "Full Name";
                dataGridView1.Columns["FullName"].Width = 100;
                dataGridView1.Columns["MemorizedPageCount"].HeaderText = "Memorized Juz Count";
                dataGridView1.Columns["MemorizedPageCount"].Width = 100;
                dataGridView1.Columns["Gender"].HeaderText = "Gender";
                dataGridView1.Columns["Gender"].Width = 100;
                dataGridView1.Columns["ImagePath"].Visible = false;
                dataGridView1.Columns["StudentLevel"].HeaderText = "Student Level";
                dataGridView1.Columns["StudentLevel"].Width = 100;
                dataGridView1.Columns.Remove("Image");
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "Image";
                imgColumn.HeaderText = "Image";
                imgColumn.DataPropertyName = "Image";
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(imgColumn);
                dataGridView1.RowTemplate.Height = 50;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
            {
                MessageBox.Show("There Is No Students List To Show Sorry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtStudentName.Text == null || txtStudentName.Text == "")
            {
                MessageBox.Show("choose A Student Please To Continue", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmSendMessage frm = new frmSendMessage(_StudentID, _StudentName, _JuzID, _StudentPageUrl);
                frm.ShowDialog();
            }
        }
    }
}
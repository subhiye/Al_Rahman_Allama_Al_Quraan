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
    public partial class frmStudentsOrdering : Form
    {
        public frmStudentsOrdering()
        {
            InitializeComponent();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudentsOrdering_Load_1(object sender, EventArgs e)
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
                dataGridView1.Columns["ImagePath"].Visible = false; // Hide the path column
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
    }
}
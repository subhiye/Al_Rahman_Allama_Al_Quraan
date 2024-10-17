using alrahman_Allama_Alquran_Business;
using System;
using System.Data;
using System.Windows.Forms;
namespace Alrahman_Allama_Allquran.Student
{
    public partial class frmAllStudentRevsionRecords : Form
    {
        private string _StudentName = "";

        private int _StudentID = -1;

        private short _JuzID = -1;

        public frmAllStudentRevsionRecords(int StudentID, short JuzID)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _JuzID = JuzID;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAllStudentRevsionRecords_Load(object sender, EventArgs e)
        {
            DataTable dtAllRecords = clsRevision_Record.GetRevisionRecordForStudentPerJuz(_StudentID, _JuzID);
            dataGridView1.DataSource = dtAllRecords;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Student Name";
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].HeaderText = "Revision ID";
                dataGridView1.Columns[1].Width = 90;
                dataGridView1.Columns[2].HeaderText = "Reviewed Page Count";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Review Date";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Any Additional Notes";
                dataGridView1.Columns[4].Width = 90;
                dataGridView1.Columns[5].HeaderText = "Juz Number";
                dataGridView1.Columns[5].Width = 90;
                dataGridView1.Columns[6].HeaderText = "Mistake Count";
                dataGridView1.Columns[6].Width = 100;
            }
            else
            {
                MessageBox.Show(_StudentName + "Has No Records In Our System ", "Warning");
                return;
            }
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
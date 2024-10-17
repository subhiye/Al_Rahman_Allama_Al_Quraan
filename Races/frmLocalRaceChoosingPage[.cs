using Alrahman_Allama_Allquran.Global_Class;
using Alrahman_Allama_Allquran.Invitations;
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

namespace Alrahman_Allama_Allquran.Races
{
    public partial class frmLocalRaceChoosingPage_ : Form
    {
        public frmLocalRaceChoosingPage_()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellContentDoubleClick);
        }

        private int _StudentID = -1;

        private string _StudentName = "";

        private int _JuzID = 0;

        private string _StudentPageUrl = "";

        private int selectedRaceTypeID = -1;

        private int _RaceID = -1;

        DataTable dtAllRaces = clsRaceDetails.GetAllRaces();

        private void FillRacesList()
        {
            foreach (DataRow row in dtAllRaces.Rows)
            {
                comboBox1.Items.Add(row["RaceTypeName"].ToString());
            }
        }

        private void frmLocalRaceChoosingPage__Load(object sender, EventArgs e)
        {
            DataTable dtStudentsListRanke = clsStudentRank.GetStudetnsRanks();
            
            if (dtStudentsListRanke.Rows.Count > 0)
            {
                dtStudentsListRanke.Columns.Add("Image", typeof(Image));
                foreach (DataRow row in dtStudentsListRanke.Rows)
                {
                    string imagePath = row["ImagePath"].ToString();
                    if (File.Exists(imagePath))
                        row["Image"] = Image.FromFile(imagePath);
                    else
                    {
                        string gender = row["Gender"].ToString();
                        if (gender == "Male")
                            row["Image"] = Properties.Resources.Ekran_görüntüsü_2024_10_07_135238;
                        else
                            row["Image"] = Properties.Resources.Ekran_görüntüsü_2024_10_07_135130;
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
            FillRacesList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtStudentNumber.Text == "")
            {
                MessageBox.Show("Choose A Student To Show Your Invitations Please.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                frmShowStudentsInvitations frm = new frmShowStudentsInvitations(_StudentPageUrl, _StudentID);
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int StudentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (StudentID == clsGlobalObjects.CurrentStudent.StudentID)
            {
                MessageBox.Show("You Cann't Send Your Self An Invitationa ");
                return;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _StudentID = ((int)dataGridView1.CurrentRow.Cells[0].Value);
                txtStudentNumber.Text = _StudentID.ToString();

                _StudentName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtStudentName.Text = _StudentName.ToString();

                _JuzID = (int)dataGridView1.CurrentRow.Cells[2].Value;
                txtJuzCount.Text = _JuzID.ToString();

                clsStudent Student = clsStudent.FindByStudentID(((int)dataGridView1.CurrentRow.Cells[0].Value));
                _StudentPageUrl = Student.PersonInfo.ImagePath;

                if (!string.IsNullOrEmpty(_StudentPageUrl))
                {
                    pictureBox1.ImageLocation = _StudentPageUrl;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.Ekran_görüntüsü_2024_10_07_135238;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Choose The rAce tyupe Please");
            }
            if (clsInvitation.IsInvitationFound(clsGlobalObjects.CurrentStudent.StudentID, _StudentID))
            {
                MessageBox.Show("You Allready Invited This Student For This Race Already");
                return;
            }
            int RaceID = _RaceID;
            clsInvitation Invitation = new clsInvitation();

            Invitation.RaceID = RaceID;
            Invitation.SenderID = clsGlobalObjects.CurrentStudent.StudentID;
            Invitation.ReceiverID = _StudentID;
            Invitation.SentAt = DateTime.Now;
            Invitation.Status = "Wating Acceptance";

            clsStudent Student = clsStudent.FindByStudentID(_StudentID);
            if(Student == null)
            {
                MessageBox.Show("This Friend Is Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if(Invitation.AddNewInvitation())
                {
                    MessageBox.Show("Your Invitation Is Sent To Your Friend", "Wow Hobe You Fun Time In That", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Faild Sent To Your Friend ", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRAcetypeName = comboBox1.SelectedItem.ToString();
            _RaceID = clsRaceType.FindRaceType(selectedRAcetypeName);
            if (_RaceID != -1)
            {
                selectedRaceTypeID = _RaceID;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if(txtStudentName.Text == "")
            {
                MessageBox.Show("choose A Student To Show Your Invitation Please .", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                frmShowStudentsInvitations frm = 
                new frmShowStudentsInvitations(_StudentID, _StudentPageUrl);
                frm.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Choose The Race tyupe Please");
                return;
            }
            
            string SelectedRaceTypeName  = comboBox1.SelectedItem.ToString();

            int RaceID = clsRaceType.FindRaceType(SelectedRaceTypeName);

            if(RaceID != -1)
            {
                selectedRaceTypeID = RaceID;
                frmShowRacescs frm = new frmShowRacescs( RaceID, _StudentID, _StudentPageUrl);
                frm.ShowDialog();
            }
            
            else
            {
                MessageBox.Show("There Is No Race Called "+ selectedRaceTypeID, "Sorry");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBox1, "Choose a Race Please .");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }
    }
}
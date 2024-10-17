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

namespace Alrahman_Allama_Allquran.Races
{
    public partial class frmShowRacescs : Form
    {
        private int _RaceTypeID = -1;
        private int _StudentID = -1;
        private string _ImagePath = "";

        public frmShowRacescs(int RaceID, int StudentID, string ImagePath)
        {
            InitializeComponent();
            _RaceTypeID = RaceID;
            _StudentID = StudentID;
            _ImagePath = ImagePath;
        }
        
        private void SetControlsFormForRace(clsRaceDetails dtRaseDetails, int yPos = 10)
        {

            Label lblRaceName = new Label();

            string RaceName = dtRaseDetails.RaceType.RacetypeName;
            lblRaceName.Text = RaceName;

            lblRaceName.ForeColor = Color.Black;
            lblRaceName.Font = new Font(lblRaceName.Font.FontFamily, 12);
            lblRaceName.Location = new Point(10, yPos);
            lblRaceName.AutoSize = true;
            this.Controls.Add(lblRaceName);


            Label lblStartDate = new Label();
            lblStartDate.Text = dtRaseDetails.StartDate.ToString();
            lblStartDate.ForeColor = Color.Black;
            lblStartDate.Font = new Font(lblStartDate.Font.FontFamily, 12);
            lblStartDate.Location = new Point(10, yPos + 30);
            lblStartDate.AutoSize = true;
            this.Controls.Add(lblStartDate);

            Label lblEndDate = new Label();
            lblEndDate.Text = dtRaseDetails.EndDate.ToString();
            lblEndDate.ForeColor = Color.Black;
            lblEndDate.Font = new Font(lblStartDate.Font.FontFamily, 12);
            lblEndDate.Location = new Point(10, yPos + 50);
            lblEndDate.AutoSize = true;
            this.Controls.Add(lblEndDate);

            PictureBox pboxStudent = new PictureBox();
            pboxStudent.Height = 100;
            pboxStudent.Width = 100;
            pboxStudent.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!string.IsNullOrEmpty(clsGlobalObjects.CurrentStudent.PersonInfo.ImagePath))
            {
                pboxStudent.ImageLocation = clsGlobalObjects.CurrentStudent.PersonInfo.ImagePath;
            }
            else
            {
                pboxStudent.Image = Properties.Resources.Ekran_görüntüsü_2024_10_07_135238;
            }
            pboxStudent.Location = new Point(400, yPos + 10);
            this.Controls.Add(pboxStudent);

            Label lblSenderID = new Label();
            lblSenderID.Text = dtRaseDetails.SenderID.ToString();
            lblSenderID.ForeColor = Color.Black;
            lblSenderID.Location = new Point(400, yPos + 120);
            lblSenderID.AutoSize = true;
            lblSenderID.Font = new Font(lblSenderID.Font.FontFamily, 16);
            this.Controls.Add(lblSenderID);

            PictureBox pboxStudentPage = new PictureBox();
            pboxStudentPage.Height = 100;
            pboxStudentPage.Width = 100;
            pboxStudentPage.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!string.IsNullOrEmpty(_ImagePath))
            {
                pboxStudentPage.ImageLocation = _ImagePath;
            }
            else
            {
                pboxStudentPage.Image = Properties.Resources.Ekran_görüntüsü_2024_10_07_135130;
            }
            pboxStudentPage.Location = new Point(700, yPos + 10);
            this.Controls.Add(pboxStudentPage);

            Label lblReceiverID = new Label();
            lblReceiverID.Text = dtRaseDetails.ReceiverID.ToString();
            lblReceiverID.ForeColor = Color.Black;
            lblReceiverID.Location = new Point(700, yPos + 120);
            lblReceiverID.AutoSize = true;
            lblReceiverID.Font = new Font(lblReceiverID.Font.FontFamily, 16);
            this.Controls.Add(lblReceiverID);

            Label lblStatus = new Label();
            lblStatus.Text = dtRaseDetails.Status;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(10, yPos + 80);
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font(lblSenderID.Font.FontFamily, 16);
            this.Controls.Add(lblStatus);
            yPos += 240;
        }
        
       
        private void frmShowRacescs_Load(object sender, EventArgs e)
        {
            int CurrentStudent = clsGlobalObjects.CurrentStudent.StudentID;

            clsRaceDetails ComplitedRaceDetails = clsRaceDetails.GetStudentsRaceInformationForComplitedRaces(CurrentStudent, _StudentID, _RaceTypeID);

            
            if (ComplitedRaceDetails == null)
            {
                MessageBox.Show("There Is No Races You Joined Here In This Page");
                return;
            }
            else
            {
                SetControlsFormForRace(ComplitedRaceDetails, 250);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
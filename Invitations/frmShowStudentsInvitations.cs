using Alrahman_Allama_Allquran.Global_Class;
using alrahman_Allama_Alquran_Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran.Invitations
{
    public partial class frmShowStudentsInvitations : Form
    {
        enum EnMode { ShowYourInvitation = 0, ShowStudentsInvitation = 1 }
        EnMode _Mode;

        private int _StudentID = -1;
        private string _ImagePath = "";
        private static int _RaceID = -1;
        private int _RaceTypeID = -1;
        clsInvitation Invitation;

        public frmShowStudentsInvitations(string ImagePath, int StudentID)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _ImagePath = ImagePath;
            _Mode = EnMode.ShowYourInvitation;
        }

        public frmShowStudentsInvitations(int StudentID, string ImagePath)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _ImagePath = ImagePath;
            _Mode = EnMode.ShowStudentsInvitation;
        }

        private void btnAgree_Click(object sender, EventArgs e, int InvitationID)
        {
            clsInvitation Invitation = clsInvitation.Find(InvitationID);

            if (Invitation == null)
            {
                MessageBox.Show("There Is No Invitation To Update ");
                return;
            }
            
            else
            {
                Invitation.Status = "Agreed";

                if (Invitation.UpdateInvitation(InvitationID))
                {
                    Button btn = (Button)sender;
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                    btn.Text = "Agreed";
                    btn.Enabled = false;

                    clsRaceDetails Race = new clsRaceDetails();

                    Race.SenderID = _StudentID;
                    Race.ReceiverID = clsGlobalObjects.CurrentStudent.StudentID;
                    Race.StartDate = DateTime.Now;
                    Race.EndDate = Race.EndDate.AddDays(15);
                    Race.Status = "Race On";
                    Race.RaceTypeID = Invitation.RaceID;
                    _RaceID = Race.AddRaceDetails();
                    if (_RaceID != -1)
                    {
                        foreach (var control in invitationControls)
                        {
                            control.Visible = false;
                        }

                        SetControlsFromForRace();
                    }
                    else
                    {
                        MessageBox.Show("Failed Adding Race Sorry");
                    }
                }
                else
                {
                    MessageBox.Show("Failed Updating Sorry");
                }
            }
        }

        private void SetControlsFromForRace()
        {
            int yPos = 10;

            clsRaceDetails dtRaseDetails = clsRaceDetails.FindRace(_RaceID);

            if (dtRaseDetails == null)
            {
                MessageBox.Show("Sorrey this Race Is Not Found .");
                return;
            }

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
            lblStartDate.Text = dtRaseDetails.EndDate.ToString();
            lblStartDate.ForeColor = Color.Black;
            lblStartDate.Font = new Font(lblStartDate.Font.FontFamily, 12);
            lblStartDate.Location = new Point(10, yPos + 30);
            lblStartDate.AutoSize = true;
            this.Controls.Add(lblStartDate);

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

            yPos += 240;
        }

        private List<Control> invitationControls = new List<Control>();

        private void SetControlsFromForInvitation(int SenderID, int ReceiverID)
        {
            if (Invitation == null)
            {
                Label lblMessage = new Label();
                lblMessage.Text = "There Is No Invitations Between You And This Student ;";
                lblMessage.ForeColor = Color.Black;
                lblMessage.Font = new Font(lblMessage.Font.FontFamily, 32);
                lblMessage.Location = new Point(50, 50);
                lblMessage.AutoSize = true;
                this.Controls.Add(lblMessage);
            }
            int yPos = 10;


            Label lblRaceID = new Label();

            lblRaceID.Text = Invitation.RaceID.ToString();
            lblRaceID.ForeColor = Color.Black;
            lblRaceID.Font = new Font(lblRaceID.Font.FontFamily, 12);
            lblRaceID.Location = new Point(10, yPos);
            lblRaceID.AutoSize = true;
            this.Controls.Add(lblRaceID);
            invitationControls.Add(lblRaceID);

            Label lblInvitationID = new Label();
            lblInvitationID.Text = Invitation.InvitationID.ToString();
            lblInvitationID.ForeColor = Color.Black;
            lblInvitationID.Font = new Font(lblInvitationID.Font.FontFamily, 12);
            lblInvitationID.Location = new Point(10, yPos + 30);
            lblInvitationID.AutoSize = true;
            this.Controls.Add(lblInvitationID);
            invitationControls.Add(lblInvitationID);

            Label lblStatus = new Label();
            lblStatus.Text = Invitation.Status;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Font = new Font(lblStatus.Font.FontFamily, 12);
            lblStatus.Location = new Point(10, yPos + 60);
            lblStatus.AutoSize = true;
            this.Controls.Add(lblStatus);
            invitationControls.Add(lblStatus);

            Label lblSentAt = new Label();
            lblSentAt.Text = Invitation.SentAt.ToString();
            lblSentAt.Font = new Font(lblSentAt.Font.FontFamily, 12);
            lblSentAt.Location = new Point(10, yPos + 90);
            lblSentAt.AutoSize = true;
            this.Controls.Add(lblSentAt);
            invitationControls.Add(lblSentAt);

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
                pboxStudent.Image = Properties.Resources.Ekran_görüntüsü_2024_10_07_1351301;
            }
            pboxStudent.Location = new Point(400, yPos + 10);
            this.Controls.Add(pboxStudent);
            invitationControls.Add(pboxStudent);

            Label lblSenderID = new Label();
            lblSenderID.Text = Invitation.SenderID.ToString();
            lblSenderID.ForeColor = Color.Black;
            lblSenderID.Location = new Point(400, yPos + 120);
            lblSenderID.AutoSize = true;
            lblSenderID.Font = new Font(lblSenderID.Font.FontFamily, 16);
            this.Controls.Add(lblSenderID);
            invitationControls.Add(lblSenderID);

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
                pboxStudentPage.Image = Properties.Resources.Ekran_görüntüsü_2024_10_07_135238;
            }
            pboxStudentPage.Location = new Point(700, yPos + 10);
            this.Controls.Add(pboxStudentPage);
            invitationControls.Add(pboxStudentPage);

            Label lblReceiverID = new Label();
            lblReceiverID.Text = Invitation.ReceiverID.ToString();
            lblReceiverID.ForeColor = Color.Black;
            lblReceiverID.Location = new Point(700, yPos + 120);
            lblReceiverID.AutoSize = true;
            lblReceiverID.Font = new Font(lblReceiverID.Font.FontFamily, 16);
            this.Controls.Add(lblReceiverID);
            invitationControls.Add(lblReceiverID);

            Button btnAgree = new Button();
            btnAgree.Text = "Join";
            btnAgree.Location = new Point(900, yPos + 50);
            btnAgree.Click += (s, ev) => btnAgree_Click(s, ev, Invitation.InvitationID);
            this.Controls.Add(btnAgree);
            invitationControls.Add(btnAgree);
            yPos += 240;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetInvitaionForStudentOrReceiver()
        {
            if(_Mode == EnMode.ShowYourInvitation)
            {
                Invitation = clsInvitation.GetInvitationBySenderIDReceiverID( clsGlobalObjects.CurrentStudent.StudentID, _StudentID);
            }
            else
            {
                Invitation = clsInvitation.GetInvitationBySenderIDReceiverID(_StudentID, clsGlobalObjects.CurrentStudent.StudentID);              
            }
        }

        private void frmShowStudentsInvitations_Load_1(object sender, EventArgs e)
        {
            GetInvitaionForStudentOrReceiver();

            if(Invitation != null)
            {
                if (_Mode == EnMode.ShowStudentsInvitation)
                {
                    SetControlsFromForInvitation(_StudentID, clsGlobalObjects.CurrentStudent.StudentID);
                }
                else
                {
                    SetControlsFromForInvitation(clsGlobalObjects.CurrentStudent.StudentID, _StudentID);
                }
            }
            else
            {
                MessageBox.Show("There Is No Invitaion ","Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

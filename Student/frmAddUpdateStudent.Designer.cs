namespace Alrahman_Allama_Allquran.Student
{
    partial class frmAddUpdateStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPersonInfoNext = new System.Windows.Forms.Button();
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardInfoWithFilter1 = new Alrahman_Allama_Allquran.People.Controls.ctrlPersonCardInfoWithFilter();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbTeachersName = new System.Windows.Forms.ComboBox();
            this.dtpMemberShipExpireDate = new System.Windows.Forms.DateTimePicker();
            this.dtpMemberShipStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblSt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtStudentNickName = new System.Windows.Forms.TextBox();
            this.lblParentLastName = new System.Windows.Forms.Label();
            this.lblStudentNickName = new System.Windows.Forms.Label();
            this.lblParentBirhtDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcUserInfo.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(458, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 35);
            this.lblTitle.TabIndex = 127;
            this.lblTitle.Text = "Adding  Student Page";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(885, 720);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1019, 720);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 125;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnPersonInfoNext
            // 
            this.btnPersonInfoNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPersonInfoNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPersonInfoNext.Location = new System.Drawing.Point(1019, 671);
            this.btnPersonInfoNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPersonInfoNext.Name = "btnPersonInfoNext";
            this.btnPersonInfoNext.Size = new System.Drawing.Size(126, 37);
            this.btnPersonInfoNext.TabIndex = 124;
            this.btnPersonInfoNext.Text = "Next";
            this.btnPersonInfoNext.UseVisualStyleBackColor = true;
            this.btnPersonInfoNext.Click += new System.EventHandler(this.btnPersonInfoNext_Click_1);
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tpPersonalInfo);
            this.tcUserInfo.Controls.Add(this.tpLoginInfo);
            this.tcUserInfo.Location = new System.Drawing.Point(167, 84);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(889, 562);
            this.tcUserInfo.TabIndex = 123;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.RosyBrown;
            this.tpPersonalInfo.Controls.Add(this.ctrlPersonCardInfoWithFilter1);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(881, 536);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            // 
            // ctrlPersonCardInfoWithFilter1
            // 
            this.ctrlPersonCardInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardInfoWithFilter1.Location = new System.Drawing.Point(6, 3);
            this.ctrlPersonCardInfoWithFilter1.Name = "ctrlPersonCardInfoWithFilter1";
            this.ctrlPersonCardInfoWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardInfoWithFilter1.Size = new System.Drawing.Size(877, 544);
            this.ctrlPersonCardInfoWithFilter1.TabIndex = 0;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.RosyBrown;
            this.tpLoginInfo.Controls.Add(this.linkLabel1);
            this.tpLoginInfo.Controls.Add(this.cbTeachersName);
            this.tpLoginInfo.Controls.Add(this.dtpMemberShipExpireDate);
            this.tpLoginInfo.Controls.Add(this.dtpMemberShipStartDate);
            this.tpLoginInfo.Controls.Add(this.txtStudentID);
            this.tpLoginInfo.Controls.Add(this.lblSt);
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.label8);
            this.tpLoginInfo.Controls.Add(this.txtParentName);
            this.tpLoginInfo.Controls.Add(this.Email);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.txtStudentNickName);
            this.tpLoginInfo.Controls.Add(this.lblParentLastName);
            this.tpLoginInfo.Controls.Add(this.lblStudentNickName);
            this.tpLoginInfo.Controls.Add(this.lblParentBirhtDate);
            this.tpLoginInfo.Controls.Add(this.pictureBox1);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(881, 536);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "LoginInfo";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(280, 263);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(70, 16);
            this.linkLabel1.TabIndex = 281;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add Parent";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // cbTeachersName
            // 
            this.cbTeachersName.FormattingEnabled = true;
            this.cbTeachersName.Location = new System.Drawing.Point(273, 301);
            this.cbTeachersName.Name = "cbTeachersName";
            this.cbTeachersName.Size = new System.Drawing.Size(216, 21);
            this.cbTeachersName.TabIndex = 280;
            // 
            // dtpMemberShipExpireDate
            // 
            this.dtpMemberShipExpireDate.Location = new System.Drawing.Point(273, 424);
            this.dtpMemberShipExpireDate.Name = "dtpMemberShipExpireDate";
            this.dtpMemberShipExpireDate.Size = new System.Drawing.Size(216, 20);
            this.dtpMemberShipExpireDate.TabIndex = 278;
            // 
            // dtpMemberShipStartDate
            // 
            this.dtpMemberShipStartDate.Location = new System.Drawing.Point(273, 363);
            this.dtpMemberShipStartDate.Name = "dtpMemberShipStartDate";
            this.dtpMemberShipStartDate.Size = new System.Drawing.Size(216, 20);
            this.dtpMemberShipStartDate.TabIndex = 277;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(273, 57);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(216, 20);
            this.txtStudentID.TabIndex = 276;
            // 
            // lblSt
            // 
            this.lblSt.AutoSize = true;
            this.lblSt.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt.Location = new System.Drawing.Point(7, 52);
            this.lblSt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSt.Name = "lblSt";
            this.lblSt.Size = new System.Drawing.Size(114, 25);
            this.lblSt.TabIndex = 275;
            this.lblSt.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 25);
            this.label2.TabIndex = 273;
            this.label2.Text = "Member Ship Expire Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(238, 25);
            this.label8.TabIndex = 268;
            this.label8.Text = "Member Ship Start Date";
            // 
            // txtParentName
            // 
            this.txtParentName.Location = new System.Drawing.Point(273, 240);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.Size = new System.Drawing.Size(216, 20);
            this.txtParentName.TabIndex = 267;
            this.txtParentName.Validating += new System.ComponentModel.CancelEventHandler(this.txtParentName_Validating);
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(7, 300);
            this.Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(148, 25);
            this.Email.TabIndex = 258;
            this.Email.Text = "Teacher Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(273, 179);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(216, 20);
            this.txtPassword.TabIndex = 253;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating_1);
            // 
            // txtStudentNickName
            // 
            this.txtStudentNickName.Location = new System.Drawing.Point(273, 118);
            this.txtStudentNickName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentNickName.Name = "txtStudentNickName";
            this.txtStudentNickName.Size = new System.Drawing.Size(216, 20);
            this.txtStudentNickName.TabIndex = 252;
            this.txtStudentNickName.Validating += new System.ComponentModel.CancelEventHandler(this.txtStudentNickName_Validating_1);
            // 
            // lblParentLastName
            // 
            this.lblParentLastName.AutoSize = true;
            this.lblParentLastName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentLastName.Location = new System.Drawing.Point(7, 176);
            this.lblParentLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParentLastName.Name = "lblParentLastName";
            this.lblParentLastName.Size = new System.Drawing.Size(100, 25);
            this.lblParentLastName.TabIndex = 250;
            this.lblParentLastName.Text = "Password";
            // 
            // lblStudentNickName
            // 
            this.lblStudentNickName.AutoSize = true;
            this.lblStudentNickName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentNickName.Location = new System.Drawing.Point(7, 114);
            this.lblStudentNickName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentNickName.Name = "lblStudentNickName";
            this.lblStudentNickName.Size = new System.Drawing.Size(192, 25);
            this.lblStudentNickName.TabIndex = 249;
            this.lblStudentNickName.Text = "Student Nick Name";
            // 
            // lblParentBirhtDate
            // 
            this.lblParentBirhtDate.AutoSize = true;
            this.lblParentBirhtDate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentBirhtDate.Location = new System.Drawing.Point(7, 238);
            this.lblParentBirhtDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParentBirhtDate.Name = "lblParentBirhtDate";
            this.lblParentBirhtDate.Size = new System.Drawing.Size(134, 25);
            this.lblParentBirhtDate.TabIndex = 247;
            this.lblParentBirhtDate.Text = "Parent Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::Alrahman_Allama_Allquran.Properties.Resources.Ekran_görüntüsü_2024_10_08_105117;
            this.pictureBox1.Location = new System.Drawing.Point(495, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 530);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 274;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1307, 829);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPersonInfoNext);
            this.Controls.Add(this.tcUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateStudent";
            this.Load += new System.EventHandler(this.frmAddUpdateStudent_Load_1);
            this.tcUserInfo.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPersonInfoNext;
        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cbTeachersName;
        private System.Windows.Forms.DateTimePicker dtpMemberShipExpireDate;
        private System.Windows.Forms.DateTimePicker dtpMemberShipStartDate;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblSt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtStudentNickName;
        private System.Windows.Forms.Label lblParentLastName;
        private System.Windows.Forms.Label lblStudentNickName;
        private System.Windows.Forms.Label lblParentBirhtDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private People.Controls.ctrlPersonCardInfoWithFilter ctrlPersonCardInfoWithFilter1;
    }
}
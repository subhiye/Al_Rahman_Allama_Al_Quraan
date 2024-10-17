namespace Alrahman_Allama_Allquran.Parent
{
    partial class frmAddUpdateParent
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
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardInfoWithFilter1 = new Alrahman_Allama_Allquran.People.Controls.ctrlPersonCardInfoWithFilter();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.txtParentID = new System.Windows.Forms.TextBox();
            this.lblSt = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtParentNickName = new System.Windows.Forms.TextBox();
            this.lblParentLastName = new System.Windows.Forms.Label();
            this.lblStudentNickName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPersonInfoNext = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tcUserInfo.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tpPersonalInfo);
            this.tcUserInfo.Controls.Add(this.tpLoginInfo);
            this.tcUserInfo.Location = new System.Drawing.Point(126, 67);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(896, 567);
            this.tcUserInfo.TabIndex = 132;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.RosyBrown;
            this.tpPersonalInfo.Controls.Add(this.ctrlPersonCardInfoWithFilter1);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(888, 541);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            // 
            // ctrlPersonCardInfoWithFilter1
            // 
            this.ctrlPersonCardInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardInfoWithFilter1.Location = new System.Drawing.Point(6, 6);
            this.ctrlPersonCardInfoWithFilter1.Name = "ctrlPersonCardInfoWithFilter1";
            this.ctrlPersonCardInfoWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardInfoWithFilter1.Size = new System.Drawing.Size(882, 532);
            this.ctrlPersonCardInfoWithFilter1.TabIndex = 0;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.RosyBrown;
            this.tpLoginInfo.Controls.Add(this.txtParentID);
            this.tpLoginInfo.Controls.Add(this.lblSt);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.txtParentNickName);
            this.tpLoginInfo.Controls.Add(this.lblParentLastName);
            this.tpLoginInfo.Controls.Add(this.lblStudentNickName);
            this.tpLoginInfo.Controls.Add(this.pictureBox1);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(888, 541);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "LoginInfo";
            // 
            // txtParentID
            // 
            this.txtParentID.Location = new System.Drawing.Point(190, 57);
            this.txtParentID.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentID.Name = "txtParentID";
            this.txtParentID.Size = new System.Drawing.Size(216, 20);
            this.txtParentID.TabIndex = 276;
            // 
            // lblSt
            // 
            this.lblSt.AutoSize = true;
            this.lblSt.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt.Location = new System.Drawing.Point(7, 52);
            this.lblSt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSt.Name = "lblSt";
            this.lblSt.Size = new System.Drawing.Size(102, 25);
            this.lblSt.TabIndex = 275;
            this.lblSt.Text = "Parent ID";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(190, 160);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(216, 20);
            this.txtPassword.TabIndex = 253;
            // 
            // txtParentNickName
            // 
            this.txtParentNickName.Location = new System.Drawing.Point(190, 109);
            this.txtParentNickName.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentNickName.Name = "txtParentNickName";
            this.txtParentNickName.Size = new System.Drawing.Size(216, 20);
            this.txtParentNickName.TabIndex = 252;
            // 
            // lblParentLastName
            // 
            this.lblParentLastName.AutoSize = true;
            this.lblParentLastName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentLastName.Location = new System.Drawing.Point(7, 153);
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
            this.lblStudentNickName.Location = new System.Drawing.Point(7, 104);
            this.lblStudentNickName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentNickName.Name = "lblStudentNickName";
            this.lblStudentNickName.Size = new System.Drawing.Size(180, 25);
            this.lblStudentNickName.TabIndex = 249;
            this.lblStudentNickName.Text = "Parent Nick Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(413, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 535);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 274;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(762, 688);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 131;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(896, 688);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 130;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnPersonInfoNext
            // 
            this.btnPersonInfoNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPersonInfoNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPersonInfoNext.Location = new System.Drawing.Point(896, 639);
            this.btnPersonInfoNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPersonInfoNext.Name = "btnPersonInfoNext";
            this.btnPersonInfoNext.Size = new System.Drawing.Size(126, 37);
            this.btnPersonInfoNext.TabIndex = 129;
            this.btnPersonInfoNext.Text = "Next";
            this.btnPersonInfoNext.UseVisualStyleBackColor = true;
            this.btnPersonInfoNext.Click += new System.EventHandler(this.btnPersonInfoNext_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(437, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(303, 35);
            this.lblTitle.TabIndex = 128;
            this.lblTitle.Text = "Adding Parent Page";
            // 
            // frmAddUpdateParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1119, 751);
            this.Controls.Add(this.tcUserInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPersonInfoNext);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateParent";
            this.Load += new System.EventHandler(this.frmAddUpdateParent_Load_1);
            this.tcUserInfo.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.TextBox txtParentID;
        private System.Windows.Forms.Label lblSt;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtParentNickName;
        private System.Windows.Forms.Label lblParentLastName;
        private System.Windows.Forms.Label lblStudentNickName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPersonInfoNext;
        private System.Windows.Forms.Label lblTitle;
        private People.Controls.ctrlPersonCardInfoWithFilter ctrlPersonCardInfoWithFilter1;
    }
}
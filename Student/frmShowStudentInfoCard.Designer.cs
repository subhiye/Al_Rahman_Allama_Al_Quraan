namespace Alrahman_Allama_Allquran.Student
{
    partial class frmShowStudentInfoCard
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
            this.btnAddMemorizing = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlStudentInfoCard1 = new Alrahman_Allama_Allquran.Teacher.Controls.ctrlStudentInfoCard();
            this.SuspendLayout();
            // 
            // btnAddMemorizing
            // 
            this.btnAddMemorizing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddMemorizing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMemorizing.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMemorizing.Location = new System.Drawing.Point(675, 785);
            this.btnAddMemorizing.Name = "btnAddMemorizing";
            this.btnAddMemorizing.Size = new System.Drawing.Size(210, 68);
            this.btnAddMemorizing.TabIndex = 126;
            this.btnAddMemorizing.Text = "Add Memorizing";
            this.btnAddMemorizing.UseVisualStyleBackColor = true;
            this.btnAddMemorizing.Click += new System.EventHandler(this.btnAddMemorizing_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(831, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 37);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 33);
            this.label1.TabIndex = 124;
            this.label1.Text = "Student Details ";
            // 
            // ctrlStudentInfoCard1
            // 
            this.ctrlStudentInfoCard1.Location = new System.Drawing.Point(25, 59);
            this.ctrlStudentInfoCard1.Name = "ctrlStudentInfoCard1";
            this.ctrlStudentInfoCard1.Size = new System.Drawing.Size(872, 720);
            this.ctrlStudentInfoCard1.TabIndex = 128;
            // 
            // frmShowStudentInfoCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(909, 867);
            this.Controls.Add(this.ctrlStudentInfoCard1);
            this.Controls.Add(this.btnAddMemorizing);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowStudentInfoCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowStudentInfoCard";
            this.Load += new System.EventHandler(this.frmShowStudentInfoCard_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddMemorizing;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private Teacher.Controls.ctrlStudentInfoCard ctrlStudentInfoCard1;
    }
}
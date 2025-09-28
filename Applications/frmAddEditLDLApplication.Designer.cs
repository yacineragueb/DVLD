namespace DVLD_project.Applications
{
    partial class frmAddEditLDLApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditLDLApplication));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbLDLApplicationInfo = new System.Windows.Forms.TabControl();
            this.PersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LoginInfo = new System.Windows.Forms.TabPage();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLDLApplicationID = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonDetailsWithFilter1 = new DVLD_project.People.Controls.ctrlPersonDetailsWithFilter();
            this.tbLDLApplicationInfo.SuspendLayout();
            this.PersonalInfo.SuspendLayout();
            this.LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(632, 669);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 58);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(748, 669);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 58);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(90, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(695, 58);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "New Local Driving License Application ";
            // 
            // tbLDLApplicationInfo
            // 
            this.tbLDLApplicationInfo.Controls.Add(this.PersonalInfo);
            this.tbLDLApplicationInfo.Controls.Add(this.LoginInfo);
            this.tbLDLApplicationInfo.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLDLApplicationInfo.Location = new System.Drawing.Point(12, 75);
            this.tbLDLApplicationInfo.Name = "tbLDLApplicationInfo";
            this.tbLDLApplicationInfo.SelectedIndex = 0;
            this.tbLDLApplicationInfo.Size = new System.Drawing.Size(850, 588);
            this.tbLDLApplicationInfo.TabIndex = 18;
            this.tbLDLApplicationInfo.SelectedIndexChanged += new System.EventHandler(this.tbLDLApplicationInfo_SelectedIndexChanged);
            // 
            // PersonalInfo
            // 
            this.PersonalInfo.BackColor = System.Drawing.Color.White;
            this.PersonalInfo.Controls.Add(this.btnNext);
            this.PersonalInfo.Controls.Add(this.ctrlPersonDetailsWithFilter1);
            this.PersonalInfo.Location = new System.Drawing.Point(4, 32);
            this.PersonalInfo.Name = "PersonalInfo";
            this.PersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.PersonalInfo.Size = new System.Drawing.Size(842, 552);
            this.PersonalInfo.TabIndex = 0;
            this.PersonalInfo.Text = "Personal Info";
            // 
            // btnNext
            // 
            this.btnNext.ImageIndex = 0;
            this.btnNext.ImageList = this.imageList1;
            this.btnNext.Location = new System.Drawing.Point(718, 486);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 51);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Arrow.png");
            // 
            // LoginInfo
            // 
            this.LoginInfo.Controls.Add(this.pictureBox5);
            this.LoginInfo.Controls.Add(this.pictureBox4);
            this.LoginInfo.Controls.Add(this.pictureBox3);
            this.LoginInfo.Controls.Add(this.cbLicenseClass);
            this.LoginInfo.Controls.Add(this.lblCreatedByUser);
            this.LoginInfo.Controls.Add(this.lblApplicationFees);
            this.LoginInfo.Controls.Add(this.lblApplicationDate);
            this.LoginInfo.Controls.Add(this.label5);
            this.LoginInfo.Controls.Add(this.lblLDLApplicationID);
            this.LoginInfo.Controls.Add(this.pictureBox2);
            this.LoginInfo.Controls.Add(this.pictureBox1);
            this.LoginInfo.Controls.Add(this.label4);
            this.LoginInfo.Controls.Add(this.label3);
            this.LoginInfo.Controls.Add(this.label2);
            this.LoginInfo.Controls.Add(this.label1);
            this.LoginInfo.Location = new System.Drawing.Point(4, 32);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.LoginInfo.Size = new System.Drawing.Size(842, 552);
            this.LoginInfo.TabIndex = 1;
            this.LoginInfo.Text = "Application Info";
            this.LoginInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_project.Properties.Resources.ApplicationType;
            this.pictureBox5.Location = new System.Drawing.Point(247, 210);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_project.Properties.Resources.Money;
            this.pictureBox4.Location = new System.Drawing.Point(247, 276);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_project.Properties.Resources.Date;
            this.pictureBox3.Location = new System.Drawing.Point(247, 153);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(312, 212);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(376, 34);
            this.cbLicenseClass.TabIndex = 16;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(307, 347);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(40, 26);
            this.lblCreatedByUser.TabIndex = 15;
            this.lblCreatedByUser.Text = "N/A";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(307, 280);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(40, 26);
            this.lblApplicationFees.TabIndex = 14;
            this.lblApplicationFees.Text = "N/A";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(307, 157);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(40, 26);
            this.lblApplicationDate.TabIndex = 13;
            this.lblApplicationDate.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Created By:";
            // 
            // lblLDLApplicationID
            // 
            this.lblLDLApplicationID.AutoSize = true;
            this.lblLDLApplicationID.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDLApplicationID.Location = new System.Drawing.Point(307, 94);
            this.lblLDLApplicationID.Name = "lblLDLApplicationID";
            this.lblLDLApplicationID.Size = new System.Drawing.Size(40, 26);
            this.lblLDLApplicationID.TabIndex = 11;
            this.lblLDLApplicationID.Text = "N/A";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_project.Properties.Resources.User;
            this.pictureBox2.Location = new System.Drawing.Point(247, 339);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.ID_Card;
            this.pictureBox1.Location = new System.Drawing.Point(247, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Licesne Class:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "L.D.L Application ID: ";
            // 
            // ctrlPersonDetailsWithFilter1
            // 
            this.ctrlPersonDetailsWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonDetailsWithFilter1.Location = new System.Drawing.Point(3, 5);
            this.ctrlPersonDetailsWithFilter1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ctrlPersonDetailsWithFilter1.Name = "ctrlPersonDetailsWithFilter1";
            this.ctrlPersonDetailsWithFilter1.Size = new System.Drawing.Size(833, 532);
            this.ctrlPersonDetailsWithFilter1.TabIndex = 0;
            // 
            // frmAddEditLDLApplication
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(874, 732);
            this.Controls.Add(this.tbLDLApplicationInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditLDLApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditLDLApplication";
            this.Load += new System.EventHandler(this.frmAddEditLDLApplication_Load);
            this.tbLDLApplicationInfo.ResumeLayout(false);
            this.PersonalInfo.ResumeLayout(false);
            this.LoginInfo.ResumeLayout(false);
            this.LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tbLDLApplicationInfo;
        private System.Windows.Forms.TabPage PersonalInfo;
        private System.Windows.Forms.Button btnNext;
        private People.Controls.ctrlPersonDetailsWithFilter ctrlPersonDetailsWithFilter1;
        private System.Windows.Forms.TabPage LoginInfo;
        private System.Windows.Forms.Label lblLDLApplicationID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblApplicationFees;
    }
}
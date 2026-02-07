namespace DVLD_project.Users
{
    partial class frmAddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUser));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbUserInfo = new System.Windows.Forms.TabControl();
            this.PersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LoginInfo = new System.Windows.Forms.TabPage();
            this.btnConfirmPasswordVisible = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnPasswordVisible = new System.Windows.Forms.Button();
            this.ckbIsActive = new System.Windows.Forms.CheckBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtbConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonDetailsWithFilter1 = new DVLD_project.People.Controls.ctrlPersonDetailsWithFilter();
            this.gbPasswordInformation = new System.Windows.Forms.GroupBox();
            this.tbUserInfo.SuspendLayout();
            this.PersonalInfo.SuspendLayout();
            this.LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbPasswordInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(304, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 58);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Add New User";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(748, 561);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 58);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(632, 561);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 58);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbUserInfo
            // 
            this.tbUserInfo.Controls.Add(this.PersonalInfo);
            this.tbUserInfo.Controls.Add(this.LoginInfo);
            this.tbUserInfo.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserInfo.Location = new System.Drawing.Point(12, 66);
            this.tbUserInfo.Name = "tbUserInfo";
            this.tbUserInfo.SelectedIndex = 0;
            this.tbUserInfo.Size = new System.Drawing.Size(850, 480);
            this.tbUserInfo.TabIndex = 17;
            this.tbUserInfo.SelectedIndexChanged += new System.EventHandler(this.tbUserDetails_SelectedIndexChange);
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
            this.LoginInfo.Controls.Add(this.gbPasswordInformation);
            this.LoginInfo.Controls.Add(this.ckbIsActive);
            this.LoginInfo.Controls.Add(this.lblUserID);
            this.LoginInfo.Controls.Add(this.txtbUsername);
            this.LoginInfo.Controls.Add(this.pictureBox2);
            this.LoginInfo.Controls.Add(this.pictureBox1);
            this.LoginInfo.Controls.Add(this.label2);
            this.LoginInfo.Controls.Add(this.label1);
            this.LoginInfo.Location = new System.Drawing.Point(4, 32);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.LoginInfo.Size = new System.Drawing.Size(842, 444);
            this.LoginInfo.TabIndex = 1;
            this.LoginInfo.Text = "Login Info";
            this.LoginInfo.UseVisualStyleBackColor = true;
            // 
            // btnConfirmPasswordVisible
            // 
            this.btnConfirmPasswordVisible.ImageIndex = 0;
            this.btnConfirmPasswordVisible.ImageList = this.imageList2;
            this.btnConfirmPasswordVisible.Location = new System.Drawing.Point(549, 109);
            this.btnConfirmPasswordVisible.Name = "btnConfirmPasswordVisible";
            this.btnConfirmPasswordVisible.Size = new System.Drawing.Size(55, 31);
            this.btnConfirmPasswordVisible.TabIndex = 5;
            this.btnConfirmPasswordVisible.UseVisualStyleBackColor = true;
            this.btnConfirmPasswordVisible.Click += new System.EventHandler(this.btnConfirmPasswordVisible_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "ClosedEye.png");
            this.imageList2.Images.SetKeyName(1, "OpenedEye.png");
            // 
            // btnPasswordVisible
            // 
            this.btnPasswordVisible.ImageIndex = 0;
            this.btnPasswordVisible.ImageList = this.imageList2;
            this.btnPasswordVisible.Location = new System.Drawing.Point(549, 47);
            this.btnPasswordVisible.Name = "btnPasswordVisible";
            this.btnPasswordVisible.Size = new System.Drawing.Size(55, 31);
            this.btnPasswordVisible.TabIndex = 3;
            this.btnPasswordVisible.UseVisualStyleBackColor = true;
            this.btnPasswordVisible.Click += new System.EventHandler(this.btnPasswordVisible_Click);
            // 
            // ckbIsActive
            // 
            this.ckbIsActive.AutoSize = true;
            this.ckbIsActive.Checked = true;
            this.ckbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsActive.Location = new System.Drawing.Point(312, 364);
            this.ckbIsActive.Name = "ckbIsActive";
            this.ckbIsActive.Size = new System.Drawing.Size(85, 27);
            this.ckbIsActive.TabIndex = 6;
            this.ckbIsActive.Text = "Is Active";
            this.ckbIsActive.UseVisualStyleBackColor = true;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(307, 54);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(40, 26);
            this.lblUserID.TabIndex = 11;
            this.lblUserID.Text = "N/A";
            // 
            // txtbConfirmPassword
            // 
            this.txtbConfirmPassword.Location = new System.Drawing.Point(305, 111);
            this.txtbConfirmPassword.Name = "txtbConfirmPassword";
            this.txtbConfirmPassword.PasswordChar = '*';
            this.txtbConfirmPassword.Size = new System.Drawing.Size(220, 27);
            this.txtbConfirmPassword.TabIndex = 4;
            this.txtbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbConfirmPassword_Validating);
            // 
            // txtbPassword
            // 
            this.txtbPassword.Location = new System.Drawing.Point(305, 49);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '*';
            this.txtbPassword.Size = new System.Drawing.Size(220, 27);
            this.txtbPassword.TabIndex = 2;
            this.txtbPassword.Tag = "Password";
            this.txtbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // txtbUsername
            // 
            this.txtbUsername.Location = new System.Drawing.Point(311, 116);
            this.txtbUsername.Name = "txtbUsername";
            this.txtbUsername.Size = new System.Drawing.Size(220, 27);
            this.txtbUsername.TabIndex = 0;
            this.txtbUsername.Tag = "Username";
            this.txtbUsername.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_project.Properties.Resources.Password;
            this.pictureBox4.Location = new System.Drawing.Point(243, 107);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_project.Properties.Resources.Password;
            this.pictureBox3.Location = new System.Drawing.Point(243, 45);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_project.Properties.Resources.User;
            this.pictureBox2.Location = new System.Drawing.Point(249, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.ID_Card;
            this.pictureBox1.Location = new System.Drawing.Point(247, 50);
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
            this.label4.Location = new System.Drawing.Point(48, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm Password:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(123, 49);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(98, 26);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            // gbPasswordInformation
            // 
            this.gbPasswordInformation.Controls.Add(this.txtbConfirmPassword);
            this.gbPasswordInformation.Controls.Add(this.btnConfirmPasswordVisible);
            this.gbPasswordInformation.Controls.Add(this.lblPassword);
            this.gbPasswordInformation.Controls.Add(this.btnPasswordVisible);
            this.gbPasswordInformation.Controls.Add(this.label4);
            this.gbPasswordInformation.Controls.Add(this.pictureBox3);
            this.gbPasswordInformation.Controls.Add(this.pictureBox4);
            this.gbPasswordInformation.Controls.Add(this.txtbPassword);
            this.gbPasswordInformation.Location = new System.Drawing.Point(5, 163);
            this.gbPasswordInformation.Name = "gbPasswordInformation";
            this.gbPasswordInformation.Size = new System.Drawing.Size(832, 174);
            this.gbPasswordInformation.TabIndex = 1;
            this.gbPasswordInformation.TabStop = false;
            this.gbPasswordInformation.Text = "Password Information";
            // 
            // frmAddEditUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(870, 632);
            this.Controls.Add(this.tbUserInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.tbUserInfo.ResumeLayout(false);
            this.PersonalInfo.ResumeLayout(false);
            this.LoginInfo.ResumeLayout(false);
            this.LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbPasswordInformation.ResumeLayout(false);
            this.gbPasswordInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tbUserInfo;
        private System.Windows.Forms.TabPage PersonalInfo;
        private System.Windows.Forms.TabPage LoginInfo;
        private People.Controls.ctrlPersonDetailsWithFilter ctrlPersonDetailsWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtbConfirmPassword;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ckbIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnPasswordVisible;
        private System.Windows.Forms.Button btnConfirmPasswordVisible;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.GroupBox gbPasswordInformation;
    }
}
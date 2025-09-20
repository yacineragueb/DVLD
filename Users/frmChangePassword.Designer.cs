namespace DVLD_project.Users
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtbNewPassword = new System.Windows.Forms.TextBox();
            this.txtbConfirmPassword = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlUserDetailsCard1 = new DVLD_project.Users.Controls.ctrlUserDetailsCard();
            this.btnNewPasswordVisible = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmPasswordVisible = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(593, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 58);
            this.btnSave.TabIndex = 5;
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
            this.btnClose.Location = new System.Drawing.Point(709, 524);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 58);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm Password:";
            // 
            // txtbCurrentPassword
            // 
            this.txtbCurrentPassword.Location = new System.Drawing.Point(200, 421);
            this.txtbCurrentPassword.Name = "txtbCurrentPassword";
            this.txtbCurrentPassword.PasswordChar = '*';
            this.txtbCurrentPassword.Size = new System.Drawing.Size(174, 22);
            this.txtbCurrentPassword.TabIndex = 0;
            this.txtbCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateCurrentPassword);
            // 
            // txtbNewPassword
            // 
            this.txtbNewPassword.Location = new System.Drawing.Point(200, 460);
            this.txtbNewPassword.Name = "txtbNewPassword";
            this.txtbNewPassword.PasswordChar = '*';
            this.txtbNewPassword.Size = new System.Drawing.Size(174, 22);
            this.txtbNewPassword.TabIndex = 1;
            this.txtbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbNewPassword_Validating);
            // 
            // txtbConfirmPassword
            // 
            this.txtbConfirmPassword.Location = new System.Drawing.Point(200, 499);
            this.txtbConfirmPassword.Name = "txtbConfirmPassword";
            this.txtbConfirmPassword.PasswordChar = '*';
            this.txtbConfirmPassword.Size = new System.Drawing.Size(174, 22);
            this.txtbConfirmPassword.TabIndex = 3;
            this.txtbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbConfirmPassword_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlUserDetailsCard1
            // 
            this.ctrlUserDetailsCard1.BackColor = System.Drawing.Color.White;
            this.ctrlUserDetailsCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrlUserDetailsCard1.Name = "ctrlUserDetailsCard1";
            this.ctrlUserDetailsCard1.Size = new System.Drawing.Size(815, 394);
            this.ctrlUserDetailsCard1.TabIndex = 0;
            // 
            // btnNewPasswordVisible
            // 
            this.btnNewPasswordVisible.ImageIndex = 1;
            this.btnNewPasswordVisible.ImageList = this.imageList1;
            this.btnNewPasswordVisible.Location = new System.Drawing.Point(400, 458);
            this.btnNewPasswordVisible.Name = "btnNewPasswordVisible";
            this.btnNewPasswordVisible.Size = new System.Drawing.Size(49, 26);
            this.btnNewPasswordVisible.TabIndex = 2;
            this.btnNewPasswordVisible.UseVisualStyleBackColor = true;
            this.btnNewPasswordVisible.Click += new System.EventHandler(this.btnNewPasswordVisible_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OpenedEye.png");
            this.imageList1.Images.SetKeyName(1, "ClosedEye.png");
            // 
            // btnConfirmPasswordVisible
            // 
            this.btnConfirmPasswordVisible.ImageIndex = 1;
            this.btnConfirmPasswordVisible.ImageList = this.imageList1;
            this.btnConfirmPasswordVisible.Location = new System.Drawing.Point(400, 497);
            this.btnConfirmPasswordVisible.Name = "btnConfirmPasswordVisible";
            this.btnConfirmPasswordVisible.Size = new System.Drawing.Size(49, 26);
            this.btnConfirmPasswordVisible.TabIndex = 4;
            this.btnConfirmPasswordVisible.UseVisualStyleBackColor = true;
            this.btnConfirmPasswordVisible.Click += new System.EventHandler(this.btnConfirmPasswordVisible_Click);
            // 
            // frmChangePassword
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(830, 594);
            this.Controls.Add(this.btnConfirmPasswordVisible);
            this.Controls.Add(this.btnNewPasswordVisible);
            this.Controls.Add(this.txtbConfirmPassword);
            this.Controls.Add(this.txtbNewPassword);
            this.Controls.Add(this.txtbCurrentPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlUserDetailsCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlUserDetailsCard ctrlUserDetailsCard1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbCurrentPassword;
        private System.Windows.Forms.TextBox txtbNewPassword;
        private System.Windows.Forms.TextBox txtbConfirmPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnConfirmPasswordVisible;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnNewPasswordVisible;
    }
}
namespace DVLD_project.Applications.LocalDrivingLicenseApplication
{
    partial class frmShowLocalDrivingLicenseApplicationInformation
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
            this.ctrlLDLApplicationDetailsCard1 = new DVLD_project.Applications.Controls.ctrlLDLApplicationDetailsCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLDLApplicationDetailsCard1
            // 
            this.ctrlLDLApplicationDetailsCard1.BackColor = System.Drawing.Color.White;
            this.ctrlLDLApplicationDetailsCard1.Location = new System.Drawing.Point(4, 12);
            this.ctrlLDLApplicationDetailsCard1.Name = "ctrlLDLApplicationDetailsCard1";
            this.ctrlLDLApplicationDetailsCard1.Size = new System.Drawing.Size(906, 390);
            this.ctrlLDLApplicationDetailsCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(766, 408);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 51);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowLocalDrivingLicenseApplicationInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(916, 470);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLDLApplicationDetailsCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLocalDrivingLicenseApplicationInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show local driving license application information";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLDLApplicationDetailsCard ctrlLDLApplicationDetailsCard1;
        private System.Windows.Forms.Button btnClose;
    }
}
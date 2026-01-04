namespace DVLD_project.Tests
{
    partial class frmListTestAppointments
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
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.lblTestTitle = new System.Windows.Forms.Label();
            this.ctrlLDLApplicationDetailsCard = new DVLD_project.Applications.Controls.ctrlLDLApplicationDetailsCard();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD_project.Properties.Resources.OpenedEye;
            this.pbTestImage.Location = new System.Drawing.Point(346, 12);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(231, 139);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 1;
            this.pbTestImage.TabStop = false;
            // 
            // lblTestTitle
            // 
            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Font = new System.Drawing.Font("Poppins SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTestTitle.Location = new System.Drawing.Point(303, 163);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Size = new System.Drawing.Size(317, 42);
            this.lblTestTitle.TabIndex = 2;
            this.lblTestTitle.Text = "Vision Test Appointment";
            // 
            // ctrlLDLApplicationDetailsCard
            // 
            this.ctrlLDLApplicationDetailsCard.BackColor = System.Drawing.Color.White;
            this.ctrlLDLApplicationDetailsCard.Location = new System.Drawing.Point(7, 224);
            this.ctrlLDLApplicationDetailsCard.Name = "ctrlLDLApplicationDetailsCard";
            this.ctrlLDLApplicationDetailsCard.Size = new System.Drawing.Size(909, 390);
            this.ctrlLDLApplicationDetailsCard.TabIndex = 0;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(914, 626);
            this.Controls.Add(this.lblTestTitle);
            this.Controls.Add(this.pbTestImage);
            this.Controls.Add(this.ctrlLDLApplicationDetailsCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListTestAppointments";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Controls.ctrlLDLApplicationDetailsCard ctrlLDLApplicationDetailsCard;
        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label lblTestTitle;
    }
}
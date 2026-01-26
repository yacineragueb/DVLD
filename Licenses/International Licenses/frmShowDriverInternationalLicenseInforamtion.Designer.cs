namespace DVLD_project.Licenses.International_Licenses
{
    partial class frmShowDriverInternationalLicenseInforamtion
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTestTitle = new System.Windows.Forms.Label();
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.ctrlInternationalDriverDetailsCard = new DVLD_project.Licenses.International_Licenses.Controls.ctrlInternationalDriverDetailsCard();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(726, 522);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 51);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTestTitle
            // 
            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Font = new System.Drawing.Font("Poppins SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTestTitle.Location = new System.Drawing.Point(187, 152);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Size = new System.Drawing.Size(503, 42);
            this.lblTestTitle.TabIndex = 6;
            this.lblTestTitle.Text = "Driver International License Information";
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD_project.Properties.Resources.License;
            this.pbTestImage.Location = new System.Drawing.Point(323, 1);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(231, 139);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 5;
            this.pbTestImage.TabStop = false;
            // 
            // ctrlInternationalDriverDetailsCard
            // 
            this.ctrlInternationalDriverDetailsCard.BackColor = System.Drawing.Color.White;
            this.ctrlInternationalDriverDetailsCard.Location = new System.Drawing.Point(12, 209);
            this.ctrlInternationalDriverDetailsCard.Name = "ctrlInternationalDriverDetailsCard";
            this.ctrlInternationalDriverDetailsCard.Size = new System.Drawing.Size(852, 307);
            this.ctrlInternationalDriverDetailsCard.TabIndex = 0;
            // 
            // frmShowDriverInternationalLicenseInforamtion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(872, 581);
            this.Controls.Add(this.lblTestTitle);
            this.Controls.Add(this.pbTestImage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlInternationalDriverDetailsCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowDriverInternationalLicenseInforamtion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver International License Inforamtion";
            this.Load += new System.EventHandler(this.frmShowDriverInternationalLicenseInforamtion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlInternationalDriverDetailsCard ctrlInternationalDriverDetailsCard;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTestTitle;
        private System.Windows.Forms.PictureBox pbTestImage;
    }
}
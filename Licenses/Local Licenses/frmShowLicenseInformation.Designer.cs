namespace DVLD_project.Drivers
{
    partial class frmShowLicenseInformation
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
            this.ctrlDriverDetailsCard = new DVLD_project.Drivers.Controller.ctrlDriverDetailsCard();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(720, 599);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 51);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTestTitle
            // 
            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Font = new System.Drawing.Font("Poppins SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTestTitle.Location = new System.Drawing.Point(264, 157);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Size = new System.Drawing.Size(338, 42);
            this.lblTestTitle.TabIndex = 4;
            this.lblTestTitle.Text = "Driver License Information";
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD_project.Properties.Resources.License;
            this.pbTestImage.Location = new System.Drawing.Point(318, 6);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(231, 139);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 3;
            this.pbTestImage.TabStop = false;
            // 
            // ctrlDriverDetailsCard
            // 
            this.ctrlDriverDetailsCard.BackColor = System.Drawing.Color.White;
            this.ctrlDriverDetailsCard.Location = new System.Drawing.Point(8, 202);
            this.ctrlDriverDetailsCard.Name = "ctrlDriverDetailsCard";
            this.ctrlDriverDetailsCard.Size = new System.Drawing.Size(850, 391);
            this.ctrlDriverDetailsCard.TabIndex = 5;
            // 
            // frmShowDriverInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(864, 656);
            this.Controls.Add(this.ctrlDriverDetailsCard);
            this.Controls.Add(this.lblTestTitle);
            this.Controls.Add(this.pbTestImage);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowDriverInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver License Information";
            this.Load += new System.EventHandler(this.frmShowDriverInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTestTitle;
        private System.Windows.Forms.PictureBox pbTestImage;
        private Controller.ctrlDriverDetailsCard ctrlDriverDetailsCard;
    }
}
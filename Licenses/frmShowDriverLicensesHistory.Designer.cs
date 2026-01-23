namespace DVLD_project.Licenses
{
    partial class frmShowDriverLicensesHistory
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDriverLicenses = new DVLD_project.Licenses.Controls.ctrlDriverLicenses();
            this.ctrlPersonDetails = new DVLD_project.ctrlPersonDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.Hisotry;
            this.pictureBox1.Location = new System.Drawing.Point(25, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(479, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 42);
            this.label2.TabIndex = 6;
            this.label2.Text = "Licenses History";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(968, 753);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 51);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.ctrlDriverLicenses.BackColor = System.Drawing.Color.White;
            this.ctrlDriverLicenses.Location = new System.Drawing.Point(12, 335);
            this.ctrlDriverLicenses.Name = "ctrlDriverLicenses";
            this.ctrlDriverLicenses.Size = new System.Drawing.Size(1098, 412);
            this.ctrlDriverLicenses.TabIndex = 7;
            // 
            // ctrlPersonDetails
            // 
            this.ctrlPersonDetails.BackColor = System.Drawing.Color.White;
            this.ctrlPersonDetails.Location = new System.Drawing.Point(293, 54);
            this.ctrlPersonDetails.Name = "ctrlPersonDetails";
            this.ctrlPersonDetails.Size = new System.Drawing.Size(811, 275);
            this.ctrlPersonDetails.TabIndex = 0;
            // 
            // frmShowDriverLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1116, 812);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDriverLicenses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlPersonDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowDriverLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licenses History";
            this.Load += new System.EventHandler(this.frmShowDriverLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonDetails ctrlPersonDetails;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private Controls.ctrlDriverLicenses ctrlDriverLicenses;
        private System.Windows.Forms.Button btnClose;
    }
}
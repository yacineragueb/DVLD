namespace DVLD_project.Applications.ReleaseDetainedLicenseApplication
{
    partial class frmListDetainedLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListDetainedLicenses));
            this.txtbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvDetainedLicensesApplicationsTable = new System.Windows.Forms.DataGridView();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetaineLicense = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.cbFilterByIsReleased = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesApplicationsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbFilter
            // 
            this.txtbFilter.Location = new System.Drawing.Point(302, 244);
            this.txtbFilter.Name = "txtbFilter";
            this.txtbFilter.Size = new System.Drawing.Size(204, 22);
            this.txtbFilter.TabIndex = 19;
            this.txtbFilter.Visible = false;
            this.txtbFilter.TextChanged += new System.EventHandler(this.txtbFilter_TextChanged);
            this.txtbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilter_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "National No.",
            "Full Name",
            "Release Application ID",
            "Is Released"});
            this.cbFilter.Location = new System.Drawing.Point(114, 243);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(182, 24);
            this.cbFilter.TabIndex = 18;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 30);
            this.label3.TabIndex = 17;
            this.label3.Text = "Filter By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(589, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 42);
            this.label2.TabIndex = 16;
            this.label2.Text = "Detained Licenses";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.DetainLicense;
            this.pictureBox1.Location = new System.Drawing.Point(555, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // dgvDetainedLicensesApplicationsTable
            // 
            this.dgvDetainedLicensesApplicationsTable.AllowUserToAddRows = false;
            this.dgvDetainedLicensesApplicationsTable.AllowUserToDeleteRows = false;
            this.dgvDetainedLicensesApplicationsTable.AllowUserToOrderColumns = true;
            this.dgvDetainedLicensesApplicationsTable.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetainedLicensesApplicationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicensesApplicationsTable.Location = new System.Drawing.Point(12, 273);
            this.dgvDetainedLicensesApplicationsTable.Name = "dgvDetainedLicensesApplicationsTable";
            this.dgvDetainedLicensesApplicationsTable.ReadOnly = true;
            this.dgvDetainedLicensesApplicationsTable.RowHeadersWidth = 51;
            this.dgvDetainedLicensesApplicationsTable.RowTemplate.Height = 24;
            this.dgvDetainedLicensesApplicationsTable.Size = new System.Drawing.Size(1393, 377);
            this.dgvDetainedLicensesApplicationsTable.TabIndex = 20;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(119, 657);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(17, 29);
            this.lblRecords.TabIndex = 23;
            this.lblRecords.Text = "0";
            this.lblRecords.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 653);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "#Records: ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1267, 656);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 51);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetaineLicense
            // 
            this.btnDetaineLicense.ImageIndex = 1;
            this.btnDetaineLicense.ImageList = this.imageList1;
            this.btnDetaineLicense.Location = new System.Drawing.Point(1318, 208);
            this.btnDetaineLicense.Name = "btnDetaineLicense";
            this.btnDetaineLicense.Size = new System.Drawing.Size(87, 58);
            this.btnDetaineLicense.TabIndex = 24;
            this.btnDetaineLicense.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ReleaseDetainedLicense.png");
            this.imageList1.Images.SetKeyName(1, "Release.png");
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.ImageKey = "ReleaseDetainedLicense.png";
            this.btnReleaseDetainedLicense.ImageList = this.imageList1;
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(1225, 208);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(87, 58);
            this.btnReleaseDetainedLicense.TabIndex = 25;
            this.btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            // 
            // cbFilterByIsReleased
            // 
            this.cbFilterByIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterByIsReleased.FormattingEnabled = true;
            this.cbFilterByIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbFilterByIsReleased.Location = new System.Drawing.Point(512, 244);
            this.cbFilterByIsReleased.Name = "cbFilterByIsReleased";
            this.cbFilterByIsReleased.Size = new System.Drawing.Size(204, 24);
            this.cbFilterByIsReleased.TabIndex = 26;
            this.cbFilterByIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbFilterByIsReleased_SelectedIndexChanged);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1417, 712);
            this.Controls.Add(this.cbFilterByIsReleased);
            this.Controls.Add(this.btnReleaseDetainedLicense);
            this.Controls.Add(this.btnDetaineLicense);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDetainedLicensesApplicationsTable);
            this.Controls.Add(this.txtbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.clsListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesApplicationsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvDetainedLicensesApplicationsTable;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetaineLicense;
        private System.Windows.Forms.Button btnReleaseDetainedLicense;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cbFilterByIsReleased;
    }
}
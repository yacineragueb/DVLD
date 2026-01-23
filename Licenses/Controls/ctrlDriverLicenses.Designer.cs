namespace DVLD_project.Licenses.Controls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.tpInternationalLicenses = new System.Windows.Forms.TabPage();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1087, 406);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocalLicenses);
            this.tabControl1.Controls.Add(this.tpInternationalLicenses);
            this.tabControl1.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1075, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.Controls.Add(this.label2);
            this.tpLocalLicenses.Controls.Add(this.dgvLocalLicensesHistory);
            this.tpLocalLicenses.Controls.Add(this.lblRecords);
            this.tpLocalLicenses.Controls.Add(this.label1);
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 32);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(1067, 332);
            this.tpLocalLicenses.TabIndex = 0;
            this.tpLocalLicenses.Text = "Local";
            this.tpLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // tpInternationalLicenses
            // 
            this.tpInternationalLicenses.Location = new System.Drawing.Point(4, 32);
            this.tpInternationalLicenses.Name = "tpInternationalLicenses";
            this.tpInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicenses.Size = new System.Drawing.Size(835, 332);
            this.tpInternationalLicenses.TabIndex = 1;
            this.tpInternationalLicenses.Text = "International";
            this.tpInternationalLicenses.UseVisualStyleBackColor = true;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(105, 300);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(17, 29);
            this.lblRecords.TabIndex = 6;
            this.lblRecords.Text = "0";
            this.lblRecords.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "#Records: ";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(8, 45);
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            this.dgvLocalLicensesHistory.RowHeadersWidth = 51;
            this.dgvLocalLicensesHistory.RowTemplate.Height = 24;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(1053, 245);
            this.dgvLocalLicensesHistory.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Local Licenses History: ";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1093, 412);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            this.tpLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.TabPage tpInternationalLicenses;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

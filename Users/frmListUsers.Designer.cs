namespace DVLD_project.Users
{
    partial class frmListUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListUsers));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvUsersTable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_project.Properties.Resources.Users;
            this.pictureBox2.Location = new System.Drawing.Point(581, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(307, 156);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // dgvUsersTable
            // 
            this.dgvUsersTable.AllowUserToAddRows = false;
            this.dgvUsersTable.AllowUserToDeleteRows = false;
            this.dgvUsersTable.AllowUserToOrderColumns = true;
            this.dgvUsersTable.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersTable.Location = new System.Drawing.Point(12, 251);
            this.dgvUsersTable.Name = "dgvUsersTable";
            this.dgvUsersTable.ReadOnly = true;
            this.dgvUsersTable.RowHeadersWidth = 51;
            this.dgvUsersTable.RowTemplate.Height = 24;
            this.dgvUsersTable.Size = new System.Drawing.Size(1420, 377);
            this.dgvUsersTable.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(638, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 42);
            this.label2.TabIndex = 6;
            this.label2.Text = "Manage Users";
            // 
            // txtbFilter
            // 
            this.txtbFilter.Location = new System.Drawing.Point(297, 222);
            this.txtbFilter.Name = "txtbFilter";
            this.txtbFilter.Size = new System.Drawing.Size(204, 22);
            this.txtbFilter.TabIndex = 12;
            this.txtbFilter.Visible = false;
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Gender",
            "Phone",
            "Email",
            "Nationality"});
            this.cbFilter.Location = new System.Drawing.Point(109, 221);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(182, 24);
            this.cbFilter.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "Filter By:";
            // 
            // btnAddUser
            // 
            this.btnAddUser.ImageIndex = 0;
            this.btnAddUser.ImageList = this.imageList1;
            this.btnAddUser.Location = new System.Drawing.Point(1345, 187);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(87, 58);
            this.btnAddUser.TabIndex = 13;
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add-User.png");
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1294, 642);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 51);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(109, 653);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(17, 29);
            this.lblRecords.TabIndex = 16;
            this.lblRecords.Text = "0";
            this.lblRecords.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 652);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "#Records: ";
            // 
            // frmListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1451, 705);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvUsersTable);
            this.Controls.Add(this.pictureBox2);
            this.Name = "frmListUsers";
            this.Text = "frmListUsers";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvUsersTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label1;
    }
}
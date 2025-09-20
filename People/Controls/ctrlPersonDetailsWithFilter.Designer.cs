namespace DVLD_project.People.Controls
{
    partial class ctrlPersonDetailsWithFilter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonDetailsWithFilter));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.txtbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonDetails1 = new DVLD_project.ctrlPersonDetails();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindPerson);
            this.gbFilter.Controls.Add(this.btnAddPerson);
            this.gbFilter.Controls.Add(this.txtbFilter);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(8, 4);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(811, 80);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.ImageIndex = 1;
            this.btnFindPerson.ImageList = this.imageList1;
            this.btnFindPerson.Location = new System.Drawing.Point(495, 26);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(75, 45);
            this.btnFindPerson.TabIndex = 2;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add-User.png");
            this.imageList1.Images.SetKeyName(1, "FindUser.png");
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.ImageIndex = 0;
            this.btnAddPerson.ImageList = this.imageList1;
            this.btnAddPerson.Location = new System.Drawing.Point(576, 25);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 45);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // txtbFilter
            // 
            this.txtbFilter.Location = new System.Drawing.Point(291, 33);
            this.txtbFilter.Name = "txtbFilter";
            this.txtbFilter.Size = new System.Drawing.Size(190, 30);
            this.txtbFilter.TabIndex = 1;
            this.txtbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Person ID",
            "National No."});
            this.cbFilter.Location = new System.Drawing.Point(95, 31);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(190, 34);
            this.cbFilter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By: ";
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(8, 90);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(811, 275);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // ctrlPersonDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "ctrlPersonDetailsWithFilter";
            this.Size = new System.Drawing.Size(823, 371);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.TextBox txtbFilter;
        private System.Windows.Forms.ImageList imageList1;
    }
}

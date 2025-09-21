using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.ApplicationType
{
    public partial class frmManageApplicationType : Form
    {
        private DataTable dtAllApplication = clsApplicationTypes.GetAllApplicationTypes();

        private void _RefreshApplicationTypesList()
        {
            dtAllApplication = clsApplicationTypes.GetAllApplicationTypes();

            dgvApplicationTypesTable.DataSource = dtAllApplication;
            lblRecords.Text = dgvApplicationTypesTable.Rows.Count.ToString();
        }

        public frmManageApplicationType()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageApplicationType_Load(object sender, EventArgs e)
        {
            dgvApplicationTypesTable.DataSource = dtAllApplication;
            lblRecords.Text = dgvApplicationTypesTable.Rows.Count.ToString();

            if (dgvApplicationTypesTable.Rows.Count > 0)
            {
                dgvApplicationTypesTable.Columns["Title"].Width = 300;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes frm = new frmUpdateApplicationTypes((int)dgvApplicationTypesTable.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }
    }
}

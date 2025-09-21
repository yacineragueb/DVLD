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

namespace DVLD_project.TestType
{
    
    public partial class frmListTestTypes : Form
    {

        private DataTable dtAllTestTypes = clsTestTypes.GetAllTestTypes();

        private void _RefreshTestTypesList()
        {
            dtAllTestTypes = clsTestTypes.GetAllTestTypes();

            dgvTestTypesTable.DataSource = dtAllTestTypes;
            lblRecords.Text = dgvTestTypesTable.Rows.Count.ToString();
        }

        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            dgvTestTypesTable.DataSource = dtAllTestTypes;
            lblRecords.Text = dgvTestTypesTable.Rows.Count.ToString();

            if (dgvTestTypesTable.Rows.Count > 0)
            {
                dgvTestTypesTable.Columns["Title"].Width = 150;
                dgvTestTypesTable.Columns["Description"].Width = 330;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditTestTypes frm = new frmAddEditTestTypes((int)dgvTestTypesTable.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypesList();
        }
    }
}

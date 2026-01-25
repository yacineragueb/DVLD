using DVLD_project.Licenses;
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

namespace DVLD_project.Applications.InternationalLicenceApplication
{
    public partial class frmListInternationalLicenseApplication : Form
    {
        private DataTable _dtAllInternationalApplication;

        public frmListInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _dtAllInternationalApplication = clsInternationalLicenseApplication.GetAllInternationalLicenseApplications();

            dgvInternationalLicenseApplicationsTable.DataSource = _dtAllInternationalApplication;
            lblRecords.Text = dgvInternationalLicenseApplicationsTable.Rows.Count.ToString();
            cbFilter.SelectedIndex = 0;

            if (dgvInternationalLicenseApplicationsTable.Rows.Count > 0)
            {
                dgvInternationalLicenseApplicationsTable.Columns[0].HeaderText = "Int. License ID";
                dgvInternationalLicenseApplicationsTable.Columns[0].Width = 110;

                dgvInternationalLicenseApplicationsTable.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenseApplicationsTable.Columns[1].Width = 110;

                dgvInternationalLicenseApplicationsTable.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenseApplicationsTable.Columns[2].Width = 110;

                dgvInternationalLicenseApplicationsTable.Columns[3].HeaderText = "Local License ID";
                dgvInternationalLicenseApplicationsTable.Columns[3].Width = 110;

                dgvInternationalLicenseApplicationsTable.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenseApplicationsTable.Columns[4].Width = 140;

                dgvInternationalLicenseApplicationsTable.Columns[5].HeaderText = "Experation Date";
                dgvInternationalLicenseApplicationsTable.Columns[5].Width = 140;

                dgvInternationalLicenseApplicationsTable.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenseApplicationsTable.Columns[6].Width = 110;
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                default:
                    FilterColumn = "";
                    break;
            }

            // Reset the filter in case nothing selected or filter value contains nothing.
            if (txtbFilter.Text.Trim() == "" || FilterColumn == "")
            {
                _dtAllInternationalApplication.DefaultView.RowFilter = "";
                lblRecords.Text = dgvInternationalLicenseApplicationsTable.Rows.Count.ToString();
                return;
            }

            // In this case we deal with integer not string.
            _dtAllInternationalApplication.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtbFilter.Text.Trim());

            lblRecords.Text = dgvInternationalLicenseApplicationsTable.Rows.Count.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllInternationalApplication.DefaultView.RowFilter = "";
            lblRecords.Text = dgvInternationalLicenseApplicationsTable.Rows.Count.ToString();

            if (cbFilter.SelectedIndex == 0) // None is selected
            {
                txtbFilter.Visible = false;
                cbFilterByIsActive.Visible = false;
            }
            else if (cbFilter.SelectedIndex == 5) // filter by Is Active
            {
                txtbFilter.Visible = false;
                cbFilterByIsActive.Visible = true;
            }
            else
            {
                cbFilterByIsActive.Visible = false;
                txtbFilter.Visible = true;
                txtbFilter.Focus();
            }

            cbFilterByIsActive.SelectedIndex = 0;
            txtbFilter.Clear();
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterByIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            if (cbFilter.Text == "Is Active")
            {
                FilterColumn = "IsActive";

                if (cbFilterByIsActive.Text == "All")
                {
                    _dtAllInternationalApplication.DefaultView.RowFilter = "";
                }
                else if (cbFilterByIsActive.Text == "Yes")
                {
                    _dtAllInternationalApplication.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, true);
                }
                else
                {
                    _dtAllInternationalApplication.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, false);
                }

                lblRecords.Text = dgvInternationalLicenseApplicationsTable.Rows.Count.ToString();
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicenseApplicationsTable.CurrentRow.Cells[0].Value;

            clsInternationalLicenseApplication internationalLicenseApplication = clsInternationalLicenseApplication.Find(InternationalLicenseID);

            if(internationalLicenseApplication != null)
            {
                frmShowPersonDetails frm = new frmShowPersonDetails(internationalLicenseApplication.ApplicationPersonID);
                frm.ShowDialog();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseApplicationID = (int)dgvInternationalLicenseApplicationsTable.CurrentRow.Cells[0].Value;

            clsInternationalLicenseApplication internationalLicenseApplication = clsInternationalLicenseApplication.Find(InternationalLicenseApplicationID);

            if (internationalLicenseApplication != null)
            {
                frmShowDriverLicensesHistory frm = new frmShowDriverLicensesHistory(internationalLicenseApplication.ApplicationPersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No International License Application Found With ID = " + InternationalLicenseApplicationID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

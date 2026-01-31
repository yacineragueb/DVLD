using DVLD_project.Drivers;
using DVLD_project.Licenses;
using DVLD_project.Licenses.Detained_Licenses;
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

namespace DVLD_project.Applications.ReleaseDetainedLicenseApplication
{
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _dtAllDetainedLicensesApplications;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _dtAllDetainedLicensesApplications = clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicensesApplicationsTable.DataSource = _dtAllDetainedLicensesApplications;
            lblRecords.Text = dgvDetainedLicensesApplicationsTable.Rows.Count.ToString();
            cbFilter.SelectedIndex = 0;

            if (dgvDetainedLicensesApplicationsTable.Rows.Count > 0)
            {
                dgvDetainedLicensesApplicationsTable.Columns[0].HeaderText = "Detain ID";
                dgvDetainedLicensesApplicationsTable.Columns[0].Width = 80;

                dgvDetainedLicensesApplicationsTable.Columns[1].HeaderText = "License ID";
                dgvDetainedLicensesApplicationsTable.Columns[1].Width = 85;

                dgvDetainedLicensesApplicationsTable.Columns[2].HeaderText = "Detain Date";
                dgvDetainedLicensesApplicationsTable.Columns[2].Width = 110;

                dgvDetainedLicensesApplicationsTable.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicensesApplicationsTable.Columns[3].Width = 90;

                dgvDetainedLicensesApplicationsTable.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicensesApplicationsTable.Columns[4].Width = 90;

                dgvDetainedLicensesApplicationsTable.Columns[5].HeaderText = "Released Date";
                dgvDetainedLicensesApplicationsTable.Columns[5].Width = 110;

                dgvDetainedLicensesApplicationsTable.Columns[6].HeaderText = "National No.";
                dgvDetainedLicensesApplicationsTable.Columns[6].Width = 95;

                dgvDetainedLicensesApplicationsTable.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicensesApplicationsTable.Columns[7].Width = 200;

                dgvDetainedLicensesApplicationsTable.Columns[8].HeaderText = "Release Application ID";
                dgvDetainedLicensesApplicationsTable.Columns[8].Width = 125;
            }
        }

        private bool _PreventTypeLetterChar(KeyPressEventArgs e)
        {
            return !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                // Filter by Detain ID
                case 1:
                    e.Handled = _PreventTypeLetterChar(e);
                    break;

                // Filter by National No
                case 2:
                    break;

                // Filter by Release Application ID
                case 4:
                    e.Handled = _PreventTypeLetterChar(e);
                    break;


                default:
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "";
                    break;
            }

            // Reset the filter in case nothing selected or filter value contains nothing.
            if (txtbFilter.Text.Trim() == "" || FilterColumn == "")
            {
                _dtAllDetainedLicensesApplications.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDetainedLicensesApplicationsTable.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            {
                // In this case we deal with integer not string.
                _dtAllDetainedLicensesApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtbFilter.Text.Trim());
            }
            else
            {
                _dtAllDetainedLicensesApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbFilter.Text.Trim());
            }

            lblRecords.Text = dgvDetainedLicensesApplicationsTable.Rows.Count.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllDetainedLicensesApplications.DefaultView.RowFilter = "";
            lblRecords.Text = dgvDetainedLicensesApplicationsTable.Rows.Count.ToString();

            if (cbFilter.SelectedIndex == 0) // None is selected
            {
                txtbFilter.Visible = false;
                cbFilterByIsReleased.Visible = false;
            }
            else if (cbFilter.SelectedIndex == 5) // filter by Is Released
            {
                txtbFilter.Visible = false;
                cbFilterByIsReleased.Visible = true;
            }
            else
            {
                cbFilterByIsReleased.Visible = false;
                txtbFilter.Visible = true;
                txtbFilter.Focus();
            }

            cbFilterByIsReleased.SelectedIndex = 0;
            txtbFilter.Clear();
        }

        private void cbFilterByIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            if (cbFilter.Text == "Is Released")
            {
                FilterColumn = "IsReleased";

                if (cbFilterByIsReleased.Text == "All")
                {
                    _dtAllDetainedLicensesApplications.DefaultView.RowFilter = "";
                }
                else if (cbFilterByIsReleased.Text == "Yes")
                {
                    _dtAllDetainedLicensesApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, true);
                }
                else
                {
                    _dtAllDetainedLicensesApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, false);
                }

                lblRecords.Text = dgvDetainedLicensesApplicationsTable.Rows.Count.ToString();
            }
        }

        private void btnDetaineLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesApplicationsTable.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID)._DriverInfo.PersonID;

            frmShowPersonDetails frm = new frmShowPersonDetails(PersonID);
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesApplicationsTable.CurrentRow.Cells[1].Value;

            frmShowLicenseInformation frm = new frmShowLicenseInformation(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesApplicationsTable.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID)._DriverInfo.PersonID;

            frmShowDriverLicensesHistory frm = new frmShowDriverLicensesHistory(PersonID);
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesApplicationsTable.CurrentRow.Cells[1].Value;

            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(LicenseID);
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicensesApplicationsTable.CurrentRow.Cells[3].Value;
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }
    }
}

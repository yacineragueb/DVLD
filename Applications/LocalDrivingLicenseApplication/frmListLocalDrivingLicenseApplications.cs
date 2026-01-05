using DVLD_project.Drivers;
using DVLD_project.Tests;
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

namespace DVLD_project.Applications
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        private static DataTable _dtAllLDLApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _AddEditLocalDrivingLicenseApplication(int ID)
        {
            frmAddEditLDLApplication frm = new frmAddEditLDLApplication(ID);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvLDLApplicationsTable.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
            cbFilter.SelectedIndex = 0;

            lblRecords.Text = dgvLDLApplicationsTable.Rows.Count.ToString();

            if(dgvLDLApplicationsTable.Rows.Count > 0 )
            {
                dgvLDLApplicationsTable.Columns[0].HeaderText = "L.D.L AppID";
                dgvLDLApplicationsTable.Columns[0].Width = 110;

                dgvLDLApplicationsTable.Columns[1].HeaderText = "Driving Class";
                dgvLDLApplicationsTable.Columns[1].Width = 220;

                dgvLDLApplicationsTable.Columns[2].HeaderText = "National No.";
                dgvLDLApplicationsTable.Columns[2].Width = 100;

                dgvLDLApplicationsTable.Columns[3].HeaderText = "Full Name";
                dgvLDLApplicationsTable.Columns[3].Width = 240;

                dgvLDLApplicationsTable.Columns[4].HeaderText = "Application Date";
                dgvLDLApplicationsTable.Columns[4].Width = 140;

                dgvLDLApplicationsTable.Columns[5].HeaderText = "Passed Tests";
                dgvLDLApplicationsTable.Columns[5].Width = 100;

                dgvLDLApplicationsTable.Columns[6].HeaderText = "Status";
                dgvLDLApplicationsTable.Columns[6].Width = 90;
            }
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                // Filter by L.D.L AppID
                case 1:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                // Filter by National No
                case 2:
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
                case "L.D.L AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "";
                    break;
            }

            // Reset the filter in case nothing selected or filter value contains nothing.
            if (txtbFilter.Text.Trim() == "" || FilterColumn == "")
            {
                _dtAllLDLApplications.DefaultView.RowFilter = "";
                lblRecords.Text = dgvLDLApplicationsTable.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                // In this case we deal with integer not string.
                _dtAllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtbFilter.Text.Trim());
            }
            else
            {
                _dtAllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbFilter.Text.Trim());
            }

            lblRecords.Text = dgvLDLApplicationsTable.Rows.Count.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtbFilter.Visible = false;
            }
            else
            {
                txtbFilter.Visible = true;
                txtbFilter.Focus();
            }

            txtbFilter.Clear();
        }

        private void btnAddLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            _AddEditLocalDrivingLicenseApplication(-1);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;
            _AddEditLocalDrivingLicenseApplication(LDLApplicationID);
        }

        private void CancelApplication_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;

            int ApplicationID = clsLocalDrivingLicenseApplication.Find(LDLApplicationID).ApplicationID;

            if (MessageBox.Show("Are you sure you want to cancel this application?", "Cancel Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsApplication.CancelApplication(ApplicationID))
                {
                    frmListLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild to cancel this Application because it has a data linked with it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LDLApplicationID, clsTestTypes.enTestType.VisionTest);
            frm.ShowDialog();
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LDLApplicationID, clsTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LDLApplicationID, clsTestTypes.enTestType.StreetTest);
            frm.ShowDialog();
        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string PersonNationalNo = (string)dgvLDLApplicationsTable.CurrentRow.Cells[2].Value;

            frmShowDriverInformation frm = new frmShowDriverInformation(PersonNationalNo);
            frm.ShowDialog();
        }

        private void SchduleTestsMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.Find(LDLApplicationID);

            if(LDLApplication != null)
            {
                int NumberOfPassedTest = LDLApplication.GetTheNumberOfPassedTest();

                if (NumberOfPassedTest == 0)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else if (NumberOfPassedTest == 1)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                }
            } else
            {
                contextMenuStrip1.Close();
                return;
            }
        }
    }
}

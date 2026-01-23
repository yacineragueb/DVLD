using DVLD_project.Applications.LocalDrivingLicenseApplication;
using DVLD_project.Drivers;
using DVLD_project.Licenses;
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
            _dtAllLDLApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();

            dgvLDLApplicationsTable.DataSource = _dtAllLDLApplications;
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
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LDLApplicationID, clsTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LDLApplicationID, clsTestTypes.enTestType.StreetTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.Find(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowDriverInformation frm = new frmShowDriverInformation(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LDLApplicationID);

            int TotalPassedTest = (int)dgvLDLApplicationsTable.CurrentRow.Cells[5].Value;

            bool IsLicenseIssued = localDrivingLicenseApplication.IsLicenseIssued();

            if (localDrivingLicenseApplication != null)
            {
                //Enable/Disable Cancel Menue Item
                //We only canel the applications with status=new.
                CancelApplication.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

                //Enabled only if person passed all tests and Does not have license. 
                IssueDrivingLicenseFirstTimeMenuItem.Enabled = (TotalPassedTest == 3) && !IsLicenseIssued;

                ShowLicenseToolStripMenuItem.Enabled = IsLicenseIssued;
                SchduleTestsMenuItem.Enabled = !IsLicenseIssued;
                editToolStripMenuItem.Enabled = !IsLicenseIssued && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

                //Enable/Disable Delete Menue Item
                //We only allow delete incase the application status is new not complete or Cancelled.
                deleteToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

                //Enable Disable Schedule menue and it's sub menue
                bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest); ;
                bool PassedWrittenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
                bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

                SchduleTestsMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

                if (SchduleTestsMenuItem.Enabled)
                {
                    //To Allow Schdule vision test, Person must not passed the same test before.
                    scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                    //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                    scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                    //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                    scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;

            frmShowLocalDrivingLicenseApplicationInformation frm = new frmShowLocalDrivingLicenseApplicationInformation(LDLApplicationID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.Find(LDLApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void IssueDrivingLicenseFirstTimeMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplication = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;

            frmIssueLicenseFirstTime frm = new frmIssueLicenseFirstTime(LDLApplication);
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLDLApplicationsTable.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(
               LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication != null)
            {
                frmShowDriverLicensesHistory frm = new frmShowDriverLicensesHistory(localDrivingLicenseApplication.ApplicationPersonID);
                frm.ShowDialog();
            } else
            {
                MessageBox.Show("No Local Driving License Application Found With ID = " + LocalDrivingLicenseApplicationID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

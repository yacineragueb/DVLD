using DVLD_project.Drivers;
using DVLD_project.Licenses;
using DVLD_project.Licenses.International_Licenses;
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

namespace DVLD_project.Applications.RenewDrivingLicenseApplication
{
    public partial class frmRenewDrivingLicenseApplication : Form
    {
        private int _RenewedLicenseID;

        public frmRenewDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _SetDefaultValueForRenewLicenseApplication()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicenseService).Fee.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void frmRenewDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _SetDefaultValueForRenewLicenseApplication();
        }

        private void ctrlDriverDetailsCardWithFilter_OnLicenseSelected(int LicenseID)
        {
            lblOldLicenseID.Text = LicenseID.ToString();
            lblLicenseFees.Text = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._LicenseClass.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            LlblShowLicenseHistory.Enabled = (LicenseID != -1);
            txtbNotes.Text = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.Notes;
            int DefaultValidityLength = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._LicenseClass.DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();

            // Check the license is not Expired.
            if (!ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will exprire on: " + ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.ExpirationDate.ToShortDateString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check the license is Active.
            if (!ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRenewLicense.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlblShowNewLicenseInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInformation frm = new frmShowLicenseInformation(_RenewedLicenseID);
            frm.ShowDialog();
        }

        private void LlblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicensesHistory frm = new frmShowDriverLicensesHistory(ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense RenewedLicense = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.RenewLicense(txtbNotes.Text, clsGlobal.CurrentUser.UserID);

            if (RenewedLicense == null)
            {
                MessageBox.Show("Faild to Renew License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblRenewLicenseApplicationID.Text = RenewedLicense.ApplicationID.ToString();
            lblRenewedLicenseID.Text = RenewedLicense.LicenseID.ToString();
            _RenewedLicenseID = RenewedLicense.LicenseID;
            MessageBox.Show("License Renewed Successfully with ID = " + RenewedLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LlblShowNewLicenseInformation.Enabled = true;
            btnRenewLicense.Enabled = false;
            ctrlDriverDetailsCardWithFilter.EnableFilter = false;
        }
    }
}

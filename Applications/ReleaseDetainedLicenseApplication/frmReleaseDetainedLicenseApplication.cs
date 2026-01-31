using DVLD_project.Drivers;
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

namespace DVLD_project.Applications.ReleaseDetainedLicenseApplication
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _SelectedLicenseID;

        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrlDriverDetailsCardWithFilter.LoadData(_SelectedLicenseID);
            ctrlDriverDetailsCardWithFilter.EnableFilter = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlblShowLicenseInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInformation frm = new frmShowLicenseInformation(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void LlblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicensesHistory frm = new frmShowDriverLicensesHistory(ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverDetailsCardWithFilter_OnLicenseSelected(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
            LlblShowLicenseHistory.Enabled = (LicenseID != -1);
            _SelectedLicenseID = LicenseID;

            //check the license is Active.
            if (!ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if license is not detained.
            if (!ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not detained, choose a detained license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DetainInfo.DetainID.ToString();
            lblDetainDate.Text = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DetainInfo.DetainDate.ToShortDateString();
            lblFineFees.Text = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DetainInfo.FineFees.ToString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.ReleaseDetainedDrivingLicsense).Fee.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblFineFees.Text) + Convert.ToDecimal(lblApplicationFees.Text)).ToString();

            btnReleaseLicense.Enabled = true;
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;

            bool IsReleased = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID);

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License Released Successfully", "License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LlblShowLicenseInformation.Enabled = true;
            btnReleaseLicense.Enabled = false;
            ctrlDriverDetailsCardWithFilter.EnableFilter = false;
        }
    }
}

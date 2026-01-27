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

namespace DVLD_project.Applications.InternationalLicenceApplication
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private int _InternationalLicenseID;

        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetDefaultValueForApplicationFields()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.NewInternationalLicense).Fee.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _SetDefaultValueForApplicationFields();
        }

        private void ctrlDriverDetailsCardWithFilter1_OnLicenseSelected(int LicenseID)
        {
            lblLocalLicenseID.Text = LicenseID.ToString();
            LlblShowLicenseHistory.Enabled = LicenseID != -1;

            //check the license class, person could not issue international license without having
            //normal license of class 3.
            if (ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicenseApplication.GetActiveInternationalLicenseIDByDriverID(ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LlblShowLicenseInformation.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                return;
            }

            btnIssueInternationaLicense.Enabled = true;
        }

        private void LlblShowLicenseInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverInternationalLicenseInforamtion frm = new frmShowDriverInternationalLicenseInforamtion(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void LlblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicensesHistory frm = new frmShowDriverLicensesHistory(ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnIssueInternationaLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicenseApplication internationalLicenseApplication = new clsInternationalLicenseApplication();

            internationalLicenseApplication.ApplicationPersonID = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DriverInfo.PersonID;
            internationalLicenseApplication.ApplicationDate = DateTime.Now;
            internationalLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            internationalLicenseApplication.LastStatusDate = DateTime.Now;
            internationalLicenseApplication.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            internationalLicenseApplication.CreateByUserID = clsGlobal.CurrentUser.UserID;

            internationalLicenseApplication.DriverID = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.DriverID;
            internationalLicenseApplication.IssuedUsingLocalLicenseID = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.LicenseID;
            internationalLicenseApplication.IssueDate = DateTime.Now;
            internationalLicenseApplication.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicenseApplication.IsActive = true;

            if (!internationalLicenseApplication.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblInternationalLicenseApplicationID.Text = internationalLicenseApplication.ApplicationID.ToString();
            lblInternationaLicenseID.Text = internationalLicenseApplication.InternationalLicenseID.ToString();
            _InternationalLicenseID = internationalLicenseApplication.InternationalLicenseID;
            MessageBox.Show("International License Issued Successfully with ID = " + internationalLicenseApplication.InternationalLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LlblShowLicenseInformation.Enabled = true;
            btnIssueInternationaLicense.Enabled = false;
            ctrlDriverDetailsCardWithFilter.EnableFilter = false;
        }
    }
}

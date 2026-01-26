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
        private clsLicense _License;

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
                return;
            }

            btnIssueInternationaLicense.Enabled = true;
        }
    }
}

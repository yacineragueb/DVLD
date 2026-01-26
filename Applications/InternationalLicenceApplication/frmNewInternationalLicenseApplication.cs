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
            LlblShowLicenseHistory.Enabled = true;
        }
    }
}

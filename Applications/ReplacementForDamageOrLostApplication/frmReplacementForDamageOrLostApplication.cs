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

namespace DVLD_project.Applications.ReplacementForDamageOrLost
{
    public partial class frmReplacementForDamageOrLostApplication : Form
    {
        private int _ReplacedLicenseID;
        public frmReplacementForDamageOrLostApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LlblShowNewLicenseInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInformation frm = new frmShowLicenseInformation(_ReplacedLicenseID);
            frm.ShowDialog();
        }

        private void LlblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicensesHistory frm = new frmShowDriverLicensesHistory(ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo._DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void _SetDefaultValueForRenewLicenseApplication()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            if(rbDamagedLicense.Checked )
            {
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.ReplacementDamagedDrivingLicense).Fee.ToString();
                lblTitle.Text = "Replacement For Damaged License";
                this.Text = lblTitle.Text;
            }

            if (rbLostLicense.Checked)
            {
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.ReplacementLostDrivingLicense).Fee.ToString();
                lblTitle.Text = "Replacement For Lost License";
                this.Text = lblTitle.Text;
            }
        }

        private void frmReplacementForDamageOrLostApplication_Load(object sender, EventArgs e)
        {
            _SetDefaultValueForRenewLicenseApplication();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            frmReplacementForDamageOrLostApplication_Load(null, null);
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            frmReplacementForDamageOrLostApplication_Load(null, null);
        }

        private void ctrlDriverDetailsCardWithFilter_OnLicenseSelected(int LicenseID)
        {
            lblOldLicenseID.Text = LicenseID.ToString();
            LlblShowLicenseHistory.Enabled = (LicenseID != -1);

            //check the license is Active.
            if (!ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense ReplacedLicense;

            if (rbDamagedLicense.Checked)
            {
                ReplacedLicense = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.ReplaceDamagedLicense(clsGlobal.CurrentUser.UserID);
            } else
            {
                ReplacedLicense = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.ReplaceLostLicense(clsGlobal.CurrentUser.UserID);
            }

            if (ReplacedLicense == null)
            {
                MessageBox.Show("Faild to Replace License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblReplacedLicenseApplicationID.Text = ReplacedLicense.ApplicationID.ToString();
            lblReplacedLicenseID.Text = ReplacedLicense.LicenseID.ToString();
            _ReplacedLicenseID = ReplacedLicense.LicenseID;
            MessageBox.Show("License Renewed Successfully with ID = " + _ReplacedLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LlblShowNewLicenseInformation.Enabled = true;
            btnIssueReplacement.Enabled = false;
            ctrlDriverDetailsCardWithFilter.EnableFilter = false;
        }
    }
}

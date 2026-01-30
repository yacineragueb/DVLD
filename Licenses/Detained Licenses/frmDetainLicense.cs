using DVLD_project.Drivers;
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

namespace DVLD_project.Licenses.Detained_Licenses
{
    public partial class frmDetainLicense : Form
    {

        private int _SelectedLicenseID;

        public frmDetainLicense()
        {
            InitializeComponent();
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

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void txtbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlDriverDetailsCardWithFilter_OnLicenseSelected(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
            LlblShowLicenseHistory.Enabled = (LicenseID != -1);
            _SelectedLicenseID = LicenseID;

            //check if license is already detained.
            if (ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already detained, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check the license is Active.
            if (!ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtbFineFees.Focus();
            btnDetainLicense.Enabled = true;
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            decimal FineFees = Convert.ToDecimal(txtbFineFees.Text);

            int DetainedID = ctrlDriverDetailsCardWithFilter.SelectedLicenseInfo.Detain(FineFees, clsGlobal.CurrentUser.UserID);

            if (DetainedID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = DetainedID.ToString();
            MessageBox.Show("License Detained Successfully with ID = " + DetainedID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LlblShowLicenseInformation.Enabled = true;
            btnDetainLicense.Enabled = false;
            ctrlDriverDetailsCardWithFilter.EnableFilter = false;
            txtbFineFees.Enabled = false;
        }
    }
}

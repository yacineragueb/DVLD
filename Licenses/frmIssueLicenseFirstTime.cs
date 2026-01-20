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

namespace DVLD_project.Licenses
{
    public partial class frmIssueLicenseFirstTime : Form
    {

        private int _LocalDrivingLicenseApplicationID;
        private int _DriverID;
        private clsLicense _License = new clsLicense();
        private clsLocalDrivingLicenseApplication _LDLApplication = null;

        public frmIssueLicenseFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IssueLicenseFirstTime_Load(object sender, EventArgs e)
        {
            txtbNotes.Focus();

            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if (_LDLApplication == null)
            {

                MessageBox.Show("No Applicaiton with ID = " + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlLDLApplicationDetailsCard.LoadData(_LocalDrivingLicenseApplicationID);
        }

        private bool _HandleAddNewDriver()
        {
            clsDriver Driver = new clsDriver();

            Driver.PersonID = _LDLApplication.ApplicationPersonID;
            Driver.CreatedDate = DateTime.Now;
            Driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if(!Driver.Save())
            {
                return false;
            }

            _DriverID = Driver.DriverID;

            return true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if(!_HandleAddNewDriver())
            {
                return;
            }

            _License.ApplicationID = _LDLApplication.ApplicationID;
            _License.DriverID = _DriverID;
            _License.LicenseClassID = _LDLApplication.LicenseClassID;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = _License.IssueDate.AddYears(_LDLApplication._LicenseClasses.DefaultValidityLength);
            _License.Notes = txtbNotes.Text;
            _License.PaidFees = _LDLApplication.PaidFees;
            _License.IsActive = true;
            _License.IssueReason = clsLicense.enIssueReason.FirstTime;
            _License.CreatedByUserId = clsGlobal.CurrentUser.UserID;

            if (_License.Save())
            {
                MessageBox.Show("License issued successfully with license ID = " + _License.LicenseID, "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else
            {
                MessageBox.Show("License Was not Issued ! ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

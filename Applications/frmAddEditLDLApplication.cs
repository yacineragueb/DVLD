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
    public partial class frmAddEditLDLApplication : Form
    {
        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        enMode _Mode = enMode.AddNew;

        private clsLocalDrivingLicenseApplication _LDLApplication;
        private int _LDLApplicationID;

        public frmAddEditLDLApplication( int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;

            if(_LDLApplicationID == -1)
            {
                _Mode = enMode.AddNew;
            } else
            {
                _Mode = enMode.Edit;
            }
        }

        private void _FillLicenseClassesInComboBox()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInComboBox();
            cbLicenseClass.SelectedIndex = 2;

            if (_Mode == enMode.AddNew)
            {
                this.Text = "New Local Driving License Application";
                lblTitle.Text = "New Local Driving License Application";
                _LDLApplication = new clsLocalDrivingLicenseApplication();
            }
            else
            {
                this.Text = "Edit Local Driving License Application";
                lblTitle.Text = "Edit Local Driving License Application";
            }

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();

            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicenseService).Fee.ToString();
        }

        private void _LoadData()
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show("This form will be closed because No Local Driving License Application with ID = " + _LDLApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblLDLApplicationID.Text = _LDLApplicationID.ToString();
            ctrlPersonDetailsWithFilter1.LoadData(_LDLApplication.ApplicationPersonID);
            lblApplicationDate.Text = _LDLApplication.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _LDLApplication.PaidFees.ToString();
            lblCreatedByUser.Text = _LDLApplication.User.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbLDLApplicationInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbLDLApplicationInfo.SelectedIndex == 0)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void frmAddEditLDLApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if(_Mode == enMode.Edit)
            {
                _LoadData();
            }
        }

        private bool _HandleSelectedPerson()
        {
            if (ctrlPersonDetailsWithFilter1.GetSelectedPerson() != null)
            {
                int selectedPersonID = ctrlPersonDetailsWithFilter1.GetSelectedPersonID();

                // Here we will add handle add Applications with the same type for person

                //if (!clsUser.IsUserExist(selectedPersonID))
                //{
                //    return true;
                //}
                //else
                //{
                //    MessageBox.Show("Selected person already has a user, choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    tbLDLApplicationInfo.SelectedIndex = 0;
                //}
            }
            else
            {
                MessageBox.Show("You did not select a person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbLDLApplicationInfo.SelectedIndex = 0;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!." + Environment.NewLine + "Put the mouse over the red icon to show what you miss.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleSelectedPerson()) return;

            int PersonID = ctrlPersonDetailsWithFilter1.GetSelectedPersonID();
            int CreatedByUserID = clsGlobal.CurrentUser.UserID;
            int LicenseClassID = cbLicenseClass.FindString(clsLicenseClasses.Find(cbLicenseClass.Text).ClassName);

            _LDLApplication.ApplicationPersonID = PersonID;
            _LDLApplication.LicenseClassID = LicenseClassID;

            if (_LDLApplication.Save())
            {
                _Mode = enMode.Edit;
                lblTitle.Text = "Edit Local Driving Licesen Application";
                lblLDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbLDLApplicationInfo.SelectedIndex = 1;
            btnSave.Enabled = true;
        }
    }
}

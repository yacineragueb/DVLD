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

namespace DVLD_project.Applications.Controls
{
    public partial class ctrlLDLApplicationDetailsCard : UserControl
    {

        private clsLocalDrivingLicenseApplication _LDLApplication = null;

        private int _LDLApplicationID = -1;

        public int LDLApplicationID
        {
            get { return _LDLApplicationID; }
        }

        public ctrlLDLApplicationDetailsCard()
        {
            InitializeComponent();
        }

        private void _FillLDLApplicationInformation()
        {
            lblLDLApplicationID.Text = _LDLApplicationID.ToString();
            lblAppliedForLicense.Text = _LDLApplication._LicenseClasses.ClassName;
            lblPassedTest.Text = _LDLApplication.GetTheNumberOfPassedTest() + "/" + clsTestTypes.GetTotalNumberOfTests();
            ctrlApplicationDetailsCard.LoadData(_LDLApplication.ApplicationID);
        }

        public void LoadData(int LDLApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.Find(LDLApplicationID);

            if(_LDLApplication == null) {
                MessageBox.Show("Local Driving License Application with ID = " + LDLApplicationID + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LDLApplicationID = LDLApplicationID;
            _FillLDLApplicationInformation();
        }
    }
}

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
            ctrlLDLApplicationDetailsCard.LoadData(_LocalDrivingLicenseApplicationID);
        }
    }
}

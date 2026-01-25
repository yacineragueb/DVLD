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

namespace DVLD_project.Drivers
{
    public partial class frmShowLicenseInformation : Form
    {
        private int _LicenseID;

        public frmShowLicenseInformation(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDriverInformation_Load(object sender, EventArgs e)
        {
            ctrlDriverDetailsCard.LoadData(_LicenseID);
        }
    }
}

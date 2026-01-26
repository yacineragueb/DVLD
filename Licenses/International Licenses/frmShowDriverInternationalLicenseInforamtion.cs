using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.Licenses.International_Licenses
{
    public partial class frmShowDriverInternationalLicenseInforamtion : Form
    {
        private int _InternationalLicenseApplicationID;

        public frmShowDriverInternationalLicenseInforamtion(int InternationalLicenseApplicationID)
        {
            InitializeComponent();

            _InternationalLicenseApplicationID = InternationalLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDriverInternationalLicenseInforamtion_Load(object sender, EventArgs e)
        {
            ctrlInternationalDriverDetailsCard.LoadData(_InternationalLicenseApplicationID);
        }
    }
}

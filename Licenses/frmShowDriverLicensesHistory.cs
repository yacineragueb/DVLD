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
    public partial class frmShowDriverLicensesHistory : Form
    {
        private int _PersonID;

        public frmShowDriverLicensesHistory(int PersonID)
        {
            InitializeComponent();
            
            _PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDriverLicensesHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails.LoadData(_PersonID);

            ctrlDriverLicenses.LoadData(_PersonID);
        }
    }
}

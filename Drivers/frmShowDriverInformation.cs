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
    public partial class frmShowDriverInformation : Form
    {
        public frmShowDriverInformation(int DriverID)
        {
            InitializeComponent();

            ctrlDriverDetailsCard.LoadData(DriverID);
        }

        public frmShowDriverInformation(string PersonNationalNo)
        {
            InitializeComponent();

            ctrlDriverDetailsCard.LoadData(PersonNationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

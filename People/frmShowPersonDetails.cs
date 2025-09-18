using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;

namespace DVLD_project
{
    public partial class frmShowPersonDetails : Form
    {
        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            ctrlPersonCardDetails.LoadData(PersonID);
        }

        public frmShowPersonDetails(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonCardDetails.LoadData(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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

namespace DVLD_project.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int _LDLApplicationID;
        public frmListTestAppointments()
        {
            InitializeComponent();
        }

        public frmListTestAppointments(int LDLApplicationID)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicationID;
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlLDLApplicationDetailsCard.LoadData(_LDLApplicationID);
        }
    }
}

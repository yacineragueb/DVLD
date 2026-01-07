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
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType, int TestAppointmentID)
        {
            InitializeComponent();

            ctrlScheduleTest.TestType = TestType;
            ctrlScheduleTest.LoadData(LocalDrivingLicenseApplicationID, TestAppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

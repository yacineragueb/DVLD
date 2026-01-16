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

namespace DVLD_project.Tests.TestType
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;

        private clsTest _Test = null;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            ctrlShowTestInformation.LoadData(_TestAppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

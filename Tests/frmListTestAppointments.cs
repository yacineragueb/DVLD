using DVLD_project.Properties;
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
        private clsTestTypes.enTestType _TestTypeID;
        private int _TestAppointment;
        public frmListTestAppointments()
        {
            InitializeComponent();
        }

        public frmListTestAppointments(int LDLApplicationID, clsTestTypes.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointment = TestAppointmentID;
        }

        private void _UpdateFormHeader()
        {
            clsTestTypes TestType = clsTestTypes.Find((int)_TestTypeID);

            if (TestType == null)
            {
                MessageBox.Show("Test Type with ID = " + _TestTypeID + " Not Found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    pbTestImage.Image = Resources.OpenedEye;
                    break;

                case clsTestTypes.enTestType.WrittenTest:
                    pbTestImage.Image = Resources.TestType;
                    break;

                case clsTestTypes.enTestType.StreetTest:
                    pbTestImage.Image = Resources.Street;
                    break;
            }

            lblTestTitle.Text = TestType.GetTestTypeString() + " Appointement";
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _UpdateFormHeader();

            ctrlLDLApplicationDetailsCard.LoadData(_LDLApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLApplicationID);

            if (LDLApplication != null)
            {
                if ( ! LDLApplication.HasAnActiveAppointment(_TestTypeID))
                {
                    frmScheduleTest frm = new frmScheduleTest(LDLApplication.LocalDrivingLicenseApplicationID, _TestTypeID, _TestAppointment);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Person already have an active appointment for this test, you cannot add new appointment.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}

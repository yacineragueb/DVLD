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
    public partial class ctrlScheduleTest : UserControl
    {
        enum enMode
        {
            AddNew,
            Edit,
        }

        private clsTestTypes.enTestType _TestType;

        public clsTestTypes.enTestType TestType
        {
            get { return _TestType; }
            set { 
                _TestType = value;

                switch(_TestType)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        pbTestImage.Image = Resources.OpenedEye;
                        gbScheduleTest.Text = "Vision Test";
                        break;

                    case clsTestTypes.enTestType.WrittenTest:
                        pbTestImage.Image = Resources.TestType;
                        gbScheduleTest.Text = "Written Test";
                        break;

                    case clsTestTypes.enTestType.StreetTest:
                        pbTestImage.Image = Resources.Street;
                        gbScheduleTest.Text = "Street Test";
                        break;
                }
            }
        }

        enMode Mode = enMode.AddNew;

        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointment;

        public void LoadData(int LocalDrivingLicenseApplicationID, int TestAppointmentID = -1)
        {
            _TestAppointmentID = TestAppointmentID;
            if(_TestAppointmentID == -1)
            {
                Mode = enMode.AddNew;
            } else
            {
                Mode = enMode.Edit;
            }

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
    }
}

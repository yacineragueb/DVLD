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
using static DVLD_project.Tests.ctrlScheduleTest;
using static DVLDBusinessLayer.clsTestTypes;

namespace DVLD_project.Tests.Controls
{
    public partial class ctrlShowTestInformation : UserControl
    {
        private clsTestTypes.enTestType _TestType;
        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointment = null;

        public clsTestTypes.enTestType TestType
        {
            get;
        }

        private void _LoadHeaderContent()
        {
            switch (_TestType)
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

        public void LoadData(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Test Appointment with ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType = (clsTestTypes.enTestType)_TestAppointment.TestTypeID;

            _LoadHeaderContent();

            lblLDLApplicationID.Text = _TestAppointment._LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _TestAppointment._LocalDrivingLicenseApplicationInfo._LicenseClasses.ClassName;
            lblFullName.Text = _TestAppointment._LocalDrivingLicenseApplicationInfo.Person.FullName();

            //this will show the trials for this test before  
            lblTrail.Text = _TestAppointment._LocalDrivingLicenseApplicationInfo.TotalTrialsPerTest(_TestType).ToString();

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            lblTestDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();

            clsTest Test = clsTest.FindLastTestPerPersonAndLicenseClass(_TestAppointment._LocalDrivingLicenseApplicationInfo.ApplicationPersonID, _TestAppointment._LocalDrivingLicenseApplicationInfo.LicenseClassID, (clsTestTypes.enTestType)_TestAppointment.TestTypeID);

            if (Test != null)
            {
                lblTestID.Text = Test.TestID.ToString();
            }
        }

        public ctrlShowTestInformation()
        {
            InitializeComponent();
        }
    }
}

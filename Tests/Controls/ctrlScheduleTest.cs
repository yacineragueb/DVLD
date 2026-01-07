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

namespace DVLD_project.Tests
{
    public partial class ctrlScheduleTest : UserControl
    {
        enum enMode
        {
            AddNew,
            Edit,
        }

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };

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
        enCreationMode CreationMode = enCreationMode.FirstTimeSchedule;

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

            //decide if the createion mode is retake test or not based if the person attended this test before
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestType))
            {
                CreationMode = enCreationMode.RetakeTestSchedule;
            }
            else
            {
                CreationMode = enCreationMode.FirstTimeSchedule;
            }

            if(CreationMode == enCreationMode.FirstTimeSchedule)
            {
                lblTitle.Text = "Schedule Test";
                gbRetakeTestInformation.Enabled = false;
            } else
            {
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInformation.Enabled = true;
                lblRetakeAppFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.RetakeTest).Fee.ToString();
            }

            lblLDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication._LicenseClasses.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.Person.FullName();

            //this will show the trials for this test before  
            lblTrail.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestType).ToString();


            if (Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestTypes.Find((int)_TestType).Fee.ToString();
                dtpTestDate.MinDate = DateTime.Now;

                _TestAppointment = new clsTestAppointment();
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
    }
}

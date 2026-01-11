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

        private bool _LoadTestAppointmentInformation()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if(DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
            {
                dtpTestDate.MinDate = DateTime.Now;
            } else
            {
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;
            }

            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
            }
            else
            {
                lblRetakeAppFees.Text = _TestAppointment._RetakeTestApplication.PaidFees.ToString();
                lblRetakeTestLDLApplicationID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }
            return true;
        }

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
                lblRetakeAppFees.Text = "0";
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
            } else
            {
                if(!_LoadTestAppointmentInformation())
                {
                    return;
                }
            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            //if (!_HandlePrviousTestConstraint())
            //    return;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.HasAnActiveAppointment(_LocalDrivingLicenseApplicationID, _TestType))
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment is loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            else
                lblUserMessage.Visible = false;

            return true;
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if(Mode == enMode.AddNew && CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplication Application = new clsApplication();

                Application.ApplicationPersonID = _LocalDrivingLicenseApplication.ApplicationPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.LastStatusDate = DateTime.Now;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.RetakeTest;
                Application.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.RetakeTest).Fee;
                Application.CreateByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!_HandleRetakeApplication())
            {
                return;
            }

            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.LDLApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                Mode = enMode.Edit;

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

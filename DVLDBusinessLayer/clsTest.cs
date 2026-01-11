using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsTest
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1,
        }

        public enum enTestResult
        {
            Fail = 0,
            Pass = 1,
        }

        enMode _Mode = enMode.AddNew;

        public int TestID {  get; set; }
        public int TestAppointmentID {  get; set; }
        public clsTestAppointment _TestAppointmentInfo;
        public enTestResult TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser _CreatedByUserInfo;

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = enTestResult.Fail;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;

            _Mode = enMode.AddNew;
        }

        private clsTest(int TestID, int TestAppointmentID, enTestResult TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            _CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            _TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);

            _Mode = enMode.Update;
        }

        public static clsTest FindLastTestPerPersonAndLicenseClass(int PersonID,  int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool result = false;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if(clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, LicenseClassID, (int)TestTypeID, ref TestID, ref TestAppointmentID, ref result, ref Notes, ref CreatedByUserID))
            {
                enTestResult TestResult = result ? enTestResult.Pass : enTestResult.Fail;

                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            } else
            {
                return null;
            }

        }
    }
}

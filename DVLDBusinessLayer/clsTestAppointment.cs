using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsTestAppointment
    {
        enum enMode
        {
            AddNew = 0,
            Update = 1,
        }

        enMode _Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public clsTestTypes _TestTypesInfo;
        public int LDLApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser _CreatedByUserInfo;
        public bool IsLooked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LDLApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLooked = false;
            this.RetakeTestApplicationID = -1;

            _Mode = enMode.AddNew;
        }

        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LDLApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLooked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDLApplicationID = LDLApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLooked = IsLooked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            _TestTypesInfo = clsTestTypes.Find(TestTypeID);
            _CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.Find(LDLApplicationID);
            
            _Mode = enMode.Update;
        }
    }
}

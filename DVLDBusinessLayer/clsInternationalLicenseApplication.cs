using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsInternationalLicenseApplication : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode _Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        private int DriverID { get; set; }
        private clsDriver _DriverInfo;
        private int IssuedUsingLocalLicenseID { get; set; }
        private clsLicense _LocalLicenseInfo;
        private DateTime IssueDate { get; set; }
        private DateTime ExpirationDate { get; set; }
        private bool IsActive { get; set; }
        private int CreatedByUserID { get; set; }
        private clsUser _CreatedByUserInfo;

        public clsInternationalLicenseApplication()
        {
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.CreatedByUserID = -1;
            this.IsActive = false;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;

            _Mode = enMode.AddNew;
        }

        private clsInternationalLicenseApplication(int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.CreateByUserID = CreatedByUserID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;

            _DriverInfo = clsDriver.Find(this.DriverID);
            _LocalLicenseInfo = clsLicense.Find(this.IssuedUsingLocalLicenseID);
            _CreatedByUserInfo = clsUser.Find(this.CreatedByUserID);

            _Mode = enMode.Update;
        }

        public static DataTable GetAllInternationalLicenseApplications()
        {
            return clsInternationalLicenseApplicationData.GetAllInternationalLicenseApplications();
        }
    }
}

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
        public int DriverID { get; set; }
        public clsDriver _DriverInfo;
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLicense _LocalLicenseInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        public clsInternationalLicenseApplication()
        {
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IsActive = false;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;

            _Mode = enMode.AddNew;
        }

        private clsInternationalLicenseApplication(int ApplicationID, int PersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, 
          int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive) : base(ApplicationID, PersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;

            _DriverInfo = clsDriver.Find(this.DriverID);
            _LocalLicenseInfo = clsLicense.Find(this.IssuedUsingLocalLicenseID);

            _Mode = enMode.Update;
        }

        public static DataTable GetAllInternationalLicenseApplications()
        {
            return clsInternationalLicenseApplicationData.GetAllInternationalLicenseApplications();
        }

        public static clsInternationalLicenseApplication Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            int CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if(clsInternationalLicenseApplicationData.GetInternationalLicenseApplicationByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                clsApplication Application = clsApplication.Find(ApplicationID);

                if(Application != null)
                {
                    return new clsInternationalLicenseApplication(ApplicationID, Application.ApplicationPersonID, Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, CreatedByUserID, InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);
                }
                else
                {
                    return null;
                }
            } else
            {
                return null;
            }
        }
    }
}

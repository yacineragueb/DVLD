using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enum enIssueReason
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamage = 3,
            ReplacementForLost = 4
        }

        public enMode _Mode = enMode.AddNew;

        public int ApplicationID { get; set; }
        public clsApplication _Application;
        public int DriverID { get; set; }
        // Add driver object here
        public int LicenseClassID { get; set; }
        public clsLicenseClasses _LicenseClass;

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive {  get; set; }
        enIssueReason IssueReason { get; set; }
        public int CreatedByUserId {  get; set; }

        public clsLicense()
        {
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.CreatedByUserId = -1;
            this.IsActive = false;
            this.Notes = "";
            this.PaidFees = 0;
            this.IssueReason = enIssueReason.FirstTime;

            _Mode = enMode.AddNew;
        }

        private clsLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, int CreatedByUserID, string Notes, decimal PaidFees, enIssueReason IssueReason, bool IsActive)
        {
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.PaidFees = PaidFees;
            this.CreatedByUserId = CreatedByUserID;

            this._Application = clsApplication.Find(this.ApplicationID);
            this._LicenseClass = clsLicenseClasses.Find(this.LicenseClassID);
            // Fill driver object here 

            _Mode = enMode.Update;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return GetActiveLicesenByPersonID(PersonID,  LicenseClassID) != 1;
        }

        public static int GetActiveLicesenByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicesenByPersonID(PersonID, LicenseClassID);
        }
    }
}

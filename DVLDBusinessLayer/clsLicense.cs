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

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication _Application;
        public int DriverID { get; set; }
        public clsDriver _DriverInfo;

        public int LicenseClassID { get; set; }
        public clsLicenseClasses _LicenseClass;

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive {  get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserId {  get; set; }

        public string GetIssueReasonString()
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";

                case enIssueReason.Renew:
                    return "Renew";

                case enIssueReason.ReplacementForDamage:
                    return "Replacement For Damage";

                case enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";

                default:
                    return "Unkown Reason";
            }
        }

        public clsLicense()
        {
            this.LicenseID = -1;
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

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, int CreatedByUserID, string Notes, decimal PaidFees, enIssueReason IssueReason, bool IsActive)
        {
            this.LicenseID = LicenseID;
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
            this._DriverInfo = clsDriver.Find(this.DriverID);

            _Mode = enMode.Update;
        }

        public static clsLicense FindLicenseByDriverID(int DriverID)
        {
            int LicenseID = -1;
            int ApplicationID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            int IssueReason = (int)enIssueReason.FirstTime;
            int CreatedByUserID = -1;

            if (clsLicenseData.FindLicenseByDriverID(ref LicenseID, ref ApplicationID, DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref CreatedByUserID, ref Notes, ref PaidFees, ref IssueReason, ref IsActive))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID,  LicenseClassID,  IssueDate, ExpirationDate, CreatedByUserID, Notes, PaidFees, (enIssueReason)IssueReason, IsActive);
            } else
            {
                return null;
            }
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

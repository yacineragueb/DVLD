using DVLDAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public bool IsDetained
        {
            get
            {
                return clsDetainedLicense.IsLicenseDetained(this.LicenseID);
            }
        }

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

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0; 
            bool IsActive = true;
            int CreatedByUserID = 1;
            int IssueReason = 1;
            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref CreatedByUserID, ref Notes,
            ref PaidFees, ref IssueReason, ref IsActive))

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, CreatedByUserID, Notes,
                                     PaidFees, (enIssueReason)IssueReason, IsActive);
            else
                return null;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return GetActiveLicesenByPersonID(PersonID,  LicenseClassID) != -1;
        }

        public static int GetActiveLicesenByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicesenByPersonID(PersonID, LicenseClassID);
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserId); 

            return this.LicenseID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserId);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLicense())
                    {
                        _Mode = enMode.Update;

                        return true;
                    } else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLicense();
            }

            return false;
        }

        public static DataTable GetDriverLicenses(int PersonID)
        {
            return clsLicenseData.GetDriverLicensesByPersonID(PersonID);
        }

        public static DataTable GetDriverInternationalLicenses(int PerosnID)
        {
            return clsLicenseData.GetDriverInternationalLicensesByPersonID(PerosnID);
        }

        public static bool IsLicenseExistByID(int LicenseID)
        {
            return clsLicenseData.IsLicenseExistByID(LicenseID);
        }
    
        public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        public bool DeactivateCurrentLicense()
        {
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this._DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicenseService;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicenseService).Fee;
            Application.CreateByUserID = CreatedByUserID;

            if(!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this._LicenseClass.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this._LicenseClass.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserId = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense ReplaceDamagedLicense(int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this._DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.ReplacementDamagedDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.ReplacementDamagedDrivingLicense).Fee;
            Application.CreateByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this._LicenseClass.DefaultValidityLength);
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = this._LicenseClass.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.ReplacementForDamage;
            NewLicense.CreatedByUserId = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense ReplaceLostLicense(int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this._DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.ReplacementLostDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationTypes.ReplacementLostDrivingLicense).Fee;
            Application.CreateByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this._LicenseClass.DefaultValidityLength);
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = this._LicenseClass.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.ReplacementForLost;
            NewLicense.CreatedByUserId = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public int Detain(decimal FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.FineFees = FineFees;
            detainedLicense.CreatedByUserID = CreatedByUserID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.LicenseID = this.LicenseID;

            if(!detainedLicense.Save())
            {
                return -1;
            } 

            return detainedLicense.DetainID;
        }
    }
}

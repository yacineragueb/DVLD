using System;
using System.Data;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsApplication
    {
        public enum enMode
        {
            AddNew = 0,
            Edit = 1
        }
        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public enMode _Mode = enMode.AddNew;
        public clsPerson Person;
        public clsUser User;
        public clsApplicationTypes ApplicationType;
        public string GetApplicationStatusString()
        {
            switch(this.ApplicationStatus)
            {
                case enApplicationStatus.New:
                    return "New";

                case enApplicationStatus.Cancelled:
                    return "Cancelled";

                case enApplicationStatus.Completed:
                    return "Completed";

                default:
                    return "Unknown Status";
            }
        }
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public string GetApplicatinStatusString()
        {
            switch(ApplicationStatus)
            {
                case enApplicationStatus.New:
                    return "New";
                
                case enApplicationStatus.Cancelled:
                    return "Cancelled";

                case enApplicationStatus.Completed:
                    return "Completed";

                default:
                    return "Unkown";
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreateByUserID { get; set; }

        public clsApplication()
        {
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreateByUserID = -1;

            _Mode = enMode.AddNew;
        }

        public clsApplication(int ApplicationID, int PersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            Person = clsPerson.Find(PersonID);
            this.ApplicationPersonID = PersonID;
            this.ApplicationDate = ApplicationDate;
            ApplicationType = clsApplicationTypes.Find(ApplicationTypeID);
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            User = clsUser.Find(CreatedByUserID);
            this.CreateByUserID = CreatedByUserID;

            _Mode = enMode.Edit;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplication(this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID, (short)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreateByUserID);

            return this.ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID, (short)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreateByUserID);
        }

        public static clsApplication Find(int ApplicationID)
        {
            int PersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            short ApplicationStatus = (short)enApplicationStatus.New;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int UserID = -1;

            if (clsApplicationsData.FindApplicationByID(ApplicationID, ref PersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref UserID))
            {
                return new clsApplication(ApplicationID, PersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, UserID);
            } else { 
                return null; 
            }
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewApplication())
                    {
                        _Mode = enMode.Edit;
                        return true;
                    } else
                    {
                        return false;
                    }

                case enMode.Edit:
                    return _UpdateApplication();
            }

            return false;
        }

        public static int GetActiveApplicationIDForLicenseClass(int ApplicantPersonId, clsApplicationTypes.enApplicationTypes ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationsData.GetActiveApplicationIDForLicenseClass(ApplicantPersonId, (int)ApplicationTypeID, LicenseClassID);
        }
    
        public static bool CancelApplication(int ApplicationID)
        {
            return clsApplicationsData.CancelApplication(ApplicationID);
        }

        public bool Delete()
        {
            return clsApplicationsData.DeleteApplication(this.ApplicationID);
        }
    }
}

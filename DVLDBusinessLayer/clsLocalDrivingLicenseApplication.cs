using System;
using System.Data;
using System.Runtime.CompilerServices;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        enMode _Mode = enMode.AddNew;

        public clsLicenseClasses _LicenseClasses;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplication() : base() 
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;

            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int ApplicationID, int PersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID ,int LocalDrivingLicenseApplicationID, int LicenseClassID) : base(ApplicationID, PersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;

            _LicenseClasses = clsLicenseClasses.Find(LicenseClassID);

            _Mode = enMode.Edit;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLDLApplication(this.ApplicationID, this.LicenseClassID);

            return this.LocalDrivingLicenseApplicationID != -1;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return false;
        }

        public static clsLocalDrivingLicenseApplication Find(int LDLApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsData.FindLDLApplicationByID(LDLApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                clsApplication Application = clsApplication.Find(ApplicationID);

                if (Application != null)
                {
                    return new clsLocalDrivingLicenseApplication(ApplicationID, Application.ApplicationPersonID, Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus,
                                Application.LastStatusDate, Application.PaidFees, Application.CreateByUserID, LDLApplicationID, LicenseClassID);
                }
                else return null;
            } else
            {
                return null;
            }
        }

        public bool Save()
        {
            base._Mode = (clsApplication.enMode)_Mode; // Casting
            if(!base.Save())
            {
                return false;
            }
            
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLocalDrivingLicenseApplication())
                    {
                        _Mode = enMode.Edit;
                        return true; 
                    }else
                    {
                        return false;
                    }

                case enMode.Edit:
                    return _UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {
            //this will get the license id that belongs to this application
            return clsLicense.GetActiveLicesenByPersonID(this.ApplicationPersonID, this.LicenseClassID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplication();
        }

        public int GetTheNumberOfPassedTest()
        {
            return clsLocalDrivingLicenseApplicationsData.GetTheNumberOfPassedTest(LocalDrivingLicenseApplicationID);
        }

        public bool DoesPassTestType(clsTestTypes.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationsData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        
        public bool HasAnActiveAppointment(clsTestTypes.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationsData.HasAnActiveAppointment(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public bool Delete()
        {
            bool IsLDLApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsLDLApplicationDeleted = clsLocalDrivingLicenseApplicationsData.DeleteLocalDriverLicenseApplication(this.LocalDrivingLicenseApplicationID);

            if(!IsLDLApplicationDeleted)
            {
                return false;
            }

            IsBaseApplicationDeleted = base.Delete();

            return IsBaseApplicationDeleted;
        }
    }
}

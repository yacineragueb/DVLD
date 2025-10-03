using System;
using System.Data;
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
        clsLicenseClasses _LicenseClasses;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplication() : base() 
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;

            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int ApplicationID, int PersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicatinStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID ,int LocalDrivingLicenseApplicationID, int LicenseClassID) : base(ApplicationID, PersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;

            _Mode = enMode.Edit;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;

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

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplication();
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return false;
        }
    }
}

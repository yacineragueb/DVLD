using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsDetainedLicense
    {
        enum enMode
        {
            AddNew = 0, Update = 1
        }

        enMode _Mode = enMode.AddNew;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public clsLicense _LicenseInfo;
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser _CreatedByUserInfo;
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleaseApplicationID = -1;
            this.ReleasedByUserID = -1;

            _Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleaseApplicationID, int ReleasedByUserID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleasedByUserID = ReleasedByUserID;

            _CreatedByUserInfo = clsUser.Find(this.CreatedByUserID);
            _LicenseInfo = clsLicense.Find(this.LicenseID);

            _Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            return false;
        }

        private bool _UpdateDetainedLicense()
        {
            return false;
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewDetainedLicense())
                    {
                        _Mode = enMode.Update;

                        return true;
                    } else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDetainedLicense();
            }

            return false;
        }
    
        public clsDetainedLicense Find(int DetainID)
        {
            int LicenseID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now;
            int ReleaseApplicationID = -1;
            int ReleasedByUserID = -1;

            if (false)
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleaseApplicationID, ReleasedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }
    }
}

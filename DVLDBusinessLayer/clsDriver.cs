using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsDriver
    {
        enum enMode
        {
            AddNew = 1,
            Update = 2,
        }

        enMode _Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public clsPerson _PersonInfo;
        public int CreatedByUserID { get; set; }
        public clsUser _CreatedUserInfo;
        public DateTime CreatedDate { get; set; }
        public clsLicense _LicenseInfo;

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            _Mode = enMode.AddNew;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            this._PersonInfo = clsPerson.Find(PersonID);
            this._CreatedUserInfo = clsUser.Find(CreatedByUserID);
            this._LicenseInfo = clsLicense.FindLicenseByDriverID(DriverID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
    }
}

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
        }

        public static clsDriver Find(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if(clsDriverData.GetDriverByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            } else
            {
                return null;
            }
        }

        public static clsDriver Find(string PersonNationalNo)
        {
            int DriverID = -1;
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverByPersonNationalNo(PersonNationalNo, ref DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedDate, this.CreatedByUserID);

            return this.DriverID != -1;
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedDate, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewDriver()) { 

                        _Mode = enMode.Update;
                    
                        return true;
                    } else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDriver();
            }

            return false;
        }
    }
}

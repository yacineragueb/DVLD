using DVLDAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClasses()
        {
            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;
            Mode = enMode.AddNew;
        }

        private clsLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription, int MinimumAllowedAge, int DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;
        }

        public static clsLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            int MinimumAllowedAge = 0;
            int DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }

        public static clsLicenseClasses Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            int MinimumAllowedAge = 0;
            int DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByClassName(ref LicenseClassID, ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static bool IsLicenseClassExistByID(int ID)
        {
            return clsLicenseClassData.IsLicenseClassExistByID(ID);
        }

        public static bool IsLicenseClassExistByClassName(string ClassName)
        {
            return clsLicenseClassData.IsLicenseClassExistByClassName(ClassName);
        }
    }
}

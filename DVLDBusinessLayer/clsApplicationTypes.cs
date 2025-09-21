using System;
using System.Data;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsApplicationTypes
    {
        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        enMode _Mode;

        public int ApplicationID {  get; set; }
        public string Title { get; set; }
        public decimal Fee { get; set; }

        public clsApplicationTypes()
        {
            ApplicationID = -1;
            Title = "";
            Fee = 0;

            _Mode = enMode.AddNew;
        }

        private clsApplicationTypes(int ApplicationID, string Title, decimal Fee)
        {
            this.ApplicationID = ApplicationID;
            this.Title = Title;
            this.Fee = Fee;

            _Mode = enMode.Edit;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ApplicationID, this.Title, this.Fee);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string Title = "";
            decimal Fee = 0.0m;

            if(clsApplicationTypesData.GetApplicationTypeByID(ApplicationTypeID, ref Title, ref Fee))
            {
                return new clsApplicationTypes(ApplicationTypeID, Title, Fee);
            } else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch(_Mode)
            {
                   case enMode.Edit:
                        return _UpdateApplicationType();

                default:
                    return false;
            }
        }
    }
}

using DVLDAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsTestTypes
    {
        public enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        public enMode _Mode;

        public int TestTypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }

        public enum enTestType
        {
            VisionTest = 1,
            WrittenTest = 2,
            StreetTest = 3
        }

        public string GetTestTypeString()
        {
            switch (TestTypeID)
            {
                case 1:
                    return "Vision Test";

                case 2:
                    return "Written Test";

                case 3:
                    return "Street Test";

                default:
                    return "Unkown Test";
            }
        }

        public clsTestTypes()
        {
            TestTypeID = -1;
            Title = "";
            Description = "";
            Fee = 0;

            _Mode = enMode.AddNew;
        }

        private clsTestTypes(int TestTypeID, string Title, string Description, decimal Fee)
        {
            this.TestTypeID = TestTypeID;
            this.Description = Description;
            this.Title = Title;
            this.Fee = Fee;

            _Mode = enMode.Edit;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType(this.TestTypeID, this.Title, this.Description, this.Fee);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes Find(int TestTypeID)
        {
            string Title = "";
            string Description = "";
            decimal Fee = 0.0m;

            if (clsTestTypesData.GetTestTypeByID(TestTypeID, ref Title, ref Description, ref Fee))
            {
                return new clsTestTypes(TestTypeID, Title, Description, Fee);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Edit:
                    return _UpdateTestType();

                default:
                    return false;
            }
        }

        public static int GetTotalNumberOfTests()
        {
            return clsTestTypesData.GetTotalNumberOfTests();
        }
    }
}

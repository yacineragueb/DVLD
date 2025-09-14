using System;
using System.Data;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsPerson
    {
        enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        public enum enGender
        {
            Male = 0,
            Female = 1
        }

        enMode _Mode = enMode.AddNew;

        public int ID {  get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPerson() 
        {
            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gender = enGender.Male;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName, int Gender, string ThirdName, string LastName, DateTime DateOfBirth, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateTime.Now;
            this.Gender = (enGender)Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = -1;
            this.ImagePath = ImagePath;

            _Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.Gender, this.ThirdName, this.LastName, this.DateOfBirth, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {

        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

    }
}

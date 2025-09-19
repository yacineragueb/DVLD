using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsUser
    {
        enum enMode
        {
            AddNew = 0,
            Update = 1,
        }

        enMode _Mode = enMode.AddNew;

        clsPerson _Person;

        public int UserID { get; set; }
        public int PersonID
        {
            get { return _Person.ID; }
            set { _Person.ID = value; }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;

            _Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = clsPerson.Find(PersonID).ID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            _Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if(clsUserData.GetUserInfoById(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            } else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

    }
}

using System;
using System.Data;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            ID = -1;
            CountryName = "";
            Mode = enMode.AddNew;
        }

        private clsCountry(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            Mode = enMode.Update;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";

            if (clsCountryDataAccess.GetCountryInfoByID(ID, ref CountryName))

                return new clsCountry(ID, CountryName);
            else
                return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int ID = -1;
           
            if (clsCountryDataAccess.GetCountryInfoByName(ref ID, CountryName))

                return new clsCountry(ID, CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }

        public static bool IsCountryExistByID(int ID)
        {
            return clsCountryDataAccess.IsCountryExistByID(ID);
        }

        public static bool IsCountryExistByName(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExistByName(CountryName);
        }

    }
}
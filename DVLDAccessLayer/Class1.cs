using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLDAccessLayer
{
    public class clsPersonDataAccess
    {
        public static bool GetPersonInfoById(int ID)
        {
            // This Will implmented later
            return true;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, int Gender, string ThirdName, string LastName, DateTime DateOfBirth, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"INSERT INTO People (NationalNo, FirstName, SecondName ,ThirdName ,LastName ,DateOfBirth ,Gendor ,Address ,Phone ,Email ,NationalityCountryID ,[ImagePath]) VALUES ( @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                }
            }
            return PersonID;
        }

    }
}

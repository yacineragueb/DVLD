using DVLDAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsCountryDataAccess
    {
        public static bool GetCountryInfoByName(ref int ID, string CountryName)
        {
            bool IsFound = false;
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CountryName", CountryName);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                ID = (int)reader["CountryID"];
                            }
                            else
                            {
                                IsFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "GetCountryInfoByName failed");
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool IsFound = false;
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CountryID", ID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                CountryName = (string)reader["CountryName"];
                            }
                            else
                            {
                                IsFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "GetCountryInfoByID failed");
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM Countries";

                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()) 
                        {
                            if(reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    } 
                    catch (Exception ex) 
                    {
                        Logger.LogError(ex, "GetAllCountries failed");
                    }
                }
            }

            return dataTable;
        }
        public static bool IsCountryExistByID(int ID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT Found = 1 FROM Countries WHERE CountryID = @CountryID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CountryID", ID);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        IsFound = result != null;
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "IsCountryExistByID failed");
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        public static bool IsCountryExistByName(string CountryName)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT Found = 1 FROM Countries WHERE CountryName = @CountryName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CountryName", CountryName);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        IsFound = result != null;
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "IsCountryExistByName failed");
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
    }
}

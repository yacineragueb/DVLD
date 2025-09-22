using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDAccessLayer
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByClassName(ref int LicenseClassID, string ClassName, ref string ClassDescription, ref int MinimumAllowedAge, ref int DefaultValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassName", ClassName);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                LicenseClassID = (int)reader["LicenseClassID"];
                                ClassDescription = (string)reader["ClassDescription"];
                                MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                                DefaultValidityLength = (int)reader["DefaultValidityLength"];
                                ClassFees = Convert.ToDecimal(reader["ClassFees"]);
                            }
                            else
                            {
                                IsFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        public static bool GetLicenseClassInfoByID( int LicenseClassID, ref string ClassName, ref string ClassDescription, ref int MinimumAllowedAge, ref int DefaultValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                ClassName = (string)reader["ClassName"];
                                ClassDescription = (string)reader["ClassDescription"];
                                MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                                DefaultValidityLength = (int)reader["DefaultValidityLength"];
                                ClassFees = Convert.ToDecimal(reader["ClassFees"]);
                            }
                            else
                            {
                                IsFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM LicenseClasses";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

            return dataTable;
        }
        public static bool IsLicenseClassExistByID(int LicenseClassID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT Found = 1 FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        IsFound = result != null;
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        public static bool IsLicenseClassExistByClassName(string ClassName)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT Found = 1 FROM LicenseClasses WHERE ClassName = @ClassName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ClassName", ClassName);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        IsFound = result != null;
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
    }
}

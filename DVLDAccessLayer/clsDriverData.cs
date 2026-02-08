using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDAccessLayer
{
    public class clsDriverData
    {

        public static bool UpdateDriver(int DriverID, int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE Drivers
                                 SET PersonID = @PersonID,
                                 CreatedByUserID = @CreatedByUserID,
                                 CreatedDate = @CreatedDate
                                 WHERE DriverID = @DriverID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "UpdateDriver failed");
                        rowsAffected = -1;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static int AddNewDriver(int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            int DriverID = -1;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate) VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    
                    try
                    {
                        connection.Open();

                        object result = cmd.ExecuteScalar();

                        if( result != null && int.TryParse(result.ToString(), out int insertedDriverID))
                        {
                            DriverID = insertedDriverID;
                        }

                    } catch (Exception ex)
                    {
                        Logger.LogError(ex, "AddNewDriver failed");
                        DriverID = -1;
                    }
                }
            }

            return DriverID;
        }

        public static bool GetDriverByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT * FROM Drivers WHERE PersonID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        conn.Open();

                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                DriverID = (int)reader["DriverID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
                            } else
                            {
                                IsFound = false;
                            }
                        }
                    } catch (Exception ex)
                    {
                        Logger.LogError(ex, "GetDriverByPersonID failed");
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        
        public static bool GetDriverByDriverID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        conn.Open();

                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)reader["PersonID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
                            } else
                            {
                                IsFound = false;
                            }
                        }

                    } catch (Exception ex)
                    {
                        Logger.LogError(ex, "GetDriverByDriverID failed");
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT D.DriverID, D.PersonID, P.NationalNo, FullName = (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName), D.CreatedDate, 
                                (
                                	SELECT COUNT(LicenseID) FROM Licenses
                                	WHERE IsActive = 1 AND D.DriverID = Licenses.DriverID
                                ) 
                                AS NumberOfActiveLicenses FROM Drivers D
                                INNER JOIN People P ON P.PersonID = D.PersonID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }

                    } catch (Exception ex)
                    {
                        Logger.LogError(ex, "GetAllDrivers failed");
                    }
                }
            }

                return dataTable;
        }
    }
}

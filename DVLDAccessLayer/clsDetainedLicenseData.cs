using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDAccessLayer
{
    public class clsDetainedLicenseData
    {
        public static bool UpdateDetainedLicense(int DetainID,
            int LicenseID, DateTime DetainDate,
            decimal FineFees, int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,   
                              WHERE DetainID = @DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            
            return (rowsAffected > 0);
        }
        public static int AddNewDetainedLicense(
            int LicenseID, DateTime DetainDate,
            decimal FineFees, int CreatedByUserID, bool IsReleased)
        {
            int DetainID = -1;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"INSERT INTO DetainedLicenses
                                    (LicenseID,
                                    DetainDate,
                                    FineFees,
                                    CreatedByUserID,
                                    IsReleased)
                               VALUES
                                    (@LicenseID,
                                    @DetainDate, 
                                    @FineFees, 
                                    @CreatedByUserID,
                                    @IsReleased);
                            
                               SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            DetainID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {
                        DetainID = -1;
                    }
                }
            }

            return DetainID;
        }
        public static bool ReleaseDetainedLicense(int DetainID,
                 int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleaseApplicationID = @ReleaseApplicationID,
                              ReleasedByUserID = @ReleasedByUserID,
                              WHERE DetainID = @DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT IsDetained=1 
                            FROM detainedLicenses 
                            WHERE 
                            LicenseID=@LicenseID 
                            AND IsReleased=0;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsDetained = Convert.ToBoolean(result);
                        }
                    }

                    catch (Exception ex)
                    {
                        IsDetained = false;
                    }
                }
            }

            return IsDetained;
        }
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT * FROM DetainedLicenses_View";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }

                    } catch (Exception ex)
                    {
                        // Error!!
                    }
                }
            }

            return dataTable;
        }
    }
}

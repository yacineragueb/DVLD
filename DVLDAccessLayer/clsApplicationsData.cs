using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDAccessLayer
{
    public class clsApplicationsData
    {
        public static bool FindApplicationByID(int ApplicationID, ref int PersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref short ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int UserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {
                        connection.Open();
                        
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)reader["ApplicantPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = Convert.ToInt16(reader["ApplicationStatus"]);
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                UserID = (int)reader["CreatedByUserID"];
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

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            using(SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) VALUES ( @ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                                SELECT SCOPE_IDENTITY();";
                
                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result!= null && int.TryParse(result.ToString(), out int insertedApplicationID))
                        {
                            ApplicationID = insertedApplicationID;
                        }
                    } catch (Exception ex)
                    {
                        ApplicationID = -1;
                    }
                }
            }

            return ApplicationID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE Applications 
                                            SET ApplicantPersonID = @ApplicantPersonID,
                                                ApplicationDate = @ApplicationDate,
                                                ApplicationTypeID = @ApplicationTypeID,
                                                ApplicationStatus = @ApplicationStatus,
                                                LastStatusDate = @LastStatusDate,
                                                PaidFees = @PaidFees,
                                                CreatedByUserID = @CreatedByUserID
                                            WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            using(SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int AppID))
                        {
                            ActiveApplicationID = AppID;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return ActiveApplicationID;
                    }
                }
            }

            return ActiveApplicationID;
        }
    }
}

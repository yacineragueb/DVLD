using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDAccessLayer
{
    public class clsLicenseData
    {

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserId)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE Licenses
                                 SET ApplicationID = @ApplicationID, DriverID = @DriverID, LicenseClass = @LicenseClass, IssueDate = @IssueDate, ExpirationDate = @ExpirationDate, Notes = @Notes, PaidFees = @PaidFees, IsActive = @IsActive, IssueReason = @IssueReason, CreatedByUserID = @CreatedByUserID 
                                 WHERE LicenseID = @LicenseID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    cmd.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
                    cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IssueReason", IssueDate);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserId);

                    if (Notes == "" || string.IsNullOrEmpty(Notes))
                    {
                        cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Notes", Notes);
                    }

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
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserId)
        {
            int LicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID) VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                                 SELECT SCOPE_IDENTITY();

                                 UPDATE Applications
	                             SET ApplicationStatus = 3
	                             WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    cmd.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
                    cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserId);

                    if (Notes == "" || string.IsNullOrEmpty(Notes))
                    {
                        cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    } else
                    {
                        cmd.Parameters.AddWithValue("@Notes", Notes);
                    }

                    try
                    {
                        connection.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedLicenseID))
                        {
                            LicenseID = insertedLicenseID;
                        }

                    }
                    catch (Exception ex)
                    {
                        LicenseID = -1;
                    }

                }
            }

            return LicenseID;
        }
        public static bool GetLicenseByDriverID(ref int LicenseID, ref int ApplicationID, int DriverID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref int CreatedByUserID, ref string Notes, ref decimal PaidFees, ref int IssueReason, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT * FROM Licenses WHERE DriverID = @DriverID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                LicenseID = (int)reader["LicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = Convert.ToInt16(reader["IssueReason"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                if (reader["Notes"] != DBNull.Value)
                                {
                                    Notes = (string)reader["Notes"];
                                } else
                                {
                                    Notes = "";
                                }
                            }
                            else
                            {
                                IsFound = false;
                            }
                        }

                    } catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

                return IsFound;
        }
        public static int GetActiveLicesenByPersonID(int PersonID, int LicenseClassID)
        {
            int ActiveLicenseID = -1;

            using(SqlConnection conn = new SqlConnection (clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT Licenses.LicenseID FROM Licenses 
                                INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
                                WHERE PersonID = @PersonID 
                                AND LicenseClass = @LicenseClassID 
                                AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand (query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        conn.Open();

                        object result = cmd.ExecuteScalar();

                        if(result != null && int.TryParse(result.ToString(), out int ActiveLicenseIDValue) )
                        {
                            ActiveLicenseID = ActiveLicenseIDValue;
                        }

                    } catch (Exception ex)
                    {
                        ActiveLicenseID = -1;
                    }
                }
            }

            return ActiveLicenseID;
        }
    }
}

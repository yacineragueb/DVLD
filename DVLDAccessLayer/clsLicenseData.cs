using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDAccessLayer
{
    public class clsLicenseData
    {
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
                                Notes = (string)reader["Notes"];
                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (int)reader["IssueReason"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
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

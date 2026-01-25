using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDAccessLayer
{
    public class clsInternationalLicenseApplicationData
    {

        public static bool GetInternationalLicenseApplicationByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT * FROM InternationalLicenses
                                WHERE InternationalLicenseID = @InternationalLicenseID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            } else
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
        public static DataTable GetAllInternationalLicenseApplications()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive FROM InternationalLicenses";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader  reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
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

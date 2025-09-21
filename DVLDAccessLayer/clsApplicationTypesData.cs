using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDAccessLayer
{
    public class clsApplicationTypesData
    {
        public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string Title, ref decimal Fee)
        {
            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                Title = (string)reader["ApplicationTypeTitle"];
                                Fee = (decimal)reader["ApplicationFees"];
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

        public static bool UpdateApplicationType(int ApplicationTypeID, string Title, decimal Fee)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE ApplicationTypes
                                 SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                     ApplicationFees = @ApplicationFees
                                 WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    cmd.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
                    cmd.Parameters.AddWithValue("@ApplicationFees", Fee);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteNonQuery();

                        if(result != null && int.TryParse(result.ToString(), out int insertedRows))
                        {
                            rowsAffected = insertedRows;
                        }

                    } catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }

                return rowsAffected > 0;
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT ApplicationTypeID AS ID, ApplicationTypeTitle AS Title, ApplicationFees AS Fees FROM ApplicationTypes;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        // Error!!!
                    }
                }

                return dataTable;
            }
        }
    }
}

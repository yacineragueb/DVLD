using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDAccessLayer
{
    public class clsTestTypesData
    {
        public static bool GetTestTypeByID(int TestTypeID, ref string Title, ref string Description, ref decimal Fee)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                Title = (string)reader["TestTypeTitle"];
                                Description = (string)reader["TestTypeDescription"];
                                Fee = (decimal)reader["TestTypeFees"];
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "GetTestTypeByID failed");
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }

        public static bool UpdateTestType(int TestTypeID, string Title, string Description, decimal Fee)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE TestTypes
                                 SET TestTypeTitle = @TestTypeTitle,
                                     TestTypeDescription = @TestTypeDescription,
                                     TestTypeFees = @TestTypeFees
                                 WHERE TestTypeID = @TestTypeID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    cmd.Parameters.AddWithValue("@TestTypeTitle", Title);
                    cmd.Parameters.AddWithValue("@TestTypeDescription", Description);
                    cmd.Parameters.AddWithValue("@TestTypeFees", Fee);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteNonQuery();

                        if (result != null && int.TryParse(result.ToString(), out int insertedRows))
                        {
                            rowsAffected = insertedRows;
                        }

                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "UpdateTestType failed");
                        rowsAffected = 0;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT ID = TestTypeID, Title = TestTypeTitle, Description = TestTypeDescription, Fees = TestTypeFees  FROM TestTypes;";

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
                        Logger.LogError(ex, "GetAllTestTypes failed");
                    }
                }

                return dataTable;
            }
        }
    
        public static int GetTotalNumberOfTests()
        {
            int totalNumberOfTests = 0;

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT COUNT(TestTypeID) AS TotalTests FROM TestTypes";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        totalNumberOfTests = (int)cmd.ExecuteScalar();
                    } catch (Exception ex)
                    {
                        Logger.LogError(ex, "GetTotalNumberOfTests failed");
                        totalNumberOfTests = 0;
                    }
                }
            }

            return totalNumberOfTests;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DVLDAccessLayer
{
    public class clsUserData
    {
        public static bool GetUserInfoById(int UserID,ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID;";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }

                    } catch(Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = - 1;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive) VALUES ( @PersonID, @UserName, @Password, @IsActive);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedUser))
                        {
                            UserID = insertedUser;
                        }
                    }
                    catch {
                        UserID = -1;
                    }
                }
            }

            return UserID;
        }

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE Users 
                                            SET UserName = @UserName,
                                                Password = @Password,
                                                IsActive = @IsActive
                                            WHERE UserID = @UserID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    } catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                    
                }
            }

                return rowsAffected > 0;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT U.UserID, U.PersonID, FullName = P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName, U.UserName, U.IsActive FROM Users U
                                JOIN People P ON U.PersonID = P.PersonID
                                ORDER BY FirstName;";

                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    } catch (Exception ex)
                    {
                        // Error!
                    }
                }
            }

                return dataTable;
        }

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"DELETE FROM Users WHERE UserID = @UserID;";

                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    } catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsUserExist(int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT Found = 1 FROM Users WHERE PersonID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

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

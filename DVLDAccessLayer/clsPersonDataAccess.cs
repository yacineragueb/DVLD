using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLDAccessLayer
{
    public class clsPersonDataAccess
    {
        public static bool GetPersonInfoById(int ID, ref string NationalNo, ref string FirstName, ref string SecondName, ref int Gender, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            using(SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM People WHERE PersonID = @PersonID";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", ID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                NationalNo = (string)reader["NationalNo"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = (string)reader["ThirdName"];
                                LastName = (string)reader["LastName"];
                                Gender = Convert.ToInt16(reader["Gendor"]);
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
                                NationalityCountryID = (int)reader["NationalityCountryID"];

                                if (reader["ImagePath"] != DBNull.Value)
                                {
                                    ImagePath = (string)reader["ImagePath"];
                                }
                                else
                                {
                                    ImagePath = "";
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

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, int Gender, string ThirdName, string LastName, DateTime DateOfBirth, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath) VALUES ( @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                    if(ImagePath != string.Empty)
                    {
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    } else
                    {
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    }

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertePersonId)) 
                        {
                            PersonID = insertePersonId;
                        }
                    }
                    catch (Exception ex)
                    {
                        PersonID = -1;
                    }
                }
            }
            return PersonID;
        }

        public static bool UpdatePerson(int ID, string NationalNo, string FirstName, string SecondName, int Gender, string ThirdName, string LastName, DateTime DateOfBirth, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"UPDATE People 
                                               SET NationalNo = @NationalNo,
                                               FirstName = @FirstName,
                                               SecondName = @SecondName,
                                               ThirdName = @ThirdName, 
                                               LastName = @LastName, 
                                               DateOfBirth = @DateOfBirth, 
                                               Gendor = @Gendor,
                                               Address = @Address,
                                               Phone = @Phone,
                                               Email = @Email,
                                               NationalityCountryID = @NationalityCountryID,
                                               ImagePath = @ImagePath
                                               WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", ID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                    if (ImagePath != string.Empty)
                    {
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    }

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Error !
                    }
                }
            }
            return rowsAffected > 0;
        }

        public static DataTable GetAllPeople()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM People;";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                table.Load(reader);
                            }
                        }
                    } catch (Exception ex) 
                    {
                        // ERROR!!
                    }
                }
            }

            return table;
        }

        public static bool DeletePerson(int ID)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "DELETE FROM People WHERE PersonID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonID", ID);

                    try
                    {
                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsPersonExist(int ID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT Found = 1 FROM People WHERE PersonID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", ID);

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

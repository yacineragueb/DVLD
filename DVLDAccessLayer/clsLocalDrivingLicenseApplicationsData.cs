using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDAccessLayer
{
    public class clsLocalDrivingLicenseApplicationsData
    {

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                        {
                            TotalTrialsPerTest = Trials;
                        }
                    }

                    catch (Exception ex)
                    {
                        TotalTrialsPerTest = 0;
                    }
                }
            }

            return TotalTrialsPerTest;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsFound = true;
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

        public static bool HasAnActiveAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool resutl = false;

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT TOP 1 IsLocked FROM TestAppointments
                                INNER JOIN LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                                WHERE TestAppointments.LocalDrivingLicenseApplicationID = 38
                                AND TestAppointments.TestTypeID = 3
                                ORDER BY TestAppointments.TestAppointmentID desc";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        conn.Open();

                        object Resutl = cmd.ExecuteScalar();

                        if(Resutl != null && bool.TryParse(Resutl.ToString(), out bool returnedResult) ) 
                        {
                            resutl = returnedResult;
                        }

                    } catch (Exception ex)
                    {
                        resutl = false;
                    }
                }
            }

            return resutl;
        }
        
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT TOP 1 * FROM TestAppointments
                                 INNER JOIN LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                                 INNER JOIN TestTypes ON TestTypes.TestTypeID = TestAppointments.TestTypeID
                                 INNER JOIN Tests ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                 WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                 AND TestAppointments.TestTypeID = @TestTypeID
                                 ORDER BY TestAppointments.TestAppointmentID desc";

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        conn.Open();
                        object Result = cmd.ExecuteScalar();

                        if(Result != null && bool.TryParse(Result.ToString(), out bool returnedResult))
                        {
                            result = returnedResult;
                        }

                    } catch (Exception ex)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public static bool DeleteLocalDriverLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = -1;
            using(SqlConnection connection = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"DELETE FROM LocalDrivingLicenseApplications 
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    } catch (Exception ex) 
                    {
                        rowsAffected = -1;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static bool FindLDLApplicationByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;

            using( SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsFound = true;

                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
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

        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID)
        {
            int LDLApplicationID = -1;
            using( SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString) )
            {
                string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID ,LicenseClassID) VALUES ( @ApplicationID, @LicenseClassID );
                                 SELECT SCOPE_IDENTITY();";

                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedLDLApplicationID))
                        {
                            LDLApplicationID = insertedLDLApplicationID;
                        }

                    } catch (Exception ex)
                    {
                        LDLApplicationID = -1;
                    }
                }
            }

            return LDLApplicationID;
        }

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.NationalNo, FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName, Applications.ApplicationDate, 
					                        (SELECT COUNT(TestAppointments.TestTypeID) AS PassedTestCount
                                            FROM      Tests INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                            WHERE   (TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (Tests.TestResult = 1)) AS PassedTestCount, 
                                        CASE 
						                    WHEN Applications.ApplicationStatus = 1 THEN 'New'
						                    WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled'
						                    WHEN Applications.ApplicationStatus = 3 THEN 'Completed'
				                        END AS Status
                                FROM Applications INNER JOIN
                                    LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                                    LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                                    People ON Applications.ApplicantPersonID = People.PersonID;";

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }

                    } catch (Exception ex)
                    {

                    }
                }
            }


            return dt;
        }

        public static int GetTheNumberOfPassedTest(int LDLApplicationID)
        {
            int NumberOfPassedTest = 0;

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT COUNT(TestAppointments.TestTypeID) AS PassedTestCount
                                FROM Tests INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                WHERE (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) AND (Tests.TestResult = 1);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);

                    try
                    {
                        conn.Open();
                        NumberOfPassedTest = (int)cmd.ExecuteScalar();
                    } catch (Exception ex)
                    {
                        NumberOfPassedTest = 0;
                    }
                } 
            }

                return NumberOfPassedTest;
        }
    }
}

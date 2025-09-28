using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDAccessLayer
{
    public class clsLocalDrivingLicenseApplicationsData
    {
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
    }
}

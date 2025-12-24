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

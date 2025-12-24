using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDAccessLayer
{
    public class clsDriverData
    {
        public static DataTable GetAllDrivers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDVLDAcessLayerSettings.connectionString))
            {
                string query = @"SELECT D.DriverID, D.PersonID, P.NationalNo, FullName = (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName), D.CreatedDate, L.IsActive  FROM Drivers D
                                 INNER JOIN People P ON P.PersonID = D.PersonID
                                 INNER JOIN Licenses L ON L.DriverID = D.DriverID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }

                    } catch (Exception ex)
                    {
                        // ERROR !!
                    }
                }
            }

                return dataTable;
        }
    }
}

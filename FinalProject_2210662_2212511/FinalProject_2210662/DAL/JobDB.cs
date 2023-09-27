using FinalProject_2210662.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_2210662.DAL
{
    public class JobDB
    {

        public static List<Job> GetAllRecords()
        {
            List<Job> listJ = new List<Job>();

            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM Jobs", conn);
                SqlDataReader reader = cmdAll.ExecuteReader();
                Job job;
                while (reader.Read())
                {
                    job = new Job();
                    job.JobId = Convert.ToInt32(reader["JobId"]);
                    job.JobTitle = reader["JobTitle"].ToString();
                    listJ.Add(job);
                }

                return listJ;

            }
        }
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.BLL;
using System.Data.SqlClient;

namespace FinalProject_2210662.DAL
{
    public class PublisherDB
    {
        public static List<Publisher> GetAllRecords()
        {
            List<Publisher> listP = new List<Publisher>();
            Publisher pub;

            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM Publishers", conn);
                SqlDataReader dr = cmdAll.ExecuteReader();
                while (dr.Read())
                {
                    pub = new Publisher();
                    pub.PublisherId = Convert.ToInt32(dr["PublisherId"]);
                    pub.PublisherName = dr["PublisherName"].ToString();
                    pub.WebAddress = dr["WebAddress"].ToString();

                    listP.Add(pub);

                }
                return listP;
            }
        }


        public static bool Duplicated_ID_validation(int id)
        {
            List<Publisher> lPub = GetAllRecords();

            foreach (Publisher pub in lPub)
            {
                if (pub.PublisherId == id)
                {
                    return false;
                }
            }

            return true;
        }




    }
}

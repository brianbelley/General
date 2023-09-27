using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.BLL;
using System.Data.SqlClient;

namespace FinalProject_2210662.DAL
{
    public class CategoryDB
    {
        public static List<Category> GetAllRecords()
        {
            List<Category> listC = new List<Category>();
            Category cate;

            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM Categories", conn);
                SqlDataReader dr = cmdAll.ExecuteReader();
                while (dr.Read())
                {
                    cate = new Category();
                    cate.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    cate.CategoryName = dr["CategoryName"].ToString();
                
                    listC.Add(cate);

                }
                return listC;
            }
        }









        public static bool Duplicated_ID_validation(int id)
        {
            List<Category> lCate = GetAllRecords();

            foreach (Category cate in lCate)
            {
                if (cate.CategoryId == id)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

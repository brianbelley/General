using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.BLL;

namespace FinalProject_2210662.DAL
{
    public class CustomerDB
    {

        public static List<Customer> GetAllRecords()
        {
            List<Customer> listC = new List<Customer>();
            

            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM Customers", conn);
                SqlDataReader reader = cmdAll.ExecuteReader();
                Customer cus;
                while (reader.Read())
                {
                    cus = new Customer();
                    cus.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    cus.CustomerName = reader["CustomerName"].ToString();
                    cus.StreetName = reader["StreetName"].ToString();
                    cus.Province = reader["Province"].ToString();
                    cus.City = reader["City"].ToString();
                    cus.PostalCode = reader["PostalCode"].ToString();
                    cus.PhoneNumber = reader["PhoneNumber"].ToString();
                    cus.ContactName = reader["ContactName"].ToString();
                    cus.ContactEmail = reader["ContactEmail"].ToString();
                    cus.CreditLimit = Convert.ToInt32(reader["CreditLimit"]);
                    cus.Status = Convert.ToInt32(reader["Status"]);
                    listC.Add(cus);
                }

                return listC;

            }



        }


    }
}

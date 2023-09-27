using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject_2210662.BLL;

namespace FinalProject_2210662.DAL
{
    public class UserAccountDB
    {
        public static List<UserAccount> GetAllRecord()
        {
            List<UserAccount> acc = new List<UserAccount>();

            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM UserAccounts",conn);
                SqlDataReader reader = cmdAll.ExecuteReader();
                UserAccount account;
                while (reader.Read())
                {
                    account = new UserAccount();
                    account.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    account.UserId = Convert.ToInt32(reader["UserId"]);
                    account.Password = reader["Password"].ToString();
                    acc.Add(account);
                }
            }


            return acc;
        }

        public static UserAccount GetUserAccountById(int id)
        {
            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdSelectById = new SqlCommand("SELECT * FROM UserAccounts WHERE UserId = @UserId",conn);
                cmdSelectById.Parameters.AddWithValue("@UserId", id);
                SqlDataReader reader = cmdSelectById.ExecuteReader();
                reader.Read();
                UserAccount account = new UserAccount();
                account.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                account.UserId = Convert.ToInt32(reader["UserId"]);
                account.Password = reader["Password"].ToString();
                return account;

            }
        }


        public static void SaveRecord(UserAccount acc)
        {
            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAdd = new SqlCommand("INSERT INTO UserAccounts VALUES (@UserId, @Password, @EmployeeId);",conn);
                cmdAdd.Parameters.AddWithValue("@UserId", acc.UserId);
                cmdAdd.Parameters.AddWithValue("@Password", acc.Password);
                cmdAdd.Parameters.AddWithValue("@EmployeeId", acc.EmployeeId);
                cmdAdd.ExecuteNonQuery();
            }
           

        }



        public static void DeleteRecord(int id)
        {
            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM UserAccounts WHERE UserId = @UserId", conn);
                cmdDelete.Parameters.AddWithValue("@UserId", id);
                cmdDelete.ExecuteNonQuery();

            }
        }


        public static void UpdateRecord(int id, string pass)
        {
            using(SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand("UPDATE UserAccounts SET Password = @Password WHERE UserId = @UserId;",conn);
                cmdUpdate.Parameters.AddWithValue("@Password", pass);
                cmdUpdate.Parameters.AddWithValue("@UserId",id); 
                cmdUpdate.ExecuteNonQuery();
            }
        }










        public static bool Duplicated_ID_validation(int id)
        {
            List<UserAccount> acc = GetAllRecord();

            foreach (UserAccount account in acc)
            {
                if (account.UserId == id)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Existed_Account_validation(int id, string pass)
        {
            List<UserAccount> acc = GetAllRecord();

            foreach (UserAccount account in acc)
            {
                if (account.UserId == id)
                {
                    if(account.Password == pass)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        
        

    }
}

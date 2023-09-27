using FinalProject_2210662.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_2210662.BLL
{
    public class UserAccount
    {
        // Attributes
        private int userId;
        private string password;
        private int employeeId;

        // Property
        public int UserId { get { return userId; } set { userId = value; } }
        public int EmployeeId { get { return employeeId; } set { employeeId = value; } }
        public string Password { get { return password; } set { password = value; } }
        
        // Custom method

       

        public void AddUserAccount (UserAccount acc)
        {
            UserAccountDB.SaveRecord(acc);
        }

        public void RemoveUserAccount (int id)
        {
            UserAccountDB.DeleteRecord(id);
        }

        public UserAccount GetUserAccountById (int id)
        {
            return UserAccountDB.GetUserAccountById(id);
        }
        public List<UserAccount> Get_all_user_account()
        {
            return UserAccountDB.GetAllRecord();
        }

        public void UpdateUserAccount(int id, string pass)
        {
            UserAccountDB.UpdateRecord(id, pass);
        }


        // Validation
        public bool Check_existed_account(int id, string pass)
        {
            return UserAccountDB.Existed_Account_validation(id, pass);
        }

        public bool Duplicated_id_check(int id)
        {
            return UserAccountDB.Duplicated_ID_validation(id);
        }
    }
}

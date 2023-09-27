using FinalProject_2210662.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_2210662.DAL
{
    public class EmployeeDB
    {
        // Save Records
        public static void SaveRecord(Employee emp)
        {

            SqlConnection conn = Utility.GetDBConnection();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;


            cmdInsert.CommandText = "INSERT INTO Employees(EmployeeId,FirstName,LastName,PhoneNumber,Email,JobId) " +
                                     "VALUES(@EmployeeId,@FirstName,@LastName,@PhoneNumber,@Email,@JobId)";
            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", emp.Email);
            cmdInsert.Parameters.AddWithValue("@JobId", emp.JobId);



            cmdInsert.ExecuteNonQuery();

            conn.Close();
        }

        //Listing Records
        public static List<Employee> GetAllRecord()
        {
            List<Employee> lEmp = new List<Employee>();

            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand("SELECT * FROM Employees", conn);
                SqlDataReader reader = cmdAll.ExecuteReader();
                Employee emp;
                while (reader.Read())
                {
                    emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.LastName = reader["LastName"].ToString();
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.PhoneNumber = reader["PhoneNumber"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.JobId = Convert.ToInt32(reader["JobId"]);
                    lEmp.Add(emp);
                }
            }


            return lEmp;
        }

        //Updating records
        public static void UpdateRecord(Employee empUpdated)
        {


            SqlConnection conn = Utility.GetDBConnection();


            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;

            cmdUpdate.CommandText = "Update Employees  " + " SET FirstName= @FirstName," + "LastName= @LastName," + "PhoneNumber= @PhoneNumber," + "Email= @Email," + "JobId= @JobId " +
                                       " WHERE EmployeeId = @EmployeeId";

            cmdUpdate.Parameters.AddWithValue("@EmployeeId", empUpdated.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", empUpdated.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", empUpdated.LastName);
            cmdUpdate.Parameters.AddWithValue("@PhoneNumber", empUpdated.PhoneNumber);
            cmdUpdate.Parameters.AddWithValue("@Email", empUpdated.Email);
            cmdUpdate.Parameters.AddWithValue("@JobId", empUpdated.JobId);



            cmdUpdate.ExecuteNonQuery();

            conn.Close();
        }

        // Deleting Records
        public static Employee DeleteRecord(int id)
        {
            Employee emp = new Employee();

            SqlConnection conn = Utility.GetDBConnection();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = conn;
            cmdDelete.CommandText = "DELETE FROM Employees " + " WHERE EmployeeId=@EmployeeId";

            cmdDelete.Parameters.AddWithValue("@EmployeeId", id);
            SqlDataReader reader = cmdDelete.ExecuteReader();
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobId = Convert.ToInt32(reader["JobId"].ToString());

            }

            return emp;
        }

        //Receiving Employee by Id
        public static Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            using (SqlConnection conn = Utility.GetDBConnection())
            {
                SqlCommand cmdAll = new SqlCommand($"SELECT * FROM Employees WHERE EmployeeId = {id};", conn);
                SqlDataReader reader = cmdAll.ExecuteReader();

                while (reader.Read())
                {
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.LastName = reader["LastName"].ToString();
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.PhoneNumber = reader["PhoneNumber"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.JobId = Convert.ToInt32(reader["JobId"]);
                    
                }

            }


            return emp;
        }

        //Another version of receiving employee's id

        public static Employee SearchRecord(int id)
        {
            Employee emp = new Employee();

            SqlConnection conn = Utility.GetDBConnection();

            SqlCommand cmdSearchById = new SqlCommand();
            cmdSearchById.Connection = conn;
            cmdSearchById.CommandText = "Select * From Employees " + "Where EmployeeId = @EmployeeId ";

            cmdSearchById.Parameters.AddWithValue("@EmployeeId", id);
            SqlDataReader reader = cmdSearchById.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    emp.EmployeeId = id;
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.PhoneNumber = reader["PhoneNumber"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.JobId = Convert.ToInt32(reader["JobId"].ToString());


                    MessageBox.Show("Employee ID: " + emp.EmployeeId + ", \nFirst Name: " + emp.FirstName + ", \nLast Name: " + emp.LastName + ", \nPhone Number: " + emp.PhoneNumber + ", \nEmail: " + emp.Email + ", \nJob ID: " + emp.JobId, "Confirmation");
                }
            }
            else //not found
            {
                emp = null;
            }


            return emp;
        }

        //Receiving Employee by name
        public static List<Employee> SearchRecordsByName(string name)
        {
            List<Employee> ListE = new List<Employee>();


            SqlConnection conn = Utility.GetDBConnection();


            SqlCommand cmdSelectAllByName = new SqlCommand();
            cmdSelectAllByName.Connection = conn;
            cmdSelectAllByName.CommandText = "SELECT * FROM Employees " + "WHERE FirstName = @FirstName " + "OR LastName = @LastName";

            cmdSelectAllByName.Parameters.AddWithValue("@FirstName", name);
            cmdSelectAllByName.Parameters.AddWithValue("@LastName", name);
            SqlDataReader reader = cmdSelectAllByName.ExecuteReader();
            Employee emp;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobId = Convert.ToInt32(reader["JobId"].ToString());
                ListE.Add(emp);

                MessageBox.Show("Employee ID: " + emp.EmployeeId + ", \nFirst Name: " + emp.FirstName + ", \nLast Name: " + emp.LastName + ", \nPhone Number: " + emp.PhoneNumber + ", \nEmail: " + emp.Email + ", \nJob ID: " + emp.JobId, "Confirmation");

            }
            return ListE;
        }

        // Validation

        public static bool Existed_employee_check(int id)
        {
            Employee emp = GetEmployeeById(id);
            if (emp.EmployeeId == 0)
            {
                
                return false;
            }
           
            return true;
        }


        public static bool Qualified_job_id_check(int id)
        {
            Employee emp = GetEmployeeById(id);
            if(emp.JobId != 11111 && emp.JobId != 22222 && emp.JobId != 33333 && emp.JobId != 44444)
            {
                MessageBox.Show(emp.JobId.ToString());
                return false;

            }
            return true;
        }

    }




}

using FinalProject_2210662.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_2210662.BLL
{
    public class Employee
    {
        // Attributes
        private int employeeId;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string email;
        private int jobId;


        // property
        public int EmployeeId { get { return employeeId; } set { employeeId= value; } }
        public string LastName { get { return lastName; } set { lastName= value; } }
        public string FirstName { get { return firstName;} set { firstName= value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber= value; } }
        public string Email { get { return email; } set { email= value; } }
        public int JobId { get { return jobId; } set { jobId= value; } }


        // Custom Method

        public Employee GetEmployeeById(int id)
        {
            return EmployeeDB.GetEmployeeById(id);

        }

        public List<Employee> GetAllEmplooyee()
        {
            return EmployeeDB.GetAllRecord();
        }

        public void SaveEmployees(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }

        //Delete Employees
        public void DeleteRecord(int id)
        {
            EmployeeDB.DeleteRecord(id);
        }

        //Search by Employee ID
        public Employee SearchEmployee(int id)
        {
            return EmployeeDB.SearchRecord(id);
        }

        //Search by Employee Name (or last name)
        public List<Employee> SearchEmployeeByName(string name)
        {
            return EmployeeDB.SearchRecordsByName(name);
        }
        //Updating Employees
        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }

        // Validation
        public bool CheckExistedEmployee(int employeeId)
        {
            return EmployeeDB.Existed_employee_check(employeeId);
        }

        public bool Check_qualified_job_id(int id)
        {
            return EmployeeDB.Qualified_job_id_check(id);
        }





    }
}

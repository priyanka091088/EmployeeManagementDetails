using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class EmployeeList
    {
        static List<Employee> _employeeDetails = null;
        static EmployeeList()
        {
            _employeeDetails = new List<Employee>()
            {
                new Employee(){Id=1,Name="priyanka",Surname="jha",Address="jharkhand",Qualification="Btech",ContactNumber=987654321,Department="Software Developer"},
                new Employee(){Id=2,Name="Tahseen",Surname="khan",Address="Gujarat",Qualification="Btech",ContactNumber=123456789,Department="Software Developer"},
                new Employee(){Id=3,Name="Bivek",Surname="Mali",Address="WestBengal",Qualification="Btech",ContactNumber=0987654321,Department=".Net Developer"},
                new Employee(){Id=4,Name="Sweta",Surname="Kumari",Address="Bihar",Qualification="Btech",ContactNumber=0123456789,Department="HR"},
            };
        }
        public static List<Employee> GetAllEmployees()
        {
            return _employeeDetails;
        }
        public static void AddNewEmployee(Employee emp)
        {
            _employeeDetails.Add(emp);
        }
        public static void UpdateEmployeeDetails(int id,Employee emp)
        {
            Employee employee = _employeeDetails.Find(c => c.Id == id);
            employee.Name = emp.Name;
            employee.Surname = emp.Surname;
            employee.Address = emp.Address;
            employee.Qualification = emp.Qualification;
            employee.ContactNumber = emp.ContactNumber;
            employee.Department = emp.Department;
        }
        public static void DeleteEmployee(int id)
        {
            Employee employee = _employeeDetails.Find(c => c.Id == id);
            _employeeDetails.Remove(employee);
        }
    }
}

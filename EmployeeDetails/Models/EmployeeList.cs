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
                new Employee(){Eid=1,Name="priyanka",Surname="jha",Address="jharkhand",Qualification="Btech",ContactNumber="987654321"},
                new Employee(){Eid=2,Name="Tahseen",Surname="khan",Address="Gujarat",Qualification="Btech",ContactNumber="123456789"},
                new Employee(){Eid=3,Name="Bivek",Surname="Mali",Address="WestBengal",Qualification="Btech",ContactNumber="0987654321"},
                new Employee(){Eid=4,Name="Sweta",Surname="Kumari",Address="Bihar",Qualification="Btech",ContactNumber="0123456789"},
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
            Employee employee = _employeeDetails.Find(c => c.Eid == id);
            employee.Name = emp.Name;
            employee.Surname = emp.Surname;
            employee.Address = emp.Address;
            employee.Qualification = emp.Qualification;
            employee.ContactNumber = emp.ContactNumber;
            //employee.Department = emp.Department;
        }
        public static void DeleteEmployee(int id)
        {
            Employee employee = _employeeDetails.Find(c => c.Eid == id);
            _employeeDetails.Remove(employee);
        }
    }
}

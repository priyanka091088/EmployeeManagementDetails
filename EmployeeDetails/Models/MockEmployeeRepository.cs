using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        
        public List<Employee> SelectAllEmployees()
        {
            return EmployeeList.GetAllEmployees();
        }
        public Employee GetEmployeeById(int id)
        {
            return EmployeeList.GetAllEmployees().Find(c => c.Id == id);
        }
        public void AddEmployee(Employee emp)
        {
            EmployeeList.AddNewEmployee(emp);
        }
        public void UpdateEmployeeDetails(int id,Employee emp)
        {
            EmployeeList.UpdateEmployeeDetails(id,emp);
        }
        public void DeleteOneEmployee(int id)
        {
            EmployeeList.DeleteEmployee(id);
        }

       
    }
}

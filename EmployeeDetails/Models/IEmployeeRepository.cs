using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public interface IEmployeeRepository
    {
        public List<Employee>SelectAllEmployees();
        public Employee GetEmployeeById(int id);
        public void AddEmployee(Employee emp);
        public void UpdateEmployeeDetails(int id,Employee emp);
        public void DeleteOneEmployee(int id);
        public void UpdateEmployeeProfile(int id, Employee emp);
    }
}

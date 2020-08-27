using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public interface IDepartmentRepository
    {
        public List<Department> SelectAllDepartment();
        public Department GetDepartById(int id);
        public void AddNewDepartment(Department dep);
        public void UpdateDepartmentDetails(int id,Department dep);
        public void DeleteOneDepart(int id);
    }
}

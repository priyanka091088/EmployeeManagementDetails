using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class MockDepartmentRepository:IDepartmentRepository
    {
        public List<Department> SelectAllDepartment()
        {
            return DepartmentList.GetAllDepartment();
        }
        public Department GetDepartById(int id)
        {
            return DepartmentList.GetAllDepartment().Find(c => c.DepartId == id);
        }
        public void AddNewDepartment(Department dep)
        {
            DepartmentList.AddDepartment(dep);
        }
        public void UpdateDepartmentDetails(int id,Department dep)
        {
            DepartmentList.UpdateDepartDetails(id,dep);
        }
        public void DeleteOneDepart(int id)
        {
            DepartmentList.DeleteDepartment(id);
        }
    }
}

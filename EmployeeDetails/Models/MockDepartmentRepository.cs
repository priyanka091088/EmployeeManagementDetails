using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class MockDepartmentRepository:IDepartmentRepository
    {
        public List<Models.Department> SelectAllDepartment()
        {
            return DepartmentList.GetAllDepartment();
        }
        public Models.Department GetDepartById(int id)
        {
            return DepartmentList.GetAllDepartment().Find(c => c.DepartId == id);
        }
        public void AddNewDepartment(Models.Department dep)
        {
            DepartmentList.AddDepartment(dep);
        }
        public void UpdateDepartmentDetails(int id,Models.Department dep)
        {
            DepartmentList.UpdateDepartDetails(id,dep);
        }
        public void DeleteOneDepart(int id)
        {
            DepartmentList.DeleteDepartment(id);
        }
    }
}

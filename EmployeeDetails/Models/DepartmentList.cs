using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class DepartmentList
    {
        static List<Department> _departDetails = null;
        static DepartmentList()
        {
            _departDetails = new List<Department>()
            {
                new Department(){DepartId=1,DepartName="HR"},
                new Department(){DepartId=2,DepartName="Software Developer"},
                new Department(){DepartId=3,DepartName=".Net Developer"},
                new Department(){DepartId=4,DepartName="Team Leader"},
            };
        }
        public static List<Department> GetAllDepartment()
        {
            return _departDetails;
        }
        public static void AddDepartment(Department dep)
        {
            _departDetails.Add(dep);
        }
        public static void UpdateDepartDetails(int id,Department dep)
        {
            Department department = _departDetails.Find(c => c.DepartId == id);
            department.DepartName = dep.DepartName;
            
        }
        public static void DeleteDepartment(int id)
        {
            Department department = _departDetails.Find(c => c.DepartId == id);
            _departDetails.Remove(department);
        }
    }
}

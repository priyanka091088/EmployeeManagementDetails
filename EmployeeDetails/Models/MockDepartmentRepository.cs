using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace EmployeeDetails.Models
{
    public class MockDepartmentRepository:IDepartmentRepository
    {
       
        private readonly AppDbContext _context;
       
        public MockDepartmentRepository(AppDbContext context)
        {
            _context = context;
            
        }
        public List<Department> SelectAllDepartment()
        {
            return _context.department.ToList();
        }
        public Department GetDepartById(int id)
        {
            return _context.department.FirstOrDefault(x => x.DepartId == id);
        }
        public void AddNewDepartment(Department dep)
        {
            _context.department.Add(dep);
            _context.SaveChanges();
           
        }
        public void UpdateDepartmentDetails(int id,Department dep)
        {
            Department d = _context.department.Find(id);
            d.DepartId = id;
            d.DepartName = dep.DepartName;
            _context.department.Update(d);
            _context.SaveChanges();
        }
        public void DeleteOneDepart(int id)
        {
            var dept = _context.department.Find(id);
            _context.department.Remove(dept);
           /* var employees = _context.employee.FirstOrDefault(e => e.DepartId == id);
            _context.employee.Remove(employees);*/
            _context.SaveChanges();
          
        }
       
    }
}

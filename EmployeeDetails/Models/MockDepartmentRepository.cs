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
        SqlConnection con;
       
        public MockDepartmentRepository()
        {
            string cs= "Data Source = LAPTOP-KFMURN8F\\SQLEXPRESS02; Initial Catalog = EmployeeManagementDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            con = new SqlConnection(cs);
            con.Open();
            
        }
        public List<Department> SelectAllDepartment()
        {
            return con.Query<Department>("select * from Department").ToList();
        }
        public Department GetDepartById(int id)
        {
            List<Department> dept = con.Query<Department>("select * from Department").ToList();
            return dept.Find(x => x.DepartId == id);
        }
        public void AddNewDepartment(Department dep)
        { 
            // Insert query  
            List<Department> dept = con.Query<Department>("select * from Department").ToList();
            dep.DepartId = dept.Max(x => x.DepartId) + 1;
            string query = "INSERT INTO Department(DepartId,DepartName) VALUES(@DepartId, @DepartName)";
            DynamicParameters Parameters = new DynamicParameters();
            Parameters.Add("@DepartId", dep.DepartId);
            Parameters.Add("@DepartName", dep.DepartName);
            con.Execute(query, Parameters);
            
            con.Close();
        }
        public void UpdateDepartmentDetails(int id, Department dep)
        {
           
            string query = "UPDATE Department SET DepartName = '" + dep.DepartName + "' WHERE DepartId = " + id;
            con.Execute(query);
            con.Close();
        }
        public void DeleteOneDepart(int id)
        {
           string query = "DELETE FROM Department WHERE DepartId = " + id;
            con.Execute(query);
            con.Close();
        }
        /* SqlConnection con;
         private List<Department> dept = new List<Department>();

         private Department department;
         public MockDepartmentRepository()
         {

             //string connect = "Data Source=LAPTOP-KFMURN8F\\SQLEXPRESS02;Initial Catalog=EmployeeManagementDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



         }*/
    }
}

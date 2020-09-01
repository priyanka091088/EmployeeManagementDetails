using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class MockDepartmentRepository:IDepartmentRepository
    {
        SqlConnection con;
        private List<Department> dept = new List<Department>();
        private Department departments;

        public MockDepartmentRepository()
        {
            string cs= "Data Source = LAPTOP-KFMURN8F\\SQLEXPRESS02; Initial Catalog = EmployeeManagementDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                departments = new Department();
                departments.DepartId = Convert.ToInt32(reader[0]);
                departments.DepartName = reader[1].ToString();
                dept.Add(departments);
            }
            con.Close();
        }
        public List<Department> SelectAllDepartment()
        {
            return dept;
        }
        public Department GetDepartById(int id)
        {
            return dept.Find(c => c.DepartId == id);
        }
        public void AddNewDepartment(Department dep)
        {
            con.Open();
            // Insert query  
            string query = "INSERT INTO Department(DepartId,DepartName) VALUES(@DepartId, @DepartName)";
            SqlCommand cmd = new SqlCommand(query, con);

            departments = new Department();
            // Passing parameter values  
            dep.DepartId = dept.Max(x => x.DepartId) + 1;

            cmd.Parameters.AddWithValue("@DepartId", dep.DepartId);
            cmd.Parameters.AddWithValue("@DepartName", dep.DepartName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateDepartmentDetails(int id, Department dep)
        {
            con.Open();
            string query = "UPDATE Department SET DepartName = '" + dep.DepartName + "' WHERE DepartId = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteOneDepart(int id)
        {
            con.Open();
            string query;
            SqlCommand cmd;
            query = "DELETE FROM Department WHERE DepartId = " + id;
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
           /* query = "DELETE FROM Employee WHERE DepartId = " + id;
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();*/
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class DepartmentList
    {
       // SqlConnection con;
        static List<Department> _departDetails = null;
        static DepartmentList()
        {
            //string connectionstring = "Data Source = LAPTOP-KFMURN8F\\SQLEXPRESS02; Initial Catalog = EmployeeManagementDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
           
            _departDetails = new List<Department>()
            {
                new Department(){DepartId=1,DepartName="HR"},
                new Department(){DepartId=2,DepartName="Software Developer"},
                new Department(){DepartId=3,DepartName=".Net Developer"},
                new Department(){DepartId=4,DepartName="Team Leader"},
            };
               // con = new SqlConnection(connectionstring);
            //con.Open();
        }
        public static List<Department> GetAllDepartment()
        {

                return _departDetails;
              /*  SqlCommand cmd = new SqlCommand("select * from Department", con);
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Department dep = new Department();
                dep.DepartId = Convert.ToInt32(reader[0]);
                dep.DepartName = reader[1].ToString();
                _departDetails.Add(dep);
            }
            con.Close();
            return _departDetails;*/
        }
        public static void AddDepartment(Department dep)
        {
                _departDetails.Add(dep);
                // con.Open();
               /* string qry = "INSERT INTO dbo.Department(DepartName) VALUES(@DeptName)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@DeptName", dep.DepartName);
            cmd.ExecuteNonQuery();
            con.Close();
            return dep;*/
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

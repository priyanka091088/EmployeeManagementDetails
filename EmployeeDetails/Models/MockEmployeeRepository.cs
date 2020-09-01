using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeDetails.Models
{
    public class MockEmployeeRepository :IEmployeeRepository
    {
        SqlConnection con;
        private List<Employee> emp = new List<Employee>();
        private Employee employees;

        public MockEmployeeRepository()
        {
            string cs = "Data Source = LAPTOP-KFMURN8F\\SQLEXPRESS02; Initial Catalog = EmployeeManagementDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee inner join Department on Employee.DepartId = Department.DepartId", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees = new Employee();
                employees.department = new Department();
                employees.Eid = Convert.ToInt32(reader[0]);
                employees.Name = reader[1].ToString();
                employees.Surname = reader[2].ToString();
                employees.Address = reader[3].ToString();
                employees.Qualification = reader[4].ToString();
                employees.ContactNumber = Convert.ToString(reader[5]);
                employees.DepartId = Convert.ToInt32(reader[6]);
                employees.department.DepartId = Convert.ToInt32(reader[7]);
                employees.department.DepartName = reader[8].ToString();
                emp.Add(employees);
            }
            con.Close();
        }
        public List<Employee> SelectAllEmployees()
        {
            return emp;
        }
        public Employee GetEmployeeById(int id)
        {
            return emp.Find(c => c.Eid == id);
        }
        public void AddEmployee(Employee employee)
        {
            con.Open();
            // Insert query  
            string query = "INSERT INTO Employee(Name,Surname,Address,Qualification,ContactNo,DepartId) VALUES(@Name,@Surname,@Address,@Qualification,@ContactNo,@DepartId)";
            SqlCommand cmd = new SqlCommand(query, con);

            employees = new Employee();
            // Passing parameter values  
            
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Surname", employee.Surname);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@Qualification", employee.Qualification);
            cmd.Parameters.AddWithValue("@ContactNo", employee.ContactNumber);
            cmd.Parameters.AddWithValue("@DepartId", employee.DepartId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateEmployeeDetails(int id,Employee employee)
        {
            con.Open();
            string query = "UPDATE Employee SET Name = '" + employee.Name + "',Surname = '" + employee.Surname + "',Address = '" + employee.Address + "',Qualification = '" + employee.Qualification + "',ContactNo = " + employee.ContactNumber + ",DepartId = " + employee.DepartId + " WHERE Eid = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteOneEmployee(int id)
        {
            con.Open();
            string query = "DELETE FROM Employee WHERE Eid = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

       
    }
}

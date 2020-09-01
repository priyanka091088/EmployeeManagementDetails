using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

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
           
        }
        public List<Employee> SelectAllEmployees()
        {

            return con.Query<Employee>("select * from Employee INNER JOIN Department ON Employee.DepartId=Department.DepartId").ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            List<Employee> emp = con.Query<Employee>("select * from Employee").ToList();
            return emp.Find(x => x.Eid == id);
        }
        public void AddEmployee(Employee employee)
        {
            // Insert query  
            List<Employee> emp = con.Query<Employee>("select * from Employee").ToList();
           
            string query = "INSERT INTO Employee(Name,Surname,Address,Qualification,ContactNo,DepartId) VALUES(@Name,@Surname,@Address,@Qualification,@ContactNo,@DepartId)";
            DynamicParameters Parameters = new DynamicParameters();
            employees = new Employee();
            // Passing parameter values  
            
            Parameters.Add("@Name", employee.Name);
            Parameters.Add("@Surname", employee.Surname);
            Parameters.Add("@Address", employee.Address);
            Parameters.Add("@Qualification", employee.Qualification);
            Parameters.Add("@ContactNo", employee.ContactNo);
            Parameters.Add("@DepartId", employee.DepartId);
            con.Execute(query,Parameters);
            con.Close();
        }
        public void UpdateEmployeeDetails(int id,Employee employee)
        {
           
            string query = "UPDATE Employee SET Name = '" + employee.Name + "',Surname = '" + employee.Surname + "',Address = '" + employee.Address + "',Qualification = '" + employee.Qualification + "',ContactNo = " + employee.ContactNo + ",DepartId = " + employee.DepartId + " WHERE Eid = " + id;
            con.Execute(query);
            con.Close();
        }
        public void DeleteOneEmployee(int id)
        {
            string query = "DELETE FROM Employee WHERE Eid = " + id;
            con.Execute(query);
            con.Close();
        }

       
    }
}

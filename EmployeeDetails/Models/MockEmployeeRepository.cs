using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using EmployeeDetails.Hubs;

namespace EmployeeDetails.Models
{
    public class MockEmployeeRepository :IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHubContext<NotificationHub> hubContext;
        public MockEmployeeRepository(AppDbContext context,UserManager<IdentityUser> _userManager,IHubContext<NotificationHub> _hubContext) 
        {
            _context = context;
            userManager = _userManager;
            hubContext = _hubContext;
        }
        public List<Employee> SelectAllEmployees()
        {
            var employee = _context.employee.Include(e => e.Department);
            return employee.ToList();


        }
        public Employee GetEmployeeById(int id)
        {
            return _context.employee.FirstOrDefault(e => e.Eid == id);
        }
        public void AddEmployee(Employee employee)
        {
            _context.employee.Add(employee);
            _context.SaveChanges();

            foreach (var emp in SelectAllEmployees())
            {


                if (emp.DepartId == employee.DepartId)
                {
                    var user = userManager.FindByEmailAsync(emp.Email).Result;

                    hubContext.Clients.User(user.Id).SendAsync("sendToUser", employee.Name,employee.Surname);
                }
            }

        }
        public void UpdateEmployeeDetails(int id,Employee emp)
        {
           Employee e= _context.employee.Find(id);
            e.Eid = id;
            e.Name = emp.Name;
            e.Surname = emp.Surname;
            e.Address = emp.Address;
            e.Email = emp.Email;
            e.Qualification = emp.Qualification;
            e.ContactNo = emp.ContactNo;
            e.DepartId = emp.DepartId;
            _context.employee.Update(e);
            _context.SaveChanges();
            
        }

        public void UpdateEmployeeProfile(int id, Employee emp)
        {
            Employee e = _context.employee.Find(id);
            e.Eid = id;
            e.Name = emp.Name;
            e.Surname = emp.Surname;
            e.Address = emp.Address;
            e.Qualification = emp.Qualification;
            e.ContactNo = emp.ContactNo;
            _context.employee.Update(e);
            _context.SaveChanges();

        }
        public void DeleteOneEmployee(int id)
        {
            var employee = _context.employee.Find(id);
            
            _context.employee.Remove(employee);
            _context.SaveChanges();

        }

       
    }
}

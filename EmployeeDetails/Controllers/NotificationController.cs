using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Hubs;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHubContext<NotificationHub> hubContext;
        public NotificationController(AppDbContext context, UserManager<IdentityUser> _userManager, IHubContext<NotificationHub> _hubContext)
        {
            _context = context;
            userManager = _userManager;
        }

        public async Task<IActionResult> Get(string message)
        {
            await hubContext.Clients.User("0fb3a538-6817-4d19-97f0-5f89da6b9a9c").SendAsync("departAddNotify", message);
            return Ok(new { Message = "Request Completed" });
        }

        /*public void AddEmployee(Employee employee)
        {
            _context.employee.Add(employee);
            _context.SaveChanges();

            foreach (var emp in SelectAllEmployees())
            {


                if (emp.DepartId == employee.DepartId)
                {
                    var user = userManager.FindByEmailAsync(emp.Email).Result;

                    hubContext.Clients.User(user.Id).SendAsync("sendToUser", employee.Name, employee.Surname);
                }
            }

        }*/

        public List<Employee> SelectAllEmployees()
        {
            var employee = _context.employee.Include(e => e.Department);
            return employee.ToList();


        }
    }
}

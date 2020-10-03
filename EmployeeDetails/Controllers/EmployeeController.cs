using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using EmployeeDetails.Hubs;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHubContext<NotificationHub> hubContext;

        public EmployeeController(AppDbContext context, UserManager<IdentityUser> _userManager, IHubContext<NotificationHub> _hubContext)
        {
            _context = context;
            userManager = _userManager;
            hubContext = _hubContext;

        }

        // GET: api/Employee
        [HttpGet]
        [Authorize(Roles = "Admin,HR,Employee")]
        public async Task<ActionResult<IEnumerable<Employee>>> Getemployee()
        {
            
            var appDbContext = _context.employee.Include(e => e.Department);
            return await appDbContext.ToListAsync();
            
           
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }


        // PUT: api/Employee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Eid)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Roles = "Admin,HR")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            
            var userName = employee.Email;
            var email = employee.Email;
            var password = employee.Name.ToUpper() + employee.Surname + "@123";
            var user = new IdentityUser { UserName = userName, Email = email };
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Employee");
                _context.employee.Add(employee);
                await _context.SaveChangesAsync();

                /*foreach (var emp in SelectAllEmployees())
                {


                    if (emp.DepartId == employee.DepartId)
                    {
                        var users = userManager.FindByEmailAsync(emp.Email).Result;

                        await hubContext.Clients.User(users.Id).SendAsync("sendToUser", employee.Name, employee.Surname);
                    }
                }*/

            }

            return CreatedAtAction("GetEmployee", new { id = employee.Eid }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,HR")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = _context.employee.Find(id);
            var userEmp = await userManager.FindByNameAsync(emp.Email);
            await userManager.DeleteAsync(userEmp);
            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.employee.Any(e => e.Eid == id);
        }

        public List<Employee> SelectAllEmployees()
        {
            var employee = _context.employee.Include(e => e.Department);
            return employee.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using EmployeeDetails.Hubs;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProfileController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<NotificationHub> hubContext;

        public EmployeeProfileController(AppDbContext context,IHubContext<NotificationHub> _hubContext)
        {
            _context = context;
            hubContext = _hubContext;
        }

        // GET: api/Employee/abc@gmail.com
        [HttpGet("{email}")]
        [Authorize(Roles = "Employee")]
        public ActionResult<Employee> GetEmployee(string email)
        {
            var employee = _context.employee.FirstOrDefault(employee => employee.Email == email);

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
        [Authorize(Roles = "Employee")]
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
                await hubContext.Clients.All.SendAsync("ProfileEditNotify", "Employee edited their profile");
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

        private bool EmployeeExists(int id)
        {
            return _context.employee.Any(e => e.Eid == id);
        }

    }
}


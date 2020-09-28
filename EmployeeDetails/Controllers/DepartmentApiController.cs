﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        public DepartmentApiController(AppDbContext context, UserManager<IdentityUser> _userManagert)
        {
            _context = context;
            userManager = _userManagert;
        }

        // GET: api/DepartmentApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> Getdepartment()
        {
            return await _context.department.ToListAsync();
        }

        // GET: api/DepartmentApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/DepartmentApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DepartId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/DepartmentApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _context.department.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.DepartId }, department);
        }

        // DELETE: api/DepartmentApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var emp = _context.employee.Where(e =>e.DepartId==id).ToList();
            foreach (var item in emp)
            {
                var userEmp = await userManager.FindByNameAsync(item.Email);
                await userManager.DeleteAsync(userEmp);
            }
            
            var department = await _context.department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.department.Remove(department);
            await _context.SaveChangesAsync();

            return department;
        }

        private bool DepartmentExists(int id)
        {
            return _context.department.Any(e => e.DepartId == id);
        }
    }
}
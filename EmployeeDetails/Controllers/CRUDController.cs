using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeDetails.Controllers
{
    public class CRUDController : Controller
    {
        private readonly IEmployeeRepository e;
        private readonly IDepartmentRepository _department;
        // GET: CRUDController
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext context;
        public CRUDController(IEmployeeRepository emp,IDepartmentRepository dep, UserManager<IdentityUser> _userManager,
                    RoleManager<IdentityRole> _roleManager,AppDbContext _context)
        {
            e = emp;
            _department = dep;
            context = _context;
            userManager = _userManager;
            roleManager = _roleManager;
        }
        public async Task<IActionResult> Index()
        {
           
                IdentityRole identityRole = new IdentityRole
                {
                    Name = "Admin"
                };
                IdentityResult roleResult = await roleManager.CreateAsync(identityRole);

                IdentityRole identityRole2 = new IdentityRole
                {
                    Name = "HR"
                };
                IdentityResult roleResult2 = await roleManager.CreateAsync(identityRole2);

                IdentityRole identityRole3 = new IdentityRole
                {
                    Name = "Employee"
                };
            IdentityResult roleResult3 = await roleManager.CreateAsync(identityRole3);
            foreach (IdentityError error in roleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            
                //Pre-Generating Admin
                var adminName = "shrutisingh@gmail.com";
                var adminEmail = "shrutisingh@gmail.com";
                var adminPassword = "Shrutisingh@123";
                var user = new IdentityUser
                {
                    UserName = adminName,
                    Email = adminEmail
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                  
                }

                //Pre-generating HR
                var hrName = "yashpatel@gmail.com";
                var hrEmail = "yashpatel@gmail.com";
                var hrPassword = "Yashpatel@123";
                var user2 = new IdentityUser
                {
                    UserName = hrName,
                    Email = hrEmail
                };
               var result2 = await userManager.CreateAsync(user2, hrPassword);
                
                if (result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user2, "HR");
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

               return View();
           
         }
         
        // GET: CRUDController/Details/5
        [Authorize(Roles ="Admin,HR,Employee")]
        public ActionResult Details()
        {

            ViewData["DepartName"] = new SelectList(_department.SelectAllDepartment(), "DepartId", "DepartName");

            if (User.IsInRole("Employee"))
            {
                var user = userManager.GetUserAsync(HttpContext.User).Result;
                var employeesList = e.SelectAllEmployees().ToList();
                var employee = employeesList.Find(x => x.Email == user.UserName);
                var emps = employeesList.Where(x => x.DepartId == employee.DepartId).ToList();
                var deptlist = _department.SelectAllDepartment();
                foreach (var emp in emps)
                {
                    emp.department = deptlist.FirstOrDefault(x => x.DepartId == emp.DepartId);
                }
                return View(emps);
            }

            var employeeList = e.SelectAllEmployees().ToList();
            var _deptlist = _department.SelectAllDepartment();
                foreach (var emp in employeeList)
                {
                    emp.department = _deptlist.FirstOrDefault(x => x.DepartId == emp.DepartId);
                }
          
               return View("/Views/CRUD/Details.cshtml", employeeList);
            
           

        }

        // GET: CRUDController/Create
       [Authorize(Roles ="Admin,HR")]
        public ActionResult Create()
        {
            ViewBag.DepartName = _department.SelectAllDepartment();
            return View();
        }

        // POST: CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin,HR")]
        public async Task<IActionResult> Create(Employee emp)
        {
            ViewBag.DepartName = _department.SelectAllDepartment();
            if (ModelState.IsValid)
            {
                var role = await roleManager.RoleExistsAsync("Employee");
                var userName = emp.Email;
                var email = emp.Email;
                var password = emp.Name.ToUpper() + emp.Surname + "@123";
                var user = new IdentityUser { UserName = userName, Email = email };
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Employee");
                     e.AddEmployee(emp);
                     return RedirectToAction("Details");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
          
        }

        // GET: CRUDController/Edit/5
        [Authorize(Roles = "Admin,HR")]
        public ActionResult Edit(int id)
        {
            ViewBag.DepartName = _department.SelectAllDepartment();
            Employee employee = e.GetEmployeeById(id);
            return View(employee);
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR")]
        public ActionResult Edit(int id, Employee emp)
        {
           
                ViewBag.DepartName = _department.SelectAllDepartment();
                e.UpdateEmployeeDetails(id,emp);
                return RedirectToAction("Details");
            
        }

        //Delete employee
        [Authorize(Roles = "Admin,HR")]
        public ActionResult Delete(int id)
        {
            Employee model = e.GetEmployeeById(id);
            return View(model);
        }

        // POST: CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR")]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var emp = context.employee.Find(id);
                var userEmp = await userManager.FindByNameAsync(emp.Email);
                await userManager.DeleteAsync(userEmp);
                e.DeleteOneEmployee(id);
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult Profile()
        {
            if (User.IsInRole("Employee"))
            {
                var user = userManager.GetUserAsync(HttpContext.User).Result;
                var employeesList = e.SelectAllEmployees().ToList();
                var employee = employeesList.Find(x => x.Email == user.UserName);
                var deptlist = _department.SelectAllDepartment();
                employee.department = deptlist.FirstOrDefault(x => x.DepartId == employee.DepartId);
                
                return View(employee);
            }
            return View();
        }

        public ActionResult EditProfile(int id)
        {
            ViewBag.DepartName = _department.SelectAllDepartment();
            Employee employee = e.GetEmployeeById(id);
            return View(employee);
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult EditProfile(int id, Employee emp)
        {

            ViewBag.DepartName = _department.SelectAllDepartment();
            e.UpdateEmployeeDetails(id, emp);
            return RedirectToAction("Profile");

        }

    }
}

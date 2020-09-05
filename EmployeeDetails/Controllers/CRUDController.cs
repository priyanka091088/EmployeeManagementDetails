using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeDetails.Controllers
{
    public class CRUDController : Controller
    {
        private readonly IEmployeeRepository e;
        private readonly IDepartmentRepository _department;
        // GET: CRUDController

        public CRUDController(IEmployeeRepository emp,IDepartmentRepository dep)
        {
            e = emp;
            _department = dep;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: CRUDController/Details/5
        public ActionResult Details()
        {
            ViewData["DepartName"] = new SelectList(_department.SelectAllDepartment(), "DepartId", "DepartName");
           // return View(e.SelectAllEmployees());
             var employeesList = e.SelectAllEmployees();
            var deptlist = _department.SelectAllDepartment();

 

            foreach(var emp in employeesList)
            {
                emp.department = (deptlist.FirstOrDefault(x => x.DepartId == emp.DepartId));
            }

 

            return View("/Views/CRUD/Details.cshtml", employeesList);

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
        public IActionResult Create(Employee emp)
        {
            try { 
                ViewBag.DepartName = _department.SelectAllDepartment();
                e.AddEmployee(emp);
                return RedirectToAction("Details");
            }

             catch
             {
                 return View();
             }
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

        // GET: CRUDController/Delete/5
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
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                e.DeleteOneEmployee(id);
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }
    }
}

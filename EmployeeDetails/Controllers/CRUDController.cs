using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeDetails.Controllers
{
    public class CRUDController : Controller
    {
        MockEmployeeRepository e = new MockEmployeeRepository();
        MockDepartmentRepository _department = new MockDepartmentRepository();
        // GET: CRUDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CRUDController/Details/5
        public ActionResult Details()
        {
            ViewData["DeptName"] = new SelectList(_department.SelectAllDepartment(), "DepartId", "DepartName");
            return View(e.SelectAllEmployees());
            /* IEnumerable<Employee> model = e.SelectAllEmployees();
             return (View(model));*/
            //return View();
        }

        // GET: CRUDController/Create
        public ActionResult Create()
        {
            ViewBag.DeptName = _department.SelectAllDepartment();
            return View();
        }

        // POST: CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            
                ViewBag.DeptName = _department.SelectAllDepartment();
                e.AddEmployee(emp);
                return RedirectToAction("Details");
               
            
            /* catch
             {
                 return View();
             }*/
        }

        // GET: CRUDController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DeptName = _department.SelectAllDepartment();
            Employee employee = e.GetEmployeeById(id);
            return View(employee);
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                e.UpdateEmployeeDetails(id,emp);
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUDController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee model = e.GetEmployeeById(id);
            return View(model);
        }

        // POST: CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

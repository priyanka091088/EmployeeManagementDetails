using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    public class CRUDController : Controller
    {
        MockEmployeeRepository e = new MockEmployeeRepository();
        // GET: CRUDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CRUDController/Details/5
        public ActionResult Details()
        {
            IEnumerable<Employee> model = e.SelectAllEmployees();
            return (View(model));
        }

        // GET: CRUDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
             try
             {
                e.AddEmployee(emp);
                return RedirectToAction("Details");
               
            }
             catch
             {
                 return View();
             }
        }

        // GET: CRUDController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee model = e.GetEmployeeById(id);
            return View(model);
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

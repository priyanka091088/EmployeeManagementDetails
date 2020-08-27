using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    public class DepartmentController : Controller
    {
        MockDepartmentRepository depart = new MockDepartmentRepository();
        // GET: DepartmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<Department> model = depart.SelectAllDepartment();
            return (View(model));
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    depart.AddNewDepartment(dep);
                    return RedirectToAction("Details");
                }
                catch
                {
                    return View();
                }
            }
            return View();
           
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            Department department = depart.GetDepartById(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department dep)
        {
            try
            {
                depart.UpdateDepartmentDetails(id,dep);
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            Department department = depart.GetDepartById(id);
            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                depart.DeleteOneDepart(id);
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }
    }
}

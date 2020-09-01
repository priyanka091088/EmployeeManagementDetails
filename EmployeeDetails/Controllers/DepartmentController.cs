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
        //private readonly IDepartmentRepository _dept;
        MockDepartmentRepository depart = new MockDepartmentRepository();
        // private MockDepartmentRepository _department;
        // GET: DepartmentController
        /*public DepartmentController(IDepartmentRepository dept)
        {
            _dept = dept;
        }*/
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            // IEnumerable<Department> model = _dept.SelectAllDepartment();
             return (View(depart.SelectAllDepartment()));
            //return View();
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
           
                try
                {
                    depart.AddNewDepartment(dep);
                    return RedirectToAction("Details");
                }
                catch
                {
                    return View();
                }
            
           // return View();
           
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
             Department department = depart.GetDepartById(id);
             return View(department);
            //return View();
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
           // return View();
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            Department department = depart.GetDepartById(id);
            return View(department);
           // return View();
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
            //return View();
        }
    }
}

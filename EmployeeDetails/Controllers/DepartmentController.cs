using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    public class DepartmentController : Controller
    {
        
       // private readonly AppDbContext _context;
        private readonly IDepartmentRepository _depart;
        // GET: DepartmentController
        public DepartmentController(IDepartmentRepository depart)
        {
            _depart = depart;
           // _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var departlist = _depart.SelectAllDepartment();
            return View(departlist);
        }

        // GET: DepartmentController/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind("DepartId,DepartName")] Department dep)
        {
           
                try
                {
                    _depart.AddNewDepartment(dep);
                    return RedirectToAction("Details");
                }
                catch
                {
                    return View();
                }
           
        }

        // GET: DepartmentController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
             Department department = _depart.GetDepartById(id);
             return View(department);
            //return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id,Department dep)
        {
             try
             {
                 _depart.UpdateDepartmentDetails(id,dep);
                 return RedirectToAction("Details");
             }
             catch
             {
                 return View();
             }
           // return View();
        }

        // GET: DepartmentController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Department department = _depart.GetDepartById(id);
            return View(department);
           // return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
             try
             {
                 _depart.DeleteOneDepart(id);
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

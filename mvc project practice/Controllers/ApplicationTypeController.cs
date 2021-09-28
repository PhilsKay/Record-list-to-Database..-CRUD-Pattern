using Microsoft.AspNetCore.Mvc;
using mvc_project_practice.Data;
using mvc_project_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_project_practice.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationTypeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Type()
        {
            var records = _applicationDbContext.ApplicationType.ToList();
            return View(records);
        }
        // Get for create category
        public IActionResult Create()
        {
            return View();
        }
        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.ApplicationType.Add(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Type");
            }
            return View(obj);   
        }
        //Get for edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _applicationDbContext.ApplicationType.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.ApplicationType.Update(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Type");
            }
            return View(obj);
        }
        // Get delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _applicationDbContext.ApplicationType.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Delete From database
        public IActionResult DeleteForm(ApplicationType obj)
        {
            _applicationDbContext.ApplicationType.Remove(obj);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Type");
        }
    }
}

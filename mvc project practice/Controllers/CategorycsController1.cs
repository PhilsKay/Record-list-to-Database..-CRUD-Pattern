using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using mvc_project_practice.Data;
using mvc_project_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_project_practice.Controllers
{
    public class CategorycsController1 : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategorycsController1(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var record = _applicationDbContext.Categorycs.ToList();
            return View(record);
        }
        // Get for create category
        public IActionResult Create()
        {
            return View();
        }
        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorycs obj)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Categorycs.Add(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
               
        }
        //Get for edit
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _applicationDbContext.Categorycs.Find(Id);
            if(obj == null)
            {
                return NotFound();
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
            var obj = _applicationDbContext.Categorycs.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Delete from dataabase
        public IActionResult DeleteForm(Categorycs obj)
        {
            _applicationDbContext.Categorycs.Remove(obj);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorycs obj)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Categorycs.Update(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

using EntityFrameworkAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkAssignment.Controllers
{
    public class TeacherController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();
        // GET: Teacher
        public ActionResult Index()
        {
            List<Teacher> Teachers = db.Teachers.ToList();
            return View(Teachers);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            var teacher = db.Teachers.Find(id);
            if (teacher==null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = db.Teachers.Find(id);
            if (teacher==null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Teacher teacher)
        {  
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(teacher).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(teacher);
            }
            catch
            {
                return View(teacher);
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            var teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Teacher teacher)
        {
            var Teacher = db.Teachers.Find(id);
            try
            {
                // TODO: Add delete logic here
                db.Teachers.Remove(Teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Teacher);
            }
        }
    }
}

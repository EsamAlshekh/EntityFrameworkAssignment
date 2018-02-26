using EntityFrameworkAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkAssignment.Controllers
{
    public class StudentController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = db.Students.ToList();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = db.Students.Find(id);
            if (student==null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    db.Students.Add(student);
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if (student==null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            catch
            {
                return View(student);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student Student)
        {
            var student = db.Students.Find(id);
            try
            {
                // TODO: Add delete logic here
                db.Students.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }
    }
}

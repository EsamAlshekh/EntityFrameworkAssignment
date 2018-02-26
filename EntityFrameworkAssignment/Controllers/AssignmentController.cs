using EntityFrameworkAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkAssignment.Controllers
{
    public class AssignmentController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();
        // GET: Assignment
        public ActionResult Index()
        {
            List<Assignment> assignments = db.Assignments.ToList();
            return View(assignments);
        }

        // GET: Assignment/Details/5
        public ActionResult Details(int id)
        {
            var Assignment = db.Assignments.Find(id);
            if (Assignment == null)
            {
                return HttpNotFound();
            }
            return View(Assignment);
        }

        // GET: Assignment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Assignments.Add(assignment);
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

        // GET: Assignment/Edit/5
        public ActionResult Edit(int id)
        {
            var Assignment = db.Assignments.Find(id);
            return View(Assignment);
        }

        // POST: Assignment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Assignment assignment)
        {

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(assignment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(assignment);
            }
            catch
            {
                return View(assignment);
            }
        }

        // GET: Assignment/Delete/5
        public ActionResult Delete(int id)
        {
            var Assignment = db.Assignments.Find(id);
            return View(Assignment);
        }

        // POST: Assignment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Assignment assignment)
        {
            try
            {
                // TODO: Add delete logic here
                var Assignment = db.Assignments.Find(id);
                db.Assignments.Remove(Assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(assignment);
            }
        }
    }
}

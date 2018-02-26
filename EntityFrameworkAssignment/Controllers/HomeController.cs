using EntityFrameworkAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkAssignment.Controllers
{
    public class HomeController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();
        public ActionResult Index(string orderBy)
        {
            List<Course> myList = new List<Course>();
            if (string.IsNullOrEmpty(orderBy))
            {
                ViewBag.OrderNameBy = "AtoZ";
                myList = db.Courses.ToList();
            }
            else
            {
                switch (orderBy)
                {
                    case "AtoZ":
                        myList = db.Courses.OrderBy(p => p.CourseName).ToList();
                        ViewBag.OrderNameBy = "ZtoA";
                        break;
                    case "ZtoA":
                        myList = db.Courses.OrderByDescending(p => p.CourseName).ToList();
                        ViewBag.OrderNameBy = "AtoZ";
                        break;
                }
            }

            return View(myList);
        }
        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            var Course = db.Courses.Find(id);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Courses.Add(course);
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

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            var Course = db.Courses.Find(id);
            return View(Course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course course)
        {

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(course);
            }
            catch
            {
                return View(course);
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            var Course = db.Courses.Find(id);
            return View(Course);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Course course)
        {
            try
            {
                // TODO: Add delete logic here
                var Course = db.Courses.Find(id);
                db.Courses.Remove(Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(course);
            }
        }
        [HttpGet]
        public ActionResult AddTeachersToCourse(int id)
        {            
            List<Teacher> Teachers = db.Teachers.ToList();
            ViewBag.courseId = id;
            return View(Teachers);
        }
        // public void AddTeacher(int id,int tId)
        [HttpGet]
        public ActionResult AddTeacher(int id, int tId)
        {
            Teacher Teacher = db.Teachers.SingleOrDefault(c => c.TeacherID == tId);

            Course Course = db.Courses.Include("Teachers").SingleOrDefault(p => p.CourseID== id);
            if (Course.Teachers.Contains(Teacher))
            {
                return RedirectToAction("TeacherIsExist", new { id = id});
            }
            else
            {
                Course.Teachers.Add(Teacher);

                db.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            
        }
        public ActionResult Back(int id)
        {
            
            return RedirectToAction("AddTeachersToCourse", new { id = id });
        }
        public ActionResult TeacherIsExist(int id)
        {
            ViewBag.courseId = id;
            return View();
        }
        [HttpGet]
        public ActionResult AddStudentToCourse(int id)
        {
           // Student ObjStudent = new Student();
            List<Student> Students = db.Students.ToList();
            // ViewBag.StudentsName = new SelectList(db.Students.ToList(), "StudentID", "StudentName");
            //ObjStudent.GetStudentList = db.Students.Select(s => new Student { StudentID = s.StudentID, StudentName = s.StudentName }).ToList();
            ViewBag.courseId = id;
            return View(Students);
        }

        [HttpGet]
        public ActionResult AddStudent(int id, int sId)
        {
            Student Student = db.Students.SingleOrDefault(c => c.StudentID == sId);

            Course Course = db.Courses.Include("Students").SingleOrDefault(p => p.CourseID == id);
            if (Course.Students.Contains(Student))
            {
                return RedirectToAction("StudentIsExist", new { id = id });
            }
            else
            {
                Course.Students.Add(Student);

                db.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            
        }
        public ActionResult BackToAddStudents(int id)
        {

            return RedirectToAction("AddStudentToCourse", new { id = id });
        }
        public ActionResult StudentIsExist(int id)
        {
            ViewBag.courseId = id;
            return View();
        }
        public ActionResult AddAssignmentToCourse(int id)
        {            
            List<Assignment> Assignments = db.Assignments.ToList();
            ViewBag.courseId = id;
            return View(Assignments);
        }
        [HttpGet]
        public ActionResult AddAssignment(int id, int aId)
        {
            Assignment Assignment = db.Assignments.SingleOrDefault(c => c.AssignmentID == aId);

            Course Course = db.Courses.Include("Assignments").SingleOrDefault(p => p.CourseID == id);
            if (Course.Assignments.Contains(Assignment))
            {
                return RedirectToAction("AssignmentIsExist", new { id = id });
            }
            else
            {
                Course.Assignments.Add(Assignment);

                db.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }

        }
        public ActionResult AssignmentIsExist(int id)
        {
            ViewBag.courseId = id;
            return View();
        }
        public ActionResult BackToAddAssignment(int id)
        {

            return RedirectToAction("AddAssignmentToCourse", new { id = id });
        }
        //The Last
    }
}
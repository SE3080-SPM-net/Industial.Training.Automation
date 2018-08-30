using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace Industial.Training.Automation.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        [Authorize(Roles = "Instructor")]
        public ActionResult Index()
        {
            var students = db.Students;
            return View(students.ToList());
        }

        public FileResult DownloadFile(string file)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + file);
            string fileName = file;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
        public ActionResult FormViewer()
        {
            return View();
        }
        public ActionResult GetLoggedInStudentsID()
        {
              var student =(from a in db.Students where a.StudentsEmail.Equals(User.Identity.Name)select a).FirstOrDefault();
                if (student == null)
                {
                    return RedirectToAction("Create");
                }
                return RedirectToAction("Details", new { id = student.Id });
            
        }
        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Id,StudentsName,StudentsID,Faculty,StudyYear,StudySemester,StartDate,EndDate,Form1_1,Form1_3,Form1_5,Form1_6,Form1_7,CompanyName,CompanyPhoneNumber,SupervisorName,InstructorID")]*/ Students students)
        {
            students.StudentsEmail = User.Identity.Name;
            if (ModelState.IsValid)
            {
                bool studentProfileExists = db.Students.Any(x => x.StudentsID == students.StudentsID);

                if (studentProfileExists == true)
                {
                    ModelState.AddModelError("StudentID", "Student profile already exisits");
                    return RedirectToAction("Create");
                }
                else
                {
                    db.Students.Add(students);
                    db.SaveChanges();
                    return RedirectToAction("GetLoggedInStudentsID");
                }
                
              
            }

           
            return View(students);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentsName,StudentsID,Faculty,StudyYear,StudySemester,StartDate,EndDate,Form1_1,Form1_3,Form1_5,Form1_6,Form1_7,CompanyName,CompanyPhoneNumber,SupervisorName,InstructorID")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        
            return View(students);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

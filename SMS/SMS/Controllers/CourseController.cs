using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            SMSEntities db = new SMSEntities();
            List<Course> lstCourse = db.Courses.ToList();
            return View(lstCourse);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SMSEntities db = new SMSEntities();
            ViewBag.SchoolID = new SelectList(db.Schools.ToList(), "SchoolID", "SchoolName");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Course obj)
        {
            SMSEntities db = new SMSEntities();
            db.Courses.Add(obj);
            db.SaveChanges();
            db.Entry(obj).Reload();
            List<Course> lstCourse = db.Courses.ToList();
            return View("Index", lstCourse);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            SMSEntities db = new SMSEntities();
            Course crc = db.Courses.FirstOrDefault(r => r.CourseID == id);
            ViewBag.SchoolID = (new SelectList(db.Schools.ToList(), "SchoolID", "SchoolName", crc.SchoolID));
            return View(crc);
        }

        [HttpPost]
        public ActionResult Edit(Course obj)
        {
            SMSEntities db = new SMSEntities();
            db.Courses.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            List<Course> lstCourse = db.Courses.ToList();
            return View("Index", lstCourse);
        }

        [HttpGet]
        public ActionResult Get(string courseid)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            SMSEntities db = new SMSEntities();
            Course sch = db.Courses.FirstOrDefault(r => r.CourseID == id);
            db.Entry(sch).State = System.Data.Entity.EntityState.Deleted;
            List<Course> lstCourse = db.Courses.ToList();
            return View("Index", lstCourse);
        }
    }
}
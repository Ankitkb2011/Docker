using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> obj = new List<Student>();
            return View(obj);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SMSEntities db = new SMSEntities();
            ViewBag.SchoolID = new SelectList(db.Schools.ToList(), "SchoolID", "SchoolName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student, HttpPostedFileBase postedFile)
        {
            if (!ModelState.IsValid)
            {
                SMSEntities db = new SMSEntities();
                ViewBag.SchoolID = new SelectList(db.Schools.ToList(), "SchoolID", "SchoolName"); 
            }

            return View();
        }

        [HttpPost]
        public JsonResult GetCourses(string SchoolID)
        {
            SMSEntities db = new SMSEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<Course> Schcourse = db.Courses.Where(x => x.SchoolID  == SchoolID).ToList();
            return Json(Schcourse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSection(string CourseID)
        {
            SMSEntities db = new SMSEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<Section> CourseSection = db.Sections.Where(x => x.CourseID == CourseID).OrderBy(x => x.SectionName).ToList();
            return Json(CourseSection, JsonRequestBehavior.AllowGet);
        }
    }
}
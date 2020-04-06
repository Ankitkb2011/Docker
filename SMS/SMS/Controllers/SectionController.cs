using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class SectionController : Controller
    {
        // GET: Section
        public ActionResult Index()
        {
            SMSEntities db = new SMSEntities();
            List<Section> lstCourse = db.Sections.OrderBy(r=>r.SectionName).ThenBy(r=>r.Course.CourseName).ToList();
            return View(lstCourse);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SMSEntities db = new SMSEntities();
            ViewBag.CourseID = new SelectList(db.Courses.ToList(), "CourseID", "CourseName");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Section obj)
        {
            SMSEntities db = new SMSEntities();
            db.Sections.Add(obj);
            db.SaveChanges();
            db.Entry(obj).Reference(r => r.Course).Load();
            List<Section> lstSection = db.Sections.ToList();
            return View("Index", lstSection);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            SMSEntities db = new SMSEntities();
            Section crc = db.Sections.FirstOrDefault(r => r.SectionID == id);
            ViewBag.CourseID = (new SelectList(db.Courses.ToList(), "CourseID", "CourseName", crc.CourseID));
            return View(crc);
        }

        [HttpPost]
        public ActionResult Edit(Section obj)
        {
            SMSEntities db = new SMSEntities();
            db.Sections.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Entry(obj).Reference(r=>r.Course).Load();
            List<Section> lstSection = db.Sections.ToList();
            return View("Index", lstSection);
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
            Section sch = db.Sections.FirstOrDefault(r => r.SectionID == id);
            db.Entry(sch).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            List<Section> lstSection = db.Sections.ToList();
            return View("Index", lstSection);
        }
    }
}
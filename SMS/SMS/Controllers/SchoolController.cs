using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult School()
        {
            SMSEntities db = new SMSEntities();

            return View(db.Schools.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(School obj)
        {
            try
            {
               School obj1 = new School();
                SMSEntities db = new SMSEntities();
                db.Schools.Add(obj1);
                db.SaveChanges();
                return View("Index", db.Schools.ToList());
            }
            catch(Exception ex)
            {
                Alerts.ShowAlerts(AlertsType.Error, ex.Message.ToString());
                return View("Create", obj);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            SMSEntities db = new SMSEntities();
            School sch = db.Schools.FirstOrDefault(r => r.SchoolID == id);
            return View(sch);
        }

        [HttpPost]
        public ActionResult Edit(School obj)
        {
            SMSEntities db = new SMSEntities();
            db.Schools.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View("School", db.Schools.ToList());
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

            School sch = db.Schools.FirstOrDefault(r => r.SchoolID == id);
            if (sch.Courses.Count > 0)
            {
                Alerts.ShowAlerts(AlertsType.Error, "Record can't be deleted. It is asssigned to some cources");
                return RedirectToAction("School");
            }
            else
            {
                db.Entry(sch).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return View("Index", db.Schools.ToList());
            }

        }
    }
}